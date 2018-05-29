using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace EmissorApp
{
    public partial class MainPage : ContentPage
    {
        StackLayout currentLayout;


        const string localsite = "http://34.217.45.222/site/";
        public float d;
         public  MainPage()
        {
            InitializeComponent();
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
            Image a = new Image() { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand, Source = ImageSource.FromFile("splash.png"), Aspect = Aspect.AspectFit };
            
            
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
        public async void SplashLayout()
        {
            StackLayout splash = new StackLayout();
            splash.HorizontalOptions = LayoutOptions.FillAndExpand;
           
            Label lb = new Label() { Text = "Move Online", HorizontalTextAlignment = TextAlignment.Center, HorizontalOptions = LayoutOptions.FillAndExpand
            };
            lb.FontSize *= d* (Device.RuntimePlatform==Device.iOS?1.5f:1f)* 1.8f;
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
                            SplashLayout();
                        }
                        else if (data.Substring(0,6) == "Nready")
                        {
                            alert("Você digitou a senha correta, porém não está apto a acessar a plataforma de emissão do DAS neste momento, Fale com seu contador");
                                                       
                            SplashLayout();

                        }
                        else if (data.Length > 9 && data.Substring(0, 10) == "changepass")
                        {
                            MPage(data.Split('|')[1]);
                            Application.Current.Properties["cnpj"] = data.Split('|')[2];
                            Application.Current.Properties["pass"] = pass.Text;
                        }
                        else if (data.Substring(0, 1) == "S")
                        {
                            MPage(data.Split('|')[1]);
                            Application.Current.Properties["cnpj"] = data.Split('|')[2];
                            Application.Current.Properties["pass"] = pass.Text;
                        }
                          else {
                            alert("Erro no sistema");
                            SplashLayout();
                        }
                    }
                    catch (Exception e)
                    {
                        alert("Error + " + e.ToString());
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
            lb.FontSize *= d* (Device.RuntimePlatform==Device.iOS?1.5f:1f)* 1.8f;
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

            StackLayout mpage = new StackLayout() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            Label lb = new Label()
            {
                Text = "Move Online",
                HorizontalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            lb.FontSize *= d* (Device.RuntimePlatform==Device.iOS?1.5f:1f)* 1.8f;
            lb.BackgroundColor = Color.FromHex("51a279");
            lb.TextColor = Color.White;

            Label select = new Label()
            {
                Text = "Bem vindo "+name +"\nSelecione uma ação: ",
                HorizontalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            select.FontSize *= d* (Device.RuntimePlatform==Device.iOS?1.5f:1f)* 0.8f;
            mpage.Children.Add(lb);
            mpage.Children.Add(select);
            string[] a = new string[6] { "Emitir", "Consultar", "Serviços Online", "Ajuda e sugestões", "Sobre","Sair" };
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
                    TextColor = Color.White, ClassId = i + "",
                    Margin = new Thickness(20, 0, 20, 0)
                };
                bt1.Clicked += (sender,e)=>Bt1_Clicked(sender,e,name);
                
                bt1.FontSize *= d* (Device.RuntimePlatform==Device.iOS?1.5f:1f)* 0.8f;
                
                
                mpage.Children.Add(bt1);
            }
            sv.Content = mpage;
            this.Content = sv;
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
                    lb.FontSize *= d* (Device.RuntimePlatform==Device.iOS?1.5f:1f)* 1.8f;
                    lb.BackgroundColor = Color.FromHex("51a279");
                    lb.TextColor = Color.White;

                    mpage.Children.Add(lb);
                    mpage.Children.Add(new Label() { Text = "Preencha todos os campos para emitir o boleto :\n", HorizontalOptions = LayoutOptions.Center, HorizontalTextAlignment = TextAlignment.Center, FontSize = lb.FontSize * 0.5f });

                    Entry pserv = new Entry()
                    { 
                        Placeholder="Prestação de serviços",
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        HorizontalTextAlignment = TextAlignment.End
                         , VerticalOptions = LayoutOptions.FillAndExpand
                         ,Keyboard= Keyboard.Numeric

                    };
                    pserv.FontSize *= d* (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 0.8f;

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
                        Placeholder= "Venda de Mercadorias",
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        HorizontalTextAlignment = TextAlignment.End
                        ,
                        VerticalOptions = LayoutOptions.Start ,                      
                        Keyboard = Keyboard.Numeric

                    };
                  
                    rprod.Unfocused += delegate
                    {
                        rprod.Text = convert(rprod.Text);
                    };
                    rprod.Focused += delegate { if (!string.IsNullOrEmpty(rprod.Text) && rprod.Text.Contains(",")) rprod.Text = rprod.Text.Replace(",", ""); };
                   // rprod.TextColor = Color.FromHex("51a279");
                    rprod.FontSize *= d* (Device.RuntimePlatform==Device.iOS?1.5f:1f)* 0.8f;
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
                    for (int i = 1; i < DateTime.Now.Month; i++)
                        meses.Add(i > 9 ? i + "/2018" : "0" + i + "/2018");
                    foreach (string s in meses) date.Items.Add(s);

                    mpage.Children.Add(date);
                    for (int i = 0; i < 2; i++)
                    {
                        mpage.Children.Add(new Label() { Text = "" });
                    }
                    Button bt1 = new Button()
                    {
                        Text = "Solicitar",
                        BackgroundColor = Color.FromHex("51a279"),
                        HorizontalOptions = LayoutOptions.FillAndExpand
                    ,
                        TextColor = Color.White,
                        Margin = new Thickness(20, 0, 20, 0)
                    };
                    bt1.FontSize *= d* (Device.RuntimePlatform==Device.iOS?1.5f:1f)* 0.8f;
                    bt1.Clicked += async delegate {
                        if (!string.IsNullOrEmpty(rprod.Text) && !string.IsNullOrEmpty(pserv.Text) && date.SelectedItem != null)
                        {
                            bool ck = true;
                           string rp1 = rprod.Text.Replace(",", "");
                           string ps1= pserv.Text.Replace(",", "");
                            
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

                    bt2.FontSize *= d* (Device.RuntimePlatform==Device.iOS?1.5f:1f)* 0.8f;
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
                    lb1.FontSize *= d* (Device.RuntimePlatform==Device.iOS?1.5f:1f)* 1.8f;
                    lb1.BackgroundColor = Color.FromHex("51a279");
                    lb1.TextColor = Color.White;
                    mpage1.Children.Add(lb1);
                    mpage1.Children.Add(new Label() { Text = "Consulte aqui suas emissões", HorizontalOptions = LayoutOptions.Center, HorizontalTextAlignment = TextAlignment.Center, FontSize = lb1.FontSize * 0.5f });
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
                            Text = "Mês = " + ((int.Parse(rqs[i].Split('@')[0]) > 9) ? int.Parse(rqs[i].Split('@')[0]) + "/2018" : 0 + int.Parse(rqs[i].Split('@')[0]) + "/2018"),
                            HorizontalOptions = LayoutOptions.CenterAndExpand,
                            HorizontalTextAlignment = TextAlignment.Center,
                            Margin = new Thickness(20, 0, 20, 0)
                        };
                        mes.FontSize *= d* (Device.RuntimePlatform==Device.iOS?1.5f:1f)* 0.8f;
                        Label sts = new Label()
                        {
                            Text = "Status : " + rqs[i].Split('@')[1],
                            HorizontalOptions = LayoutOptions.CenterAndExpand,
                            HorizontalTextAlignment = TextAlignment.Center,
                            Margin = new Thickness(20, 0, 20, 0)
                        };
                        sts.FontSize *= d* (Device.RuntimePlatform==Device.iOS?1.5f:1f)* 0.8f;
                        mpage1.Children.Add(mes);
                        mpage1.Children.Add(sts);
                        if (!string.IsNullOrEmpty(rqs[i].Split('@')[2])) {
                            Button bolet = new Button()
                            {
                                Text = "Visualizar boleto",
                                BackgroundColor = Color.FromHex("51a279"),
                                HorizontalOptions = LayoutOptions.FillAndExpand,
                                TextColor = Color.White,
                                ClassId = i + "",
                                Margin = new Thickness(40, 0, 40, 0)
                            };
                            bolet.FontSize *= d* (Device.RuntimePlatform==Device.iOS?1.5f:1f)* 0.8f;
                            bolet.ClassId = rqs[i].Split('@')[2];
                            bolet.Clicked += Bolet_Clicked;
                            Grid g = new Grid() { HorizontalOptions = LayoutOptions.FillAndExpand };
                            Label pg1 = new Label() { Margin = new Thickness(30, 0, 30, 0), Text = "Pago :",  HorizontalOptions = LayoutOptions.Start };
                            pg1.FontSize *= d* (Device.RuntimePlatform==Device.iOS?1.5f:1f)* 0.8f;
                            g.Children.Add(pg1);

                            Xamarin.Forms.Switch pg2 = new Xamarin.Forms.Switch() { HorizontalOptions = LayoutOptions.End,Margin= new Thickness(0,0,20,0) };
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
                            bolet1.FontSize *= d* (Device.RuntimePlatform==Device.iOS?1.5f:1f)* 0.8f;
                            bolet1.ClassId = rqs[i].Split('@')[0];
                            mpage1.Children.Add(bolet1);
                            bolet1.Clicked += (sender, e) => Bolet1_Clicked(sender, e, name, pg);
                        }
                        for (int j = 0; j < 1; j++) mpage1.Children.Add(new Label() { Text = "" });
                        BoxView bx = new BoxView()
                        {
                            HorizontalOptions = LayoutOptions.FillAndExpand,                            
                            HeightRequest = 2
                            ,BackgroundColor= Color.Gray
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

                        bta.FontSize *= d* (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 0.8f;
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

                    btv.FontSize *= d* (Device.RuntimePlatform==Device.iOS?1.5f:1f)* 0.8f;
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
                    lb2.FontSize *= d* (Device.RuntimePlatform==Device.iOS?1.5f:1f)* 1.8f;
                    lb2.BackgroundColor = Color.FromHex("51a279");
                    lb2.TextColor = Color.White;
                    mpage2.Children.Add(lb2);
                    mpage2.Children.Add(new Label() { Text = "Solicite aqui um serviço a seu contador :", HorizontalOptions = LayoutOptions.Center, HorizontalTextAlignment = TextAlignment.Center, FontSize = lb2.FontSize * 0.5f });

                    string[] services = new string[] { "Abertura de Empresas", "Agendar um Atendimento on-line", "Ajuda para Emitir uma NF-e", "Ajuda para Emitir uma NFS-e", "Atualizar CNPJ", "Atualizar dados de cobrança", "Cadastro de Anuncios no CNPJ", "Cancelar CNPJ", "Certidão Negativa de Débitos", "Certificado Digital", "Contratar um Funcionário", "Declaração de Faturamento", "Demitir um Funcionário", "Enviar meu Funcionário de Férias", "Folha de Pagamento de Funcionários", "Folha de Pagamento de Sócios", "Imposto de Renda", "Licença de Funcionamento", "Minha Empresa Cresceu Preciso de Ajuda", "Não Recebi a Folha de Pagamento", "Não Recebi meu Parcelamento", "Não Recebi meus Impostos", "Preciso de Ajuda me Ligue", "Preciso de um Doc. Assinado pelo Contador", "Quero abrir um chamado estou com problemas", "Quero Indicar um Cliente e Ganhar Desconto", "Quero Regularizar meus Impostos", "Relatórios da minha Empresa", "Segunda via de Boleto da Mensalidade", "Tenho uma duvida preciso da Ajuda de um Contador" };
                    foreach(string s in services)
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
                case 3:
                    ScrollView sw2 = new ScrollView();
                    StackLayout mpage3 = new StackLayout() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
                    Label lb3 = new Label()
                    {
                        Text = "Move Online",
                        HorizontalTextAlignment = TextAlignment.Center,
                        HorizontalOptions = LayoutOptions.FillAndExpand
                    };
                    lb3.FontSize *= d* (Device.RuntimePlatform==Device.iOS?1.5f:1f)* 1.8f;
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
                                 Application.Current.Properties["cnpj"].ToString(), name);
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
                case 4:
                    ScrollView swv = new ScrollView();
                    StackLayout mpage4 = new StackLayout() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
                    Label lb4 = new Label()
                    {
                        Text = "Move Online",
                        HorizontalTextAlignment = TextAlignment.Center,
                        HorizontalOptions = LayoutOptions.FillAndExpand
                    };
                    lb4.FontSize *= d* (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 1.8f;
                    lb4.BackgroundColor = Color.FromHex("51a279");
                    lb4.TextColor = Color.White;

                    Label abt = new Label()
                    {
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        HorizontalTextAlignment = TextAlignment.Center,
                        Text = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?"
                        ,
                        Margin = new Thickness(20, 0, 20, 0)

                    };
                    abt.FontSize *= d* (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 0.8f;
                    Button btz = new Button()
                    {
                        Text = "Conheça nosso site",
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Margin = new Thickness(20, 0, 20, 0),
                        BackgroundColor = Color.FromHex("51a279"),
                        TextColor = Color.White

            };
                    btz.FontSize *= d* (Device.RuntimePlatform == Device.iOS ? 1.5f : 1f) * 0.8f;
                    btz.Clicked += delegate
                    {
                        Device.OpenUri(new Uri("http://moveonline.com.br/"));
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
                case 5:
                    Application.Current.Properties.Remove("cnpj");
                    Application.Current.Properties.Remove("pass");
                    SplashLayout();
                    break;
            }
        }

        private async void Btn_Clicked(object sender, EventArgs e,string name )
        {
            if ( await DisplayAlert("Move Online", "Você realmente deseja solicitar o serviço de " + ((Button)sender).Text, "Sim", "Não"))
            {
                string resu = await DependencyService.Get<INatives>().SolicitarServ(localsite + "email.php", ((Button)sender).Text,
                    Application.Current.Properties["cnpj"].ToString(), name);
                if (resu == "OK") alert("Sucesso ao solicitar o serviço");
                else alert("Erro no sistema");
            }
        }

        private async void Bolet1_Clicked(object sender, EventArgs e, string name, int pg)
        {
            if (await DisplayAlert("Move Online", "Você tem certeza que deseja recalcular a competência do mês " + (int.Parse(((Button)sender).ClassId) > 9 ? ((Button)sender).ClassId + "/2018" : "0" + ((Button)sender).ClassId + "/2018"), "Sim", "Não"))
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

    }
   
    }
