using ConsultarCep.Service;
using ConsultarCep.Service.Model;
using System;
using Xamarin.Forms;

namespace ConsultarCep
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BtnBuscarCep.Clicked += BuscarCep;
        }

        private void BuscarCep(object sender, EventArgs args)
        {
            var cep = Cep.Text.Trim();
            if (isValidCEP(cep))
            {
                try
                {
                    Endereco endereco = ViaCepService.BuscarEnderecoViaCEP(cep);

                    if (endereco != null)
                    {
                        lbResultado.Text = string.Format("Endereço: {0}, {1}, {2}", endereco.Localidade, endereco.Uf, endereco.Logradouro);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "Endereço não encontrado para o cepe informado: " + cep, "ok");
                    }
                }
                catch (Exception e)
                {
                    DisplayAlert("ERRO", "Erro Crítico", "ok");
                }
            }
        }

        private bool isValidCEP(string cep)
        {
            var NovoCep = 0;
            if (!int.TryParse(cep, out NovoCep))
            {
                DisplayAlert("ERRO", "CEP inválido, deve conter apenas numeros", "ok");
                return false;
            }

            if (cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP inválido, deve conter 8 caracteres", "ok");
                return false;
            }

            return true;
        }
    }
}
