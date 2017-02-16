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
using System.Runtime.InteropServices;

namespace DNSQueryUI
{
    public partial class Form2 : MetroForm
    {
        [DllImport("CommonUtil.dll")]
        //private static extern double Sub(double a, double b);
        public static extern bool DecryptMessage(string In, string Out);
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
             
            StreamReader sr = new StreamReader(openFileDialog1.FileName, Encoding.UTF8);
            //richTextBox1.Text = sr.ReadToEnd();
            textBox1.Text = sr.ReadToEnd();
            sr.Close();
        }
        
        public void ReadLog()
        {
            string fi64 = "C:\\Program Files (x86)\\sresolver\\log\\" + "DSRMService_" + DateTime.Today.ToString("yyyy_MM_dd") + ".log";           
            string fi32 = "C:\\Program Files\\sresolver\\log\\"+"DSRMService_" + DateTime.Today.ToString("yyyy_MM_dd") + ".log";
            //DirectoryInfo folderpath64 = new DirectoryInfo("C:\\Program Files (x86)\\sresolver\\log\\");
            //DirectoryInfo folderpath32 = new DirectoryInfo("C:\\Program Files\\sresolver\\log\\");

            //FileInfo filename = new FileInfo("DSRMService_" + DateTime.Today.ToString("yyyy_MM_dd") + ".log");
            //string[] StrArr; 
            try
            {
                if (File.Exists(fi64))
                {
                    
                    FileStream fs64 = new FileStream("C:\\Program Files (x86)\\sresolver\\log\\" + "DSRMService_" + DateTime.Today.ToString("yyyy_MM_dd") + ".log", FileMode.Open, FileAccess.Read, FileShare.None);
                    StreamReader sr64 = new StreamReader(fs64, Encoding.UTF8);
                    //StreamWriter sw64 = new StreamWriter(fs64, Encoding.UTF8);
                    //string strRead;
                    //string strPlain;
                    while (sr64.Peek() >= 0)
                    {
                        //DecryptMessage(fi64, textBox1.Text = sr64.ReadToEnd());
                        //richTextBox1.Text = sr64.ReadToEnd();
                        textBox1.Text = sr64.ReadToEnd();
                    } 
                    /*
                    while (!sr64.EndOfStream)
                    {
                        //StrArr = fi64.Split(' ');
                        strRead = sr64.ReadLine();
                        strPlain = "";
                        DecryptMessage(strRead, strPlain);
                        textBox1.Text = strPlain;
                    }*/
                    fs64.Close();

                    /*
                    int counter = 0;
                    string line="";
                    string plain="";
                    StreamReader file = new StreamReader(@"C:\\Program Files(x86)\\sresolver\\log\\" + "DSRMService_" + DateTime.Today.ToString("yyyy_MM_dd") + ".log");
                    //while((line=file.ReadLine())!=null)
                    while(file.Peek() >= 0)
                    {
                        line = file.ReadLine();
                        
                        DecryptMessage(line, plain);
                        textBox1.Text = plain;
                        counter++;
                        
                    }
                    file.Close();
                    */
                    /*
                    StreamReader reader = new StreamReader(new FileStream("C:\\Program Files (x86)\\sresolver\\log\\" + "DSRMService_" + DateTime.Today.ToString("yyyy_MM_dd") + ".log", FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
                    long lastMaxOffset = reader.BaseStream.Length;

                    while(true)
                    {
                        //System.Threading.Thread.Sleep(100);
                            if (reader.BaseStream.Length == lastMaxOffset)
                            continue;
                        reader.BaseStream.Seek(lastMaxOffset, SeekOrigin.Begin);
                        string line = "";
                        string plain = "";
                        while((line=reader.ReadLine())!=null)
                        {
                            DecryptMessage(line, plain);
                            //Console.WriteLine(plain);
                            textBox1.Text = plain;
                        }
                        lastMaxOffset = reader.BaseStream.Position;
                    }*/
                    
                }
                else if (File.Exists(fi32))
                {
                    FileStream fs32 = new FileStream("C:\\Program Files\\sresolver\\log\\" + "DSRMService_" + DateTime.Today.ToString("yyyy_MM_dd") + ".log", FileMode.Open, FileAccess.Read, FileShare.None);
                    StreamReader sr32 = new StreamReader(fs32, Encoding.UTF8);
                    while (sr32.Peek() >= 0)
                    {
                        //DecryptMessage(fi32, textBox1.Text = sr32.ReadToEnd());
                        //richTextBox1.Text = sr32.ReadToEnd();
                        textBox1.Text = sr32.ReadToEnd();
                    }
                    fs32.Close();
                }
                else
                {
                    //richTextBox1.ForeColor = Color.Red;
                    //richTextBox1.Text = "로그파일이 존재하지 않습니다.";
                    textBox1.Text = "로그파일이 존재하지 않습니다.";
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
           // richTextBox1.SelectionStart = richTextBox1.Text.Length;
            //richTextBox1.ScrollToCaret();
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
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

            /*
            int counter = 0;
            string line="";
            string plain="";
            StreamReader file = new StreamReader(@"C:\\Program Files (x86)\\sresolver\\log\\" + "DSRMService_" + DateTime.Today.ToString("yyyy_MM_dd") + ".log");
            //while((line=file.ReadLine())!=null)
            while(file.Peek() >= 0)
            {
                line = file.ReadLine();

                DecryptMessage(line, plain);
                textBox1.Text = plain;
                counter++;

            }
            file.Close();
            */
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            fileopen1();
            //richTextBox1.SelectionStart = richTextBox1.Text.Length;
            //richTextBox1.ScrollToCaret();
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
        }

        //drag && drop 구현
        private void txtfile_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    string[] strFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
                    StreamReader objSr = new StreamReader(strFiles[0], Encoding.UTF8);
                    this.textBox1.Clear();
                    this.textBox1.Text = objSr.ReadToEnd();
                    objSr.Close();
                }
            }
        }

        private void txtfile_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void txtfile_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            if (e.EscapePressed)
            {
                e.Action = DragAction.Cancel;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = textBox1.Text.Length.ToString();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                if (sender != null)
                    ((TextBox)sender).SelectAll();
            }            
        }
        /*
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F))
            {
                MessageBox.Show("What the Ctrl+F?");
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        */

    }
}
