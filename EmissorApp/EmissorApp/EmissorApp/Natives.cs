using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmissorApp
{
    public interface INatives
    {
        Task<string> Login(string url, string login, string pass);
        Task<string> esqsenha(string url,string email);
        Task<string> EmitDass(string site ,string rprod,string pserv,string date,string cpnj,string tt);
        Task<string> HasDas(string site, string mes, string cnpj);
        Task<string> GetRequests(string site, string cnpj);
    }
}
