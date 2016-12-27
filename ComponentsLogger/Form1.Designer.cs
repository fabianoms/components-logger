namespace ComponentsLogger
{
    partial class Form1
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
            this.Interval = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.secondsOfIntervLabel = new System.Windows.Forms.Label();
            this.StartBtn = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.ObservationTime = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.secondsObsTimeLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ethComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.wifiComboBox = new System.Windows.Forms.ComboBox();
            this.saveLogFileBtn = new System.Windows.Forms.Button();
            this.groupBoxExperiment = new System.Windows.Forms.GroupBox();
            this.UndefinedObservationTime = new System.Windows.Forms.CheckBox();
            this.groupBoxNetInterface = new System.Windows.Forms.GroupBox();
            this.wifiCheckBox = new System.Windows.Forms.CheckBox();
            this.ethCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dvdUnit = new System.Windows.Forms.Label();
            this.hdUnit = new System.Windows.Forms.Label();
            this.LCDBrightnessCheckBox = new System.Windows.Forms.CheckBox();
            this.CPUFreqCheckBox = new System.Windows.Forms.CheckBox();
            this.MemoryCheckBox = new System.Windows.Forms.CheckBox();
            this.MotherBoardCB = new System.Windows.Forms.CheckBox();
            this.DVDStateCheckBox = new System.Windows.Forms.CheckBox();
            this.DVDCheckBox = new System.Windows.Forms.CheckBox();
            this.HDCheckBox = new System.Windows.Forms.CheckBox();
            this.dvdUnitComboBox = new System.Windows.Forms.ComboBox();
            this.hdUnitComboBox = new System.Windows.Forms.ComboBox();
            this.DownloadCheckBox = new System.Windows.Forms.CheckBox();
            this.NetworkStateCheckbox = new System.Windows.Forms.CheckBox();
            this.UploadCheckBox = new System.Windows.Forms.CheckBox();
            this.ethInPCounter = new System.Diagnostics.PerformanceCounter();
            this.hdPerfCounter = new System.Diagnostics.PerformanceCounter();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Interval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ObservationTime)).BeginInit();
            this.groupBoxExperiment.SuspendLayout();
            this.groupBoxNetInterface.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ethInPCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hdPerfCounter)).BeginInit();
            this.SuspendLayout();
            // 
            // Interval
            // 
            this.Interval.Location = new System.Drawing.Point(12, 55);
            this.Interval.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Interval.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.Interval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Interval.Name = "Interval";
            this.Interval.Size = new System.Drawing.Size(80, 22);
            this.Interval.TabIndex = 0;
            this.Interval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Intervalo entre medições:";
            // 
            // secondsOfIntervLabel
            // 
            this.secondsOfIntervLabel.AutoSize = true;
            this.secondsOfIntervLabel.Location = new System.Drawing.Point(100, 58);
            this.secondsOfIntervLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.secondsOfIntervLabel.Name = "secondsOfIntervLabel";
            this.secondsOfIntervLabel.Size = new System.Drawing.Size(80, 17);
            this.secondsOfIntervLabel.TabIndex = 1;
            this.secondsOfIntervLabel.Text = "segundo(s)";
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(460, 379);
            this.StartBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(141, 37);
            this.StartBtn.TabIndex = 2;
            this.StartBtn.Text = "Iniciar log";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            this.saveFileDialog1.Filter = "Arquivos de texto (txt)|*.txt|Todos os arquivos|*.*";
            // 
            // ObservationTime
            // 
            this.ObservationTime.Enabled = false;
            this.ObservationTime.Location = new System.Drawing.Point(39, 146);
            this.ObservationTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ObservationTime.Maximum = new decimal(new int[] {
            36000,
            0,
            0,
            0});
            this.ObservationTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ObservationTime.Name = "ObservationTime";
            this.ObservationTime.Size = new System.Drawing.Size(80, 22);
            this.ObservationTime.TabIndex = 0;
            this.ObservationTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 98);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tempo de Observação:";
            // 
            // secondsObsTimeLabel
            // 
            this.secondsObsTimeLabel.AutoSize = true;
            this.secondsObsTimeLabel.Enabled = false;
            this.secondsObsTimeLabel.Location = new System.Drawing.Point(127, 149);
            this.secondsObsTimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.secondsObsTimeLabel.Name = "secondsObsTimeLabel";
            this.secondsObsTimeLabel.Size = new System.Drawing.Size(80, 17);
            this.secondsObsTimeLabel.TabIndex = 1;
            this.secondsObsTimeLabel.Text = "segundo(s)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 34);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Interface de Rede Ethernet";
            // 
            // ethComboBox
            // 
            this.ethComboBox.FormattingEnabled = true;
            this.ethComboBox.Location = new System.Drawing.Point(12, 55);
            this.ethComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ethComboBox.Name = "ethComboBox";
            this.ethComboBox.Size = new System.Drawing.Size(341, 24);
            this.ethComboBox.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 92);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Interface de Rede WiFi";
            // 
            // wifiComboBox
            // 
            this.wifiComboBox.FormattingEnabled = true;
            this.wifiComboBox.Location = new System.Drawing.Point(12, 113);
            this.wifiComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.wifiComboBox.Name = "wifiComboBox";
            this.wifiComboBox.Size = new System.Drawing.Size(341, 24);
            this.wifiComboBox.TabIndex = 3;
            // 
            // saveLogFileBtn
            // 
            this.saveLogFileBtn.Location = new System.Drawing.Point(12, 196);
            this.saveLogFileBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.saveLogFileBtn.Name = "saveLogFileBtn";
            this.saveLogFileBtn.Size = new System.Drawing.Size(185, 36);
            this.saveLogFileBtn.TabIndex = 4;
            this.saveLogFileBtn.Text = "Escolher Arquivo de Log";
            this.saveLogFileBtn.UseVisualStyleBackColor = true;
            this.saveLogFileBtn.Click += new System.EventHandler(this.saveLogFileBtn_Click);
            // 
            // groupBoxExperiment
            // 
            this.groupBoxExperiment.Controls.Add(this.UndefinedObservationTime);
            this.groupBoxExperiment.Controls.Add(this.label1);
            this.groupBoxExperiment.Controls.Add(this.Interval);
            this.groupBoxExperiment.Controls.Add(this.saveLogFileBtn);
            this.groupBoxExperiment.Controls.Add(this.ObservationTime);
            this.groupBoxExperiment.Controls.Add(this.secondsOfIntervLabel);
            this.groupBoxExperiment.Controls.Add(this.label3);
            this.groupBoxExperiment.Controls.Add(this.secondsObsTimeLabel);
            this.groupBoxExperiment.Location = new System.Drawing.Point(387, 16);
            this.groupBoxExperiment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxExperiment.Name = "groupBoxExperiment";
            this.groupBoxExperiment.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxExperiment.Size = new System.Drawing.Size(289, 240);
            this.groupBoxExperiment.TabIndex = 5;
            this.groupBoxExperiment.TabStop = false;
            this.groupBoxExperiment.Text = "Experimento";
            // 
            // UndefinedObservationTime
            // 
            this.UndefinedObservationTime.AutoSize = true;
            this.UndefinedObservationTime.Checked = true;
            this.UndefinedObservationTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UndefinedObservationTime.Location = new System.Drawing.Point(12, 118);
            this.UndefinedObservationTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UndefinedObservationTime.Name = "UndefinedObservationTime";
            this.UndefinedObservationTime.Size = new System.Drawing.Size(120, 21);
            this.UndefinedObservationTime.TabIndex = 5;
            this.UndefinedObservationTime.Text = "Indeterminado";
            this.UndefinedObservationTime.UseVisualStyleBackColor = true;
            this.UndefinedObservationTime.CheckedChanged += new System.EventHandler(this.UndefinedObservationTime_CheckedChanged);
            // 
            // groupBoxNetInterface
            // 
            this.groupBoxNetInterface.Controls.Add(this.wifiCheckBox);
            this.groupBoxNetInterface.Controls.Add(this.ethCheckBox);
            this.groupBoxNetInterface.Controls.Add(this.label5);
            this.groupBoxNetInterface.Controls.Add(this.label6);
            this.groupBoxNetInterface.Controls.Add(this.ethComboBox);
            this.groupBoxNetInterface.Controls.Add(this.wifiComboBox);
            this.groupBoxNetInterface.Location = new System.Drawing.Point(16, 15);
            this.groupBoxNetInterface.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxNetInterface.Name = "groupBoxNetInterface";
            this.groupBoxNetInterface.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxNetInterface.Size = new System.Drawing.Size(363, 155);
            this.groupBoxNetInterface.TabIndex = 6;
            this.groupBoxNetInterface.TabStop = false;
            this.groupBoxNetInterface.Text = "Interfaces de Rede";
            // 
            // wifiCheckBox
            // 
            this.wifiCheckBox.AutoSize = true;
            this.wifiCheckBox.Location = new System.Drawing.Point(172, 92);
            this.wifiCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.wifiCheckBox.Name = "wifiCheckBox";
            this.wifiCheckBox.Size = new System.Drawing.Size(18, 17);
            this.wifiCheckBox.TabIndex = 4;
            this.wifiCheckBox.UseVisualStyleBackColor = true;
            this.wifiCheckBox.CheckedChanged += new System.EventHandler(this.wifiCheckBox_CheckedChanged);
            // 
            // ethCheckBox
            // 
            this.ethCheckBox.AutoSize = true;
            this.ethCheckBox.Location = new System.Drawing.Point(197, 34);
            this.ethCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ethCheckBox.Name = "ethCheckBox";
            this.ethCheckBox.Size = new System.Drawing.Size(18, 17);
            this.ethCheckBox.TabIndex = 4;
            this.ethCheckBox.UseVisualStyleBackColor = true;
            this.ethCheckBox.CheckedChanged += new System.EventHandler(this.ethCheckBox_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dvdUnit);
            this.groupBox1.Controls.Add(this.hdUnit);
            this.groupBox1.Controls.Add(this.LCDBrightnessCheckBox);
            this.groupBox1.Controls.Add(this.CPUFreqCheckBox);
            this.groupBox1.Controls.Add(this.MemoryCheckBox);
            this.groupBox1.Controls.Add(this.MotherBoardCB);
            this.groupBox1.Controls.Add(this.DVDStateCheckBox);
            this.groupBox1.Controls.Add(this.DVDCheckBox);
            this.groupBox1.Controls.Add(this.HDCheckBox);
            this.groupBox1.Controls.Add(this.dvdUnitComboBox);
            this.groupBox1.Controls.Add(this.hdUnitComboBox);
            this.groupBox1.Controls.Add(this.DownloadCheckBox);
            this.groupBox1.Controls.Add(this.NetworkStateCheckbox);
            this.groupBox1.Controls.Add(this.UploadCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(16, 177);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(363, 377);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Efetuar Log";
            // 
            // dvdUnit
            // 
            this.dvdUnit.AutoSize = true;
            this.dvdUnit.Enabled = false;
            this.dvdUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dvdUnit.Location = new System.Drawing.Point(27, 262);
            this.dvdUnit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dvdUnit.Name = "dvdUnit";
            this.dvdUnit.Size = new System.Drawing.Size(145, 15);
            this.dvdUnit.TabIndex = 5;
            this.dvdUnit.Text = "UnidadeCorrespondente:";
            // 
            // hdUnit
            // 
            this.hdUnit.AutoSize = true;
            this.hdUnit.Enabled = false;
            this.hdUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hdUnit.Location = new System.Drawing.Point(27, 113);
            this.hdUnit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.hdUnit.Name = "hdUnit";
            this.hdUnit.Size = new System.Drawing.Size(145, 15);
            this.hdUnit.TabIndex = 5;
            this.hdUnit.Text = "UnidadeCorrespondente:";
            // 
            // LCDBrightnessCheckBox
            // 
            this.LCDBrightnessCheckBox.AutoSize = true;
            this.LCDBrightnessCheckBox.Location = new System.Drawing.Point(12, 214);
            this.LCDBrightnessCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LCDBrightnessCheckBox.Name = "LCDBrightnessCheckBox";
            this.LCDBrightnessCheckBox.Size = new System.Drawing.Size(117, 21);
            this.LCDBrightnessCheckBox.TabIndex = 4;
            this.LCDBrightnessCheckBox.Text = "Brilho do LCD";
            this.LCDBrightnessCheckBox.UseVisualStyleBackColor = true;
            // 
            // CPUFreqCheckBox
            // 
            this.CPUFreqCheckBox.AutoSize = true;
            this.CPUFreqCheckBox.Location = new System.Drawing.Point(12, 193);
            this.CPUFreqCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CPUFreqCheckBox.Name = "CPUFreqCheckBox";
            this.CPUFreqCheckBox.Size = new System.Drawing.Size(159, 21);
            this.CPUFreqCheckBox.TabIndex = 4;
            this.CPUFreqCheckBox.Text = "Informações da CPU";
            this.CPUFreqCheckBox.UseVisualStyleBackColor = true;
            // 
            // MemoryCheckBox
            // 
            this.MemoryCheckBox.AutoSize = true;
            this.MemoryCheckBox.Location = new System.Drawing.Point(12, 172);
            this.MemoryCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MemoryCheckBox.Name = "MemoryCheckBox";
            this.MemoryCheckBox.Size = new System.Drawing.Size(133, 21);
            this.MemoryCheckBox.TabIndex = 4;
            this.MemoryCheckBox.Text = "Uso de Memória";
            this.MemoryCheckBox.UseVisualStyleBackColor = true;
            // 
            // MotherBoardCB
            // 
            this.MotherBoardCB.AutoSize = true;
            this.MotherBoardCB.Location = new System.Drawing.Point(11, 338);
            this.MotherBoardCB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MotherBoardCB.Name = "MotherBoardCB";
            this.MotherBoardCB.Size = new System.Drawing.Size(197, 21);
            this.MotherBoardCB.TabIndex = 4;
            this.MotherBoardCB.Text = "Informações da Placa Mãe";
            this.MotherBoardCB.UseVisualStyleBackColor = true;
            // 
            // DVDStateCheckBox
            // 
            this.DVDStateCheckBox.AutoSize = true;
            this.DVDStateCheckBox.Location = new System.Drawing.Point(11, 314);
            this.DVDStateCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DVDStateCheckBox.Name = "DVDStateCheckBox";
            this.DVDStateCheckBox.Size = new System.Drawing.Size(182, 21);
            this.DVDStateCheckBox.TabIndex = 4;
            this.DVDStateCheckBox.Text = "Estado do drive de DVD";
            this.DVDStateCheckBox.UseVisualStyleBackColor = true;
            // 
            // DVDCheckBox
            // 
            this.DVDCheckBox.AutoSize = true;
            this.DVDCheckBox.Enabled = false;
            this.DVDCheckBox.Location = new System.Drawing.Point(12, 240);
            this.DVDCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DVDCheckBox.Name = "DVDCheckBox";
            this.DVDCheckBox.Size = new System.Drawing.Size(163, 21);
            this.DVDCheckBox.TabIndex = 4;
            this.DVDCheckBox.Text = "Uso do drive de DVD";
            this.DVDCheckBox.UseVisualStyleBackColor = true;
            this.DVDCheckBox.CheckedChanged += new System.EventHandler(this.DVDCheckBox_CheckedChanged);
            // 
            // HDCheckBox
            // 
            this.HDCheckBox.AutoSize = true;
            this.HDCheckBox.Location = new System.Drawing.Point(12, 91);
            this.HDCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.HDCheckBox.Name = "HDCheckBox";
            this.HDCheckBox.Size = new System.Drawing.Size(99, 21);
            this.HDCheckBox.TabIndex = 4;
            this.HDCheckBox.Text = "Uso do HD";
            this.HDCheckBox.UseVisualStyleBackColor = true;
            this.HDCheckBox.CheckedChanged += new System.EventHandler(this.HDCheckBox_CheckedChanged);
            // 
            // dvdUnitComboBox
            // 
            this.dvdUnitComboBox.Enabled = false;
            this.dvdUnitComboBox.FormattingEnabled = true;
            this.dvdUnitComboBox.Location = new System.Drawing.Point(28, 282);
            this.dvdUnitComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dvdUnitComboBox.Name = "dvdUnitComboBox";
            this.dvdUnitComboBox.Size = new System.Drawing.Size(221, 24);
            this.dvdUnitComboBox.TabIndex = 3;
            // 
            // hdUnitComboBox
            // 
            this.hdUnitComboBox.Enabled = false;
            this.hdUnitComboBox.FormattingEnabled = true;
            this.hdUnitComboBox.Location = new System.Drawing.Point(28, 133);
            this.hdUnitComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.hdUnitComboBox.Name = "hdUnitComboBox";
            this.hdUnitComboBox.Size = new System.Drawing.Size(221, 24);
            this.hdUnitComboBox.TabIndex = 3;
            // 
            // DownloadCheckBox
            // 
            this.DownloadCheckBox.AutoSize = true;
            this.DownloadCheckBox.Enabled = false;
            this.DownloadCheckBox.Location = new System.Drawing.Point(12, 70);
            this.DownloadCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DownloadCheckBox.Name = "DownloadCheckBox";
            this.DownloadCheckBox.Size = new System.Drawing.Size(147, 21);
            this.DownloadCheckBox.TabIndex = 4;
            this.DownloadCheckBox.Text = "Taxa de Download";
            this.DownloadCheckBox.UseVisualStyleBackColor = true;
            // 
            // NetworkStateCheckbox
            // 
            this.NetworkStateCheckbox.AutoSize = true;
            this.NetworkStateCheckbox.Enabled = false;
            this.NetworkStateCheckbox.Location = new System.Drawing.Point(12, 28);
            this.NetworkStateCheckbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NetworkStateCheckbox.Name = "NetworkStateCheckbox";
            this.NetworkStateCheckbox.Size = new System.Drawing.Size(225, 21);
            this.NetworkStateCheckbox.TabIndex = 4;
            this.NetworkStateCheckbox.Text = "Estado das Interfaces de Rede";
            this.NetworkStateCheckbox.UseVisualStyleBackColor = true;
            // 
            // UploadCheckBox
            // 
            this.UploadCheckBox.AutoSize = true;
            this.UploadCheckBox.Enabled = false;
            this.UploadCheckBox.Location = new System.Drawing.Point(12, 49);
            this.UploadCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UploadCheckBox.Name = "UploadCheckBox";
            this.UploadCheckBox.Size = new System.Drawing.Size(130, 21);
            this.UploadCheckBox.TabIndex = 4;
            this.UploadCheckBox.Text = "Taxa de Upload";
            this.UploadCheckBox.UseVisualStyleBackColor = true;
            // 
            // ethInPCounter
            // 
            this.ethInPCounter.CategoryName = "Network Interface";
            this.ethInPCounter.CounterName = "Bytes Received/sec";
            // 
            // hdPerfCounter
            // 
            this.hdPerfCounter.CategoryName = "PhysicalDisk";
            this.hdPerfCounter.CounterName = "Disk Bytes/sec";
            this.hdPerfCounter.InstanceName = "_Total";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 577);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxNetInterface);
            this.Controls.Add(this.groupBoxExperiment);
            this.Controls.Add(this.StartBtn);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Components Logger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Interval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ObservationTime)).EndInit();
            this.groupBoxExperiment.ResumeLayout(false);
            this.groupBoxExperiment.PerformLayout();
            this.groupBoxNetInterface.ResumeLayout(false);
            this.groupBoxNetInterface.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ethInPCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hdPerfCounter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown Interval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label secondsOfIntervLabel;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.NumericUpDown ObservationTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label secondsObsTimeLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ethComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox wifiComboBox;
        private System.Windows.Forms.Button saveLogFileBtn;
        private System.Windows.Forms.GroupBox groupBoxExperiment;
        private System.Windows.Forms.GroupBox groupBoxNetInterface;
        private System.Windows.Forms.CheckBox wifiCheckBox;
        private System.Windows.Forms.CheckBox ethCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox UploadCheckBox;
        private System.Windows.Forms.CheckBox CPUFreqCheckBox;
        private System.Windows.Forms.CheckBox MemoryCheckBox;
        private System.Windows.Forms.CheckBox HDCheckBox;
        private System.Windows.Forms.CheckBox DownloadCheckBox;
        private System.Windows.Forms.CheckBox NetworkStateCheckbox;
        private System.Windows.Forms.CheckBox LCDBrightnessCheckBox;
        private System.Diagnostics.PerformanceCounter ethInPCounter;
        private System.Windows.Forms.Label hdUnit;
        private System.Windows.Forms.ComboBox hdUnitComboBox;
        private System.Diagnostics.PerformanceCounter hdPerfCounter;
        private System.Windows.Forms.Label dvdUnit;
        private System.Windows.Forms.CheckBox DVDCheckBox;
        private System.Windows.Forms.ComboBox dvdUnitComboBox;
        private System.Windows.Forms.CheckBox DVDStateCheckBox;
        private System.Windows.Forms.CheckBox MotherBoardCB;
        private System.Windows.Forms.CheckBox UndefinedObservationTime;
        private System.Windows.Forms.Timer timer;
    }
}

