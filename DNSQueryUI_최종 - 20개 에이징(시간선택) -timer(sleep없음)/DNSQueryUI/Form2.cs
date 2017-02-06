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
            string fi64 = "C:\\Program Files (x86)\\sresolver\\log\\"+"DSRMService_" + DateTime.Today.ToString("yyyy_MM_dd") + ".log";
            string fi32 = "C:\\Program Files\\sresolver\\log\\"+"DSRMService_" + DateTime.Today.ToString("yyyy_MM_dd") + ".log";

            //DirectoryInfo folderpath64 = new DirectoryInfo("C:\\Program Files (x86)\\sresolver\\log\\");
            //DirectoryInfo folderpath32 = new DirectoryInfo("C:\\Program Files\\sresolver\\log\\");

            //FileInfo filename = new FileInfo("DSRMService_" + DateTime.Today.ToString("yyyy_MM_dd") + ".log");

            try
            {
                if (File.Exists(fi64))
                {
                    StreamReader sr64 = new StreamReader(fi64);
                    while (sr64.Peek() >= 0)
                    {
                        metroTextBox1.Text = sr64.ReadToEnd();
                    }
                }
                else
                {
                    StreamReader sr32 = new StreamReader(fi32);
                    while (sr32.Peek() >= 0)
                    {
                        metroTextBox1.Text = sr32.ReadToEnd();
                    }
                }
            }
            catch 
            {
                MessageBox.Show("로그파일이 존재 하지 않습니다.", "로그파일 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            { this.metroTextBox1.Text = DateTime.Now.ToString(); }
        }
    }
}