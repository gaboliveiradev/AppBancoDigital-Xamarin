using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBancoDigital.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicialPix : ContentPage
    {
        public InicialPix()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            img_transferir.Source = ImageSource.FromResource("AppBancoDigital.Assets.transferir-dinheiro.png");
            img_programar.Source = ImageSource.FromResource("AppBancoDigital.Assets.agenda.png");
            img_copia_cola.Source = ImageSource.FromResource("AppBancoDigital.Assets.interface.png");
            img_qr_code.Source = ImageSource.FromResource("AppBancoDigital.Assets.codigo-qr.png");

            img_cobrar.Source = ImageSource.FromResource("AppBancoDigital.Assets.charges.png");
            img_depositar.Source = ImageSource.FromResource("AppBancoDigital.Assets.deposito.png");
            img_close.Source = ImageSource.FromResource("AppBancoDigital.Assets.fechar.png");
            img_info.Source = ImageSource.FromResource("AppBancoDigital.Assets.info.png");
            img_chevron_left.Source = ImageSource.FromResource("AppBancoDigital.Assets.chevron_left.png");
            img_chevron_left_configurar.Source = ImageSource.FromResource("AppBancoDigital.Assets.chevron_left.png");
        }

        private async void onClickCloseAreaPix_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Home());
        }

        private void hadleClickInfo_Tapped(object sender, EventArgs e)
        {

        }
    }
}