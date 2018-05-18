using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;
namespace EmissorApp
{
    public partial class MainPage : ContentPage
    {
        StackLayout currentLayout;


        const string localsite = "http://192.168.1.111/site/";

         public  MainPage()
        {
            InitializeComponent();
            currentLayout = new StackLayout();
            currentLayout.HorizontalOptions = LayoutOptions.FillAndExpand;
            this.Content = currentLayout;
            // SplashLayout();
            this.Padding = new Thickness(0, Device.RuntimePlatform == Device.iOS ? 20 : 0, 0, 5);
            // MPage();/
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
                    if (data == "N")
                    {
                        alert("Email ou senha incorretos");
                        SplashLayout();
                    }
                    else if (data == "Nready")
                    {
                        alert("Você digitou a senha correta, porém não está apto a acessar a plataforma de emissão do DAS neste momento, Fale com seu contador");
                        SplashLayout();                       
                        
                    }
                    else if (data.Length > 9 && data.Substring(0, 10) == "changepass")
                    {
                        MPage();
                        Application.Current.Properties["cnpj"] = data.Split('|')[2];
                        Application.Current.Properties["pass"] = pass;
                    }
                    else if (data.Substring(0, 1) == "S")
                    {
                        MPage();
                        Application.Current.Properties["cnpj"] = data.Split('|')[2];
                        Application.Current.Properties["pass"] = pass;
                    }
                    else alert("Erro no sistema");
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
            Label lb = new Label() { Text = "Emissor Das", HorizontalTextAlignment = TextAlignment.Center, HorizontalOptions = LayoutOptions.FillAndExpand
            };
            lb.FontSize *= 1.8f;
            lb.BackgroundColor = Color.FromHex("118DF0");
            lb.TextColor = Color.White;
            splash.Children.Add(lb);
            splash.Children.Add(new Label() { Text = "Digite suas credenciais para entrar no aplicativo, caso não possua consulte o seu consultor.", HorizontalOptions = LayoutOptions.Center, HorizontalTextAlignment = TextAlignment.Center, FontSize = lb.FontSize * 0.5f });
            for (int i = 0; i < 2; i++)
            {
                splash.Children.Add(new Label() { Text = "" });
            }
            Entry user = new Entry() { Margin = new Thickness(20, 0, 20, 0), HorizontalOptions = LayoutOptions.Fill, HorizontalTextAlignment = TextAlignment.Start, Placeholder = "CNPJ ou EMAIL" };
            user.FontSize *= 0.7f;

            splash.Children.Add(user);
            Entry pass = new Entry() { Margin = new Thickness(20, 0, 20, 0), HorizontalOptions = LayoutOptions.Fill, HorizontalTextAlignment = TextAlignment.Start, Placeholder = "Senha", IsPassword = true };
            pass.FontSize *= 0.7f;
            splash.Children.Add(pass);
            for (int i = 0; i < 1; i++)
            {
                splash.Children.Add(new Label() { Text = "" });
            }
            Button bt = new Button()
            {
                Text = "Entrar",
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex("118DF0"),

            };
            bt.FontSize *= 0.7f;
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
                    lb2.FontSize *= 1.0f;

                    lb2.TextColor = Color.FromHex("118DF0");
                    splash.Children.Add(lb2);
                    this.Content = splash;
                    await Task.Delay(1000);
                    try
                    {
                        string data = await DependencyService.Get<INatives>().Login(localsite + "login.php", user.Text, pass.Text);
                        if (data == "N")
                        {
                            alert("Email ou senha incorretos");
                            SplashLayout();
                        }
                        else if (data == "Nready")
                        {
                            alert("Você digitou a senha correta, porém não está apto a acessar a plataforma de emissão do DAS neste momento, Fale com seu contador");
                                                       
                            SplashLayout();

                        }
                        else if (data.Length > 9 && data.Substring(0, 10) == "changepass")
                        {
                            MPage();
                            Application.Current.Properties["cnpj"] = data.Split('|')[2];
                            Application.Current.Properties["pass"] = pass.Text;
                        }
                        else if (data.Substring(0, 1) == "S")
                        {
                            MPage();
                            Application.Current.Properties["cnpj"] = data.Split('|')[2];
                            Application.Current.Properties["pass"] = pass.Text;
                        }
                        else alert("Erro no sistema");
                    }
                    catch (Exception e)
                    {
                        alert("Error + " + e.ToString());
                    }
                }
                else alert("Preencha todos os campos");
            };
            Label esq = new Label() { Text = "Esqueceu sua senha ?", FontSize = lb.FontSize * 0.4f, TextColor = Color.FromHex("118DF0"), HorizontalTextAlignment = TextAlignment.Center, HorizontalOptions = LayoutOptions.Center };
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
            DisplayAlert("Emissor Das:", s, "Ok");
        }
        async void EsqueceuSenha()
        {
            StackLayout esqpass = new StackLayout() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            Label lb = new Label()
            {
                Text = "Emissor Das",
                HorizontalTextAlignment = TextAlignment.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            lb.FontSize *= 1.8f;
            lb.BackgroundColor = Color.FromHex("118DF0");
            lb.TextColor = Color.White;
            esqpass.Children.Add(lb);
            esqpass.Children.Add(new Label() { Text = "Digite o CNPJ cadastrado na conta para recuperar sua senha, caso tenha esquecido contate seu consultor", HorizontalOptions = LayoutOptions.Center, HorizontalTextAlignment = TextAlignment.Center, FontSize = lb.FontSize * 0.5f });
            for (int i = 0; i < 2; i++)
            {
                esqpass.Children.Add(new Label() { Text = "" });
            }
            Entry user = new Entry() { Margin = new Thickness(20, 0, 20, 0), HorizontalOptions = LayoutOptions.Fill, HorizontalTextAlignment = TextAlignment.Start, Placeholder = "CNPJ" };
            user.FontSize *= 0.7f;
            Button bt = new Button()
            {
                Text = "Enviar",
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex("118DF0"),

            };
            bt.FontSize *= 0.7f;
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
            Label esq = new Label() { Text = "Voltar", FontSize = lb.FontSize * 0.4f, TextColor = Color.FromHex("118DF0"), HorizontalTextAlignment = TextAlignment.Center, HorizontalOptions = LayoutOptions.Center };
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += delegate
            {
                SplashLayout();
            };
            esq.GestureRecognizers.Add(tap);
            esqpass.Children.Add(esq);

            this.Content = esqpass;
        }
        async void MPage()
        {
            ScrollView sv = new ScrollView();

            StackLayout mpage = new StackLayout() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            Label lb = new Label()
            {
                Text = "Emissor Das",
                HorizontalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            lb.FontSize *= 1.8f;
            lb.BackgroundColor = Color.FromHex("118DF0");
            lb.TextColor = Color.White;

            Label select = new Label()
            {
                Text = "Selecione uma ação: ",
                HorizontalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            select.FontSize *= 0.8f;
            mpage.Children.Add(lb);
            mpage.Children.Add(select);
            string[] a = new string[6] { "Emitir Das", "Consultar Emissões", "Solicitar serviços", "Ajuda e sujestões", "Configurações", "Sobre" };
            int maior = 0;
            for (int i = 0; i < a.Length; i++)
            {

                Button bt1 = new Button()
                {
                    Text = a[i],
                    BackgroundColor = Color.FromHex("118DF0"),
                    HorizontalOptions = LayoutOptions.FillAndExpand
                    ,
                    TextColor = Color.White, ClassId = i + "",
                    Margin = new Thickness(20, 0, 20, 0)
                };
                bt1.Clicked += Bt1_Clicked;
                
                bt1.FontSize *= 0.8f;
                
                
                mpage.Children.Add(bt1);
            }
            sv.Content = mpage;
            this.Content = sv;
        }

        private void Bt1_Clicked(object sender, EventArgs e)
        {
            MenuPageAsync(int.Parse(((Button)sender).ClassId));

        }


/* Unmerged change from project 'EmissorApp.iOS'
Before:
        void MenuPage(int pg)
After:
        void MenuPageAsync(int pg)
*/
        async Task MenuPageAsync(int pg)
        {
            switch (pg){
                case 0:
                    
                    StackLayout mpage = new StackLayout() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
                    Label lb = new Label()
                    {
                        Text = "Emissor Das",
                        HorizontalTextAlignment = TextAlignment.Center,
                        HorizontalOptions = LayoutOptions.FillAndExpand
                    };
                    lb.FontSize *= 1.8f;
                    lb.BackgroundColor = Color.FromHex("118DF0");
                    lb.TextColor = Color.White;                  

                    mpage.Children.Add(lb);
                    mpage.Children.Add(new Label() { Text = "Preencha todos os campos para emitir o boleto", HorizontalOptions = LayoutOptions.Center, HorizontalTextAlignment = TextAlignment.Center, FontSize = lb.FontSize * 0.5f });
         
                   Entry pserv = new Entry()
                    { Placeholder = "Prestação de serviços",
                        HorizontalOptions = LayoutOptions.EndAndExpand,
                        HorizontalTextAlignment = TextAlignment.End
                        ,VerticalOptions= LayoutOptions.Start
                        , Margin = new Thickness(20, 0, 20, 0)

                    };
                    pserv.Focused += delegate { if(!string.IsNullOrEmpty(pserv.Text) && pserv.Text.Contains(",")) pserv.Text = pserv.Text.Replace(",", ""); };

                    pserv.TextColor= Color.FromHex("118DF0");
                    pserv.Unfocused += delegate
                    {
                        pserv.Text = convert(pserv.Text);
                    };
                    Grid g1 = new Grid()
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand
                    };
                    g1.Children.Add(pserv);
                    Label rs = new Label()
                    {
                        Text = " R$ :", HorizontalOptions = LayoutOptions.Start,VerticalTextAlignment=TextAlignment.Center, HorizontalTextAlignment = TextAlignment.Start,FontSize= pserv.FontSize
                    };
                      Label rs2 = new Label()
                    {
                        Text = " R$ :", HorizontalOptions = LayoutOptions.Start,VerticalTextAlignment=TextAlignment.Center, HorizontalTextAlignment = TextAlignment.Start,FontSize= pserv.FontSize
                    };
                    g1.Children.Add(rs2);
                    mpage.Children.Add(g1);

                    Entry rprod = new Entry()
                    {
                        Placeholder = "Revenda de produtos",
                        HorizontalOptions = LayoutOptions.EndAndExpand,
                        HorizontalTextAlignment = TextAlignment.End
                        ,
                        VerticalOptions = LayoutOptions.Start
                        ,
                        Margin = new Thickness(20, 0, 20, 0)
                        
                    };
                    rprod.Unfocused += delegate
                    {
                        rprod.Text = convert(rprod.Text);
                    };
                    rprod.Focused += delegate { if (!string.IsNullOrEmpty(rprod.Text)&&rprod.Text.Contains(",")) rprod.Text = rprod.Text.Replace(",", ""); };
                    rprod.TextColor = Color.FromHex("118DF0"); 
                    rprod.FontSize *= 1f;
                   Grid g2 =  new Grid()
                   {
                       HorizontalOptions = LayoutOptions.FillAndExpand
                   };
                    g2.Children.Add(rprod);
                    g2.Children.Add(rs);
                    mpage.Children.Add(g2);

                    for (int i = 0; i < 2; i++) mpage.Children.Add(new Label() { Text = "" });

                    Picker date = new Picker()
                    {
                        Title = "Selecione o mês",
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Margin = new Thickness(20, 0, 20, 0)
                        , TextColor = rprod.TextColor

                    };List<string> meses = new List<string>();
                    for (int i = 1; i < DateTime.Now.Month; i++)
                        meses.Add(i > 9 ? i + "/2018" : "0" + i + "/2018");
                    foreach (string s in meses) date.Items.Add(s);
                    
                    mpage.Children.Add(date);
                    Button bt1 = new Button()
                    {
                        Text = "Solicitar",
                        BackgroundColor = Color.FromHex("118DF0"),
                        HorizontalOptions = LayoutOptions.FillAndExpand
                    ,
                        TextColor = Color.White,
                        Margin = new Thickness(20, 0, 20, 0)
                    };
                    bt1.FontSize *= 0.8f;
                    bt1.Clicked += async delegate {
                        if (!string.IsNullOrEmpty(rprod.Text) && !string.IsNullOrEmpty(pserv.Text) && date.SelectedItem != null)
                        {
                            bool ck = true;
                            rprod.Text = rprod.Text.Replace(",", "");
                            pserv.Text = rprod.Text.Replace(",", "");
                            if (int.Parse(pserv.Text) + int.Parse(rprod.Text) > 50000)
                                ck = await DisplayAlert("Emissor Das", "Você digitou uma quantia acima do valor de R$: 50.000,00 , você tem certeza que deseja continuar?", "Continuar", "Cancelar");
                                
                            if (ck)
                            {
                                string ask= await DependencyService.Get<INatives>().HasDas(localsite+"login.php", (date.SelectedIndex + 1) + "", Application.Current.Properties["cnpj"].ToString());
                                if (ask == "ask" || ask == "OK")
                                {
                                    
                                    if (ask == "ask")
                                    {
                                        bool chk = false;
                                        chk = await DisplayAlert("Emissor Das", "Já existe uma emissão o mês "+(date.SelectedIndex+1)+" para essa data, deseja recalcular?", "Continuar","Cancelar");
                                         if (chk)
                                        {
                                            string resu = await DependencyService.Get<INatives>().EmitDass(localsite + "login.php", rprod.Text, pserv.Text, date.SelectedIndex + 1 + "", Application.Current.Properties["cnpj"].ToString(), ask);
                                            if (resu == "OK")
                                            {
                                                alert("Sucesso ao fazer o pedido, Aguarde o resultado na aba Consultar Emissões");
                                                MenuPageAsync(1);
                                            }
                                            else alert("Erro no sistema");
                                        }                                    
                                    }
                                    else {
                                        string resu = await DependencyService.Get<INatives>().EmitDass(localsite + "login.php", rprod.Text, pserv.Text, date.SelectedIndex + 1 + "", Application.Current.Properties["cnpj"].ToString(), ask);
                                        if (resu == "OK")
                                        {
                                            alert("Sucesso ao fazer o pedido, Aguarde o resultado na aba Consultar Emissões");
                                            MenuPageAsync(1);
                                        }
                                        else alert("Erro no sistema");
                                    }
                                }
                                else alert("Erro no sistema");

                            }

                        }
                        else alert("Preencha todos os campos corretamente");

                    };
                    mpage.Children.Add(bt1);
                    Button bt2 = new Button()
                    {
                        Text = "Voltar",
                        BackgroundColor = Color.FromHex("118DF0"),
                        HorizontalOptions = LayoutOptions.FillAndExpand
                   ,
                        TextColor = Color.White,
                        Margin = new Thickness(20, 0, 20, 0)
                    };
                   
                    bt2.FontSize *= 0.8f;
                    bt2.Clicked += delegate { MPage(); };
                    mpage.Children.Add(bt2);
                    this.Content = mpage;

                    break;
                case 1:
                    ScrollView sw = new ScrollView();
                    StackLayout mpage1 = new StackLayout() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
                    Label lb1 = new Label()
                    {
                        Text = "Emissor Das",
                        HorizontalTextAlignment = TextAlignment.Center,
                        HorizontalOptions = LayoutOptions.FillAndExpand
                    };
                    lb1.FontSize *= 1.8f;
                    lb1.BackgroundColor = Color.FromHex("118DF0");
                    lb1.TextColor = Color.White;
                    mpage1.Children.Add(lb1);
                    mpage1.Children.Add(new Label() { Text = "Consulte aqui suas emissões", HorizontalOptions = LayoutOptions.Center, HorizontalTextAlignment = TextAlignment.Center, FontSize = lb1.FontSize * 0.5f });
                    
                    sw.Content = mpage1;
                    this.Content = sw;
                    Button bt3 = new Button()
                    {
                        Text = "Voltar",
                        BackgroundColor = Color.FromHex("118DF0"),
                        HorizontalOptions = LayoutOptions.FillAndExpand
                   ,
                        TextColor = Color.White,
                        Margin = new Thickness(20, 0, 20, 0)
                    };

                    bt3.FontSize *= 0.8f;
                    bt3.Clicked += delegate { MPage(); };
                    
                    string reqs = await DependencyService.Get<INatives>().GetRequests(localsite + "login.php", Application.Current.Properties["cnpj"].ToString());
                    string[] rqs = reqs.Split('|');
                    for (int i =0;i<rqs.Length;i++)
                    {
                        Label mes = new Label()
                        {
                            Text = "Mês = " + ((int.Parse(rqs[i].Split('@')[0]) > 9) ? int.Parse(rqs[i].Split('@')[0]) + "/2018" : 0 + int.Parse(rqs[i].Split('@')[0]) + "/2018"),
                            HorizontalOptions = LayoutOptions.CenterAndExpand,
                            HorizontalTextAlignment = TextAlignment.Center,
                            Margin = new Thickness(20, 0, 20, 0)
                        };
                        mes.FontSize *= 0.8f;
                        Label sts = new Label()
                        {
                            Text = "Status : " + rqs[i].Split('@')[1],
                            HorizontalOptions = LayoutOptions.CenterAndExpand,
                            HorizontalTextAlignment = TextAlignment.Center,
                            Margin = new Thickness(20, 0, 20, 0)
                        };
                        sts.FontSize *= 0.8f;
                        mpage1.Children.Add(mes);
                        mpage1.Children.Add(sts);
                        if (!string.IsNullOrEmpty(rqs[i].Split('@')[2])){
                            Button bolet = new Button()
                            {
                                Text = "Baixar boleto",
                                BackgroundColor = Color.FromHex("118DF0"),
                                HorizontalOptions = LayoutOptions.Center,
                                TextColor = Color.White,
                                ClassId = i + "",
                                Margin = new Thickness(20, 0, 20, 0)
                            };                            
                            bolet.FontSize *= 0.8f;
                            mpage1.Children.Add(bolet);
                            Grid g = new Grid() { HorizontalOptions = LayoutOptions.FillAndExpand };
                            g.Children.Add()
                            Button bolet1 = new Button()
                            {
                                Text = "Recalcular",
                                BackgroundColor = Color.FromHex("118DF0"),
                                HorizontalOptions = LayoutOptions.Center,
                                TextColor = Color.White,
                                ClassId = i + "",
                                Margin = new Thickness(20, 0, 20, 0)
                            };
                            bolet1.FontSize *= 0.8f;
                            mpage1.Children.Add(bolet1);
                        }
                    }

                    mpage1.Children.Add(bt3);
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
            }
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
