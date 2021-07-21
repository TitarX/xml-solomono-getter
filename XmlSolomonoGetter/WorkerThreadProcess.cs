using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.IO;
using XmlXPath;
using System.Data.SqlClient;
using System.Data;

namespace XmlSolomonoGetter
{
    class WorkerThreadProcess
    {
        public delegate void MainFormInvokeDelegate();

        private MainFormInvokeDelegate mainFormInvokeDelegate = null;
        private MainForm mainForm = null;
        private DataForWorkerThread dataForWorkerThread = null;
        private Thread thisThread = null;

        public WorkerThreadProcess(MainForm mainForm, DataForWorkerThread dataForWorkerThread)
        {

            this.mainForm = mainForm;
            this.dataForWorkerThread = dataForWorkerThread;

            Thread thisThread = new Thread(this.Run);
            this.thisThread = thisThread;
            thisThread.Start();
        }

        public Thread ThisThread
        {
            get
            {
                return thisThread;
            }
        }

        private void Run()
        {
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            StreamWriter csvStreamWriter = null;

            if (dataForWorkerThread.SqlConnectionString != null)
            {
                sqlConnection = new SqlConnection(dataForWorkerThread.SqlConnectionString);

                sqlConnection.Open();
                sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "INSERT INTO XmlSolomonoData VALUES(@Date,@Host,@Index,@Index_date,@Mr,@Ip," +
                    "@Hin,@Hin_l1,@Hin_l2,@Hin_l3,@Hin_l4,@Din,@Din_l1,@Din_l2,@Din_l3,@Din_l4," +
                    "@Hout,@Hout_l1,@Hout_l2,@Hout_l3,@Hout_l4,@Dout,@Anchors,@Anchors_out,@Igood)";
                sqlCommand.Parameters.Add("@Date", SqlDbType.DateTime);
                sqlCommand.Parameters.Add("@Host", SqlDbType.VarChar);
                sqlCommand.Parameters.Add("@Index", SqlDbType.Int);
                sqlCommand.Parameters.Add("@Index_date", SqlDbType.Date);
                sqlCommand.Parameters.Add("@Mr", SqlDbType.Int);
                sqlCommand.Parameters.Add("@Ip", SqlDbType.Int);
                sqlCommand.Parameters.Add("@Hin", SqlDbType.Int);
                sqlCommand.Parameters.Add("@Hin_l1", SqlDbType.Int);
                sqlCommand.Parameters.Add("@Hin_l2", SqlDbType.Int);
                sqlCommand.Parameters.Add("@Hin_l3", SqlDbType.Int);
                sqlCommand.Parameters.Add("@Hin_l4", SqlDbType.Int);
                sqlCommand.Parameters.Add("@Din", SqlDbType.Int);
                sqlCommand.Parameters.Add("@Din_l1", SqlDbType.Int);
                sqlCommand.Parameters.Add("@Din_l2", SqlDbType.Int);
                sqlCommand.Parameters.Add("@Din_l3", SqlDbType.Int);
                sqlCommand.Parameters.Add("@Din_l4", SqlDbType.Int);
                sqlCommand.Parameters.Add("@Hout", SqlDbType.Int);
                sqlCommand.Parameters.Add("@Hout_l1", SqlDbType.Int);
                sqlCommand.Parameters.Add("@Hout_l2", SqlDbType.Int);
                sqlCommand.Parameters.Add("@Hout_l3", SqlDbType.Int);
                sqlCommand.Parameters.Add("@Hout_l4", SqlDbType.Int);
                sqlCommand.Parameters.Add("@Dout", SqlDbType.Int);
                sqlCommand.Parameters.Add("@Anchors", SqlDbType.Int);
                sqlCommand.Parameters.Add("@Anchors_out", SqlDbType.Int);
                sqlCommand.Parameters.Add("@Igood", SqlDbType.VarChar);
            }

            if (dataForWorkerThread.CsvFilePath != null)
            {
                csvStreamWriter = new StreamWriter(File.Open(dataForWorkerThread.CsvFilePath, FileMode.Append, FileAccess.Write, FileShare.None));

                if (new FileInfo(dataForWorkerThread.CsvFilePath).Length == 0)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append("Date");
                    stringBuilder.Append(StaticData.ListSeparator);
                    stringBuilder.Append("Host");
                    stringBuilder.Append(StaticData.ListSeparator);
                    stringBuilder.Append("Index");
                    stringBuilder.Append(StaticData.ListSeparator);
                    stringBuilder.Append("Index-date");
                    stringBuilder.Append(StaticData.ListSeparator);
                    stringBuilder.Append("Mr");
                    stringBuilder.Append(StaticData.ListSeparator);
                    stringBuilder.Append("Ip");
                    stringBuilder.Append(StaticData.ListSeparator);
                    stringBuilder.Append("Hin");
                    stringBuilder.Append(StaticData.ListSeparator);
                    stringBuilder.Append("Hin-l1");
                    stringBuilder.Append(StaticData.ListSeparator);
                    stringBuilder.Append("Hin-l2");
                    stringBuilder.Append(StaticData.ListSeparator);
                    stringBuilder.Append("Hin-l3");
                    stringBuilder.Append(StaticData.ListSeparator);
                    stringBuilder.Append("Hin-l4");
                    stringBuilder.Append(StaticData.ListSeparator);
                    stringBuilder.Append("Din");
                    stringBuilder.Append(StaticData.ListSeparator);
                    stringBuilder.Append("Din-l1");
                    stringBuilder.Append(StaticData.ListSeparator);
                    stringBuilder.Append("Din-l2");
                    stringBuilder.Append(StaticData.ListSeparator);
                    stringBuilder.Append("Din-l3");
                    stringBuilder.Append(StaticData.ListSeparator);
                    stringBuilder.Append("Din-l4");
                    stringBuilder.Append(StaticData.ListSeparator);
                    stringBuilder.Append("Hout");
                    stringBuilder.Append(StaticData.ListSeparator);
                    stringBuilder.Append("Hout-l1");
                    stringBuilder.Append(StaticData.ListSeparator);
                    stringBuilder.Append("Hout-l2");
                    stringBuilder.Append(StaticData.ListSeparator);
                    stringBuilder.Append("Hout-l3");
                    stringBuilder.Append(StaticData.ListSeparator);
                    stringBuilder.Append("Hout-l4");
                    stringBuilder.Append(StaticData.ListSeparator);
                    stringBuilder.Append("Dout");
                    stringBuilder.Append(StaticData.ListSeparator);
                    stringBuilder.Append("Anchors");
                    stringBuilder.Append(StaticData.ListSeparator);
                    stringBuilder.Append("Anchors_out");
                    stringBuilder.Append(StaticData.ListSeparator);
                    stringBuilder.Append("Igood");
                    stringBuilder.Append(StaticData.NewLine);

                    csvStreamWriter.Write(stringBuilder.ToString());
                }
            }

            try
            {
                foreach (String urlString in dataForWorkerThread.UrlStrings)
                {
                    Thread.Sleep(1000);

                    WebRequest webRequest = WebRequest.Create(String.Concat(StaticData.XmlSolomonoUrlString, urlString.Trim()));
                    WebResponse webResponse = webRequest.GetResponse();
                    StreamReader streamReader = new StreamReader(webResponse.GetResponseStream());
                    String responseString = streamReader.ReadToEnd();
                    streamReader.Close();
                    webResponse.Close();

                    XPathDataReader xPathDataReader = XPathDataReader.newInstance(responseString,
                        new KeyValuePair<String, FileInfo>("", new FileInfo(String.Concat(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "\\XmlSchemaForXmlResponse.xsd"))));
                    String date = DateTime.Now.ToString();
                    String host = xPathDataReader.ReadData("/data/host/text()")[0].ToString();
                    String index = xPathDataReader.ReadData("/data/index/text()")[0].ToString();
                    String index_date = xPathDataReader.ReadData("/data/index/@date")[0].ToString();
                    String mr = xPathDataReader.ReadData("/data/mr/text()")[0].ToString();
                    String ip = xPathDataReader.ReadData("/data/ip/text()")[0].ToString();
                    String hin = xPathDataReader.ReadData("/data/hin/text()")[0].ToString();
                    String hin_l1 = xPathDataReader.ReadData("/data/hin/@l1")[0].ToString();
                    String hin_l2 = xPathDataReader.ReadData("/data/hin/@l2")[0].ToString();
                    String hin_l3 = xPathDataReader.ReadData("/data/hin/@l3")[0].ToString();
                    String hin_l4 = xPathDataReader.ReadData("/data/hin/@l4")[0].ToString();
                    String din = xPathDataReader.ReadData("/data/din/text()")[0].ToString();
                    String din_l1 = xPathDataReader.ReadData("/data/din/@l1")[0].ToString();
                    String din_l2 = xPathDataReader.ReadData("/data/din/@l2")[0].ToString();
                    String din_l3 = xPathDataReader.ReadData("/data/din/@l3")[0].ToString();
                    String din_l4 = xPathDataReader.ReadData("/data/din/@l4")[0].ToString();
                    String hout = xPathDataReader.ReadData("/data/hout/text()")[0].ToString();
                    String hout_l1 = xPathDataReader.ReadData("/data/hout/@l1")[0].ToString();
                    String hout_l2 = xPathDataReader.ReadData("/data/hout/@l2")[0].ToString();
                    String hout_l3 = xPathDataReader.ReadData("/data/hout/@l3")[0].ToString();
                    String hout_l4 = xPathDataReader.ReadData("/data/hout/@l4")[0].ToString();
                    String dout = xPathDataReader.ReadData("/data/dout/text()")[0].ToString();
                    String anchors = xPathDataReader.ReadData("/data/anchors/text()")[0].ToString();
                    String anchors_out = xPathDataReader.ReadData("/data/anchors_out/text()")[0].ToString();
                    String igood = xPathDataReader.ReadData("/data/igood/text()")[0].ToString();

                    if (sqlConnection != null)
                    {
                        sqlCommand.Parameters["@Date"].Value = date;
                        sqlCommand.Parameters["@Host"].Value = host;
                        sqlCommand.Parameters["@Index"].Value = index;
                        if (index_date.Equals("-"))
                        {
                            sqlCommand.Parameters["@Index_date"].Value = DBNull.Value;
                        }
                        else
                        {
                            sqlCommand.Parameters["@Index_date"].Value = index_date;
                        }
                        sqlCommand.Parameters["@Mr"].Value = mr;
                        sqlCommand.Parameters["@Ip"].Value = ip;
                        sqlCommand.Parameters["@Hin"].Value = hin;
                        sqlCommand.Parameters["@Hin_l1"].Value = hin_l1;
                        sqlCommand.Parameters["@Hin_l2"].Value = hin_l2;
                        sqlCommand.Parameters["@Hin_l3"].Value = hin_l3;
                        sqlCommand.Parameters["@Hin_l4"].Value = hin_l4;
                        sqlCommand.Parameters["@Din"].Value = din;
                        sqlCommand.Parameters["@Din_l1"].Value = din_l1;
                        sqlCommand.Parameters["@Din_l2"].Value = din_l2;
                        sqlCommand.Parameters["@Din_l3"].Value = din_l3;
                        sqlCommand.Parameters["@Din_l4"].Value = din_l4;
                        sqlCommand.Parameters["@Hout"].Value = hout;
                        sqlCommand.Parameters["@Hout_l1"].Value = hout_l1;
                        sqlCommand.Parameters["@Hout_l2"].Value = hout_l2;
                        sqlCommand.Parameters["@Hout_l3"].Value = hout_l3;
                        sqlCommand.Parameters["@Hout_l4"].Value = hout_l4;
                        sqlCommand.Parameters["@Dout"].Value = dout;
                        sqlCommand.Parameters["@Anchors"].Value = anchors;
                        sqlCommand.Parameters["@Anchors_out"].Value = anchors_out;
                        sqlCommand.Parameters["@Igood"].Value = igood;

                        sqlCommand.ExecuteNonQuery();
                    }

                    if (csvStreamWriter != null)
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.Append(date);
                        stringBuilder.Append(StaticData.ListSeparator);
                        stringBuilder.Append(host);
                        stringBuilder.Append(StaticData.ListSeparator);
                        stringBuilder.Append(index);
                        stringBuilder.Append(StaticData.ListSeparator);
                        stringBuilder.Append(index_date);
                        stringBuilder.Append(StaticData.ListSeparator);
                        stringBuilder.Append(mr);
                        stringBuilder.Append(StaticData.ListSeparator);
                        stringBuilder.Append(ip);
                        stringBuilder.Append(StaticData.ListSeparator);
                        stringBuilder.Append(hin);
                        stringBuilder.Append(StaticData.ListSeparator);
                        stringBuilder.Append(hin_l1);
                        stringBuilder.Append(StaticData.ListSeparator);
                        stringBuilder.Append(hin_l2);
                        stringBuilder.Append(StaticData.ListSeparator);
                        stringBuilder.Append(hin_l3);
                        stringBuilder.Append(StaticData.ListSeparator);
                        stringBuilder.Append(hin_l4);
                        stringBuilder.Append(StaticData.ListSeparator);
                        stringBuilder.Append(din);
                        stringBuilder.Append(StaticData.ListSeparator);
                        stringBuilder.Append(din_l1);
                        stringBuilder.Append(StaticData.ListSeparator);
                        stringBuilder.Append(din_l2);
                        stringBuilder.Append(StaticData.ListSeparator);
                        stringBuilder.Append(din_l3);
                        stringBuilder.Append(StaticData.ListSeparator);
                        stringBuilder.Append(din_l4);
                        stringBuilder.Append(StaticData.ListSeparator);
                        stringBuilder.Append(hout);
                        stringBuilder.Append(StaticData.ListSeparator);
                        stringBuilder.Append(hout_l1);
                        stringBuilder.Append(StaticData.ListSeparator);
                        stringBuilder.Append(hout_l2);
                        stringBuilder.Append(StaticData.ListSeparator);
                        stringBuilder.Append(hout_l3);
                        stringBuilder.Append(StaticData.ListSeparator);
                        stringBuilder.Append(hout_l4);
                        stringBuilder.Append(StaticData.ListSeparator);
                        stringBuilder.Append(dout);
                        stringBuilder.Append(StaticData.ListSeparator);
                        stringBuilder.Append(anchors);
                        stringBuilder.Append(StaticData.ListSeparator);
                        stringBuilder.Append(anchors_out);
                        stringBuilder.Append(StaticData.ListSeparator);
                        stringBuilder.Append(igood);
                        stringBuilder.Append(StaticData.NewLine);

                        csvStreamWriter.Write(stringBuilder.ToString());
                    }

                    if (!mainForm.IsNowWorkerThreadAbort)
                    {
                        mainFormInvokeDelegate = delegate
                        {
                            mainForm.ProgressBarPerformStep();
                        };
                        mainForm.Invoke(mainFormInvokeDelegate);
                    }

                    while (dataForWorkerThread.IsNowPause)
                    {
                        Thread.Sleep(1000);
                    }
                }


                if (!mainForm.IsNowWorkerThreadAbort)
                {
                    mainFormInvokeDelegate = delegate
                    {
                        MessageBox.Show(mainForm, "Данные получены и сохранены", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    };
                    mainForm.Invoke(mainFormInvokeDelegate);
                }
            }
            catch (Exception ex)
            {
                if (!mainForm.IsNowWorkerThreadAbort)
                {
                    mainFormInvokeDelegate = delegate
                    {
                        MessageBox.Show(mainForm, ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    };
                    mainForm.Invoke(mainFormInvokeDelegate);
                }
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }

                if (csvStreamWriter != null)
                {
                    csvStreamWriter.Close();
                }
            }
        }
    }
}
