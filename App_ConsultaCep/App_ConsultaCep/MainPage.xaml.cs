using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App_ConsultaCep.Servico.Modelo;
using App_ConsultaCep.Servico;

namespace App_ConsultaCep
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            cBotao.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            string cep = cCep.Text.Trim();
            if (isvalidaCEP(cep))
            {
                try
                {
                    Endereco end = Viacepservico.BuscarEnderecoViaCep(cep);
                    if (end != null)
                    {
                        cResultado.Text string.Format("Endereço:" + "{2} de {3} {0},{1}", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("Erro!", "O endereço não foi encontrado" + "Para o CEP informado" + cep, "OK");
                    }
                    catch (Exception e)
                {
                    DisplayAlert("Erro Critico", e.Message, "OK");
                }
                }
            }
        }

        private bool isvalidaCEP(string cep)
        {
            bool valido = true;
            if (cep.Length != 8)
            {
                DisplayAlert("Erro!","CEP Inválido ou menor que 8 digitos","OK");
                valido = false;
            }

            int NovoCEP = 0;
            if (!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("Erro!", "O cep deve ser composto apenas por números", "OK");
                valido = false;
            }
            return valido;

        }
    }
}
