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
        }
    }
}