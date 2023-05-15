using AppBancoDigital.DataService;
using AppBancoDigital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBancoDigital.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginRegister : ContentPage
    {
        uint time_animation = 200;

        public void onOfLoader(bool s, string type)
        {
            if(type == "r")
            {
                act__loader__register.IsVisible = s;
                act__loader__register.IsRunning = s;
            } else if(type == "l")
            {
                act__loader__login.IsVisible = s;
                act__loader__login.IsRunning = s;
            }
        }

        public void config_initial_app()
        {
            // Adicionando as imagens
            details.Source = ImageSource.FromResource("AppBancoDigital.Assets.details.png");
            logo.Source = ImageSource.FromResource("AppBancoDigital.Assets.logo_back_purple.png");

            img__cpf__login.Source = ImageSource.FromResource("AppBancoDigital.Assets.cpf.png");
            img__cpf__register.Source = ImageSource.FromResource("AppBancoDigital.Assets.cpf.png");

            img__password__login.Source = ImageSource.FromResource("AppBancoDigital.Assets.password.png");
            img__password__register.Source = ImageSource.FromResource("AppBancoDigital.Assets.password.png");
            img__password__confirmar__register.Source = ImageSource.FromResource("AppBancoDigital.Assets.password.png");

            img__nome__register.Source = ImageSource.FromResource("AppBancoDigital.Assets.user.png");
            img__data__nascimento__register.Source = ImageSource.FromResource("AppBancoDigital.Assets.data_nascimento.png");

            // Ocultando os componentes da tela de login
            logo.TranslateTo(0, 20);
            lbl__titulo__login.TranslateTo(-300, 0);
            lbl__subtitulo__login.TranslateTo(270, 0);
            stc__cpf__login.TranslateTo(-375, 0);
            stc__password__login.TranslateTo(375, 0);
            stc__btn__logar.TranslateTo(0, 220);

            // Ocultando os componentes da tela de register
            lbl__titulo__register.TranslateTo(-300, 0);
            lbl__subtitulo__register.TranslateTo(310, 0);
            stc__nome__register.TranslateTo(-375, 0);
            stc__cpf__register.TranslateTo(375, 0);
            stc__data__nascimento__register.TranslateTo(-375, 0);
            stc__password__register.TranslateTo(375, 0);
            stc__password__confirmar__register.TranslateTo(-375, 0);
            stc__btn__register.TranslateTo(0, 140);
            //grid__register.TranslateTo(0, 800);
        }

        public async void hideRegisterAndShowLogin()
        {
            await lbl__titulo__register.TranslateTo(-300, 0, time_animation, Easing.CubicOut);
            await lbl__subtitulo__register.TranslateTo(310, 0, time_animation, Easing.CubicOut);
            await stc__nome__register.TranslateTo(-375, 0, time_animation, Easing.CubicOut);
            await stc__cpf__register.TranslateTo(375, 0, time_animation, Easing.CubicOut);
            await stc__data__nascimento__register.TranslateTo(-375, 0, time_animation, Easing.CubicOut);
            await stc__password__register.TranslateTo(375, 0, time_animation, Easing.CubicOut);
            await stc__password__confirmar__register.TranslateTo(-375, 0, time_animation, Easing.CubicOut);
            await stc__btn__register.TranslateTo(0, 140, time_animation, Easing.CubicOut);
            //await grid__register.TranslateTo(0, 800, time_animation, Easing.CubicOut);

            grid__register.IsVisible = false;
            grid__login.IsVisible = true;

            await details.TranslateTo(0, -60, 2000, Easing.CubicOut);
            await logo.TranslateTo(0, 0, time_animation, Easing.CubicOut);
            await lbl__titulo__login.TranslateTo(0, 0, time_animation, Easing.CubicOut);
            await lbl__subtitulo__login.TranslateTo(0, 0, time_animation, Easing.CubicOut);
            await stc__cpf__login.TranslateTo(0, 0, time_animation, Easing.CubicOut);
            await stc__password__login.TranslateTo(0, 0, time_animation, Easing.CubicOut);
            await stc__btn__logar.TranslateTo(0, 0, time_animation, Easing.CubicOut);
            //await grid__login.TranslateTo(0, 0, time_animation, Easing.CubicOut);
        }

        public async void hideLoginAndShowRegister()
        {
            //await grid__login.TranslateTo(0, -800, time_animation, Easing.CubicOut);
            await lbl__titulo__login.TranslateTo(-300, 0, time_animation, Easing.CubicOut);
            await lbl__subtitulo__login.TranslateTo(270, 0, time_animation, Easing.CubicOut);
            await stc__cpf__login.TranslateTo(-375, 0, time_animation, Easing.CubicOut);
            await stc__password__login.TranslateTo(375, 0, time_animation, Easing.CubicOut);
            await stc__btn__logar.TranslateTo(0, 220, time_animation, Easing.CubicOut);
            await logo.TranslateTo(0, -140, time_animation, Easing.CubicOut);
            await details.TranslateTo(0, -280, time_animation, Easing.Linear);

            grid__login.IsVisible = false;
            grid__register.IsVisible = true;

            await lbl__titulo__register.TranslateTo(0, 0, time_animation, Easing.CubicOut);
            await lbl__subtitulo__register.TranslateTo(0, 0, time_animation, Easing.CubicOut);
            await stc__nome__register.TranslateTo(0, 0, time_animation, Easing.CubicOut);
            await stc__cpf__register.TranslateTo(0, 0, time_animation, Easing.CubicOut);
            await stc__data__nascimento__register.TranslateTo(0, 0, time_animation, Easing.CubicOut);
            await stc__password__register.TranslateTo(0, 0, time_animation, Easing.CubicOut);
            await stc__password__confirmar__register.TranslateTo(0, 0, time_animation, Easing.CubicOut);
            await stc__btn__register.TranslateTo(0, 0, time_animation, Easing.CubicOut);
            //await grid__register.TranslateTo(0, 0, time_animation, Easing.CubicOut);
        }

        public LoginRegister()
        {
            InitializeComponent();
            config_initial_app();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected async override void OnAppearing()
        {
            // Efeito de movimentar a nossa img Details para cima.
            await details.TranslateTo(0, -60, 2000, Easing.Linear);

            await lbl__titulo__login.TranslateTo(0, 0, time_animation, Easing.CubicOut);
            await lbl__subtitulo__login.TranslateTo(0, 0, time_animation, Easing.CubicOut);
            await stc__cpf__login.TranslateTo(0, 0, time_animation, Easing.CubicOut);
            await stc__password__login.TranslateTo(0, 0, time_animation, Easing.CubicOut);
            await stc__btn__logar.TranslateTo(0, 0, time_animation, Easing.CubicOut);
        }

        private void onClickLabelCriarConta_Tapped(object sender, EventArgs e)
        {
            hideLoginAndShowRegister();
        }

        private void onClickLabelLogin_Tapped(object sender, EventArgs e)
        {
            hideRegisterAndShowLogin();
        }

        private void btn__register_Clicked(object sender, EventArgs e)
        {
            onOfLoader(true, "r");

            /*string nome_digitado = txt__nome__register.Text;
            string cpf_digitado = Regex.Replace(txt__cpf__register.Text, "[^0-9]", "");
            string senha_sha1;
            using (var sha1 = new SHA1Managed())
            {
                senha_sha1 = BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(txt__password__register.Text)));
                senha_sha1 = string.Join("", senha_sha1.ToLower().Split('-'));
            }

            Correntista c = await DataServiceCorrentista.Cadastrar(new Correntista
            {
                nome = nome_digitado,
                cpf = cpf_digitado,
                senha = senha_sha1,
            });*/
        }
    }
}