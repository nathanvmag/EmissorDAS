using CefSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Collections;
using System.Threading;

namespace webTest
{
    public partial class Server : Form
    {
        string numboletos = "Foram emitidos {0} boletos no dia de hoje";
        int boletosday, today;
        public static string cachepath = Path.Combine(Path.GetTempPath(), "/cachecef");
        bool first = true;
        WebClient webclient;
        public static DASpicker ds;
        public static Queue<string> requests;
        public const string serversite = "http://localhost";
        float opentime;
        string reqfile = @"C:\xampp\htdocs\Site\r\requests.txt";
        public static int errors;
        public Server()
        {
            try
            {
                InitializeComponent();
                initializeCEF();
                first = false;
                cnpjbox.Text = "27124625000111";
                textBox1.Text = "0";
                textBox2.Text = "0";
                webclient = new WebClient();
                webclient.Encoding = Encoding.UTF8;
                requests = new Queue<string>();
                errors = 0;
            }
            catch( Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

           
                if (cnpjbox.Text != "" && textBox1.Text != "" && textBox2.Text != "")
                {
                    string cnpjb = cnpjbox.Text;
                    string date = numericUpDown1.Value < 10 ? "0" + numericUpDown1.Value + "/2018" : numericUpDown1.Value + "/2018";
                    int[] recs = new int[4] { int.Parse(textBox1.Text.Replace(",","")), int.Parse(textBox2.Text.Replace(",", "")), 0, 0 };
                    ds = null;
                    ds = new DASpicker(cnpjb, date, new int[2] {0,23}, recs,first,true);
                    ds.Show();
                     ds.Name = "Emitir DAS de " + cnpjb;
                    first = true;
                }
                else Console.WriteLine("Preencha todos os campos");

           
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
           
        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.')&& (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {   if (ds != null)
                {
                    if (DASpicker.canexit)
                    {
                        ds.Close();
                        DASpicker.canexit = false;
                    }
                }
                DateTime time = DateTime.Now;
                numericUpDown1.Maximum = time.Month - 1;
                label3.Text = string.Format(numboletos, boletosday);
                if (today != time.Day)
                {
                    today = time.Day;
                    boletosday = 0;
                }
                if (ds != null && !ds.Visible)
                    ds = null;
                if (!timer2.Enabled && (!ds.Visible || ds != null))
                    timer2.Enabled = true;

                if (ds != null && ds.Visible&&ds.stcount)
                {
                    opentime += 1;
                    if (opentime % 200 == 0) Console.WriteLine("O erro esta com " + opentime);
                    if (opentime > 2000)
                    {
                        ds.erroclose();
                        opentime = 0;
                        errors++;
                    }
                }
            }
            catch (Exception x)
            {
                Console.WriteLine(x.ToString());
            }
        }



        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            try { Cef.Shutdown(); }
            catch { };
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {

        }



  

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
     
            e.Handled = true;
        
    }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        void initializeCEF()
        {
            try
            {
                CefSettings settings = new CefSettings();
                settings.RemoteDebuggingPort = 8088;
                settings.CachePath = Server.cachepath;
                // Initialize cef with the provided settings
                Cef.Initialize(settings);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = ((TextBox)sender).Text.Replace(",", "");
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
           ( (TextBox)sender).Text = convert(((TextBox)sender).Text);

        }
        static AutoResetEvent autoEvent = new AutoResetEvent(false);

        private async void timer2_Tick(object sender, EventArgs e)
        {
            try {
                if (requests.Count == 0 && (ds == null || ds != null && !ds.Visible))
                {
                    try
                    {
                        if(File.Exists("requests.txt")&&errors==0)
                        {
                            StreamReader sr = new StreamReader("requests.txt");
                            string query = sr.ReadToEnd();
                            sr.Close();
                            if(query.Split('|').Length>0)
                            if (!String.IsNullOrEmpty(query.Split('|')[0]))
                            {
                                requests.Enqueue(query.Split('|')[0]);
                            }
                            Console.WriteLine("pegou do requestsavo");
                        }
                        else if (File.Exists(reqfile)&&errors==0)
                        {
                            string query = webclient.DownloadString(serversite + "/Site/r/requests.txt");
                            Console.WriteLine(query);
                            string ex = webclient.DownloadString(serversite + "/Site/r/clean.php");
                            if (ex == "1") Console.WriteLine("sucess");
                            
                            
                            StreamWriter sw = new StreamWriter(new FileStream("requests.txt",FileMode.OpenOrCreate),UTF8Encoding.UTF8);
                            string strcopy = "";
                            foreach (string s in query.Split('|'))
                            {
                                if (!String.IsNullOrEmpty(s))
                                {
                                    requests.Enqueue(s);
                                    strcopy += s + "?0|";
                                }
                            }
                            Console.WriteLine("vai escrever assim "+strcopy);
                            sw.Write(strcopy);
                            sw.Close();                          
                        }
                         else
                        {
                            if (errors>0)
                            {
                                System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application
                                this.Close(); //to turn off current app
                            }
                        }
                       
                               
                    }
                    catch (Exception ex)
                    {
                        //((System.Windows.Forms.Timer)sender).Stop();
                        // Console.WriteLine("nao possui");
                    }
                }
                else
                {
                    if (requests.Count > 0)
                    {
                        if (ds == null || ds != null && !ds.Visible)
                        {
                            string work = requests.Dequeue();
                            string[] infos = work.Split('?');
                            var parametres = new System.Collections.Specialized.NameValueCollection();
                            parametres.Add("servID", "881");
                            parametres.Add("cnpj", infos[0].Trim());
                            string tbs = Encoding.UTF8.GetString(webclient.UploadValues(serversite + "/Site/login.php", parametres));
                            List<int> tts = new List<int>();
                            int[] finaltab = new int[0];
                            Console.WriteLine("tbs= " + tbs);
                            if (tbs.Split('@')[1].Split(',').Length > 0)
                            {
                                foreach (string s in tbs.Split('@')[1].Split(','))
                                {
                                    if (!String.IsNullOrEmpty(s)) tts.Add(int.Parse(s));
                                }
                                finaltab = tts.ToArray();
                            }
                            int[] myrecs = new int[4] { int.Parse(infos[1]), int.Parse(infos[2]), 0, 0 };

                            string date = int.Parse(infos[3]) < 10 ? "0" + infos[3] + "/2018" : infos[3] + "/2018";
                            Console.WriteLine(infos[0] + "  " + date + "  " + finaltab.Length + "  " + myrecs.Length);
                            Console.WriteLine(tbs.Split('@')[0]);
                            ds = null;
                            ds = new DASpicker(infos[0], date, finaltab, myrecs, first, tbs.Split('@')[0] == "0" ? false : true);
                            ds.Show();
                            ds.Name = "Emitir DAS de " + infos[0];
                            first = true;
                            timer2.Enabled = false;
                            boletosday++;
                            opentime = 0;

                        }
                    } }
          
        }
            catch (Exception x)
            {
                Console.WriteLine(x.ToString());
            }

        }
        public static  void Restart()
        {
            System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application
            Application.Exit();
        }

        string convert(string num)
        {
            string s = num.ToString();

            if (s.Length >= 3) return s.Substring(0, s.Length - 2) + "," + s.Substring(s.Length - 2);
            else return "0," + s;
        }
    }
}
