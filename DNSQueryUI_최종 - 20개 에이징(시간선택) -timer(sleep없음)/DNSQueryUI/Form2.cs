using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework;
using MetroFramework.Controls;
using System.IO;
using System.Diagnostics;
using System.Timers;

namespace DNSQueryUI
{
    public partial class Form2 : MetroForm
    {
        public Form2()
        {
            InitializeComponent();
            
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
     
            
            if (timer2.Enabled)
            {
                
                timer2.Stop();
                metroButton1.Text = "로그파일 열기";
            }
            else
            {

                fileopen();
                timer2.Start();
                metroButton1.Text = "실시간 로그 STOP";
            }

        }
        public void fileopen()
        {
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Filter = "로그 파일 (*.log)|*.log|텍스트 파일 (*.txt)|*.txt|모든 파일 (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileopen1();
            }
            
        }
        public void fileopen1()
        {
            StreamReader sr = new StreamReader(openFileDialog1.FileName, Encoding.Default);
            richTextBox1.Text = sr.ReadToEnd();
            sr.Close();
        }
        
        public void ReadLog()
        {
            string fi64 = "C:\\Program Files (x86)\\sresolver\\log\\" + "DSRMService_" + DateTime.Today.ToString("yyyy_MM_dd") + ".log";
            string fi32 = "C:\\Program Files\\sresolver\\log\\"+"DSRMService_" + DateTime.Today.ToString("yyyy_MM_dd") + ".log";
                 
            //DirectoryInfo folderpath64 = new DirectoryInfo("C:\\Program Files (x86)\\sresolver\\log\\");
            //DirectoryInfo folderpath32 = new DirectoryInfo("C:\\Program Files\\sresolver\\log\\");

            //FileInfo filename = new FileInfo("DSRMService_" + DateTime.Today.ToString("yyyy_MM_dd") + ".log");

            try
            {
                if (File.Exists(fi64))
                {
                    FileStream fs64 = new FileStream("C:\\Program Files (x86)\\sresolver\\log\\" + "DSRMService_" + DateTime.Today.ToString("yyyy_MM_dd") + ".log", FileMode.Open, FileAccess.Read, FileShare.None);
                    StreamReader sr64 = new StreamReader(fs64);
                    while (sr64.Peek() >= 0)
                    {
                        richTextBox1.Text = sr64.ReadToEnd();
                    }
                    fs64.Close();
                }
                else if (File.Exists(fi32))
                {
                    FileStream fs32 = new FileStream("C:\\Program Files\\sresolver\\log\\" + "DSRMService_" + DateTime.Today.ToString("yyyy_MM_dd") + ".log", FileMode.Open, FileAccess.Read, FileShare.None);
                    StreamReader sr32 = new StreamReader(fs32);
                    while (sr32.Peek() >= 0)
                    {
                        richTextBox1.Text = sr32.ReadToEnd();
                    }
                    fs32.Close();
                }
                else
                {
                    richTextBox1.ForeColor = Color.Red;
                    richTextBox1.Text = "로그파일이 존재하지 않습니다.";
                }
            }
            catch
            {
                //metroTextBox1.Text = "로그파일이 존재하지 않습니다.";
                //MessageBox.Show("로그파일이 존재 하지 않습니다.", "로그파일 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            //{ this.metroTextBox1.Text = DateTime.Now.ToString(); }
            ReadLog();
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
            //timer1.Enabled = true;
            //metroButton2_Click(null, null); // 주기적으로 버튼 클릭하기

        }
        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                metroButton2.Text = "로그 바로보기";
            }
            else
            {
                timer1.Start();
                metroButton2.Text = "실시간 로그 STOP";
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            fileopen1();
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }
    }
}