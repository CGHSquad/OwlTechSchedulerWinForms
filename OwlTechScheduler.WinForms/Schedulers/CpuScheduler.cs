using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zen.Barcode;
using System.Drawing.Imaging;
using System.IO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OwlTechScheduler.WinForms.Models;
using OwlTechScheduler.WinForms.Schedulers;

namespace OwlTechScheduler.WinForms.Schedulers
{
    public partial class CpuScheduler : Form
    {
        public CpuScheduler()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //dashBoardTab.Show();
            this.tabSelection.SelectTab(0);
            this.sidePanel.Height = btnDashBoard.Height;
            this.sidePanel.Top = btnDashBoard.Top;

            //this.btnProductCode.BackColor = Color.Transparent;
            //this.btnCpuScheduler.BackColor = Color.Transparent;
            //this.btnDashBoard.BackColor = Color.DimGray;
        }

        private void btnCpuScheduler_Click(object sender, EventArgs e)
        {
            //this.dashBoardTab.Show();
            this.tabSelection.SelectTab(1);
            this.sidePanel.Height = btnCpuScheduler.Height;
            this.sidePanel.Top = btnCpuScheduler.Top;

            //this.btnProductCode.BackColor = Color.Transparent;         
            //this.btnDashBoard.BackColor = Color.Transparent;
            //this.btnCpuScheduler.BackColor = Color.DimGray;
        }
        private List<Process> GenerateSampleProcesses(int count)
        {
            var list = new List<Process>();
            var rand = new Random();
            int currentTime = 0;
            for (int i = 0; i < count; i++)
            {
                currentTime += rand.Next(1, 5); // add spacing/gaps
                list.Add(new Process
                {
                    Id = i + 1,
                    ArrivalTime = currentTime,
                    BurstTime = rand.Next(2, 6),
                    Priority = rand.Next(1, 5)
                });
            }

            return list;
        }

        private void btnSRTF_Click(object sender, EventArgs e)
        {
            if (txtAdvancedProcess.Text != "")
            {
                int count;
                if (int.TryParse(txtAdvancedProcess.Text, out count))
                {
                    var processes = GenerateSampleProcesses(count);
                    var result = SrtfScheduler.Run(processes);
                    DisplayResults(result);
                }
                else
                {
                    MessageBox.Show("Please enter a valid number.");
                }
            }
        }

        private void btnMLFQ_Click(object sender, EventArgs e)
        {
            if (txtAdvancedProcess.Text != "")
            {
                int count;
                if (int.TryParse(txtAdvancedProcess.Text, out count))
                {
                    var processes = GenerateSampleProcesses(count);
                    var result = SrtfScheduler.Run(processes);
                    DisplayResults(result);
                }
                else
                {
                    MessageBox.Show("Please enter a valid number.");
                }
            }
        }


        private void btnFCFS_Click(object sender, EventArgs e)
        {
            if (txtProcess.Text != "")
            {
                Algorithms.fcfsAlgorithm(txtProcess.Text);
                int numberOfProcess = Int16.Parse(txtProcess.Text);
                if (numberOfProcess <= 10)
                {
                    this.progressBar1.Increment(4); //cpu progress bar
                    this.progressBar1.SetState(1);
                    this.progressBar2.Increment(13);
                    this.progressBar2.SetState(1);
                }
                else if (numberOfProcess > 10)
                {
                    this.progressBar1.Increment(15);
                    this.progressBar1.SetState(1);
                    this.progressBar2.Increment(38); //memory progress bar
                    this.progressBar2.SetState(3);
                }

                listView1.Clear();
                listView1.View = View.Details;
                
                listView1.Columns.Add("Process ID", 150, HorizontalAlignment.Center);
                listView1.Columns.Add("Quantum Time", 100, HorizontalAlignment.Center);

                for (int i = 0; i < numberOfProcess; i++)
                {
                    //listBoxProcess.Items.Add(" Process " + (i + 1));
                    var item = new ListViewItem();
                    item.Text = "Process " + (i + 1);
                    item.SubItems.Add("-");
                    listView1.Items.Add(item);
                }
                //listBoxProcess.Items.Add("\n");
                //listBoxProcess.Items.Add(" Total number of processes executed: " + numberOfProcess);
                listView1.Items.Add("\n");
                listView1.Items.Add("CPU handles: " + numberOfProcess);
            }
            else
            {
                MessageBox.Show("Enter number of processes", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProcess.Focus();
            }
        }

        private void btnSJF_Click(object sender, EventArgs e)
        {
            if (txtProcess.Text != "")
            {
                Algorithms.sjfAlgorithm(txtProcess.Text);
                int numberOfProcess = Int16.Parse(txtProcess.Text);
                if (numberOfProcess <= 10)
                {
                    this.progressBar1.Increment(4); //cpu progress bar
                    this.progressBar1.SetState(1);
                    this.progressBar2.Increment(13);
                    this.progressBar2.SetState(1);
                }
                else if (numberOfProcess > 10)
                {
                    this.progressBar1.Increment(15);
                    this.progressBar1.SetState(1);
                    this.progressBar2.Increment(38); //memory progress bar
                    this.progressBar2.SetState(3);
                }

                listView1.Clear();
                listView1.View = View.Details;
               
                listView1.Columns.Add("Process ID", 150, HorizontalAlignment.Center);
                listView1.Columns.Add("Quantum Time", 100, HorizontalAlignment.Center);

                for (int i = 0; i < numberOfProcess; i++)
                {
                    var item = new ListViewItem();
                    item.Text = "Process " + (i + 1);
                    item.SubItems.Add("-");
                    listView1.Items.Add(item);
                }
                
                listView1.Items.Add("\n");
                listView1.Items.Add("CPU handles: " + numberOfProcess);
            }
            else
            {
                MessageBox.Show("Enter number of processes", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProcess.Focus();
            }
        }

        private void btnPriority_Click(object sender, EventArgs e)
        {
            if (txtProcess.Text != "")
            {
                Algorithms.priorityAlgorithm(txtProcess.Text);
                int numberOfProcess = Int16.Parse(txtProcess.Text);
                if (numberOfProcess <= 10)
                {
                    this.progressBar1.Increment(4); //cpu progress bar
                    this.progressBar1.SetState(1);  //cpu color progress bar
                    this.progressBar2.Increment(13);
                    this.progressBar2.SetState(1);
                }
                else if (numberOfProcess > 10)
                {
                    this.progressBar1.Increment(15);
                    this.progressBar1.SetState(1);
                    this.progressBar2.Increment(38); //memory progress bar
                    this.progressBar2.SetState(3);   //memory color progress bar
                }
                listView1.Clear();
                listView1.View = View.Details;

                listView1.Columns.Add("Process ID", 150, HorizontalAlignment.Center);
                listView1.Columns.Add("Quantum Time", 100, HorizontalAlignment.Center);

                for (int i = 0; i < numberOfProcess; i++)
                {
                    var item = new ListViewItem();
                    item.Text = "Process " + (i + 1);
                    item.SubItems.Add("-");
                    listView1.Items.Add(item);
                }

                listView1.Items.Add("\n");
                listView1.Items.Add("CPU handles : " + numberOfProcess);
            }
            else
            {
                MessageBox.Show("Enter number of processes", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProcess.Focus();
            }
        }

        private void txtProcess_TextChanged(object sender, EventArgs e)
        {

        }

        private void restartApp_Click(object sender, EventArgs e)
        {
            this.Hide();
            CpuScheduler cpuScheduler = new CpuScheduler();
            cpuScheduler.ShowDialog();
        }

        private void btnBarcode_Click(object sender, EventArgs e)
        {
            if (txtCodeInput.Text != "")
            {
                string barcode = txtCodeInput.Text;
                //Code128BarcodeDraw barcode = BarcodeDrawFactory.Code128WithChecksum;
                //pictureBoxCodeOutput.Image = barcode.Draw(barcodeInput, 30);
                //pictureBoxCodeOutput.Height = barcode.Draw(txtCodeInput.Text, 150).Height;
                //pictureBoxCodeOutput.Width = barcode.Draw(txtCodeInput.Text, 150).Width;

                Bitmap bitmap = new Bitmap(barcode.Length * 36, 109);   //40, 150
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    Font font = new Font("IDAutomationHC39M Free Version", 25);
                    PointF point = new PointF(2f, 2f);
                    SolidBrush black = new SolidBrush(Color.Black);
                    SolidBrush white = new SolidBrush(Color.White);
                    graphics.FillRectangle(white, 0, 0, bitmap.Width, bitmap.Height);
                    graphics.DrawString(barcode, font, black, point);
                }
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    bitmap.Save(memoryStream, ImageFormat.Png);
                    pictureBoxCodeOutput.Image = bitmap;
                    //pictureBoxCodeOutput.Height = bitmap.Height;
                    //pictureBoxCodeOutput.Width = bitmap.Width;
                }
            }
            else
            {
                MessageBox.Show("No Input", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodeInput.Focus();
            }
            
        }

        private void btnQrcode_Click(object sender, EventArgs e)
        {
            if (txtCodeInput.Text != "")
            {
                CodeQrBarcodeDraw codeQr = BarcodeDrawFactory.CodeQr;
                pictureBoxCodeOutput.Image = codeQr.Draw(txtCodeInput.Text, 100);
                //string barcode = txtCodeInput.Text;
                //Bitmap bitmap = new Bitmap(barcode.Length * 40, 150);
                //pictureBoxCodeOutput.Image = bitmap; 
            }
            else
            {
                MessageBox.Show("No Input", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodeInput.Focus();
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (pictureBoxCodeOutput.Image == null)
            {
                return;
            }
            else if (pictureBoxCodeOutput.Image != null)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "PNG|*.png|JPEG|*.jpeg|ICON|*.ico"})
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        pictureBoxCodeOutput.Image.Save(saveFileDialog.FileName);
                    }
                }
            }           
        }

        private void btnProductCode_Click(object sender, EventArgs e)
        {
            //this.dashBoardTab.Show();
            this.tabSelection.SelectTab(3);
            this.sidePanel.Height = btnProductCode.Height;
            this.sidePanel.Top = btnProductCode.Top;
            
            //this.btnCpuScheduler.BackColor = Color.Transparent;
            //this.btnDashBoard.BackColor = Color.Transparent;
            //this.btnProductCode.BackColor = Color.DimGray;
        }

        private void CpuScheduler_Load(object sender, EventArgs e)
        {
            this.sidePanel.Height = btnDashBoard.Height;
            this.sidePanel.Top = btnDashBoard.Top;
            this.progressBar1.Increment(5);
            this.progressBar2.Increment(17);
            listView1.View = View.Details;
            listView1.GridLines = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Application.Exit();
            timer1.Start();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void btnRoundRobin_Click(object sender, EventArgs e)
        {
            if (txtProcess.Text != "")
            {
                Algorithms.roundRobinAlgorithm(txtProcess.Text);
                int numberOfProcess = Int16.Parse(txtProcess.Text);
                if (numberOfProcess <= 10)
                {
                    this.progressBar1.Increment(4); //cpu progress bar
                    this.progressBar1.SetState(1);  //cpu color progress bar
                    this.progressBar2.Increment(13);
                    this.progressBar2.SetState(1);
                }
                else if (numberOfProcess > 10)
                {
                    this.progressBar1.Increment(15);
                    this.progressBar1.SetState(1);
                    this.progressBar2.Increment(38); //memory progress bar
                    this.progressBar2.SetState(3);   //memory color progress bar
                }
                string quantumTime = Helper.QuantumTime;
                listView1.Clear();
                listView1.View = View.Details;

                listView1.Columns.Add("Process ID", 150, HorizontalAlignment.Center);
                listView1.Columns.Add("Quantum Time", 100, HorizontalAlignment.Center);

                for (int i = 0; i < numberOfProcess; i++)
                {
                    var item = new ListViewItem();
                    item.Text = "Process " + (i + 1);
                    item.SubItems.Add(quantumTime);
                    listView1.Items.Add(item);
                }

                listView1.Items.Add("\n");
                listView1.Items.Add("CPU handles: " + numberOfProcess);
            }
            else
            {
                MessageBox.Show("Enter number of processes", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProcess.Focus();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(this.Opacity > 0.0)
            {
                this.Opacity -= 0.021;
            } else
            {
                timer1.Stop();
                Application.Exit();
            }
        }

        private void txtCodeInput_Click(object sender, EventArgs e)
        {
            this.txtCodeInput.Clear();
        }
        private void btnAdvancedScheduler_Click(object sender, EventArgs e)
        {
            this.tabSelection.SelectTab(advancedSchedulerTab);
            this.sidePanel.Height = btnAdvancedScheduler.Height;
            this.sidePanel.Top = btnAdvancedScheduler.Top;
        }



        private void DisplayResults(List<Process> processes)
        {
            lvResults.Items.Clear(); // Only clear data, not structure
            lvResults.View = View.Details;
            lvResults.GridLines = true;
            lvResults.FullRowSelect = true;

            // Re-add columns every time
            lvResults.Columns.Add("PID", 50);
            lvResults.Columns.Add("Arrival", 60);
            lvResults.Columns.Add("Burst", 60);
            lvResults.Columns.Add("Start", 60);
            lvResults.Columns.Add("Complete", 80);
            lvResults.Columns.Add("Waiting", 60);
            lvResults.Columns.Add("Turnaround", 80);

            double totalWT = 0;
            double totalTAT = 0;
            int firstArrival = processes.Min(p => p.ArrivalTime);
            int lastCompletion = processes.Max(p => p.CompletionTime);
            int totalTime = lastCompletion - firstArrival;
            int totalProcesses = processes.Count;

            foreach (var p in processes.OrderBy(p => p.Id))
            {
                var row = new ListViewItem(p.Id.ToString());
                row.SubItems.Add(p.ArrivalTime.ToString());
                row.SubItems.Add(p.BurstTime.ToString());
                row.SubItems.Add(p.StartTime.ToString());
                row.SubItems.Add(p.CompletionTime.ToString());
                row.SubItems.Add(p.WaitingTime.ToString());
                row.SubItems.Add(p.TurnaroundTime.ToString());

                lvResults.Items.Add(row);

                totalWT += p.WaitingTime;
                totalTAT += p.TurnaroundTime;
            }

            double avgWT = totalWT / totalProcesses;
            double avgTAT = totalTAT / totalProcesses;
            double throughput = (double)totalProcesses / totalTime;
            double totalBurstTime = processes.Sum(p => p.BurstTime);
            double cpuUtilization = (processes.Sum(p => p.BurstTime) / (double)totalTime) * 100;
            
            

            // Show metrics in a popup
            MessageBox.Show(
                $"Average Waiting Time (AWT): {avgWT:F2}\n" +
                $"Average Turnaround Time (ATT): {avgTAT:F2}\n" +
                $"Throughput: {throughput:F2} processes/unit time\n" +
                $"CPU Utilization: {cpuUtilization:F2}%",
                "Performance Summary",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }


    }
}