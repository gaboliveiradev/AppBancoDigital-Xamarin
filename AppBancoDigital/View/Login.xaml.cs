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
    public partial class Login : ContentPage
    {
        public void onOfLoader(bool s)
        {
            //loader.IsVisible = s;
            //loader.IsRunning = s;
        }

        public void config_inicial()
        {
            logo.TranslateTo(0, 20);
            lbl__titulo.TranslateTo(-300, 0);
            lbl__subtitulo.TranslateTo(270, 0);
        }

        public Login()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            

            // Adicionando as imagens
            details.Source = ImageSource.FromResource("AppBancoDigital.Assets.details.png");
            logo.Source = ImageSource.FromResource("AppBancoDigital.Assets.logo_back_purple.png");
            img__cpf.Source = ImageSource.FromResource("AppBancoDigital.Assets.cpf.png");

            config_inicial();
        }

        protected async override void OnAppearing()
        {
            // Efeito de movimentar a nossa img Details para cima.
            await details.TranslateTo(0, -60, 2000, Easing.Linear);

            await lbl__titulo.TranslateTo(0, 0, 800, Easing.CubicOut);
            await lbl__subtitulo.TranslateTo(0, 0, 800, Easing.CubicOut);
        }
    }
}