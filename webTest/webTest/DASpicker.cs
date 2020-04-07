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
using System.Net;

namespace webTest
{

    public partial class DASpicker : Form
    {
        ChromiumWebBrowser chromeBrowser;
        public int counter = 0;
        bool logado = false;
        public string cnpj;
        string myadress;
        public bool comecadas;
        bool completeTask = false;
        Task loguei;
        Task Completetask;
        float[] receitas;
        public string DATA;
        int[] Tabela;
        bool fix;
        int c = 0;
        bool exit;
        public static bool canexit;
        bool coucomp;
        JavascriptResponse jr;
        bool download = false;
        int tempcounter = 0;
        public int dcount = 0;
        System.Windows.Forms.Timer t;
        public bool stcount;
        public bool one,tsair,stdown,sucess;
        int errorCounts = 0;
        public DASpicker(string cnpjj, string data, int[] tab, float[] recs, bool initialized, bool c2)
        {
            int counter = 0;
            logado = false;
            cnpj = "";
            myadress = "";
            comecadas = new bool();
            completeTask = false;
            receitas = new float[0] { };
            DATA = "";
            Tabela = new int[0] { };
            fix = new bool();
            c = 0;
            exit = new bool();
            canexit = new bool();
            coucomp = new bool();
            download = false;
            tempcounter = 0;
            tsair = false;
            //COMEÇA AQUI ANTES É PARA RESET
            fix = initialized;
            cnpj = cnpjj.Trim();
            DATA = data;
            Tabela = tab;
            receitas = recs;
            InitializeComponent();
            InitializeChromium();
            logado = false;
            comecadas = false;
            completeTask = false;
            exit = false;
            coucomp = c2;
            DownloadHandler.count = 0;
            download = true;
            counter = 0;
            tempcounter = counter + 1;
            c = 0;
            t = new System.Windows.Forms.Timer();
            t.Tick += T_Tick;
            errorCounts = 0;
            t.Interval = 10000;
           t.Enabled = true;
            dcount = 0;
            stcount = false;
            one = false;
            stdown = false;
        }

        private void T_Tick(object sender, EventArgs e)
        {
            if (counter >= 2)
            {
                if (counter != tempcounter) tempcounter = counter;
                else
                {
                    errorCounts++;
                    RestartALL();
                    Console.WriteLine("Pelo contador");
                   if (errorCounts==120)
                    {
                        erroclose();
                    }
                }
            }
        }

        public void InitializeChromium()
        {


            Completetask = new Task(() => { completeTask = true; });

            chromeBrowser = new ChromiumWebBrowser("https://cav.receita.fazenda.gov.br/autenticacao");
            chromeBrowser.AddressChanged += ChromeBrowser_AddressChanged;
            chromeBrowser.DownloadHandler = new DownloadHandler();
            chromeBrowser.IsBrowserInitializedChanged += ChromeBrowser_IsBrowserInitializedChanged;  
            this.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;


        }

        private void ChromeBrowser_IsBrowserInitializedChanged(object sender, IsBrowserInitializedChangedEventArgs e)
        {
           if (e.IsBrowserInitialized) chromeBrowser.LoadingStateChanged += ChromeBrowser_LoadingStateChanged;

        }

        private void ChromeBrowser_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            myadress = e.Address;

        }

        private async void ChromeBrowser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (chromeBrowser != null)
            {
                try
                {

                    if (e.IsLoading == false)
                    {
                        if (exit&&!tsair)
                        {
                            if (!canexit)
                            {
                                if (myadress == "https://cav.receita.fazenda.gov.br/SimplesNacional/Aplicacoes/ATSPO/pgdasd2018.app/sair")
                                {
                                    t.Stop();
                                    t = null;
                                    canexit = true;

                                }
                                else
                                {
                                    tsair = true;
                                    jr = await chromeBrowser.EvaluateScriptAsync("window.location.href = 'https://cav.receita.fazenda.gov.br/SimplesNacional/Aplicacoes/ATSPO/pgdasd2018.app/sair'");
                                    if (jr.Success)
                                    {
                                        if (t != null && chromeBrowser != null)
                                        {
                                            t.Stop();
                                            tsair = true;

                                            t = null;
                                            chromeBrowser.Stop();
                                            chromeBrowser = null;
                                            exit = false;
                                            if (sucess)
                                            {
                                                Server.Restart();
                                            }
                                        }
                                        canexit = true;

                                    }
                                }
                                tsair = true;

                                Console.WriteLine("tentou sair");
                                
                            }
                        }
                        else
                        {
                            if (!fix)
                            {
                                if (counter == 0 && !logado)
                                {
                                    Console.Write("começa aui /r/n");
                                    // chromeBrowser.ExecuteScriptAsync(GetElement("caixa-login-certificado") + ".click()");
                                    ClickId("caixa-login-certificado");
                                    counter++;


                                }

                                else if (counter == 1 && !logado)
                                {
                                    jr = await chromeBrowser.EvaluateScriptAsync("document.getElementById('btnPerfil').click()");

                                    if (cnpj == "27124625000111")
                                    {
                                        Console.WriteLine("tentou" + cnpj);
                                        jr = await chromeBrowser.EvaluateScriptAsync("document.getElementById('txtNIPapel').value=\'" + cnpj + "\'; ");
                                        await Task.Delay(2000);
                                        jr = await chromeBrowser.EvaluateScriptAsync("enviaDados('formRespLegal')");
                                        if (jr.Success)
                                        {
                                            Console.WriteLine("loguei");
                                            logado = true;
                                            counter = 2;
                                            completeTask = false;
                                            loguei = chromeBrowser.EvaluateScriptAsync("window.location.href = 'https://cav.receita.fazenda.gov.br/ecac/Aplicacao.aspx?id=10009&origem=menu';").ContinueWith(task => completeTask = true);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("tentou" + cnpj);
                                        jr = await chromeBrowser.EvaluateScriptAsync("document.getElementById('txtNIPapel2').value=\'" + cnpj + "\'; ");
                                        await Task.Delay(2000);
                                        jr = await chromeBrowser.EvaluateScriptAsync("enviaDados('formPJ')");

                                    }

                                    Console.WriteLine("aqui1");
                                    counter++;

                                }
                                if (counter == 2 && !logado)
                                {

                                    jr = await chromeBrowser.EvaluateScriptAsync("document.getElementById('btnPerfil').click()");
                                    if (cnpj == "27124625000111")
                                    {
                                        Console.WriteLine("tentou segundo " + cnpj);
                                        jr = await chromeBrowser.EvaluateScriptAsync("document.getElementById('txtNIPapel').value=\'" + cnpj + "\'; ");
                                        await Task.Delay(2000);
                                        jr = await chromeBrowser.EvaluateScriptAsync("enviaDados('formRespLegal')");

                                    }
                                    else
                                    {
                                        Console.WriteLine("tentou" + cnpj);
                                        jr = await chromeBrowser.EvaluateScriptAsync("document.getElementById('txtNIPapel2').value=\'" + cnpj + "\'; ");
                                        await Task.Delay(2000);
                                        jr = await chromeBrowser.EvaluateScriptAsync("enviaDados('formPJ')");

                                    }

                                    Console.WriteLine("aqui2");
                                    if (jr.Success)
                                    {
                                        Console.WriteLine("loguei");
                                        logado = true;
                                        counter = 2;
                                        completeTask = false;
                                        loguei = chromeBrowser.EvaluateScriptAsync("window.location.href = 'https://cav.receita.fazenda.gov.br/ecac/Aplicacao.aspx?id=10009&origem=menu';").ContinueWith(task => completeTask = true);
                                    }
                                }
                                if (loguei != null && loguei.IsCompleted)
                                {
                                    comecadas = true;
                                }
                            }
                            else
                            {
                                jr = await chromeBrowser.EvaluateScriptAsync("document.getElementById('btnPerfil').click()");
                                if (cnpj == "27124625000111")
                                {
                                    Console.WriteLine("tentou segundo " + cnpj);
                                    jr = await chromeBrowser.EvaluateScriptAsync("document.getElementById('txtNIPapel').value=\'" + cnpj + "\'; ");
                                    await Task.Delay(2000);
                                    jr = await chromeBrowser.EvaluateScriptAsync("enviaDados('formRespLegal');");

                                }
                                else
                                {
                                    Console.WriteLine("tentou " + cnpj);
                                    jr = await chromeBrowser.EvaluateScriptAsync("document.getElementById('txtNIPapel2').value=\'" + cnpj + "\'; ");
                                    await Task.Delay(2000);
                                    jr = await chromeBrowser.EvaluateScriptAsync("enviaDados('formPJ')");

                                }

                                if (jr.Success) fixstart();
                            }
                            if (comecadas)
                            {
                                GetDas(counter, DATA, Tabela, receitas[0], receitas[1], receitas[2], receitas[3], coucomp);
                                counter++;
                            }
                        }
                    }


                }
                catch (Exception x)
                {
                    /// System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application
                    ///Application.Exit(); //to turn off current app
                   // Console.WriteLine(x.ToString());

                }
            }
        }
               void fixstart()
        {
            c=2;
            // comecadas = true;
            counter = 2;
            Console.WriteLine("AQUI");
            fix = false;
            logado = true;
            if (c == 2||c==1)
            {
                start();
            }
        }
        async void start()
        {
            comecadas = true;
            GetDas(counter, DATA, Tabela, receitas[0], receitas[1], receitas[2], receitas[3], coucomp);

        }


        async void GetDas(int count, string data, int[] tabela, float receita1, float receita2, float receita3, float receita4, bool coucomp)
        {
            try
            {
                if (comecadas && chromeBrowser != null)
                {
                    stcount = true;
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
                        JavascriptResponse jt = await chromeBrowser.EvaluateScriptAsync("$('td[style*=" + "\"padding: 2px\"" + "]')[0].innerHTML");
                        if (jt.Success)
                        {
                            string ncnpj = jt.Result.ToString();
                            ncnpj = ncnpj.Replace(".", "").Replace("-", "").Replace("/", "");
                            Console.WriteLine("compare " + ncnpj + "  " + cnpj + "  " + ncnpj == cnpj);
                            if (ncnpj != cnpj) erroclose();
                        }
                        else RestartALL();
                        completeTask = false;
                        ChangeValue("pa", data);
                        jr = await chromeBrowser.EvaluateScriptAsync(GetElement("pa") + ".parentElement.parentElement.submit()"); ;
                        if (!jr.Success) RestartALL();
                    }
                    else if (count == 4)
                    {
                        JavascriptResponse jt = await chromeBrowser.EvaluateScriptAsync("$('td[style*=" + "\"padding: 2px\"" + "]')[0].innerHTML");
                        if (jt.Success)
                        {
                            string ncnpj = jt.Result.ToString();
                            ncnpj = ncnpj.Replace(".", "").Replace("-", "").Replace("/", "");
                            Console.WriteLine("compare " + ncnpj + "  " + cnpj + "  " + ncnpj == cnpj);
                            if (ncnpj != cnpj) erroclose();
                        }
                        else RestartALL();
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
                        count = 7;
                        Console.WriteLine("Pulou");

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
                        if (receita1 + receita2 != 0)
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
                        else
                        {
                            jr = await chromeBrowser.EvaluateScriptAsync("$('form').submit()");
                            if (!jr.Success) RestartALL();
                        }
                    }
                    else if (count == 7)
                    {
                        completeTask = false;

                        jr = await chromeBrowser.EvaluateScriptAsync("document.getElementsByClassName(\"btn btn-success btn-sm\")[0].click();");
                        if (!jr.Success) RestartALL();

                        jr = await chromeBrowser.EvaluateScriptAsync("$('form').submit()");
                        if (!jr.Success) RestartALL();
                        await Task.Delay(4000);
                        download = true;
                        //  exit = true;
                        // await chromeBrowser.EvaluateScriptAsync("window.location.href = 'https://cav.receita.fazenda.gov.br/SimplesNacional/Aplicacoes/ATSPO/pgdasd2018.app/sair'");


                    }
                    else if (download)
                    {
                        if (count == 8)
                        {
                            if (receita1 + receita2 != 0)
                            {
                                jr = await chromeBrowser.EvaluateScriptAsync("document.getElementsByClassName('btn btn-success btn-sm')[1].click()"); ;
                                Console.WriteLine("aQUII");
                            }
                            else
                            {
                                jr = await chromeBrowser.EvaluateScriptAsync("document.getElementsByClassName('btn btn-success btn-sm')[0].target=''");

                                jr = await chromeBrowser.EvaluateScriptAsync("document.getElementsByClassName('btn btn-success btn-sm')[0].click()"); ;
                                Console.WriteLine("AQUI RENDA 0");
                            }

                        }
                        else if (count == 9&&!stdown)
                        {
                            if (receita1 + receita2 != 0)
                            {
                                //jr = await chromeBrowser.EvaluateScriptAsync(" $('form').submit()"); ;
                                jr = await chromeBrowser.EvaluateScriptAsync("document.getElementsByClassName('btn btn-success btn-sm')[1].click()"); ;

                                if (!jr.Success) RestartALL();
                            }
                            else
                            {
                                jr = await chromeBrowser.EvaluateScriptAsync("document.getElementsByClassName('btn btn-success btn-sm')[0].target=''");

                                jr = await chromeBrowser.EvaluateScriptAsync("document.getElementsByClassName('btn btn-success btn-sm')[0].click()"); ;
                                Console.WriteLine("AQUI RENDA 0 2 ");
                            }

                        }
                        else if (count == 10)
                        {
                            if (comecadas&&!stdown)
                            {
                                if (myadress == "https://sinac.cav.receita.fazenda.gov.br/SimplesNacional/Aplicacoes/ATSPO/pgdasd2018.app/Declaracao/Transmitir" && !one)
                                {
                                    if (receita1 + receita2 != 0)
                                    {
                                        counter = 9;
                                        GetDas(counter, DATA, Tabela, receitas[0], receitas[1], receitas[2], receitas[3], coucomp);
                                        Console.WriteLine("Apertadnv");counter++;
                                        
                                    }
                                    else
                                    {
                                        counter = 9;
                                        GetDas(counter, DATA, Tabela, receitas[0], receitas[1], receitas[2], receitas[3], coucomp);
                                        Console.WriteLine("Apertadnv");
                                    }
                                    //  one = true;
                                }
                                else
                                {
                                    jr = await chromeBrowser.EvaluateScriptAsync("$('form').submit()"); ;
                                    if (!jr.Success) RestartALL();
                                }
                            }
                        }
                        else if (count >= 11 && comecadas&&!stdown)
                        {
                            if (myadress == "https://sinac.cav.receita.fazenda.gov.br/SimplesNacional/Aplicacoes/ATSPO/pgdasd2018.app/Declaracao/Transmitir" && !one)
                            {
                                if (receita1 + receita2 != 0)
                                {
                                    counter = 10;
                                    GetDas(counter, DATA, Tabela, receitas[0], receitas[1], receitas[2], receitas[3], coucomp);
                                    Console.WriteLine("Apertadnv");
                                }
                                else
                                {
                                    counter = 9;
                                    GetDas(counter, DATA, Tabela, receitas[0], receitas[1], receitas[2], receitas[3], coucomp);
                                    Console.WriteLine("Apertadnv");
                                }
                            }
                        }
                    }
                }
            }

            catch (Exception e)
            {
                ///  System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application
                /// Application.Exit(); //to turn off current app
                //Console.WriteLine(e.ToString());
            }
            
        }

        async void RestartALL()
        {
            if (Server.ds != null&&chromeBrowser!=null)
            {
                counter = 1;
               if(chromeBrowser!=null) jr = await chromeBrowser.EvaluateScriptAsync("window.location.href = 'https://sinac.cav.receita.fazenda.gov.br/SimplesNacional/Aplicacoes/ATSPO/pgdasd2018.app/declaracao?clear=1'");
                one = false;
                Console.WriteLine("RESETOUUUU");
                if (chromeBrowser != null) chromeBrowser.Stop();


            }
        }
        public void  erroclose()
        {
            if (chromeBrowser != null)
            {
                comecadas = false;
                counter = 99;
                Server.errors++;

                /* using (WebClient webclient = new WebClient())
                   {
                       webclient.Encoding = Encoding.UTF8;
                       var parametres = new System.Collections.Specialized.NameValueCollection();
                       parametres.Add("servID", "356");
                       parametres.Add("cnpj", cnpj);
                       parametres.Add("mes", int.Parse(DATA.Split('/')[0]) + "");
                       string tbs = Encoding.UTF8.GetString(webclient.UploadValues(Server.serversite + "/Site/login.php", parametres));
                       Console.WriteLine("Resultado do erro : " + tbs);
                   }*/
                StreamReader sr = new StreamReader("requests.txt");
                string query = sr.ReadToEnd();
                sr.Close();
                string[] rqs = query.Split('|');
                string rq1 = "";
                if (rqs[0].Split('?').Length > 0)
                {
                    if (int.Parse(rqs[0].Split('?')[rqs[0].Split('?').Length - 1]) < 4)
                    {
                        for (int i = 0; i < rqs[0].Split('?').Length - 1; i++)
                        {
                            rq1 += rqs[0].Split('?')[i] + "?";
                        }
                        rq1 += (int.Parse(rqs[0].Split('?')[rqs[0].Split('?').Length - 1]) + 1).ToString() + "|";
                        string fstring = rq1;
                        Console.WriteLine("RQ1 " + rq1);
                        for (int j = 1; j < rqs.Length; j++)
                        {
                            if (!string.IsNullOrEmpty(rqs[j]))
                            {
                                fstring += rqs[j];
                                fstring += "|";
                            }
                        }
                       
                        if (File.Exists("requests.txt")) File.Delete("requests.txt");
                        Console.WriteLine("ESCREVE " + fstring);
                        StreamWriter sw = new StreamWriter(new FileStream("requests.txt", FileMode.OpenOrCreate), UTF8Encoding.UTF8);
                        sw.Write(fstring);
                        sw.Close();
                    }
                    else
                    {
                        using (WebClient webclient = new WebClient())
                        {
                            webclient.Encoding = Encoding.UTF8;
                            var parametres = new System.Collections.Specialized.NameValueCollection();
                            parametres.Add("servID", "356");
                            parametres.Add("cnpj", cnpj);
                            parametres.Add("mes", int.Parse(DATA.Split('/')[0]) + "");
                            string tempfile  = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"das\" + Server.ds.cnpj + @"\" + Server.ds.DATA.Split('/')[0] + @"\temp.pdf");
                            if (File.Exists(tempfile))
                            {
                                parametres.Add("tempfile", tempfile);
                            }

                            string tbs = Encoding.UTF8.GetString(webclient.UploadValues(Server.serversite + "/Site/login.php", parametres));
                            Console.WriteLine("Resultado do erro : " + tbs);
                        }
                        StreamReader sr1 = new StreamReader("requests.txt");
                        string query1 = sr1.ReadToEnd();
                        sr1.Close();
                        string[] rqs1 = query1.Split('|');
                        if (File.Exists("requests.txt")) File.Delete("requests.txt");
                        if (!string.IsNullOrEmpty(rqs1[1]))
                        {
                            string temp = "";
                            for (int i = 1; i < rqs1.Length; i++)
                                temp += rqs1[i] + "|";
                            StreamWriter sw = new StreamWriter(new FileStream("requests.txt", FileMode.OpenOrCreate), UTF8Encoding.UTF8);
                            sw.Write(temp);
                            sw.Close();
                        }

                    }

                }

                exit = true;
                chromeBrowser.EvaluateScriptAsync("window.location.href = 'https://cav.receita.fazenda.gov.br/SimplesNacional/Aplicacoes/ATSPO/pgdasd2018.app/sair'");
            }
        }

        string GetElement(string s)
        {
            return "document.getElementById(\'" + s + "\')";
        }
        async void ChangeValue(string id, string value)
        {
            if (chromeBrowser!=null)
           await chromeBrowser.EvaluateScriptAsync("document.getElementById(\'" + id + "\').value=\'" + value + "\'; ");

        }
        async void ClickId(string id)
        {
            if (chromeBrowser != null)
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
            if (!exit&&!tsair)
            {
                exit = true;
                chromeBrowser.EvaluateScriptAsync("window.location.href = 'https://cav.receita.fazenda.gov.br/SimplesNacional/Aplicacoes/ATSPO/pgdasd2018.app/sair'");
                e.Cancel = tsair;
               // t.Stop(); 
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
        public async void sucessExit(string file1)
        {
            comecadas = false;

            counter = 99;
            string fileplace = @"C:\xampp\htdocs\Site\das\" + cnpj + @"\" + DATA.Split('/')[0];
            if (!Directory.Exists(fileplace)) Directory.CreateDirectory(fileplace);

            File.Copy(file1, fileplace + @"\boleto.pdf", true);
            string boletopath = "/Site/das/" + cnpj + "/" + DATA.Split('/')[0] + "/boleto.pdf";

            using (WebClient webclient = new WebClient())
            {
                webclient.Encoding = Encoding.UTF8;
                var parametres = new System.Collections.Specialized.NameValueCollection();
                parametres.Add("servID", "230");
                parametres.Add("cnpj", cnpj);
                parametres.Add("mes", int.Parse(DATA.Split('/')[0]) + "");
                parametres.Add("boleto", boletopath);
                string tbs = Encoding.UTF8.GetString(webclient.UploadValues(Server.serversite + "/Site/login.php", parametres));
                Console.WriteLine("Resultado do sucess : " + tbs);
                parametres = new System.Collections.Specialized.NameValueCollection();
                parametres.Add("servID", "20");
                parametres.Add("cnpj", cnpj);
                parametres.Add("mes", int.Parse(DATA.Split('/')[0]) + "");
                tbs = Encoding.UTF8.GetString(webclient.UploadValues(Server.serversite + "/Site/email.php", parametres));
                Console.WriteLine("Resultado do email : " + tbs);

            }
            StreamReader sr = new StreamReader("requests.txt");
            string query = sr.ReadToEnd();
            sr.Close();
            string[] rqs = query.Split('|');
            if(File.Exists("requests.txt")) File.Delete("requests.txt");
            if ( !string.IsNullOrEmpty(rqs[1])) {
                string temp="";
                for (int i = 1; i < rqs.Length; i++)
                    temp += rqs[i] +"|";
                StreamWriter sw = new StreamWriter(new FileStream("requests.txt", FileMode.OpenOrCreate), UTF8Encoding.UTF8);
                sw.Write(temp);
                sw.Close();
            }
           exit = true;
           JavascriptResponse jr= await chromeBrowser.EvaluateScriptAsync("window.location.href = 'https://cav.receita.fazenda.gov.br/SimplesNacional/Aplicacoes/ATSPO/pgdasd2018.app/sair'");
            Console.WriteLine(jr.Result.ToString());
            sucess = true;
        }

        private void DASpicker_FormClosed(object sender, FormClosedEventArgs e)
        {
            //  if (Cef.IsInitialized) Cef.Shutdown();
        }
        string convert(float num)
        {
            string s = num.ToString();

            if (s.Length >= 3) return s.Substring(0, s.Length - 2) + "," + s.Substring(s.Length - 2);
            else return "0," + s;
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
            OnBeforeDownloadFired?.Invoke(this, downloadItem);
            Server.ds.stdown = true;
            if (!callback.IsDisposed)
            {
                using (callback)
                {
                    file1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"das\" + Server.ds.cnpj + @"\" + Server.ds.DATA.Split('/')[0] + @"\boleto.pdf");
                    if (File.Exists(file1))
                    {
                        if (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"das\" + Server.ds.cnpj + @"\" + Server.ds.DATA.Split('/')[0] + @"\temp.pdf"))) File.Delete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"das\" + Server.ds.cnpj + @"\" + Server.ds.DATA.Split('/')[0] + @"\temp.pdf"));
                        File.Move(file1, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"das\" + Server.ds.cnpj + @"\" + Server.ds.DATA.Split('/')[0] + @"\temp.pdf"));
                       // File.Delete(file1);

                    }
                    callback.Continue(file1, showDialog: false);
                    Console.WriteLine("comeceu " + file1);
                    Server.ds.comecadas = false;

                }

            }
        }

        public void OnDownloadUpdated(IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback)
        {
            OnBeforeDownloadFired?.Invoke(this, downloadItem);
            Server.ds.stdown = true;

            if (downloadItem.IsInProgress)
            {

                Console.WriteLine("baixando a" + downloadItem.CurrentSpeed);
                Server.ds.comecadas = false;
            }
            
            if (downloadItem.IsComplete)
            {
                Console.WriteLine("baixo");
                Server.ds.sucessExit(file1);
              /*  Server.ds.dcount++;
                Console.WriteLine("BAIXOU");
                if (count == 0) count = 1;
                else if (count == 1)
                {
                    if (File.Exists(file1) && File.Exists(file2))
                    {
                        if (!FileEquals(file1, file2))
                            count = 2;
                    }
                }*/

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

    
