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

namespace webTest
{
    public partial class Server : Form
    {
        string numboletos = "Foram emitidos {0} boletos no dia de hoje";
        int boletosday, today;
        public static string cachepath = Path.Combine(Path.GetTempPath(), "/cachecef");
        bool first = true;
       public static DASpicker ds;
        public Server()
        {
            InitializeComponent();
            initializeCEF();
            first = false;
            cnpjbox.Text = "27124625000111";
            textBox1.Text = "0";
            textBox2.Text = "0";
          
        }

        private void button1_Click(object sender, EventArgs e)
        {

           
                if (cnpjbox.Text != "" && textBox1.Text != "" && textBox2.Text != "")
                {
                    string cnpjb = cnpjbox.Text;
                    string date = numericUpDown1.Value < 10 ? "0" + numericUpDown1.Value + "/2018" : numericUpDown1.Value + "/2018";
                    int[] recs = new int[4] { int.Parse(textBox1.Text.Replace(",","")), int.Parse(textBox2.Text.Replace(",", "")), 0, 0 };
                     ds = new DASpicker(cnpjb, date, new int[1] { 13}, recs,first,true);
                     ds.Show();
                     ds.Name = "Emitir DAS de " + cnpjb;
                    first = true;
                }
                else MessageBox.Show("Preencha todos os campos");

           
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) 
                 )
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
            if (DASpicker.canexit)
            { ds.Close();
                DASpicker.canexit = false;
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
            }

        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
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
            CefSettings settings = new CefSettings();
            settings.RemoteDebuggingPort = 8088;
            settings.CachePath = Server.cachepath;
            // Initialize cef with the provided settings
            Cef.Initialize(settings);

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = ((TextBox)sender).Text.Replace(",", "");
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
           ( (TextBox)sender).Text = convert(float.Parse(((TextBox)sender).Text));

        }

        string convert(float num)
        {
            return ((float)(num) / 100f).ToString().Replace(".", ",");
        }
    }
}
