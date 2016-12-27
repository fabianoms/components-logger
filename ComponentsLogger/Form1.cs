using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Management;
using System.Diagnostics;
using System.Threading;
using ComponentsLogger.DataReaders;
using System.Collections;
using ComponentsLogger.DataReaders.Win;
using ComponentsLogger.DataReaders.OHM;
using OpenHardwareMonitor.Hardware;

namespace ComponentsLogger
{
    public partial class Form1 : Form
    {
        private StreamWriter writer;
        private int observationTime;
        private int currentObservationTime;
        private int interval;
        private bool hasEthLog;
        private bool hasWifiLog;
        private string logFile;
        private bool loggerRunning;

        private List<ComponentDataReader> dataReaders;
        private Computer computer;

        public Form1()
        {
            InitializeComponent();
            loggerRunning = false;
            dataReaders = new List<ComponentDataReader>();
            observationTime = 0;
            currentObservationTime = 0;
            interval = 0;
            hasEthLog = false;
            hasWifiLog = false;
            timer.Tick += new EventHandler(timer_Tick);
            SetComboBoxes();

            computer = new Computer();
            computer.Open();
        }

        private void SetComboBoxes()
        {
            ethComboBox.Enabled = false;
            wifiComboBox.Enabled = false;

            PerformanceCounterCategory[] categories = PerformanceCounterCategory.GetCategories();
            PerformanceCounterCategory netInterfaceCategory = null;
            PerformanceCounterCategory hdCategory = null;
            foreach (PerformanceCounterCategory category in categories)
            {
                string a = Properties.Resources.NetworkInterfaceCategoryName;
                if (category.CategoryName.Equals(Properties.Resources.NetworkInterfaceCategoryName))
                    netInterfaceCategory = category;
                else if (category.CategoryName.Equals(Properties.Resources.PhysicalDiskCategoryName))
                    hdCategory = category;

                if (netInterfaceCategory != null && hdCategory != null)
                    break;
            }


            if (netInterfaceCategory == null)
                MessageBox.Show("Não foi possível encontrar as interfaces de rede");
            if (hdCategory == null)
                MessageBox.Show("Não foi possível detectar as unidades de disco");

                
            string[] instanceNames = netInterfaceCategory.GetInstanceNames();
            foreach (string instanceName in instanceNames)
            {
                ethComboBox.Items.Add(instanceName);
                wifiComboBox.Items.Add(instanceName);
            }
            instanceNames = hdCategory.GetInstanceNames();
            List<string> instanceNamesSorted = new List<string>(instanceNames);
            instanceNamesSorted.Sort();
            foreach (string instanceName in instanceNamesSorted)
            {
                hdUnitComboBox.Items.Add(instanceName);
                dvdUnitComboBox.Items.Add(instanceName);
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            lock (dataReaders)
            {
                if (currentObservationTime >= observationTime)
                {
                    timer.Stop();
                    MessageBox.Show("Concluído!");
                    this.Close();
                }
                else
                {
                    string output = "";
                    foreach (ComponentDataReader dataReader in dataReaders)
                    {
                        output += dataReader.ReadData();
                    }
                    output = output.Replace(',', '.');  //hard coded
                    if (writer != null)
                    {
                        lock (writer)
                        {
                            writer.WriteLine(output);
                        }
                    }
                    currentObservationTime += interval;
                }
            }
        }

        private void saveLogFileBtn_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == saveFileDialog1.ShowDialog())
            {
                if (writer != null)
                    writer.Close();
                logFile = saveFileDialog1.FileName;
            }
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            if (!loggerRunning)
            {
                bool startOK = StartLogging();
                if (startOK)
                {
                    StartBtn.Text = "Parar log";
                }
            }
            else
            {
                StopLogging();
                StartBtn.Text = "Iniciar log";
            }
        }

        private bool StartLogging()
        {
            interval = (int)Interval.Value;
            timer.Interval = interval * 1000;
            observationTime = (UndefinedObservationTime.Checked) ? int.MaxValue : (int)ObservationTime.Value;
            if (InformationsOK())
            {
                writer = new StreamWriter(logFile, true);
                SetEnabledForAll(false);
                loggerRunning = true;
                LoadLoggers();
                timer.Start();
                return true;
            }
            return false;
        }

        private void StopLogging()
        {
            timer.Stop();
            dataReaders.Clear();
            loggerRunning = false;
            if (writer != null)
            {
                lock (writer)
                {
                    writer.Close();
                }
            }
        }
        
        private bool InformationsOK()
        {
            if (string.IsNullOrEmpty(logFile))
            {
                MessageBox.Show("Escolha um arquivo de log.");
                return false;
            }
            if (!UndefinedObservationTime.Checked)
            {
                if (Interval.Value >= ObservationTime.Value)
                {
                    MessageBox.Show("Tempo de observação deve ser maior que o intervalo entre medições.");
                    return false;
                }
            }
            if (wifiComboBox.Enabled &&
                (wifiComboBox.SelectedItem == null))
            {
                MessageBox.Show("Selecione uma interface de rede sem fio.");
                return false;
            }
            if (ethComboBox.Enabled &&
                (ethComboBox.SelectedItem == null))
            {
                MessageBox.Show("Selecione uma interface de rede Ethernet.");
                return false;
            }
            if (HDCheckBox.Checked &&
                hdUnitComboBox.SelectedItem == null)
            {
                MessageBox.Show("Selecione a unidade correspondente ao seu HD");
                return false;
            }
            if (DVDCheckBox.Checked &&
                dvdUnitComboBox.SelectedItem == null)
            {
                MessageBox.Show("Selecione a unidade correspondente ao seu drive de CD/DVD");
                return false;
            }
            return true;
        }

        private void LoadLoggers()
        {
            WriteChosenComponents();

            ComponentDataReader dateTimeReader, hdDataReader, dvdStatusDataReader, memoryDataReader, cpuDataReader, 
                ethDataReader, wifiDataReader, lcdDataReader, cpuCoolerDataReader;

            dateTimeReader = new CurrentTimeDataReader();

            if (CPUFreqCheckBox.Checked)
                cpuDataReader = new ProcessorDataReaderOHM(computer);
            else
                cpuDataReader = new EmptyDataReader();
            
            if (LCDBrightnessCheckBox.Checked)
                lcdDataReader = new LCDDataReader();
            else
                lcdDataReader = new EmptyDataReader();

            if (HDCheckBox.Checked)
                hdDataReader = new HardDiskDataReader((string)hdUnitComboBox.SelectedItem, "HD");
                //hdDataReader = new HardDiskDataReaderOHM(computer);                
            else
                hdDataReader = new EmptyDataReader();

            bool dvdIO, dvdStatus;
            dvdIO = DVDCheckBox.Checked;
            dvdStatus = DVDStateCheckBox.Checked;
            if ((!dvdIO) && (!dvdStatus))
                dvdStatusDataReader = new EmptyDataReader();
            else
                dvdStatusDataReader = new DVDDriveDataReader(dvdIO, dvdStatus);
            

            if (MemoryCheckBox.Checked)
                //memoryDataReader = new MemoryDataReader();
                memoryDataReader = new MemoryDataReaderOHM(computer);
            else
                memoryDataReader = new EmptyDataReader();

            bool logDownload = DownloadCheckBox.Checked;
            bool logUpload = UploadCheckBox.Checked;
            bool logNetworkStatus = NetworkStateCheckbox.Checked;
            if (hasEthLog)
                ethDataReader = new NetworkDataReader((string) ethComboBox.SelectedItem, NetworkDeviceType.Ethernet, logDownload, logUpload, logNetworkStatus);
            else
                ethDataReader = new EmptyDataReader();

            if (hasWifiLog)
                wifiDataReader = new NetworkDataReader((string)wifiComboBox.SelectedItem, NetworkDeviceType.Wireless, logDownload, logUpload, logNetworkStatus);
            else
                wifiDataReader = new EmptyDataReader();

            if (MotherBoardCB.Checked)
                cpuCoolerDataReader = new MainBoardDataReaderOHM(computer);
            else
                cpuCoolerDataReader = new EmptyDataReader();


            dataReaders.Add(dateTimeReader);
            dataReaders.Add(cpuDataReader);
            dataReaders.Add(hdDataReader);
            dataReaders.Add(dvdStatusDataReader);
            dataReaders.Add(memoryDataReader);
            dataReaders.Add(lcdDataReader);
            dataReaders.Add(ethDataReader);
            dataReaders.Add(wifiDataReader);
            dataReaders.Add(cpuCoolerDataReader);

            writer.Write("#"); //beginning header
            foreach (ComponentDataReader dataReader in dataReaders)
            {
                writer.Write(dataReader.GetDataHeader());
            }
            writer.WriteLine();
        }

        private void WriteChosenComponents()
        {
            if (ethComboBox.Items != null && ethComboBox.Items.Count > 0)
            {
                writer.WriteLine("Network Interfaces: ");
                foreach (string item in ethComboBox.Items)
                {
                    writer.WriteLine(item);
                }
            }
            else if (wifiComboBox.Items != null && wifiComboBox.Items.Count > 0)
            {
                writer.WriteLine("Network Interfaces: ");
                foreach (string item in wifiComboBox.Items)
                {
                    writer.WriteLine(item);
                }
            }

            if (ethComboBox.SelectedItem != null)
                writer.WriteLine("Interface Ethernet: " + ethComboBox.SelectedItem.ToString());
            if (wifiComboBox.SelectedItem != null)
                writer.WriteLine("Interface Wireless: " + wifiComboBox.SelectedItem.ToString());
            if (hdUnitComboBox.SelectedItem != null)
                writer.WriteLine("Unidade do Disco Rígido: " + hdUnitComboBox.SelectedItem.ToString());
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopLogging();
        }

        private void SetEnabledForAll(bool isEnabled)
        {
            ethCheckBox.Enabled = isEnabled;
            ethComboBox.Enabled = isEnabled;
            wifiCheckBox.Enabled = isEnabled;
            wifiComboBox.Enabled = isEnabled;
            NetworkStateCheckbox.Enabled = isEnabled;
            UploadCheckBox.Enabled = isEnabled;
            DownloadCheckBox.Enabled = isEnabled;
            HDCheckBox.Enabled = isEnabled;
            hdUnitComboBox.Enabled = isEnabled;
            MemoryCheckBox.Enabled = isEnabled;
            CPUFreqCheckBox.Enabled = isEnabled;
            LCDBrightnessCheckBox.Enabled = isEnabled;
            DVDCheckBox.Enabled = isEnabled;
            dvdUnitComboBox.Enabled = isEnabled;
            DVDStateCheckBox.Enabled = isEnabled;
            MotherBoardCB.Enabled = isEnabled;
            Interval.Enabled = isEnabled;
            UndefinedObservationTime.Enabled = isEnabled;
            ObservationTime.Enabled = isEnabled;
            saveLogFileBtn.Enabled = isEnabled;
        }

        private void ethCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            hasEthLog = ethComboBox.Enabled = ((CheckBox)sender).Checked;
            if (hasEthLog)
            {
                UploadCheckBox.Enabled = true;
                DownloadCheckBox.Enabled = true;
                NetworkStateCheckbox.Enabled = true;
            }
            else if (!hasWifiLog)
            {
                UploadCheckBox.Enabled = false;
                DownloadCheckBox.Enabled = false;
                NetworkStateCheckbox.Enabled = false;
            }
        }

        private void wifiCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            hasWifiLog = wifiComboBox.Enabled = ((CheckBox)sender).Checked;
            if (hasWifiLog)
            {
                UploadCheckBox.Enabled = true;
                DownloadCheckBox.Enabled = true;
                NetworkStateCheckbox.Enabled = true;
            }
            else if (!hasEthLog)
            {
                UploadCheckBox.Enabled = false;
                DownloadCheckBox.Enabled = false;
                NetworkStateCheckbox.Enabled = false;
            }
        }

        private void HDCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool enabled = ((CheckBox)sender).Checked;
            hdUnit.Enabled = hdUnitComboBox.Enabled = enabled;
        }

        private void DVDCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool enabled = ((CheckBox)sender).Checked;
            dvdUnit.Enabled = dvdUnitComboBox.Enabled = enabled;
        }

        private void UndefinedObservationTime_CheckedChanged(object sender, EventArgs e)
        {
            bool enabled = ((CheckBox)sender).Checked;
            ObservationTime.Enabled = secondsObsTimeLabel.Enabled = !enabled;
        }
    }
}
