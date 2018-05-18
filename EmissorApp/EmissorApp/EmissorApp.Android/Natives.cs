using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using EmissorApp.Droid;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net;
using System.Threading.Tasks;

[assembly: Dependency(typeof(Natives))]
namespace EmissorApp.Droid
{
    class Natives : INatives
    {
        public async Task<string> EmitDass(string site,string rprod, string pserv, string date, string cpnj,string tt)
        {
            WebClient wb = new WebClient();
            wb.Encoding = Encoding.UTF8;
            var reqparm = new System.Collections.Specialized.NameValueCollection();
            reqparm.Add("servID", "772");
            reqparm.Add("cnpj", cpnj);
            reqparm.Add("pserv", pserv);
            reqparm.Add("rvend", rprod);
            reqparm.Add("mes", date);
            reqparm.Add("tt", tt);
            byte[] responsebytes = await wb.UploadValuesTaskAsync(site, "POST", reqparm);
            string responsebody = Encoding.UTF8.GetString(responsebytes);
            if (responsebody == "OK")
            {
                var reqparm2 = new System.Collections.Specialized.NameValueCollection();
                reqparm2.Add("servID", "912");
                reqparm2.Add("cnpj", cpnj);
                reqparm2.Add("pserv", pserv);
                reqparm2.Add("rprod", rprod);
                reqparm2.Add("mes", date);
                reqparm2.Add("status", "Gerando boleto");
                reqparm2.Add("pago", "0");
                byte[] responsebytes2 = await wb.UploadValuesTaskAsync(site, "POST", reqparm2);
                string responsebody2 = Encoding.UTF8.GetString(responsebytes2);
                return responsebody2;
            }
            else return responsebody;
        }

        public async Task<string> esqsenha(string url,string email)
        {
            WebClient wb = new WebClient();
            wb.Encoding = Encoding.UTF8;
            var reqparm = new System.Collections.Specialized.NameValueCollection();
            reqparm.Add("servID", "103");
            reqparm.Add("cnpj", email);           
            byte[] responsebytes = await wb.UploadValuesTaskAsync(url, "POST", reqparm);
            string responsebody = Encoding.UTF8.GetString(responsebytes);
            return responsebody;
        }

        public async  Task<string> GetRequests(string site, string cnpj)
        {
            WebClient wb = new WebClient();
            wb.Encoding = Encoding.UTF8;
            var reqparm = new System.Collections.Specialized.NameValueCollection();
            reqparm.Add("servID", "183");
            reqparm.Add("cnpj", cnpj);
            byte[] responsebytes = await wb.UploadValuesTaskAsync(site, "POST", reqparm);
            string responsebody = Encoding.UTF8.GetString(responsebytes);
            return responsebody;
        }

        public async Task<string> HasDas(string site, string mes, string cnpj)
        {
            WebClient wb = new WebClient();
            wb.Encoding = Encoding.UTF8;
            var reqparm = new System.Collections.Specialized.NameValueCollection();
            reqparm.Add("servID", "3156");
            reqparm.Add("cnpj", cnpj);
            reqparm.Add("mes", mes);
            byte[] responsebytes = await wb.UploadValuesTaskAsync(site, "POST", reqparm);
            string responsebody = Encoding.UTF8.GetString(responsebytes);
            return responsebody;
        }

        public async Task<string> Login(string url,string login,string pass)
        {
            long l;
            WebClient wb = new WebClient();
            wb.Encoding = Encoding.UTF8;
            if (!long.TryParse(login, out l))
            {
                var reqparm1 = new System.Collections.Specialized.NameValueCollection();
                reqparm1.Add("servID", "606");
                reqparm1.Add("login", login);
                reqparm1.Add("pass", pass);
                byte[] responsebytes1 = await wb.UploadValuesTaskAsync(url, "POST", reqparm1);
                string responsebody1 = Encoding.UTF8.GetString(responsebytes1);
                l = long.Parse(responsebody1);
            }
            Console.WriteLine("hey converti" + l);

                    
           
            var reqparm = new System.Collections.Specialized.NameValueCollection();
            reqparm.Add("servID","593");
            reqparm.Add("login", l.ToString());
            reqparm.Add("pass",pass);
            byte[] responsebytes = wb.UploadValues(url, "POST", reqparm);
            string responsebody = Encoding.UTF8.GetString(responsebytes);
            return responsebody+"|"+l;

        }
        
    }
}