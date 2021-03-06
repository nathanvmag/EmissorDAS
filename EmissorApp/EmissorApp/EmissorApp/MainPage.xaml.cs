﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Net;
using System.Net.Security;
using Rg.Plugins.Popup.Services;

namespace EmissorApp
{
    public partial class MainPage : ContentPage
    {
        StackLayout currentLayout;


        const string localsite = "https://moveonline.com.br/site/";
        public float d;
         public  MainPage()
        {
            InitializeComponent();
            InitiateSSLTrust();
            currentLayout = new StackLayout();
            currentLayout.HorizontalOptions = LayoutOptions.FillAndExpand;
            this.Content = currentLayout;
            // SplashLayout();
             this.Padding = new Thickness(0, Device.RuntimePlatform == Device.iOS ? 20 : 0, 0, 5);
            splashscreen();

            // MPage();/
           // checklogin();
            }
        async void splashscreen()
        {
            Image a = new Image() { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand, Source = ImageSource.FromFile("splash.jpg"), Aspect = Aspect.AspectFit };
                      
            this.Content = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children ={
                   a
                }
            };
            await Task.Delay(5000); 
             d = (int)DependencyService.Get<INatives>().density();
            checklogin();
            
        }
        async void tutorialimage(string name )
        {
            Image a = new Image() { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand, Source = ImageSource.FromFile("movetutorial.jpeg"), Aspect = Aspect.AspectFit };

            this.Content = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children ={
                   a
                }
            };
            await Task.Delay(7000);
            MPage(name);

        }
        async void checklogin()
            {
            if (Application.Current.Properties.ContainsKey("cnpj") && Application.Current.Properties.ContainsKey("pass"))
            {
                try
                {
                    string user = Application.Current.Properties["cnpj"].ToString();
                    string pass= Application.Current.Properties["pass"].ToString();
                    string data = await DependencyService.Get<INatives>().Login(localsite + "login.php", user, pass);
                    if (data.Substring(0, 1) == "N")
                    {
                        alert("Email ou senha foram alterados, por favor entre novamente");
                        Application.Current.Properties.Remove("cnpj");
                        Application.Current.Properties.Remove("pass");
                        SplashLayout();
                    }
                    else if (data == "Nready")
                    {
                        alert("Você digitou a senha correta, porém não está apto a acessar a plataforma de emissão do DAS neste momento, Fale com seu contador");
                        SplashLayout();

                    }
                    else if (data.Length > 9 && data.Substring(0, 10) == "changepass")
                    {
                        MPage(data.Split('|')[1]);
                        Application.Current.Properties["cnpj"] = data.Split('|')[2];
                        Application.Current.Properties["pass"] = pass;
                    }
                    else if (data.Substring(0, 1) == "S")
                    {
                        MPage(data.Split('|')[1]);
                        Application.Current.Properties["cnpj"] = data.Split('|')[2];
                        Application.Current.Properties["pass"] = pass;
                    }
                    else {
                        alert("Erro no sistema "+ data);
                        SplashLayout();
                    }
                }
                catch (Exception e)
                {
                    alert("Error + " + e.ToString());
                }
            }
            else { SplashLayout(); }
            }
        public async void SplashLayout(string usert ="")
        {
            //var result = await Plugin.DialogKit.CrossDiaglogKit.Current.GetInputTextAsync("New Title", "Type something:");
            StackLayout splash = new StackLayout();
            splash.HorizontalOptions = LayoutOptions.FillAndExpand;
           
            Label lb = new Label() { Text = "Move Online", HorizontalTextAlignment = TextAlignment.Center, HorizontalOptions = LayoutOptions.FillAndExpand
            };
            lb.FontSize *= d* (Device.RuntimePlatform==Device.iOS?1.5f:1f)* 1.5f;
            lb.BackgroundColor = Color.FromHex("51a279");
            lb.TextColor = Color.White;
            splash.Children.Add(lb);
            splash.Children.Add(new Label() { Text = "Digite suas credenciais para entrar no aplicativo, caso não possua consulte o seu consultor.", HorizontalOptions = LayoutOptions.Center, HorizontalTextAlignment = TextAlignment.Center, FontSize = lb.FontSize * (Device.RuntimePlatform==Device.iOS?0.4f: 0.5f) });
            for (int i = 0; i < 2; i++)
            {
                splash.Children.Add(new Label() { Text = "" });
            }
            Entry user = new Entry() { Margin = new Thickness(20, 0, 20, 0), HorizontalOptions = LayoutOptions.Fill, HorizontalTextAlignment = TextAlignment.Start, Placeholder = "CNPJ ou EMAIL" };
            user.FontSize *= d* (Device.RuntimePlatform==Device.iOS?1.8f:1f)* 0.7f;
            user.Text = string.IsNullOrWhiteSpace(usert) ? "" : usert;
            splash.Children.Add(user);
            Entry pass = new Entry() { Margin = new Thickness(20, 0, 20, 0), HorizontalOptions = LayoutOptions.Fill, HorizontalTextAlignment = TextAlignment.Start, Placeholder = "Senha", IsPassword = true };
            pass.FontSize *= d* (Device.RuntimePlatform==Device.iOS?1.8f:1f)* 0.7f;
            splash.Children.Add(pass);
            for (int i = 0; i < 1; i++)
            {
                splash.Children.Add(new Label() { Text = "" });
            }
            Button bt = new Button()
            {
                Text = "Entrar",
                HorizontalOptions =Device.RuntimePlatform==Device.iOS?LayoutOptions.FillAndExpand: LayoutOptions.Center,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex("51a279"),               
                Margin = new Thickness(40, 0, 40, 0),

            };
            bt.FontSize *= d* (Device.RuntimePlatform==Device.iOS?1.5f:1f)* 0.7f;
            splash.Children.Add(bt);


            bt.Clicked += async delegate
            { if (!string.IsNullOrEmpty(pass.Text) && !string.IsNullOrEmpty(user.Text))
                {
                    splash = new StackLayout();
                    splash.Margin = 0;
                    splash.Padding = 0;
                    splash.HorizontalOptions = LayoutOptions.FillAndExpand;
                    lb.Text = "Entrando";
                    splash.Children.Add(lb);
                    Label lb2 = new Label()
                    {
                        Text = "Aguarde por favor",
                        HorizontalTextAlignment = TextAlignment.Center,
                        HorizontalOptions = LayoutOptions.FillAndExpand
                    };
                    lb2.FontSize *= d* (Device.RuntimePlatform==Device.iOS?1.5f:1f)* 1.0f;

                    lb2.TextColor = Color.FromHex("51a279");
                    splash.Children.Add(lb2);
                    ActivityIndicator loading = new ActivityIndicator()
                    {
                        HorizontalOptions = LayoutOptions.Center,
                        Color = Color.FromHex("51a279"),
                        IsRunning = true
                    };
                    splash.Children.Add(loading);
                    this.Content = splash;
                    await Task.Delay(1000);
                    try
                    {
                        string data = await DependencyService.Get<INatives>().Login(localsite + "login.php", user.Text, pass.Text);
                        splash.Children.Remove(loading);
                        if (data.Substring(0,1) == "N")
                        {
                            alert("Email ou senha incorretos");
                            SplashLayout(user.Text);
                        }
                        else if (data.Substring(0,6) == "Nready")
                        {
                            alert("Você digitou a senha correta, porém não está apto a acessar a plataforma de emissão do DAS neste momento, Fale com seu contador");
                                                       
                            SplashLayout();

                        }
                        else if (data.Length > 9 && data.Substring(0, 10) == "changepass")
                        {
                            showtutorial(data.Split('|')[1]);
                            Application.Current.Properties["cnpj"] = data.Split('|')[2];
                            Application.Current.Properties["pass"] = pass.Text;
                        }
                        else if (data.Substring(0, 1) == "S")
                        {
                            showtutorial(data.Split('|')[1]);
                            Application.Current.Properties["cnpj"] = data.Split('|')[2];
                            Application.Current.Properties["pass"] = pass.Text;
                        }
                          else {
                            alert("Erro no sistema");
                            SplashLayout(user.Text) ;
                        }
                    }
                    catch (Exception e)
                    {
                        alert("Error + "+ localsite+" "+ e.ToString());
                    }
                }
                else alert("Preencha todos os campos");
            };
            Label esq = new Label() { Text = "Esqueceu sua senha ?", FontSize = lb.FontSize * 0.4f, TextColor = Color.FromHex("51a279"), HorizontalTextAlignment = TextAlignment.Center, HorizontalOptions = LayoutOptions.Center };
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += delegate
            {
                EsqueceuSenha();
            };
            esq.GestureRecognizers.Add(tap);
            splash.Children.Add(esq);
            this.Content = splash;
        }
        void showtutorial(string name)
        {
            /*
            StackLayout splash = new StackLayout();
            splash.HorizontalOptions = LayoutOptions.FillAndExpand;

            Label lb = new Label()
            {
                Text = "Aprenda a usar",
                HorizontalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            lb.FontSize *= d * (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 1.5f;
            lb.BackgroundColor = Color.FromHex("51a279");
            lb.TextColor = Color.White;
            splash.Children.Add(lb);
            string[] tutos = new string[6] { "Impostos:" + "\n" + " Receba seus impostos em poucos minutos com apenas um click.", "Download de Impostos:" + "\n" + " Consulte seus impostos quando e onde quiser com apenas um click.", "Alertas Para Aviso e lembretes:" + "\n" + " Não esqueça mais de pagar seus impostos, nós lembramos você.", "Atualização de Status e Controle de Impostos:" + "\n" + " Tenha o controle de seus impostos na palma de suas mãos, tudo com apenas um click.", "Calculo de Impostos atrasados:" + "\n" + " Não Perca mais tempo enviando e-mails e ligando para seu contador, no Move online basta apenas um click você recebe seu imposto direto no seu celular e e-mail em questão de minutos.", "Solicitação de Chamados:" + "\n" + " Basta apenas um click pra sabermos o que você precisa." };
            Label ttx=new Label() { Text = tutos[0], HorizontalOptions = LayoutOptions.Center, HorizontalTextAlignment = TextAlignment.Center };
            int comand = 0;
            ttx.FontSize*= d * (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 0.8f;
            splash.Children.Add(ttx);
            for (int i = 0; i < 5; i++)
            {
                splash.Children.Add(new Label() { Text = "" });
            }
            Button bt2 = new Button()
            {
                Text = "Próximo",
                BackgroundColor = Color.FromHex("51a279"),
                HorizontalOptions = LayoutOptions.FillAndExpand
                 , VerticalOptions = LayoutOptions.End,
                TextColor = Color.White,
                Margin = new Thickness(20, 0, 20, 0)
            };

            bt2.FontSize *= d * (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 0.8f;
            bt2.Clicked += delegate
            {
                if (comand >= 5) MPage(name);
                else
                {
                    comand++;
                    ttx.Text = tutos[comand];
                    if(comand==5)
                    bt2.Text = "Iniciar";
                }
            };
            Button bt3 = bt2;
            bt3.Text = "Pular";
            bt3.Clicked += delegate { Console.WriteLine("hey"); };
            splash.Children.Add(bt2);
            this.Content = splash;*/
            tutorialimage(name);

        }
        void alert(string s)
        {
            DisplayAlert("Move Online:", s, "Ok");
        }
        async void EsqueceuSenha()
        {
            StackLayout esqpass = new StackLayout() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            Label lb = new Label()
            {
                Text = "Move Online",
                HorizontalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            lb.FontSize *= d* (Device.RuntimePlatform==Device.iOS?1.5f:1f)* 1.5f;
            lb.BackgroundColor = Color.FromHex("51a279");
            lb.TextColor = Color.White;
            esqpass.Children.Add(lb);
            esqpass.Children.Add(new Label() { Text = "Digite o CNPJ cadastrado na conta para recuperar sua senha, caso tenha esquecido contate seu consultor", HorizontalOptions = LayoutOptions.Center, HorizontalTextAlignment = TextAlignment.Center, FontSize = lb.FontSize * 0.3f });
            for (int i = 0; i < 2; i++)
            {
                esqpass.Children.Add(new Label() { Text = "" });
            }
            Entry user = new Entry() { Margin = new Thickness(20, 0, 20, 0), HorizontalOptions = LayoutOptions.Fill, HorizontalTextAlignment = TextAlignment.Start, Placeholder = "CNPJ" };
            user.FontSize *= d * (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 0.5f;
            Button bt = new Button()
            {
                Text = "Enviar",
                HorizontalOptions = Device.RuntimePlatform == Device.iOS ? LayoutOptions.FillAndExpand : LayoutOptions.Center,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex("51a279"),
                Margin = new Thickness(40, 0, 40, 0)


            };
            bt.FontSize *= d* (Device.RuntimePlatform==Device.iOS?1.5f:1f)* 0.7f;
            bt.Clicked += async delegate
            {
                if (!string.IsNullOrEmpty(user.Text))
                {
                    string resu =  await DependencyService.Get<INatives>().esqsenha(localsite + "email.php", user.Text);
                    alert(resu);
                    if (resu == "OK")
                    {
                        alert("Email de senha enviado com sucesso");
                        SplashLayout();
                    }
                    else
                    {
                        alert("Este cnpj não está cadastrado");
                    }
                }
                else
                {
                    alert("Preencha o campo corretamente");
                }
            };
            esqpass.Children.Add(user);
            esqpass.Children.Add(bt);
            Label esq = new Label() { Text = "Voltar", FontSize = lb.FontSize * 0.4f, TextColor = Color.FromHex("51a279"), HorizontalTextAlignment = TextAlignment.Center, HorizontalOptions = LayoutOptions.Center };
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += delegate
            {
                SplashLayout();
            };
            esq.GestureRecognizers.Add(tap);
            esqpass.Children.Add(esq);

            this.Content = esqpass;
        }
        async void MPage(string name)
        {
            ScrollView sv = new ScrollView();
            if (!Application.Current.Properties.ContainsKey("aceitatermos"))
            {
                StackLayout mpage = new StackLayout() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
                Label lb = new Label()
                {
                    Text = "Move Online",
                    HorizontalTextAlignment = TextAlignment.Center,
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
                lb.FontSize *= d * (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 1.5f;
                lb.BackgroundColor = Color.FromHex("51a279");
                lb.TextColor = Color.White;

                Label select = new Label()
                {
                    Text = "Seja bem vindo, " + name + "\nPara usar o APP Move Online você deve aceitar nossos Termos de Uso e Privacidade. ",
                    HorizontalTextAlignment = TextAlignment.Center,
                    HorizontalOptions = LayoutOptions.CenterAndExpand
                };
                select.FontSize *= d * (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 0.8f;
                mpage.Children.Add(lb);
                mpage.Children.Add(select);
                string[] a = new string[2] { "Ler termos", "Aceitar" };
                int maior = 0;
                for (int i = 0; i < 1; i++)
                {
                    mpage.Children.Add(new Label() { Text = "" });
                }
                for (int i = 0; i < a.Length; i++)
                {

                    Button bt1 = new Button()
                    {
                        Text = a[i],
                        BackgroundColor = Color.FromHex("51a279"),
                        HorizontalOptions = LayoutOptions.FillAndExpand
                        ,
                        TextColor = Color.White,
                        ClassId = (i+10) + "",
                        Margin = new Thickness(20, 0, 20, 0)
                    };
                    bt1.Clicked += (sender, e) => Bt1_Clicked(sender, e, name);

                    bt1.FontSize *= d * (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 0.8f;


                    mpage.Children.Add(bt1);
                }
                sv.Content = mpage;
                this.Content = sv;
            

            }
            else
            {

                StackLayout mpage = new StackLayout() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
                Label lb = new Label()
                {
                    Text = "Move Online",
                    HorizontalTextAlignment = TextAlignment.Center,
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
                lb.FontSize *= d * (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 1.5f;
                lb.BackgroundColor = Color.FromHex("51a279");
                lb.TextColor = Color.White;

                Label select = new Label()
                {
                    Text = "Seja bem vindo, " + name + "",
                    HorizontalTextAlignment = TextAlignment.Center,
                    HorizontalOptions = LayoutOptions.CenterAndExpand
                };
                select.FontSize *= d * (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 0.8f;
                mpage.Children.Add(lb);
                mpage.Children.Add(select);
                string[] a = new string[9] { "Imposto", "Consulta", "Abrir Chamado", "Documentos", "Dúvidas", "Enviar documentos", "Manual", "Termos de uso e Privacidade",  "Sair" };
                int maior = 0;
                for (int i = 0; i < 1; i++)
                {
                    mpage.Children.Add(new Label() { Text = "" });
                }
                //  await PopupNavigation.Instance.PushAsync(new popup(),true);

                for (int i = 0; i < a.Length; i++)
                {

                    Button bt1 = new Button()
                    {
                        Text = a[i],
                        BackgroundColor = Color.FromHex("51a279"),
                        HorizontalOptions = LayoutOptions.FillAndExpand
                        ,
                        TextColor = Color.White,
                        ClassId = i + "",
                        Margin = new Thickness(20, 0, 20, 0)
                    };
                    bt1.Clicked += (sender, e) => Bt1_Clicked(sender, e, name);

                    bt1.FontSize *= d * (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 0.8f;


                    mpage.Children.Add(bt1);
                }
                sv.Content = mpage;
                this.Content = sv;
            }
        }

        private void Bt1_Clicked(object sender, EventArgs e,string name)
        {
            MenuPageAsync(int.Parse(((Button)sender).ClassId),name);

        }


/* Unmerged change from project 'EmissorApp.iOS'
Before:
        void MenuPage(int pg)
After:
        void MenuPageAsync(int pg)
*/
        async Task MenuPageAsync(int pg,string name)
        {
            switch (pg) {
                case 0:
                    StackLayout mpage = new StackLayout() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
                    Label lb = new Label()
                    {
                        Text = "Move Online",
                        HorizontalTextAlignment = TextAlignment.Center,
                        HorizontalOptions = LayoutOptions.FillAndExpand
                    };
                    lb.FontSize *= d * (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 1.5f;
                    lb.BackgroundColor = Color.FromHex("51a279");
                    lb.TextColor = Color.White;

                    mpage.Children.Add(lb);
                    mpage.Children.Add(new Label() { Text = "Informe aqui seu faturamento para emitir seu imposto:\n", HorizontalOptions = LayoutOptions.Center, HorizontalTextAlignment = TextAlignment.Center, FontSize = lb.FontSize * 0.5f });

                    Entry pserv = new Entry()
                    {
                        Placeholder = "Serviços",
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        HorizontalTextAlignment = TextAlignment.End
                         , VerticalOptions = LayoutOptions.FillAndExpand
                         , Keyboard = Keyboard.Numeric

                    };
                    pserv.FontSize *= d * (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 0.8f;

                    pserv.Focused += delegate { if (!string.IsNullOrEmpty(pserv.Text) && pserv.Text.Contains(",")) pserv.Text = pserv.Text.Replace(",", ""); };

                    // pserv.TextColor = Color.FromHex("51a279");
                    pserv.Unfocused += delegate
                    {
                        pserv.Text = convert(pserv.Text);
                    };
                    Grid g1 = new Grid()
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Margin = new Thickness(40, 0, 40, 0)
                    };
                    g1.Children.Add(pserv);
                    Label rs = new Label()
                    {
                        Text = " R$ :", HorizontalOptions = LayoutOptions.Start, VerticalTextAlignment = TextAlignment.Center, HorizontalTextAlignment = TextAlignment.Start, FontSize = pserv.FontSize
                    };
                    Label rs2 = new Label()
                    {
                        Text = " R$ :", HorizontalOptions = LayoutOptions.Start, VerticalTextAlignment = TextAlignment.Center, HorizontalTextAlignment = TextAlignment.Start, FontSize = pserv.FontSize
                    };
                    //g1.Children.Add(rs2);

                    mpage.Children.Add(g1);

                    Entry rprod = new Entry()
                    {
                        Placeholder = "Comércio",
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        HorizontalTextAlignment = TextAlignment.End
                        ,
                        VerticalOptions = LayoutOptions.Start,
                        Keyboard = Keyboard.Numeric

                    };

                    rprod.Unfocused += delegate
                    {
                        rprod.Text = convert(rprod.Text);
                    };
                    rprod.Focused += delegate { if (!string.IsNullOrEmpty(rprod.Text) && rprod.Text.Contains(",")) rprod.Text = rprod.Text.Replace(",", ""); };
                    // rprod.TextColor = Color.FromHex("51a279");
                    rprod.FontSize *= d * (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 0.8f;
                    Grid g2 = new Grid()
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Margin = new Thickness(40, 0, 40, 0)
                    };
                    g2.Children.Add(rprod);
                    //g2.Children.Add(rs);

                    mpage.Children.Add(g2);

                    for (int i = 0; i < 2; i++) mpage.Children.Add(new Label() { Text = "" });

                    Picker date = new Picker()
                    {
                        Title = "Selecione o mês",
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Margin = new Thickness(20, 0, 20, 0)
                        , TextColor = rprod.TextColor

                    }; List<string> meses = new List<string>();
                    for (int i = 0; i < 2; i++)
                    {
                        mpage.Children.Add(new Label() { Text = "" });
                    }
                    for (int i = 1; i < DateTime.Now.Month + 1; i++)
                        meses.Add(i > 9 ? i + ("/" + DateTime.Now.Year.ToString()) : "0" + i + ("/" + DateTime.Now.Year.ToString()));
                    foreach (string s in meses) date.Items.Add(s);

                    mpage.Children.Add(date);
                    for (int i = 0; i < 2; i++)
                    {
                        mpage.Children.Add(new Label() { Text = "" });
                    }
                    Button bt1 = new Button()
                    {
                        Text = "Calcular",
                        BackgroundColor = Color.FromHex("51a279"),
                        HorizontalOptions = LayoutOptions.FillAndExpand
                    ,
                        TextColor = Color.White,
                        Margin = new Thickness(20, 0, 20, 0)
                    };
                    bt1.FontSize *= d * (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 0.8f;
                    bt1.Clicked += async delegate {
                        if (!string.IsNullOrEmpty(rprod.Text) && !string.IsNullOrEmpty(pserv.Text) && date.SelectedItem != null)
                        {
                            bool ck = true;
                            string rp1 = rprod.Text.Replace(",", "");
                            string ps1 = pserv.Text.Replace(",", "");

                            int a, b;
                            if (int.TryParse(ps1, out a) && int.TryParse(rp1, out b))
                            {
                                if (int.Parse(ps1) + int.Parse(rp1) > 2500000)
                                    ck = await DisplayAlert("Move Online", "Você digitou uma quantia acima do valor de R$: 25.000,00 , você tem certeza que deseja continuar?", "Continuar", "Cancelar");

                                if (ck)
                                {
                                    string ask = await DependencyService.Get<INatives>().HasDas(localsite + "login.php", (date.SelectedIndex + 1) + "", Application.Current.Properties["cnpj"].ToString());
                                    if (ask == "ask" || ask == "OK")
                                    {

                                        if (ask == "ask")
                                        {
                                            bool chk = false;
                                            chk = await DisplayAlert("Move Online", "Já existe uma emissão o mês " + (date.SelectedIndex + 1) + " para essa data, deseja recalcular?", "Continuar", "Cancelar");
                                            if (chk)
                                            {
                                                string resu = await DependencyService.Get<INatives>().EmitDass(localsite + "login.php", rp1, ps1, date.SelectedIndex + 1 + "", Application.Current.Properties["cnpj"].ToString(), ask);

                                                if (resu == "OK")
                                                {
                                                    alert("Sucesso ao fazer o pedido, Aguarde o resultado na aba Consultar Emissões");
                                                    MenuPageAsync(1, name);
                                                }
                                                else alert("Erro no sistema");
                                            }
                                        }
                                        else
                                        {
                                            string resu = await DependencyService.Get<INatives>().EmitDass(localsite + "login.php", rp1, ps1, date.SelectedIndex + 1 + "", Application.Current.Properties["cnpj"].ToString(), ask);

                                            if (resu == "OK")
                                            {
                                                alert("Sucesso ao fazer o pedido, Aguarde o resultado na aba Consultar Emissões");
                                                MenuPageAsync(1, name);
                                            }
                                            else alert("Erro no sistema");
                                        }
                                    }
                                    else alert("Erro no sistema");

                                }
                            }
                            else alert("Preencha apenas com números");

                        }
                        else alert("Preencha todos os campos corretamente");

                    };
                    mpage.Children.Add(bt1);
                    Button bt2 = new Button()
                    {
                        Text = "Voltar",
                        BackgroundColor = Color.FromHex("51a279"),
                        HorizontalOptions = LayoutOptions.FillAndExpand
                   ,
                        TextColor = Color.White,
                        Margin = new Thickness(20, 0, 20, 0)
                    };

                    bt2.FontSize *= d * (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 0.8f;
                    bt2.Clicked += delegate { MPage(name); };
                    mpage.Children.Add(bt2);
                    this.Content = mpage;

                    break;
                case 1:
                    try
                    {
                        ScrollView sw = new ScrollView();
                        StackLayout mpage1 = new StackLayout() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
                        Label lb1 = new Label()
                        {
                            Text = "Move Online",
                            HorizontalTextAlignment = TextAlignment.Center,
                            HorizontalOptions = LayoutOptions.FillAndExpand
                        };
                        lb1.FontSize *= d * (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 1.5f;
                        lb1.BackgroundColor = Color.FromHex("51a279");
                        lb1.TextColor = Color.White;
                        mpage1.Children.Add(lb1);
                        mpage1.Children.Add(new Label() { Text = "Gerencie aqui seus impostos", HorizontalOptions = LayoutOptions.Center, HorizontalTextAlignment = TextAlignment.Center, FontSize = lb1.FontSize * 0.5f });
                        sw.Content = mpage1;
                        for (int i = 0; i < 1; i++) mpage1.Children.Add(new Label() { Text = "" });

                        this.Content = sw;
                        ActivityIndicator loading = new ActivityIndicator()
                        {
                            HorizontalOptions = LayoutOptions.Center,
                            Color = Color.FromHex("51a279"),
                            IsRunning = true
                        };
                        mpage1.Children.Add(loading);
                        string reqs = await DependencyService.Get<INatives>().GetRequests(localsite + "login.php", Application.Current.Properties["cnpj"].ToString());
                        string[] rqs = reqs.Split('|');
                        mpage1.Children.Remove(loading);
                        for (int i = 0; i < rqs.Length - 1; i++)
                        {

                            Label mes = new Label()
                            {
                                Text = "Mês = " + ((int.Parse(rqs[i].Split('@')[0]) > 9) ? int.Parse(rqs[i].Split('@')[0]) + ("/" + DateTime.Now.Year.ToString()) : 0 + int.Parse(rqs[i].Split('@')[0]) + ("/" + DateTime.Now.Year.ToString())),
                                HorizontalOptions = LayoutOptions.CenterAndExpand,
                                HorizontalTextAlignment = TextAlignment.Center,
                                Margin = new Thickness(20, 0, 20, 0)
                            };
                            mes.FontSize *= d * (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 0.8f;
                            Label sts = new Label()
                            {
                                Text = "Status : " + rqs[i].Split('@')[1].Replace("Boleto","Imposto"),
                                HorizontalOptions = LayoutOptions.CenterAndExpand,
                                HorizontalTextAlignment = TextAlignment.Center,
                                Margin = new Thickness(20, 0, 20, 0)
                            };
                            sts.FontSize *= d * (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 0.8f;
                            mpage1.Children.Add(mes);
                            mpage1.Children.Add(sts);
                            if (!string.IsNullOrEmpty(rqs[i].Split('@')[2])) {
                                Button bolet = new Button()
                                {
                                    Text = "Visualizar imposto",
                                    BackgroundColor = Color.FromHex("51a279"),
                                    HorizontalOptions = LayoutOptions.FillAndExpand,
                                    TextColor = Color.White,
                                    ClassId = i + "",
                                    Margin = new Thickness(40, 0, 40, 0)
                                };
                                bolet.FontSize *= d * (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 0.8f;
                                bolet.ClassId = rqs[i].Split('@')[2];
                                bolet.Clicked += Bolet_Clicked;
                                Grid g = new Grid() { HorizontalOptions = LayoutOptions.FillAndExpand };
                                Label pg1 = new Label() { Margin = new Thickness(30, 0, 30, 0), Text = "", HorizontalOptions = LayoutOptions.Start };
                                pg1.FontSize *= d * (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 0.8f;
                                g.Children.Add(pg1);

                                Xamarin.Forms.Switch pg2 = new Xamarin.Forms.Switch() { HorizontalOptions = LayoutOptions.End, Margin = new Thickness(0, 0, 20, 0) };
                                pg2.IsToggled = rqs[i].Split('@')[3] == "0" ? false : true;
                                pg2.Toggled += (sender, e) => Pg2_Toggled(sender, e, name, pg);
                                pg2.ClassId = rqs[i].Split('@')[0];
                                g.Children.Add(pg2);
                                mpage1.Children.Add(g);
                                mpage1.Children.Add(bolet);
                                Button bolet1 = new Button()
                                {
                                    Text = "Recalcular",
                                    BackgroundColor = Color.FromHex("51a279"),
                                    HorizontalOptions = LayoutOptions.FillAndExpand,
                                    TextColor = Color.White,
                                    ClassId = i + "",
                                    Margin = new Thickness(40, 0, 40, 0)
                                };
                                bolet1.FontSize *= d * (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 0.8f;
                                bolet1.ClassId = rqs[i].Split('@')[0];
                                mpage1.Children.Add(bolet1);
                                bolet1.Clicked += (sender, e) => Bolet1_Clicked(sender, e, name, pg);
                            }
                            for (int j = 0; j < 1; j++) mpage1.Children.Add(new Label() { Text = "" });
                            BoxView bx = new BoxView()
                            {
                                HorizontalOptions = LayoutOptions.FillAndExpand,
                                HeightRequest = 2
                                , BackgroundColor = Color.Gray
                            };
                            mpage1.Children.Add(bx);



                        }
                        Button bta = new Button()
                        {
                            Text = "Atualizar",
                            BackgroundColor = Color.FromHex("51a279"),
                            HorizontalOptions = LayoutOptions.FillAndExpand
                      ,
                            TextColor = Color.White,
                            Margin = new Thickness(20, 0, 20, 0)
                        };

                        bta.FontSize *= d * (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 0.8f;
                        bta.Clicked += delegate { MenuPageAsync(pg, name); };
                        mpage1.Children.Add(bta);
                        Button btv = new Button()
                        {
                            Text = "Voltar",
                            BackgroundColor = Color.FromHex("51a279"),
                            HorizontalOptions = LayoutOptions.FillAndExpand
                  ,
                            TextColor = Color.White,
                            Margin = new Thickness(20, 0, 20, 0)
                        };

                        btv.FontSize *= d * (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 0.8f;
                        btv.Clicked += delegate { MPage(name); };
                        mpage1.Children.Add(btv);
                    }
                    catch (Exception e)
                    {
                        alert(e.ToString());
                    }
                    break;
                case 2:
                    ScrollView sw1 = new ScrollView();
                    StackLayout mpage2 = new StackLayout() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
                    Label lb2 = new Label()
                    {
                        Text = "Move Online",
                        HorizontalTextAlignment = TextAlignment.Center,
                        HorizontalOptions = LayoutOptions.FillAndExpand
                    };
                    lb2.FontSize *= d * (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 1.5f;
                    lb2.BackgroundColor = Color.FromHex("51a279");
                    lb2.TextColor = Color.White;
                    mpage2.Children.Add(lb2);
                    mpage2.Children.Add(new Label() { Text = "Abra aqui seu chamado :", HorizontalOptions = LayoutOptions.Center, HorizontalTextAlignment = TextAlignment.Center, FontSize = lb2.FontSize * 0.5f });

                    string[] services = new string[] {"Certificado digital", "Declaração de faturamento", "Folha de funcionários", "Folha de sócios", "Férias", "Rescisão", "INSS", "FGTS", "IRRF", "Simples Nacional", "Parcelamento", "Relatorios contabilidade", "Nota fiscal de produtos", "Nota fiscal de serviços", "Regularizar mensalidade", "Demais serviços"};
                    //"Abertura de Empresas", "Agendar um Atendimento on-line", "Ajuda para Emitir uma NF-e", "Ajuda para Emitir uma NFS-e", "Atualizar CNPJ", "Atualizar dados de cobrança", "Cadastro de Anuncios no CNPJ", "Cancelar CNPJ", "Certidão Negativa de Débitos", "Certificado Digital", "Contratar um Funcionário", "Declaração de Faturamento", "Demitir um Funcionário", "Enviar meu Funcionário de Férias", "Folha de Pagamento de Funcionários", "Folha de Pagamento de Sócios", "Imposto de Renda", "Licença de Funcionamento", "Minha Empresa Cresceu Preciso de Ajuda", "Não Recebi a Folha de Pagamento", "Não Recebi meu Parcelamento", "Não Recebi meus Impostos", "Preciso de Ajuda me Ligue", "Preciso de um Doc. Assinado pelo Contador", "Quero abrir um chamado estou com problemas", "Quero Indicar um Cliente e Ganhar Desconto", "Quero Regularizar meus Impostos", "Relatórios da minha Empresa", "Segunda via de Boleto da Mensalidade", "Tenho uma duvida preciso da Ajuda de um Contador" };
                    Label esq = new Label() { Text = "Visualizar chamados abertos", FontSize= lb2.FontSize*0.5f, TextColor = Color.FromHex("51a279"), HorizontalTextAlignment = TextAlignment.Center, HorizontalOptions = LayoutOptions.Center };
                    TapGestureRecognizer tap = new TapGestureRecognizer();
                    tap.Tapped += async delegate
                    {
                        //  EsqueceuSenha();
                        sw1 = new ScrollView();
                        mpage2 = new StackLayout() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
                        mpage2.Children.Add(lb2);
                        string chamados = await DependencyService.Get<INatives>().getChamadosAsync(localsite + "login.php", Application.Current.Properties["cnpj"].ToString());
                        var splited = chamados.Split('&');
                        for(var i =0;i<splited.Length-1;i++)
                        {
                            Console.WriteLine(splited[i]);
                            var infos = splited[i].Split('|');
                            Label mes = new Label()
                            {
                                Text = "Tipo: \n"+infos[0] ,
                                HorizontalOptions = LayoutOptions.CenterAndExpand,
                                HorizontalTextAlignment = TextAlignment.Center,
                                Margin = new Thickness(20, 0, 20, 0)
                            };
                            mes.FontSize *= d * (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 0.8f;
                            Label sts = new Label()
                            {
                                Text = "Data de abertura:\n "+infos[1] ,
                                HorizontalOptions = LayoutOptions.CenterAndExpand,
                                HorizontalTextAlignment = TextAlignment.Center,
                                Margin = new Thickness(20, 0, 20, 0)
                            };
                            sts.FontSize *= d * (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 0.8f;
                            DateTime dt  = DateTime.ParseExact(infos[1], "dd/MM/yyyy",
                                       System.Globalization.CultureInfo.InvariantCulture);
                            dt = dt.AddDays(2);
                            Label sts2 = new Label()
                            {
                                Text = "Prazo de resposta:\n " + dt.ToString("dd/MM/yyyy"),
                                HorizontalOptions = LayoutOptions.CenterAndExpand,
                                HorizontalTextAlignment = TextAlignment.Center,
                                Margin = new Thickness(20, 0, 20, 0)
                            };
                            sts2.FontSize *= d * (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 0.8f;
                            var status = new string[] { "Em análise", "Respondido", "Encerrado" };
                            Label sts3 = new Label()
                            {
                                Text = "Status:\n" +  status [int.Parse(infos[2])],
                                HorizontalOptions = LayoutOptions.CenterAndExpand,
                                HorizontalTextAlignment = TextAlignment.Center,
                                Margin = new Thickness(20, 0, 20, 0)
                            };
                            sts3.FontSize *= d * (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 0.8f;
                            Label sts4 = new Label()
                            {
                                Text = "Descrição:\n" + infos[3].Replace("<br />","\n"),
                                HorizontalOptions = LayoutOptions.CenterAndExpand,
                                HorizontalTextAlignment = TextAlignment.Center,
                                Margin = new Thickness(20, 0, 20, 0)
                            };
                            sts4.FontSize *= d * (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 0.8f;
                            mpage2.Children.Add(mes);
                            mpage2.Children.Add(sts);
                            mpage2.Children.Add(sts2);
                            mpage2.Children.Add(sts3);
                            mpage2.Children.Add(sts4);
                            Button bolet1 = new Button()
                            {
                                Text = "Encerrar",
                                BackgroundColor = Color.FromHex("51a279"),
                                HorizontalOptions = LayoutOptions.FillAndExpand,
                                TextColor = Color.White,
                                ClassId = i + "",
                                Margin = new Thickness(40, 0, 40, 0)
                            };
                            bolet1.FontSize *= d * (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 0.8f;
                            //bolet1.ClassId = rqs[i].Split('@')[0];
                           if(infos[2]!="2") mpage2.Children.Add(bolet1);
                            // bolet1.Clicked += (sender, e) => Bolet1_Clicked(sender, e, name, pg);
                            bolet1.Clicked += async delegate
                            {
                                string enc = await DependencyService.Get<INatives>().encerrarChamadoAsync(localsite + "login.php", infos[4]);
                                if (enc == "OK") MenuPageAsync(2, name);
                            };
                            for (int j = 0; j < 1; j++) mpage2.Children.Add(new Label() { Text = "" });
                            BoxView bx = new BoxView()
                            {
                                HorizontalOptions = LayoutOptions.FillAndExpand,
                                HeightRequest = 2
                                ,
                                BackgroundColor = Color.Gray
                            };
                            mpage2.Children.Add(bx);


                    }

                        Button btbk = new Button()
                        {
                            Text = "Voltar",
                            BackgroundColor = Color.FromHex("51a279"),
                            HorizontalOptions = LayoutOptions.FillAndExpand
                            ,
                            TextColor = Color.White,
                            Margin = new Thickness(20, 0, 20, 0)
                        };

                        btbk.FontSize *= d * (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 0.8f;
                        btbk.Clicked += delegate { MenuPageAsync(2, name); };
                        mpage2.Children.Add(btbk);
                        sw1.Content = mpage2;
                        this.Content = sw1;
                    };
                    esq.GestureRecognizers.Add(tap);
                    mpage2.Children.Add(esq);

                    foreach (string s in services)
                    {
                        Button btn = new Button()
                        {
                            Text = s,
                            BackgroundColor = Color.FromHex("51a279"),
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            TextColor = Color.White,
                            
                            Margin = new Thickness(20, 0, 20, 0)
                        };
                        btn.FontSize *= d* (Device.RuntimePlatform==Device.iOS?1.5f:1f)* 0.8f;
                        btn.Clicked +=(sender,e)=> Btn_Clicked(sender,e,name);
                        mpage2.Children.Add(btn);
                    }
                    Button btv1 = new Button()
                    {
                        Text = "Voltar",
                        BackgroundColor = Color.FromHex("51a279"),
                        HorizontalOptions = LayoutOptions.FillAndExpand
                  ,
                        TextColor = Color.White,
                        Margin = new Thickness(20, 0, 20, 0)
                    };

                    btv1.FontSize *= d* (Device.RuntimePlatform==Device.iOS?1.5f:1f)* 0.8f;
                    btv1.Clicked += delegate { MPage(name); };
                    mpage2.Children.Add(btv1);
                    sw1.Content = mpage2;
                    this.Content = sw1;
                    break;
                case 4:
                    ScrollView sw2 = new ScrollView();
                    StackLayout mpage3 = new StackLayout() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
                    Label lb3 = new Label()
                    {
                        Text = "Move Online",
                        HorizontalTextAlignment = TextAlignment.Center,
                        HorizontalOptions = LayoutOptions.FillAndExpand
                    };
                    lb3.FontSize *= d* (Device.RuntimePlatform==Device.iOS?1.5f:1f)* 1.5f;
                    lb3.BackgroundColor = Color.FromHex("51a279");
                    lb3.TextColor = Color.White;
                    mpage3.Children.Add(lb3);
                    sw2.Content = mpage3;
                    Editor edit = new Editor()
                    {
                        Text = "Digite aqui sua dúvida ou sugestão",
                        TextColor= Color.Gray,
                        VerticalOptions = LayoutOptions.FillAndExpand
                    };
                    edit.FontSize *= d* (Device.RuntimePlatform==Device.iOS?1.5f:1f)* 0.8f;
                    mpage3.Children.Add(edit);
                    Button send = new Button()
                    {
                        Text = "Enviar",
                        BackgroundColor = Color.FromHex("51a279"),
                        HorizontalOptions = LayoutOptions.FillAndExpand
                  ,
                        TextColor = Color.White,
                        Margin = new Thickness(20, 0, 20, 0)
                    };
                    send.FontSize *= d* (Device.RuntimePlatform==Device.iOS?1.5f:1f)* 0.8f;

                    send.Clicked += async delegate
                     {
                         if (await DisplayAlert("Move Online", "Você realmente deseja solicitar a ajuda ou sugestão de " + edit.Text, "Sim", "Não"))
                         {
                             string resu = await DependencyService.Get<INatives>().SolicitarServ(localsite + "email.php", edit.Text,
                                 Application.Current.Properties["cnpj"].ToString(), name,edit.Text);
                             if (resu == "OK")
                             {
                                 alert("Sucesso ao solicitar o serviço");
                                 edit.Text = "Digite aqui sua dúvida ou sugestão";
                             }

                             else alert("Erro no sistema");
                         }
                     };
                    mpage3.Children.Add(send);
                    Button btv2 = new Button()
                    {
                        Text = "Voltar",
                        BackgroundColor = Color.FromHex("51a279"),
                        HorizontalOptions = LayoutOptions.FillAndExpand
                  ,
                        TextColor = Color.White,
                        Margin = new Thickness(20, 0, 20, 0)
                    };

                    btv2.FontSize *= d* (Device.RuntimePlatform==Device.iOS?1.5f:1f)* 0.8f;
                    btv2.Clicked += delegate { MPage(name); };
                    mpage3.Children.Add(btv2);
                    this.Content = sw2;
                    break;
                case 5:
                    ScrollView swv = new ScrollView();
                    StackLayout mpage4 = new StackLayout() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
                    Label lb4 = new Label()
                    {
                        Text = "Move Online",
                        HorizontalTextAlignment = TextAlignment.Center,
                        HorizontalOptions = LayoutOptions.FillAndExpand
                    };
                    lb4.FontSize *= d* (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 1.5f;
                    lb4.BackgroundColor = Color.FromHex("51a279");
                    lb4.TextColor = Color.White;

                    Label abt = new Label()
                    {
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        HorizontalTextAlignment = TextAlignment.Start,
                        Text= @"A Move Online conta com uma equipe de especialistas em contabilidade, para atender aos interesses da sua empresa com excelência. Acreditamos que a tecnologia pode ser utilizada para otimizar processos, diminuir custos e gerar resultados econômicos. Nesse Canal você pode enviar arquivos direto do seu celular."+"\n",
                        Margin = new Thickness(20, 0, 20, 0)

                    };
                    abt.FontSize *= d* (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 0.8f;
                    Button btz = new Button()
                    {
                        Text = "Enviar documentos",
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Margin = new Thickness(20, 0, 20, 0),
                        BackgroundColor = Color.FromHex("51a279"),
                        TextColor = Color.White

            };
                    btz.FontSize *= d* (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 0.8f;
                    btz.Clicked += delegate
                    {
                        Device.OpenUri(new Uri("http://moveonline.com.br/sobre.html#fale-conosco"));
                    };
                    mpage4.Children.Add(lb4);
                    mpage4.Children.Add(abt);
                    mpage4.Children.Add(btz);

                    Button btv3 = new Button()
                    {
                        Text = "Voltar",
                        BackgroundColor = Color.FromHex("51a279"),
                        HorizontalOptions = LayoutOptions.FillAndExpand
                 ,
                        TextColor = Color.White,
                        Margin = new Thickness(20, 0, 20, 0)
                    };

                    btv3.FontSize *= d* (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 0.8f;
                    btv3.Clicked += delegate { MPage(name); };
                    mpage4.Children.Add(btv3);

                    swv.Content = mpage4;
                    this.Content = swv;

                    break;
                case 6:
                    //showtutorial(name);
                    Device.OpenUri(new Uri(localsite + "manual.pdf"));

                    Device.OpenUri(new Uri("http://bit.ly/MoveTutorial"));

                    break;
                case 7:
                    Device.OpenUri(new Uri(localsite + "termosuso.pdf"));
                    break;
                case 8:

                    Application.Current.Properties.Remove("cnpj");
                    Application.Current.Properties.Remove("pass");
                    Application.Current.Properties.Remove("aceitatermos");
                    SplashLayout(); break;

                case 9:
                    
                    break;
                case 10:
                    Device.OpenUri(new Uri(localsite + "termosuso.pdf"));

                    break;
                case 11:
                    Application.Current.Properties["aceitatermos"] = true;
                    MPage(name);
                    break;
                case 12:
                    await DisplayAlert("Aceitar termos", "Para utilizar o app Move Online você deve aceitar os termos", "Ok");
                    break;
                case 3:
                    ScrollView sw3 = new ScrollView();
                    StackLayout mpage7 = new StackLayout() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
                    Label lb7 = new Label()
                    {
                        Text = "Move Online",
                        HorizontalTextAlignment = TextAlignment.Center,
                        HorizontalOptions = LayoutOptions.FillAndExpand
                    };
                    lb7.FontSize *= d * (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 1.5f;
                    lb7.BackgroundColor = Color.FromHex("51a279");
                    lb7.TextColor = Color.White;
                    mpage7.Children.Add(lb7);
                    mpage7.Children.Add(new Label() { Text = "Selecione o mês desejado para visualizar os documentos", HorizontalOptions = LayoutOptions.Center, HorizontalTextAlignment = TextAlignment.Center, FontSize = lb7.FontSize * 0.5f });
                    Picker date2 = new Picker()
                    {
                        Title = "Selecione o mês",
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Margin = new Thickness(20, 0, 20, 0)
                       ,
                        TextColor = Color.FromHex("51a279")

                    }; List<string> meses2 = new List<string>();
                    for (int i = 1; i < DateTime.Now.Month+1; i++)
                        meses2.Add(i > 9 ? i + ("/"+DateTime.Now.Year.ToString()) : "0" + i + ("/"+DateTime.Now.Year.ToString()));
                    foreach (string s in meses2) date2.Items.Add(s);
                    mpage7.Children.Add(date2);
                    Label tit = new Label() { Text = "", HorizontalOptions = LayoutOptions.Center, HorizontalTextAlignment = TextAlignment.Center, FontSize = lb7.FontSize * 0.3f };
                    mpage7.Children.Add(tit);
                   
                   
                    date2.SelectedIndexChanged += async delegate
                     {
                         tit.Text = "Exibindo documentos do mes " + date2.SelectedItem.ToString();
                         View todelete= null ;
                         foreach (View v in mpage7.Children) if (v.ClassId == "tmp") todelete = v;
                         if (todelete != null) mpage7.Children.Remove(todelete);
                         StackLayout tmp = new StackLayout
                         {
                             ClassId = "tmp"
                         };                        

                         string resu = await DependencyService.Get<INatives>().getfiles(localsite + "files.php", Application.Current.Properties["cnpj"].ToString(), date2.SelectedIndex + 1 + "");

                         if (resu.Split('|').Length>0&&resu!="n"&&!string.IsNullOrWhiteSpace(resu))
                             {
                             for (int i = 0; i < resu.Split('|').Length; i++)
                             {
                                 if (!string.IsNullOrWhiteSpace(resu.Split('|')[i]))
                                 {
                                     Label docs = new Label() { Text = "", HorizontalOptions = LayoutOptions.Center, HorizontalTextAlignment = TextAlignment.Center, FontSize = lb7.FontSize * 0.5f, TextColor = Color.FromHex("51a279") };
                                     docs.Text = resu.Split('|')[i];
                                     TapGestureRecognizer tp = new TapGestureRecognizer();
                                     docs.ClassId = docs.Text + "|" + (date2.SelectedIndex + 1);
                                     tp.Tapped += Tp_Tapped;
                                     
                                     docs.GestureRecognizers.Add(tp);
                                     tmp.Children.Add( docs);
                                 }
                             }
                         }
                         else if (resu =="error")
                         {
                             alert("Erro no sistema");
                         }
                         else
                             {
                             Label docs = new Label() { Text = "", HorizontalOptions = LayoutOptions.Center, HorizontalTextAlignment = TextAlignment.Center, FontSize = lb7.FontSize * 0.4f };
                             docs.Text = "Nenhum documento carregado para este mês";
                             tmp.Children.Add( docs);

                         }
                         mpage7.Children.Insert(mpage7.Children.Count-3, tmp);
                     };
                    for (int i = 0; i < 2; i++) mpage7.Children.Add(new Label() { Text = "" });

                    Button btv4 = new Button()
                    {
                        Text = "Voltar",
                        BackgroundColor = Color.FromHex("51a279"),
                        HorizontalOptions = LayoutOptions.FillAndExpand
                ,
                        TextColor = Color.White,
                        Margin = new Thickness(20, 0, 20, 0)
                    };

                    btv4.FontSize *= d * (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 0.8f;
                    btv4.Clicked += delegate { MPage(name); };
                    mpage7.Children.Add(btv4);
                    sw3.Content = mpage7;
                    this.Content = sw3;
                    break;
            }
        }

        private void Tp_Tapped(object sender, EventArgs e)
        {
            string[] a = ((Label)sender).ClassId.Split('|');
            
         Device.OpenUri(new Uri(localsite + "docss/" + Application.Current.Properties["cnpj"].ToString() + "/" + a[1] + "/" +a[0]));
                  
        }

        private async void Btn_Clicked(object sender, EventArgs e,string name )
        {
            if ( await DisplayAlert("Move Online", "Você realmente deseja solicitar o serviço de " + ((Button)sender).Text, "Sim", "Não"))
            {
                string descri = await InputBox(this.Navigation);

                string resu = await DependencyService.Get<INatives>().SolicitarServ(localsite + "email.php", ((Button)sender).Text,
                    Application.Current.Properties["cnpj"].ToString(), name,descri);
                if (resu == "OK") alert("Sucesso ao solicitar o serviço");
                else alert("Erro no sistema");
            }
        }

        private async void Bolet1_Clicked(object sender, EventArgs e, string name, int pg)
        {
            if (await DisplayAlert("Move Online", "Você tem certeza que deseja recalcular a competência do mês " + (int.Parse(((Button)sender).ClassId) > 9 ? ((Button)sender).ClassId + ("/"+DateTime.Now.Year.ToString()) : "0" + ((Button)sender).ClassId + ("/"+DateTime.Now.Year.ToString())), "Sim", "Não"))
                { 
                string resu = await DependencyService.Get<INatives>().Recalculate(localsite + "login.php", Application.Current.Properties["cnpj"].ToString(), ((Button)sender).ClassId);
                if (resu == "OK") alert("Sucesso ao recalcular");
                else alert("Erro no sistema");
            }
        }
        
        private void Bolet_Clicked(object sender, EventArgs e)
        {
            //alert(localsite.Replace("/Site/", "") + ((Button)sender).ClassId);
            Device.OpenUri(new Uri(localsite.Replace("/site/", "")+((Button)sender).ClassId));
        }

        private async void Pg2_Toggled(object sender, ToggledEventArgs e, string name, int pg)
        {

            string resu =await DependencyService.Get<INatives>().Save(localsite + "cnpj.php", Application.Current.Properties["cnpj"].ToString(), ((Xamarin.Forms.Switch)sender).ClassId, ((Xamarin.Forms.Switch)sender).IsToggled == true ? "1" : "0");
            if (resu != "OK") alert("Erro no sistema");
            else MenuPageAsync(pg, name);
        }

        string convert(string num)
        {
            var s = num;
            if (!string.IsNullOrEmpty(s))
            {
                if (s.Contains(","))
                s = s.Replace(",", "");
                if (s.Length>=2&&(s.Substring(s.Length - 1) == "0" && s[s.Length - 2] == '0'))
                {
                    if (s.Length >= 3) s = s + ",00";
                    else s = "0," + s;

                }
                else
                {
                    if (s.Length >= 3) s = s.Substring(0, s.Length - 2) + "," + s.Substring(s.Length - 2);
                    else s = "0," + s;
                }
            }
            return s;
        }
        public  void InitiateSSLTrust()
        {
            try
            {
                //Change SSL checks so that all checks pass
                ServicePointManager.ServerCertificateValidationCallback =
                   new RemoteCertificateValidationCallback(
                        delegate
                        { return true; }
                    );
            }
            catch (Exception ex)
            {
                alert(ex.ToString());
            }
        }
        public static Task<string> InputBox(INavigation navigation)
        {
            // wait in this proc, until user did his input 
            var tcs = new TaskCompletionSource<string>();

            var lblTitle = new Label { Text = "Detalhes", HorizontalOptions = LayoutOptions.Center, FontAttributes = FontAttributes.Bold };
            var lblMessage = new Label() { Text = "Digite os detalhes do seu chamado, caso exista.", HorizontalOptions = LayoutOptions.Center, HorizontalTextAlignment = TextAlignment.Center };
            var txtInput = new Entry { Text = "",
                Placeholder = "",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.End
                         ,
                VerticalOptions = LayoutOptions.FillAndExpand
                         
               
            };

            var btnOk = new Button
            {
                Text = "Ok",
                BackgroundColor = Color.FromHex("51a279"),
                HorizontalOptions = LayoutOptions.FillAndExpand
                ,
                TextColor = Color.White,
                Margin = new Thickness(20, 0, 20, 0)
            };
            btnOk.Clicked += async (s, e) =>
            {
                // close page
                var result = txtInput.Text;
                await navigation.PopModalAsync();
                // pass result
                tcs.SetResult(result);
            };

            var btnCancel = new Button
            {
                Text = "Cancelar",
                BackgroundColor = Color.FromHex("51a279"),
                HorizontalOptions = LayoutOptions.FillAndExpand
                ,
                TextColor = Color.White,
                Margin = new Thickness(20, 0, 20, 0)
            };
            btnCancel.Clicked += async (s, e) =>
            {
                // close page
                await navigation.PopModalAsync();
                // pass empty result
                tcs.SetResult(null);
            };

            var slButtons = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { btnOk, btnCancel },
            };

            var layout = new StackLayout
            {
                Padding = new Thickness(0, 40, 0, 0),
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Orientation = StackOrientation.Vertical,
                Children = { lblTitle, lblMessage, txtInput, slButtons },
            };

            // create and show page
            var page = new ContentPage();
            page.Content = layout;
            navigation.PushModalAsync(page);
            // open keyboard
            txtInput.Focus();

            // code is waiting her, until result is passed with tcs.SetResult() in btn-Clicked
            // then proc returns the result
            return tcs.Task;
        }


    }
   
    }
