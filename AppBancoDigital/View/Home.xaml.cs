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
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            frm_saldo.TranslateTo(0, 60);
            img_ocultar.Source = ImageSource.FromResource("AppBancoDigital.Assets.ocultar.png");
            img_mostrar.Source = ImageSource.FromResource("AppBancoDigital.Assets.olho-aberto.png");
            img_ocultado.Source = ImageSource.FromResource("AppBancoDigital.Assets.ocultado.png");
        }

        private void onClickOcultarSaldo_Tapped(object sender, EventArgs e)
        {
            img_mostrar.IsVisible = true;
            img_ocultar.IsVisible = false;

            lbl_saldo.IsVisible = false;
            img_ocultado.IsVisible = true;
        }

        private void onClickMostrarSaldo_Tapped(object sender, EventArgs e)
        {
            img_mostrar.IsVisible = false;
            img_ocultar.IsVisible = true;

            lbl_saldo.IsVisible = true;
            img_ocultado.IsVisible = false;
        }
    }
}