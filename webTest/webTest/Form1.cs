using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.IO;

namespace webTest
{
    public partial class Form1 : Form
    {
        public ChromiumWebBrowser chromeBrowser;
        int counter = 0;
        float receita = 1000;
        string cachepath = Path.Combine(Path.GetTempPath(), "/cachecef");
        public Form1()
        {
            InitializeComponent();
            InitializeChromium();

        }
        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            settings.RemoteDebuggingPort = 8088;
            settings.CachePath = cachepath;
            // Initialize cef with the provided settings
            Cef.Initialize(settings);

            // Create a browser component
            chromeBrowser = new ChromiumWebBrowser("https://cav.receita.fazenda.gov.br/autenticacao");
            chromeBrowser.LoadingStateChanged += ChromeBrowser_LoadingStateChanged;

            // Add it to the form and fill it to the form window.
            this.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
        }

        private void ChromeBrowser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            
            if (e.IsLoading==false)
            {
                // ChangeValue("NI", "293103193");
                if (counter == 0)
                {
                    System.Threading.Thread.Sleep(2000);


                    chromeBrowser.ExecuteScriptAsync(GetElement("caixa-login-certificado") + ".click()");
                   
                }
                else if (counter == 1) {
                    System.Threading.Thread.Sleep(2000);


                    chromeBrowser.EvaluateScriptAsync("window.location.href = 'https://cav.receita.fazenda.gov.br/ecac/Aplicacao.aspx?id=10009&origem=menu';");

                }
                else if (counter==2)
                {
                    System.Threading.Thread.Sleep(2000);


                    chromeBrowser.EvaluateScriptAsync("window.location.href = 'https://sinac.cav.receita.fazenda.gov.br/SimplesNacional/Aplicacoes/ATSPO/pgdasd2018.app/declaracao?clear=1'");
                }
                else if (counter==3)
                {
                    System.Threading.Thread.Sleep(2000);


                    ChangeValue("pa", "03/2018");
                    chromeBrowser.EvaluateScriptAsync(GetElement("pa") + ".parentElement.parentElement.submit()");

                }
                else if(counter==4)
                {
                    chromeBrowser.EvaluateScriptAsync("if (document.getElementsByName('rpaCaixaInt')[0]==null) window.location.href = ' https://sinac.cav.receita.fazenda.gov.br/SimplesNacional/Aplicacoes/ATSPO/pgdasd2018.app/declaracao/rpa'");
                    chromeBrowser.EvaluateScriptAsync("document.getElementsByName('rpaCaixaInt')[0].value = "+receita*100);
                    chromeBrowser.EvaluateScriptAsync(" document.getElementsByName('rpaCaixaInt')[0].click();");
                    chromeBrowser.EvaluateScriptAsync("document.getElementsByName('rpaCompInt')[0].value = " + 000);
                    chromeBrowser.EvaluateScriptAsync(" document.getElementsByName('rpaCompInt')[0].click();");
                    chromeBrowser.EvaluateScriptAsync("document.getElementsByName('rpaCompExt')[0].value = " + 000);
                    chromeBrowser.EvaluateScriptAsync(" document.getElementsByName('rpaCompExt')[0].click();");
                    chromeBrowser.EvaluateScriptAsync("document.getElementsByName('rpaCaixaExt')[0].value = " + 000);
                    chromeBrowser.EvaluateScriptAsync(" document.getElementsByName('rpaCaixaExt')[0].click();");
                                          
                    chromeBrowser.EvaluateScriptAsync("$('form').submit()");

                    
                }
                else if (counter==5)
                {
                    checkActivities(new int[0] {  });

                    ClickId("btn-salvar");
                }else if (counter == 6)
                {

                }


                counter++;
            }
        }
        string GetElement(string s)
        {
            return "document.getElementById(\'" +s+ "\')";
        }
        void ChangeValue(string id, string value)
        {
            chromeBrowser.EvaluateScriptAsync("document.getElementById(\'"+id+ "\').value=\'" + value+ "\'; ");

        }
        void ClickId(string id)
        {
            chromeBrowser.ExecuteScriptAsync("document.getElementById(\'"+id+"\').click()");

        }
        void checkActivities(int[]values)
        {
            foreach (int i in values)
            {
                chromeBrowser.ExecuteScriptAsync("document.querySelectorAll('[data-atividade]')["+i+"].click();");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
            if (Directory.Exists(cachepath)) clearFolder(cachepath);
            
        }
        private void clearFolder(string FolderName)
        {
            DirectoryInfo dir = new DirectoryInfo(FolderName);

            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.Delete();
            }

            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                clearFolder(di.FullName);
                di.Delete();
            }
        }
    }
}
