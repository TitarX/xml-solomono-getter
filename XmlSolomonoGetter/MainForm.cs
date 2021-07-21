using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Threading;

namespace XmlSolomonoGetter
{
    public partial class MainForm : Form
    {
        private SettingsData settingsData = null;
        private String csvFilePath = null;
        private String sqlConnectionString = null;
        private Thread workerThread = null;
        private Thread waitingWorkerThread = null;
        private DataForWorkerThread dataForWorkerThread = null;
        private bool isNowWorkerThreadAbort = false;
        private Object objectForLock = null;

        public MainForm()
        {
            InitializeComponent();
            InitializeComponent2();
        }
        public bool IsNowWorkerThreadAbort
        {
            get
            {
                lock (objectForLock)
                {
                    return isNowWorkerThreadAbort;
                }
            }
        }

        private void InitializeComponent2()
        {
            objectForLock = new Object();
            toolStripProgressBar.Size = new Size(this.Width / 2, toolStripProgressBar.Size.Height);
            settingsData = SettingsDataProcess.CreateSettingsData();
            this.Load += ChangingFormLocationAtLoad;
            this.FormClosing += ExitButton_Click;
        }

        private void CheckDestinationForResult()
        {
            if (resultToCsvFileCheckBox.CheckState == CheckState.Checked)
            {
                csvFilePath = csvFileTextBox.Text.Trim();
                if (File.Exists(csvFilePath))
                {
                    FileStream csvFileStream = File.Open(csvFilePath, FileMode.Append, FileAccess.Write, FileShare.None);
                    csvFileStream.Close();
                }
                else
                {
                    FileStream csvFileStream = File.Create(csvFilePath);
                    csvFileStream.Close();
                }
            }
            else
            {
                csvFilePath = null;
            }

            if (resultToMsSqlServerCheckBox.CheckState == CheckState.Checked)
            {
                if (dbTextBox.Text.Trim().Equals(""))
                {
                    throw new Exception("Поле \"База данных\" не заполнено");
                }

                if (windowsAuthenticationRadioButton.Checked && !serverAuthenticationRadioButton.Checked)
                {
                    sqlConnectionString = String.Format("Data Source={0};Initial Catalog={1};Integrated Security=SSPI"
                        , serverTextBox.Text.Trim(), dbTextBox.Text.Trim());
                }
                else if (!windowsAuthenticationRadioButton.Checked && serverAuthenticationRadioButton.Checked)
                {
                    sqlConnectionString = String.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3}"
                        , serverTextBox.Text.Trim(), dbTextBox.Text.Trim(), userTextBox.Text.Trim(), passwordTextBox.Text.Trim());
                }

                if (sqlConnectionString != null)
                {
                    using (SqlConnection sqlConnection = new SqlConnection(sqlConnectionString))
                    {
                        sqlConnection.Open();
                        SqlCommand sqlCommand = sqlConnection.CreateCommand();
                        sqlCommand.CommandText = "SELECT id FROM sysobjects WHERE name='XmlSolomonoData' AND xtype='U'";
                        if (sqlCommand.ExecuteScalar() == null)
                        {
                            DialogResult dialogResult = MessageBox.Show(this, "В указанной базе данных не найдена таблица для сохранения результатов запроса.\n" +
                                "Создать новую таблицу?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                            if (dialogResult == DialogResult.Yes)
                            {
                                sqlCommand.CommandText = "CREATE TABLE XmlSolomonoData" +
                                "(Date datetime NOT NULL,Host varchar(256) NOT NULL,[Index] int NOT NULL,[Index-date] date NULL," +
                                "Mr int NOT NULL,Ip int NOT NULL," +
                                "Hin int NOT NULL,[Hin-l1] int NOT NULL,[Hin-l2] int NOT NULL,[Hin-l3] int NOT NULL,[Hin-l4] int NOT NULL," +
                                "Din int NOT NULL,[Din-l1] int NOT NULL,[Din-l2] int NOT NULL,[Din-l3] int NOT NULL,[Din-l4] int NOT NULL," +
                                "Hout int NOT NULL,[Hout-l1] int NOT NULL,[Hout-l2] int NOT NULL,[Hout-l3] int NOT NULL,[Hout-l4] int NOT NULL," +
                                "Dout int NOT NULL,Anchors int NOT NULL,Anchors_out int NOT NULL,Igood varchar(256) NOT NULL,PRIMARY KEY([Date],Host))";
                                sqlCommand.ExecuteNonQuery();
                            }
                            else
                            {
                                sqlConnectionString = null;
                            }
                        }
                    }
                }
            }
            else
            {
                sqlConnectionString = null;
            }
        }

        public void ProgressBarPerformStep()
        {
            toolStripProgressBar.PerformStep();
        }

        public void ChangeFormComponentsStatusAtStopping()
        {
            toolStripProgressBar.Value = 0;
            startButton.Text = "Старт";

            if (workerThread.ThreadState == ThreadState.Aborted)
            {
                toolStripStatusLabel.Text = "Прервано";
            }
            else
            {
                toolStripStatusLabel.Text = "Завершено";
            }

            urlListFileTextBox.Enabled = true;
            stopButton.Enabled = false;
            resetButton.Enabled = true;
            resultToCsvFileCheckBox.Enabled = true;
            resultToMsSqlServerCheckBox.Enabled = true;

            if (resultToCsvFileCheckBox.Checked == true)
            {
                csvFileTextBox.Enabled = true;
            }

            if (resultToMsSqlServerCheckBox.Checked == true)
            {
                windowsAuthenticationRadioButton.Enabled = true;
                serverAuthenticationRadioButton.Enabled = true;

                if (windowsAuthenticationRadioButton.Checked == true)
                {
                    serverTextBox.Enabled = true;
                    dbTextBox.Enabled = true;
                }
                else if (serverAuthenticationRadioButton.Checked == true)
                {
                    serverTextBox.Enabled = true;
                    dbTextBox.Enabled = true;
                    userTextBox.Enabled = true;
                    passwordTextBox.Enabled = true;
                }
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            if (workerThread != null && workerThread.IsAlive)
            {
                if (dataForWorkerThread.IsNowPause)
                {
                    dataForWorkerThread.IsNowPause = !dataForWorkerThread.IsNowPause;
                }

                isNowWorkerThreadAbort = true;
                workerThread.Abort();
                workerThread.Join();
            }

            settingsData.MainFormX = this.Location.X;
            settingsData.MainFormY = this.Location.Y;
            SettingsDataProcess.SaveSettingsData(settingsData);

            Application.Exit();
        }

        private void ResultToCsvFileCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            if (resultToCsvFileCheckBox.CheckState == CheckState.Checked)
            {
                csvFileTextBox.Enabled = true;
            }
            else if (resultToCsvFileCheckBox.CheckState == CheckState.Unchecked)
            {
                csvFileTextBox.Enabled = false;
            }
        }

        private void ResultToMsSqlServerCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            if (resultToMsSqlServerCheckBox.CheckState == CheckState.Checked)
            {
                windowsAuthenticationRadioButton.Enabled = true;
                serverAuthenticationRadioButton.Enabled = true;

                AuthenticationRadioButton_CheckedChanged(null, null);
            }
            else if (resultToMsSqlServerCheckBox.CheckState == CheckState.Unchecked)
            {
                windowsAuthenticationRadioButton.Enabled = false;
                serverAuthenticationRadioButton.Enabled = false;
                serverTextBox.Enabled = false;
                dbTextBox.Enabled = false;
                userTextBox.Enabled = false;
                passwordTextBox.Enabled = false;
            }
        }

        private void AuthenticationRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (windowsAuthenticationRadioButton.Checked && !serverAuthenticationRadioButton.Checked)
            {
                serverTextBox.Enabled = true;
                dbTextBox.Enabled = true;
                userTextBox.Enabled = false;
                passwordTextBox.Enabled = false;
            }
            else if (!windowsAuthenticationRadioButton.Checked && serverAuthenticationRadioButton.Checked)
            {
                serverTextBox.Enabled = true;
                dbTextBox.Enabled = true;
                userTextBox.Enabled = true;
                passwordTextBox.Enabled = true;
            }
            else
            {
                serverTextBox.Enabled = false;
                dbTextBox.Enabled = false;
                userTextBox.Enabled = false;
                passwordTextBox.Enabled = false;
            }
        }

        private void UrlListFileTextBox_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (Directory.Exists(settingsData.UrlListFileFolder))
            {
                openFileDialog.InitialDirectory = settingsData.UrlListFileFolder;
            }
            openFileDialog.Filter = "Текстовые файлы (.txt)|*.txt|Все файлы|*.*";
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                String fileName = openFileDialog.FileName;
                urlListFileTextBox.Text = fileName;
                settingsData.UrlListFileFolder = Path.GetDirectoryName(fileName);
            }
        }

        private void UrlListFileTextBox_TextChanged(object sender, EventArgs e)
        {
            String filePath = urlListFileTextBox.Text.Trim();
            if (!filePath.Equals("") && File.Exists(filePath))
            {
                startButton.Enabled = true;
            }
            else
            {
                startButton.Enabled = false;
            }
        }

        private void CsvFileTextBox_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (Directory.Exists(settingsData.CsvFileFolder))
            {
                openFileDialog.InitialDirectory = settingsData.CsvFileFolder;
            }
            openFileDialog.Filter = "CSV-файлы (.csv)|*.csv|Все файлы|*.*";
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                String fileName = openFileDialog.FileName;
                csvFileTextBox.Text = fileName;
                settingsData.CsvFileFolder = Path.GetDirectoryName(fileName);
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if ((workerThread != null && workerThread.IsAlive) || (waitingWorkerThread != null && waitingWorkerThread.IsAlive))
            {
                dataForWorkerThread.IsNowPause = !dataForWorkerThread.IsNowPause;

                if (dataForWorkerThread.IsNowPause)
                {
                    toolStripStatusLabel.Text = "Остановлено";
                    startButton.Text = "Старт";
                }
                else
                {
                    toolStripStatusLabel.Text = "Выполняется";
                    startButton.Text = "Пауза";
                }
            }
            else
            {
                try
                {
                    CheckDestinationForResult();

                    if (csvFilePath == null && sqlConnectionString == null)
                    {
                        MessageBox.Show(this, "Не указано место сохранения результата", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        StreamReader urlStreamReader = File.OpenText(urlListFileTextBox.Text.Trim());
                        String[] urlStrings = urlStreamReader.ReadToEnd().Split(',');
                        if (urlStrings.Length == 1 && urlStrings[0].Equals(""))
                        {
                            MessageBox.Show(this, "Список URL пуст", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            toolStripProgressBar.Maximum = urlStrings.Length;
                            toolStripStatusLabel.Text = "Выполняется";
                            startButton.Text = "Пауза";

                            stopButton.Enabled = true;
                            resetButton.Enabled = false;
                            resultToCsvFileCheckBox.Enabled = false;
                            resultToMsSqlServerCheckBox.Enabled = false;
                            windowsAuthenticationRadioButton.Enabled = false;
                            serverAuthenticationRadioButton.Enabled = false;
                            urlListFileTextBox.Enabled = false;
                            csvFileTextBox.Enabled = false;
                            serverTextBox.Enabled = false;
                            dbTextBox.Enabled = false;
                            userTextBox.Enabled = false;
                            passwordTextBox.Enabled = false;

                            dataForWorkerThread = new DataForWorkerThread();
                            dataForWorkerThread.CsvFilePath = csvFilePath;
                            dataForWorkerThread.SqlConnectionString = sqlConnectionString;
                            dataForWorkerThread.UrlStrings = urlStrings;

                            WorkerThreadProcess worketThreadProcess = new WorkerThreadProcess(this, dataForWorkerThread);
                            workerThread = worketThreadProcess.ThisThread;
                            WaitingWorkerThreadProcess waitingWorkerThreadProcess = new WaitingWorkerThreadProcess(this, workerThread);
                            waitingWorkerThread = waitingWorkerThreadProcess.ThisThread;
                        }
                    }
                }
                catch (ThreadAbortException)
                { }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            if (workerThread != null && workerThread.IsAlive)
            {
                if (dataForWorkerThread.IsNowPause)
                {
                    dataForWorkerThread.IsNowPause = !dataForWorkerThread.IsNowPause;
                }

                isNowWorkerThreadAbort = true;
                workerThread.Abort();
                workerThread.Join();
                isNowWorkerThreadAbort = false;
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            urlListFileTextBox.Text = "";
            csvFileTextBox.Text = "";
            serverTextBox.Text = "";
            dbTextBox.Text = "";
            userTextBox.Text = "";
            passwordTextBox.Text = "";
            windowsAuthenticationRadioButton.Checked = false;
            serverAuthenticationRadioButton.Checked = false;
            resultToCsvFileCheckBox.Checked = false;
            resultToMsSqlServerCheckBox.Checked = false;
            resultToCsvFileCheckBox.Checked = false;
        }

        private void ChangingFormLocationAtLoad(object sender, EventArgs e)
        {
            this.Location = new Point(settingsData.MainFormX, settingsData.MainFormY);
        }
    }
}
