namespace XmlSolomonoGetter
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.exitButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.urlListFileLabel = new System.Windows.Forms.Label();
            this.urlListFileTextBox = new System.Windows.Forms.TextBox();
            this.splitPanel1 = new System.Windows.Forms.Panel();
            this.resultToCsvFileCheckBox = new System.Windows.Forms.CheckBox();
            this.csvFileLabel = new System.Windows.Forms.Label();
            this.csvFileTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.resultToMsSqlServerCheckBox = new System.Windows.Forms.CheckBox();
            this.windowsAuthenticationRadioButton = new System.Windows.Forms.RadioButton();
            this.serverAuthenticationRadioButton = new System.Windows.Forms.RadioButton();
            this.serverLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.userLabel = new System.Windows.Forms.Label();
            this.dbLabel = new System.Windows.Forms.Label();
            this.dbTextBox = new System.Windows.Forms.TextBox();
            this.serverTextBox = new System.Windows.Forms.TextBox();
            this.userTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.urlFileToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.stopButton = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.resetButton = new System.Windows.Forms.Button();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.exitButton.Location = new System.Drawing.Point(12, 320);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 0;
            this.exitButton.Text = "Выход";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // startButton
            // 
            this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.startButton.Enabled = false;
            this.startButton.Location = new System.Drawing.Point(515, 320);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Старт";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // urlListFileLabel
            // 
            this.urlListFileLabel.AutoSize = true;
            this.urlListFileLabel.Location = new System.Drawing.Point(12, 9);
            this.urlListFileLabel.Name = "urlListFileLabel";
            this.urlListFileLabel.Size = new System.Drawing.Size(126, 13);
            this.urlListFileLabel.TabIndex = 2;
            this.urlListFileLabel.Text = "Файл со списком URL:";
            // 
            // urlListFileTextBox
            // 
            this.urlListFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.urlListFileTextBox.Location = new System.Drawing.Point(144, 6);
            this.urlListFileTextBox.Name = "urlListFileTextBox";
            this.urlListFileTextBox.Size = new System.Drawing.Size(446, 20);
            this.urlListFileTextBox.TabIndex = 3;
            this.urlFileToolTip.SetToolTip(this.urlListFileTextBox, "URL в списке должны быть разделены запятой");
            this.urlListFileTextBox.Click += new System.EventHandler(this.UrlListFileTextBox_Click);
            this.urlListFileTextBox.TextChanged += new System.EventHandler(this.UrlListFileTextBox_TextChanged);
            // 
            // splitPanel1
            // 
            this.splitPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitPanel1.Location = new System.Drawing.Point(12, 32);
            this.splitPanel1.Name = "splitPanel1";
            this.splitPanel1.Size = new System.Drawing.Size(578, 23);
            this.splitPanel1.TabIndex = 4;
            // 
            // resultToCsvFileCheckBox
            // 
            this.resultToCsvFileCheckBox.AutoSize = true;
            this.resultToCsvFileCheckBox.Location = new System.Drawing.Point(15, 61);
            this.resultToCsvFileCheckBox.Name = "resultToCsvFileCheckBox";
            this.resultToCsvFileCheckBox.Size = new System.Drawing.Size(195, 17);
            this.resultToCsvFileCheckBox.TabIndex = 5;
            this.resultToCsvFileCheckBox.Text = "Сохранить результат в CSV-файл";
            this.resultToCsvFileCheckBox.UseVisualStyleBackColor = true;
            this.resultToCsvFileCheckBox.CheckStateChanged += new System.EventHandler(this.ResultToCsvFileCheckBox_CheckStateChanged);
            // 
            // csvFileLabel
            // 
            this.csvFileLabel.AutoSize = true;
            this.csvFileLabel.Location = new System.Drawing.Point(12, 85);
            this.csvFileLabel.Name = "csvFileLabel";
            this.csvFileLabel.Size = new System.Drawing.Size(60, 13);
            this.csvFileLabel.TabIndex = 6;
            this.csvFileLabel.Text = "CSV-файл:";
            // 
            // csvFileTextBox
            // 
            this.csvFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.csvFileTextBox.Enabled = false;
            this.csvFileTextBox.Location = new System.Drawing.Point(78, 85);
            this.csvFileTextBox.Name = "csvFileTextBox";
            this.csvFileTextBox.Size = new System.Drawing.Size(512, 20);
            this.csvFileTextBox.TabIndex = 7;
            this.csvFileTextBox.Click += new System.EventHandler(this.CsvFileTextBox_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(12, 111);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(578, 23);
            this.panel1.TabIndex = 8;
            // 
            // resultToMsSqlServerCheckBox
            // 
            this.resultToMsSqlServerCheckBox.AutoSize = true;
            this.resultToMsSqlServerCheckBox.Location = new System.Drawing.Point(15, 140);
            this.resultToMsSqlServerCheckBox.Name = "resultToMsSqlServerCheckBox";
            this.resultToMsSqlServerCheckBox.Size = new System.Drawing.Size(285, 17);
            this.resultToMsSqlServerCheckBox.TabIndex = 9;
            this.resultToMsSqlServerCheckBox.Text = "Сохранить результат в базу данных MS SQL Server";
            this.resultToMsSqlServerCheckBox.UseVisualStyleBackColor = true;
            this.resultToMsSqlServerCheckBox.CheckStateChanged += new System.EventHandler(this.ResultToMsSqlServerCheckBox_CheckStateChanged);
            // 
            // windowsAuthenticationRadioButton
            // 
            this.windowsAuthenticationRadioButton.AutoSize = true;
            this.windowsAuthenticationRadioButton.Enabled = false;
            this.windowsAuthenticationRadioButton.Location = new System.Drawing.Point(306, 140);
            this.windowsAuthenticationRadioButton.Name = "windowsAuthenticationRadioButton";
            this.windowsAuthenticationRadioButton.Size = new System.Drawing.Size(156, 17);
            this.windowsAuthenticationRadioButton.TabIndex = 10;
            this.windowsAuthenticationRadioButton.TabStop = true;
            this.windowsAuthenticationRadioButton.Text = "Аутентификация Windows";
            this.windowsAuthenticationRadioButton.UseVisualStyleBackColor = true;
            this.windowsAuthenticationRadioButton.CheckedChanged += new System.EventHandler(this.AuthenticationRadioButton_CheckedChanged);
            // 
            // serverAuthenticationRadioButton
            // 
            this.serverAuthenticationRadioButton.AutoSize = true;
            this.serverAuthenticationRadioButton.Enabled = false;
            this.serverAuthenticationRadioButton.Location = new System.Drawing.Point(306, 163);
            this.serverAuthenticationRadioButton.Name = "serverAuthenticationRadioButton";
            this.serverAuthenticationRadioButton.Size = new System.Drawing.Size(186, 17);
            this.serverAuthenticationRadioButton.TabIndex = 11;
            this.serverAuthenticationRadioButton.TabStop = true;
            this.serverAuthenticationRadioButton.Text = "Аутентификация MS SQL Server";
            this.serverAuthenticationRadioButton.UseVisualStyleBackColor = true;
            this.serverAuthenticationRadioButton.CheckedChanged += new System.EventHandler(this.AuthenticationRadioButton_CheckedChanged);
            // 
            // serverLabel
            // 
            this.serverLabel.AutoSize = true;
            this.serverLabel.Location = new System.Drawing.Point(9, 187);
            this.serverLabel.Name = "serverLabel";
            this.serverLabel.Size = new System.Drawing.Size(47, 13);
            this.serverLabel.TabIndex = 13;
            this.serverLabel.Text = "Сервер:";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(10, 265);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(48, 13);
            this.passwordLabel.TabIndex = 14;
            this.passwordLabel.Text = "Пароль:";
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Location = new System.Drawing.Point(10, 241);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(83, 13);
            this.userLabel.TabIndex = 15;
            this.userLabel.Text = "Пользователь:";
            // 
            // dbLabel
            // 
            this.dbLabel.AutoSize = true;
            this.dbLabel.Location = new System.Drawing.Point(10, 215);
            this.dbLabel.Name = "dbLabel";
            this.dbLabel.Size = new System.Drawing.Size(75, 13);
            this.dbLabel.TabIndex = 16;
            this.dbLabel.Text = "База данных:";
            // 
            // dbTextBox
            // 
            this.dbTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbTextBox.Enabled = false;
            this.dbTextBox.Location = new System.Drawing.Point(99, 212);
            this.dbTextBox.Name = "dbTextBox";
            this.dbTextBox.Size = new System.Drawing.Size(491, 20);
            this.dbTextBox.TabIndex = 17;
            // 
            // serverTextBox
            // 
            this.serverTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serverTextBox.Enabled = false;
            this.serverTextBox.Location = new System.Drawing.Point(99, 186);
            this.serverTextBox.Name = "serverTextBox";
            this.serverTextBox.Size = new System.Drawing.Size(491, 20);
            this.serverTextBox.TabIndex = 18;
            // 
            // userTextBox
            // 
            this.userTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userTextBox.Enabled = false;
            this.userTextBox.Location = new System.Drawing.Point(99, 238);
            this.userTextBox.Name = "userTextBox";
            this.userTextBox.Size = new System.Drawing.Size(491, 20);
            this.userTextBox.TabIndex = 19;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordTextBox.Enabled = false;
            this.passwordTextBox.Location = new System.Drawing.Point(99, 262);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(491, 20);
            this.passwordTextBox.TabIndex = 20;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Location = new System.Drawing.Point(12, 288);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(580, 23);
            this.panel2.TabIndex = 21;
            // 
            // stopButton
            // 
            this.stopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(434, 320);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 23;
            this.stopButton.Text = "Стоп";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 350);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(602, 22);
            this.statusStrip.TabIndex = 24;
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(300, 16);
            this.toolStripProgressBar.Step = 1;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // resetButton
            // 
            this.resetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.resetButton.Location = new System.Drawing.Point(93, 320);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 25;
            this.resetButton.Text = "Сброс";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 372);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.userTextBox);
            this.Controls.Add(this.serverTextBox);
            this.Controls.Add(this.dbTextBox);
            this.Controls.Add(this.dbLabel);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.serverLabel);
            this.Controls.Add(this.serverAuthenticationRadioButton);
            this.Controls.Add(this.windowsAuthenticationRadioButton);
            this.Controls.Add(this.resultToMsSqlServerCheckBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.csvFileTextBox);
            this.Controls.Add(this.csvFileLabel);
            this.Controls.Add(this.resultToCsvFileCheckBox);
            this.Controls.Add(this.splitPanel1);
            this.Controls.Add(this.urlListFileTextBox);
            this.Controls.Add(this.urlListFileLabel);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.exitButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(608, 396);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XML Solomono getter";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label urlListFileLabel;
        private System.Windows.Forms.TextBox urlListFileTextBox;
        private System.Windows.Forms.Panel splitPanel1;
        private System.Windows.Forms.CheckBox resultToCsvFileCheckBox;
        private System.Windows.Forms.Label csvFileLabel;
        private System.Windows.Forms.TextBox csvFileTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox resultToMsSqlServerCheckBox;
        private System.Windows.Forms.RadioButton windowsAuthenticationRadioButton;
        private System.Windows.Forms.RadioButton serverAuthenticationRadioButton;
        private System.Windows.Forms.Label serverLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Label dbLabel;
        private System.Windows.Forms.TextBox dbTextBox;
        private System.Windows.Forms.TextBox serverTextBox;
        private System.Windows.Forms.TextBox userTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolTip urlFileToolTip;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Button resetButton;
    }
}

