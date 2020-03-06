using System;
using System.Collections.Generic;
using System.Text;
using App_ConsultaCep.Servico.Modelo;
using System.Net;
using Newtonsoft.Json;

namespace App_ConsultaCep.Servico
{
    public class Viacepservico
    {
        public static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCep(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            return end;
        }
    }
}
