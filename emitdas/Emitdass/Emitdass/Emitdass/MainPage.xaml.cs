using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using System.Diagnostics;

namespace Emitdass
{
	public partial class MainPage : ContentPage
	{
        StackLayout currentLayout;
        HttpClient client;

        string localsite = "http://34.217.45.222/site/";

        public MainPage()
        {
            InitializeComponent();
            currentLayout = new StackLayout();
            currentLayout.HorizontalOptions = LayoutOptions.FillAndExpand;
            this.Content = currentLayout;
            SplashLayout();
            client = new HttpClient();
            client.Timeout = new TimeSpan(15000);
        }
        public void SplashLayout()
        {
            StackLayout splash = new StackLayout();
            splash.HorizontalOptions = LayoutOptions.FillAndExpand;
            Label lb = new Label()
            {
                Text = "Emissor Das",
                HorizontalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand
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
            Entry user = new Entry() { HorizontalOptions = LayoutOptions.Fill, HorizontalTextAlignment = TextAlignment.Start, Placeholder = "CNPJ ou EMAIL" };
            user.FontSize *= 0.7f;

            splash.Children.Add(user);
            Entry pass = new Entry() { HorizontalOptions = LayoutOptions.Fill, HorizontalTextAlignment = TextAlignment.Start, Placeholder = "Senha", IsPassword = true };
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
            this.Content = splash;
            bt.Clicked += delegate
            {
                
                Login("ahh", "jdjsh");

            };
        }
        async void Login(string user, string pass)
        {
            await DisplayAlert("hdashudh", "djsaj", "jjj");
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("login", "aaa"),
                new KeyValuePair<string, string>("pass", "aaa")

        });
            var response = await client.PostAsync(localsite + "login.php", content);
           // string a = await response.Content.ReadAsStringAsync();
            await DisplayAlert("ahhh","kk", "heyy");
        }

    }
}
