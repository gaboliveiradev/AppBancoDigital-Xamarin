using AppBancoDigital.DataService;
using AppBancoDigital.Model;
using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBancoDigital.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        int idCorrentista = (int)Application.Current.Properties["id_correntista"];
        string nomeCorrentista = (string)Application.Current.Properties["nome_correntista"];

        public void config_initial_imagens()
        {
            img_ocultar.Source = ImageSource.FromResource("AppBancoDigital.Assets.ocultar.png");
            img_mostrar.Source = ImageSource.FromResource("AppBancoDigital.Assets.olho-aberto.png");
            img_ocultado_saldo.Source = ImageSource.FromResource("AppBancoDigital.Assets.ocultado.png");
            img_ocultado_limite.Source = ImageSource.FromResource("AppBancoDigital.Assets.ocultado.png");
            img_area_pix.Source = ImageSource.FromResource("AppBancoDigital.Assets.pix.png");
            img_transferir.Source = ImageSource.FromResource("AppBancoDigital.Assets.transferir.png");
            img_cobrar.Source = ImageSource.FromResource("AppBancoDigital.Assets.cobrar.png");
            img_limite.Source = ImageSource.FromResource("AppBancoDigital.Assets.limite.png");
        }

        public Home()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            frm_saldo.TranslateTo(0, 60);
            config_initial_imagens();
        }

        protected async override void OnAppearing()
        {
            Conta c = await DataServiceConta.GetDataOfConta(new Conta()
            {
                id_correntista = idCorrentista,
            }, "/conta/dados");

            if (c != null)
            {
                lbl_saldo.Text = c.saldo.ToString("C", new CultureInfo("pt-BR"));
                lbl_limite.Text = c.limite.ToString("C", new CultureInfo("pt-BR"));
                lbl_nome.Text = $"Bem Vindo(a), {nomeCorrentista}.";
            }
            else
            {
                await DisplayAlert("Erro", "Houve um problema ao ler os dados de sua conta!", "OK");
            }
        }

        private void onClickOcultarSaldo_Tapped(object sender, EventArgs e)
        {
            img_mostrar.IsVisible = true;
            img_ocultar.IsVisible = false;

            lbl_saldo.IsVisible = false;
            lbl_limite.IsVisible = false;
            img_ocultado_saldo.IsVisible = true;
            img_ocultado_limite.IsVisible = true;
        }

        private void onClickMostrarSaldo_Tapped(object sender, EventArgs e)
        {
            img_mostrar.IsVisible = false;
            img_ocultar.IsVisible = true;

            lbl_saldo.IsVisible = true;
            lbl_limite.IsVisible = true;
            img_ocultado_saldo.IsVisible = false;
            img_ocultado_limite.IsVisible = false;
        }

        private void onClickAreaPix_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("Area Pix", "", "OK");
        }

        private void onClickTransferir_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("Transferir", "", "OK");
        }

        private void onClickCobrar_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("Cobrar", "", "OK");
        }

        private void onClickLimite_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("Gerenciar Limite", "", "OK");
        }
    }
}