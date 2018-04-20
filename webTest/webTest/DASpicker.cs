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
using System.Timers;
using webTest;
using System.Globalization;

namespace webTest
{

    public partial class DASpicker : Form
    {
        ChromiumWebBrowser chromeBrowser;
        int counter = 0;
        bool logado = false;
        public string cnpj;
        string myadress;
        bool comecadas;
        bool completeTask = false;
        Task loguei;
        Task Completetask;
        int[] receitas;
        public string DATA;
        int[] Tabela;
        bool fix;
        int c = 0;
        bool exit;
        DASpicker ds;
        public static bool canexit;
        bool coucomp;
        JavascriptResponse jr;
        bool download = false;
        public DASpicker(string cnpjj, string data, int[] tab, int[] recs, bool initialized, bool c)
        {
            fix = initialized;
            cnpj = cnpjj;
            DATA = data;
            Tabela = tab;
            receitas = recs;
            InitializeComponent();
            InitializeChromium();
            logado = false;
            comecadas = false;
            completeTask = false;
            exit = false;
            ds = this;
            coucomp = c;
            DownloadHandler.count = 0;
            download = true;
        }
        public void InitializeChromium()
        {


            Completetask = new Task(() => { completeTask = true; });

            chromeBrowser = new ChromiumWebBrowser("https://cav.receita.fazenda.gov.br/autenticacao");
            chromeBrowser.LoadingStateChanged += ChromeBrowser_LoadingStateChanged;
            chromeBrowser.AddressChanged += ChromeBrowser_AddressChanged;
            chromeBrowser.DownloadHandler = new DownloadHandler();

            this.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;


        }



        private void ChromeBrowser_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            myadress = e.Address;

        }

        private void ChromeBrowser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {


            if (e.IsLoading == false)
            {
                if (exit)
                {
                    if (myadress == "https://cav.receita.fazenda.gov.br/SimplesNacional/Aplicacoes/ATSPO/pgdasd2018.app/sair") ;
                    canexit = true;
                }
                if (!fix)
                {
                    if (counter == 0 && !logado)
                    {
                        System.Threading.Thread.Sleep(2000);
                        chromeBrowser.ExecuteScriptAsync(GetElement("caixa-login-certificado") + ".click()");
                        counter++;


                    }

                    else if (counter == 1 && !logado)
                    {
                        ClickId("btnPerfil");
                        ChangeValue("txtNIPapel2", cnpj);
                        chromeBrowser.ExecuteScriptAsync("enviaDados('formPJ')");
                        counter++;

                    }
                    if (counter == 2 && !logado)
                    {

                        ClickId("btnPerfil");
                        logado = true;
                        counter = 2;
                        completeTask = false;
                        loguei = chromeBrowser.EvaluateScriptAsync("window.location.href = 'https://cav.receita.fazenda.gov.br/ecac/Aplicacao.aspx?id=10009&origem=menu';").ContinueWith(task => completeTask = true);
                    }
                    if (loguei != null && loguei.IsCompleted) comecadas = true;
                }
                else
                {
                    completeTask = false;
                    ClickId("btnPerfil");
                    ChangeValue("txtNIPapel2", cnpj);
                    chromeBrowser.EvaluateScriptAsync("enviaDados('formPJ')").ContinueWith(task => fixstart());
                }
                if (comecadas)
                {
                    GetDas(counter, DATA, Tabela, receitas[0], receitas[1], receitas[2], receitas[3], coucomp);
                    counter++;
                }



            }
        }
        void fixstart()
        {
            c++;
            // comecadas = true;
            counter = 2;
            Console.WriteLine("AQUI");
            completeTask = true;
            fix = false;
            logado = true;
            if (c == 2)
            {
                start();
            }
        }
        async void start()
        {
            await Task.Delay(3000);
            comecadas = true;
            Console.WriteLine("esepero e vieo");
            GetDas(counter, DATA, Tabela, receitas[0], receitas[1], receitas[2], receitas[3], coucomp);

        }


        async void GetDas(int count, string data, int[] tabela, int receita1, int receita2, int receita3, int receita4, bool coucomp)
        {
            try
            {
                Console.WriteLine(myadress + "  " + counter);

                await Task.Delay(1000);

                if (count == 1)
                {
                    jr = await chromeBrowser.EvaluateScriptAsync("window.location.href = 'https://cav.receita.fazenda.gov.br/ecac/Aplicacao.aspx?id=10009&origem=menu';");

                }
                else if (count == 2)
                {
                    completeTask = false;
                    jr = await chromeBrowser.EvaluateScriptAsync("window.location.href = 'https://sinac.cav.receita.fazenda.gov.br/SimplesNacional/Aplicacoes/ATSPO/pgdasd2018.app/declaracao?clear=1'");
                }
                else if (count == 3)
                {
                    completeTask = false;
                    ChangeValue("pa", data);
                    jr = await chromeBrowser.EvaluateScriptAsync(GetElement("pa") + ".parentElement.parentElement.submit()"); ;
                    if (!jr.Success) RestartALL();
                }
                else if (count == 4)
                {

                    await chromeBrowser.EvaluateScriptAsync("if(document.getElementsByClassName('btn btn-success btn-sm sim')[0]!=null)document.getElementsByClassName('btn btn-success btn-sm sim')[0].click()").ContinueWith(task => completeTask = true);

                    await chromeBrowser.EvaluateScriptAsync("if (document.getElementsByName('rpaCaixaInt')[0]==null) window.location.href = ' https://sinac.cav.receita.fazenda.gov.br/SimplesNacional/Aplicacoes/ATSPO/pgdasd2018.app/declaracao/rpa'");

                    if (coucomp)
                    {
                        await chromeBrowser.EvaluateScriptAsync("document.getElementsByName('rpaCaixaInt')[0].value = \"" + convert(receita1 + receita2) + "\"");
                        Console.WriteLine(((float)(receita1 + receita2) / 100f).ToString().Replace(".", ","));
                        jr = await chromeBrowser.EvaluateScriptAsync("document.getElementsByName('rpaCompInt')[0].value = " + 000);
                        if (!jr.Success) RestartALL();

                    }
                    else
                    {
                        await chromeBrowser.EvaluateScriptAsync("document.getElementsByName('rpaCaixaInt')[0].value = " + 000);
                        jr = await chromeBrowser.EvaluateScriptAsync("document.getElementsByName('rpaCompInt')[0].value =\"" + convert(receita1 + receita2) + "\"");
                        if (!jr.Success) RestartALL();

                    }
                    await chromeBrowser.EvaluateScriptAsync("document.getElementsByName('rpaCompExt')[0].value = " + 000);
                    await chromeBrowser.EvaluateScriptAsync("document.getElementsByName('rpaCaixaExt')[0].value = " + 000);
                    await chromeBrowser.EvaluateScriptAsync(" document.getElementsByName('rpaCaixaInt')[0].focus()");
                    jr = await chromeBrowser.EvaluateScriptAsync(" document.getElementsByName('rpaCompInt')[0].focus()");
                    if (!jr.Success) RestartALL();
                    await chromeBrowser.EvaluateScriptAsync("$('form').submit()").ContinueWith(task => completeTask = true);

                }
                else if (count == 5 && receita1 + receita2 == 0)
                {

                    GetDas(7, DATA, Tabela, receitas[0], receitas[1], receitas[2], receitas[3], coucomp);
                    counter = 7;

                }


                else if (count == 5)
                {
                    completeTask = false;
                    jr = await chromeBrowser.EvaluateScriptAsync("for (var i =0;i<document.querySelectorAll('[data-atividade]').length;i++){if(document.querySelectorAll('[data-atividade]')[i].children[1].value!=''){document.querySelectorAll('[data-atividade]')[i].children[1].click();console.log('eee')}}");

                    if (!jr.Success) RestartALL();
                    checkActivities(tabela);
                    ClickId("btn-salvar");

                }
                else if (count == 6)
                {
                    completeTask = false;
                    if (tabela.Length == 2)
                    {

                        jr = await chromeBrowser.EvaluateScriptAsync(" document.getElementsByClassName('form-control input-sm money receita-valor')[0].value=\"" + convert(receita2) + "\"");
                        jr = await chromeBrowser.EvaluateScriptAsync(" document.getElementsByClassName('form-control input-sm money receita-valor')[1].value=\"" + convert(receita1) + "\"");
                        if (!jr.Success) RestartALL();

                    }
                    else await chromeBrowser.EvaluateScriptAsync(" document.getElementsByClassName('form-control input-sm money receita-valor')[0].value=\"" + convert(receita1 + receita2) + "\"");
                    await Task.Delay(1000);
                    jr = await chromeBrowser.EvaluateScriptAsync("document.getElementsByClassName(\"btn btn-success btn-sm btn-calcular\")[0].click()");
                    if (!jr.Success) RestartALL();

                }
                else if (count == 7)
                {
                    completeTask = false;

                    jr = await chromeBrowser.EvaluateScriptAsync("document.getElementsByClassName(\"btn btn-success btn-sm\")[0].click();");
                    if (!jr.Success) RestartALL();

                    // jr = await chromeBrowser.EvaluateScriptAsync("$('form').submit()");
                    //if (!jr.Success) RestartALL();
                    download = false;
                    await Task.Delay(4000);
                    exit = true;
                     await chromeBrowser.EvaluateScriptAsync("window.location.href = 'https://cav.receita.fazenda.gov.br/SimplesNacional/Aplicacoes/ATSPO/pgdasd2018.app/sair'");


                }
                else if (download&&( DownloadHandler.count != 2 || (DownloadHandler.count == 0 && receita1 + receita2 == 0)))
                {

                    if (DownloadHandler.count == 0)
                    {
                        jr = await chromeBrowser.EvaluateScriptAsync("if($('form')!=null)$('form').submit();");
                        if (!jr.Success) RestartALL();

                        jr = await chromeBrowser.EvaluateScriptAsync("document.getElementsByClassName('btn btn-success btn-sm')[0].target='';document.getElementsByClassName('btn btn-success btn-sm')[0].click();");
                        if (!jr.Success) RestartALL();
                        if (receita1 + receita2 == 0)
                        {
                            Console.WriteLine("fecha chefa");
                           // exit = true;
                           // await chromeBrowser.EvaluateScriptAsync("window.location.href = 'https://cav.receita.fazenda.gov.br/SimplesNacional/Aplicacoes/ATSPO/pgdasd2018.app/sair'");
                            DownloadHandler.count = 0;

                        }
                        Console.WriteLine("AQUI 1");
                    }
                    if (DownloadHandler.count == 1 && receita1 + receita2 != 0)
                    {
                        await chromeBrowser.EvaluateScriptAsync("if($('form')!=null)$('form').submit();");
                        await chromeBrowser.EvaluateScriptAsync("document.getElementsByClassName('btn btn-success btn-sm')[1].target='';document.getElementsByClassName('btn btn-success btn-sm')[1].click();");
                        jr = await chromeBrowser.EvaluateScriptAsync("$('form').submit()");
                        if (!jr.Success) RestartALL();
                        Console.WriteLine("AQUI 2");
                    }
                }
                else if (DownloadHandler.count == 2 || (DownloadHandler.count == 1 && receita1 + receita2 == 0))
                {
                    exit = true;
                    await chromeBrowser.EvaluateScriptAsync("window.location.href = 'https://cav.receita.fazenda.gov.br/SimplesNacional/Aplicacoes/ATSPO/pgdasd2018.app/sair'");
                    DownloadHandler.count = 0;
                }
                // await chromeBrowser.EvaluateScriptAsync("document.getElementsByClassName('btn btn-success btn-sm')[1].click();");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        async void RestartALL()
        {
            counter = 1;
            jr = await chromeBrowser.EvaluateScriptAsync("window.location.href = 'https://sinac.cav.receita.fazenda.gov.br/SimplesNacional/Aplicacoes/ATSPO/pgdasd2018.app/declaracao?clear=1'");

            Console.WriteLine("RESETOUUUU");

        }

        string GetElement(string s)
        {
            return "document.getElementById(\'" + s + "\')";
        }
        async void ChangeValue(string id, string value)
        {
            await chromeBrowser.EvaluateScriptAsync("document.getElementById(\'" + id + "\').value=\'" + value + "\'; ");

        }
        async void ClickId(string id)
        {
            await chromeBrowser.EvaluateScriptAsync("document.getElementById(\'" + id + "\').click()").ContinueWith(task => completeTask = true);

        }
        void checkActivities(int[] values)
        {


            foreach (int i in values)
            {
                chromeBrowser.EvaluateScriptAsync("if(document.querySelectorAll('[data-atividade]')[" + i + "].children[1].value=='')document.querySelectorAll('[data-atividade]')[" + i + "].click()");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!exit)
            {
                exit = true;
                chromeBrowser.EvaluateScriptAsync("window.location.href = 'https://cav.receita.fazenda.gov.br/SimplesNacional/Aplicacoes/ATSPO/pgdasd2018.app/sair'");
                e.Cancel = exit;
            }

            // Cef.ShutdownWithoutChecks();  
            // if (Directory.Exists(Server.cachepath)) clearFolder(Server.cachepath);

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

        private void DASpicker_FormClosed(object sender, FormClosedEventArgs e)
        {
            //  if (Cef.IsInitialized) Cef.Shutdown();
        }
        string convert(float num)
        {
            return ((float)(num) / 100f).ToString().Replace(".", ",");
        }
    }

    public class DownloadHandler : IDownloadHandler
    {
        public event EventHandler<DownloadItem> OnBeforeDownloadFired;

        public event EventHandler<DownloadItem> OnDownloadUpdatedFired;
        public static int count = 0;
        string file1, file2;
        public void OnBeforeDownload(IBrowser browser, DownloadItem downloadItem, IBeforeDownloadCallback callback)
        {
            var handler = OnBeforeDownloadFired;

            if (handler != null)
            {
                handler(this, downloadItem);
            }

            if (!callback.IsDisposed)
            {
                using (callback)
                {
                    if (count == 0) {
                        file1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"das\" + Server.ds.cnpj + @"\" + Server.ds.DATA + @"\recibo.pdf");
                        callback.Continue(file1, showDialog: false);
                        Console.WriteLine("comeceu " + file1);

                    } else
                    {
                        file2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"das\" + Server.ds.cnpj + @"\" + Server.ds.DATA + @"\DAS.pdf");
                        callback.Continue(file2, showDialog: false);
                        Console.WriteLine("comeceu " + file2);
                        Console.WriteLine("cont " + count);
                    }
                }

            }
        }

        public void OnDownloadUpdated(IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback)
        {
            var handler = OnDownloadUpdatedFired;
            if (handler != null)
            {
                handler(this, downloadItem);
            }
            if (downloadItem.IsComplete)
            {
                Console.WriteLine("BAIXOU");
                if (count == 0) count = 1;
                else if (count == 1)
                {
                    if (File.Exists(file1) && File.Exists(file2))
                    {
                        if (FileEquals(file1, file2))
                            count = 2;
                    }
                }
            }
        }




        static bool FileEquals(string path1, string path2)
        {
            byte[] file1 = File.ReadAllBytes(path1);
            byte[] file2 = File.ReadAllBytes(path2);
            if (file1.Length == file2.Length)
            {
                for (int i = 0; i < file1.Length; i++)
                {
                    if (file1[i] != file2[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;

        }
    }
}

    
