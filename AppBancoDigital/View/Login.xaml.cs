using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBancoDigital.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        uint time_animation = 800;

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
            stc__cpf.TranslateTo(-375, 0);
            stc__password.TranslateTo(375, 0);
            stc__btn__logar.TranslateTo(0, 220);
        }

        public async void hideLogin()
        {
            await lbl__titulo.TranslateTo(-300, 0, time_animation, Easing.CubicOut);
            await lbl__subtitulo.TranslateTo(270, 0, time_animation, Easing.CubicOut);
            await stc__cpf.TranslateTo(-375, 0, time_animation, Easing.CubicOut);
            await stc__password.TranslateTo(375, 0, time_animation, Easing.CubicOut);
            await stc__btn__logar.TranslateTo(0, 220, time_animation, Easing.CubicOut);
            logo.IsVisible = false;
            await details.TranslateTo(0, -300, time_animation, Easing.CubicOut);
            gridLogin.IsVisible = false;
        }

        public Login()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            // Adicionando as imagens
            details.Source = ImageSource.FromResource("AppBancoDigital.Assets.details.png");
            logo.Source = ImageSource.FromResource("AppBancoDigital.Assets.logo_back_purple.png");
            img__cpf.Source = ImageSource.FromResource("AppBancoDigital.Assets.cpf.png");
            img__password.Source = ImageSource.FromResource("AppBancoDigital.Assets.password.png");

            config_inicial();
        }

        protected async override void OnAppearing()
        {
            // Efeito de movimentar a nossa img Details para cima.
            await details.TranslateTo(0, -60, 2000, Easing.Linear);

            await lbl__titulo.TranslateTo(0, 0, time_animation, Easing.CubicOut);
            await lbl__subtitulo.TranslateTo(0, 0, time_animation, Easing.CubicOut);
            await stc__cpf.TranslateTo(0, 0, time_animation, Easing.CubicOut);
            await stc__password.TranslateTo(0, 0, time_animation, Easing.CubicOut);
            await stc__btn__logar.TranslateTo(0, 0, time_animation, Easing.CubicOut);
        }

        private void onClickLabelCriarConta_Tapped(object sender, EventArgs e)
        {
            hideLogin();
        }
    }
}