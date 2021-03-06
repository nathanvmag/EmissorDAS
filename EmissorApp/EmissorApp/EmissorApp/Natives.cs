﻿using System;
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
        Task<string> Save(string site, string cnpj, string date, string pg);
        Task<string> Recalculate(string site, string cnpj, string mes);
        Task<string> SolicitarServ(string site, string serv, string cnpj, string name,string descri);
        Task<string> getfiles(string site, string cnpj, string mes);
        Task<string> getChamadosAsync(string site, string cnpj);
        Task<string> encerrarChamadoAsync(string site, string id);
        float density();
    }
}
