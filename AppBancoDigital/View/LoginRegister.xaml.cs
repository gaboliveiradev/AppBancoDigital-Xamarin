using AppBancoDigital.DataService;
using AppBancoDigital.Model;
using AppBancoDigital.View.Popup;
using Rg.Plugins.Popup.Extensions;
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
                btn__register.IsEnabled = !s;
            }
            else if(type == "l")
            {
                act__loader__login.IsVisible = s;
                act__loader__login.IsRunning = s;
                btn__logar.IsEnabled = !s;
            }
        }

        public void config_initial_app()
        {
            // Adicionando as imagens
            details.Source = ImageSource.FromResource("AppBancoDigital.Assets.details.png");
            logo.Source = ImageSource.FromResource("AppBancoDigital.Assets.logo_back_purple.png");

            img__cpf__login.Source = ImageSource.FromResource("AppBancoDigital.Assets.cpf.png");
            img__cpf__register.Source = ImageSource.FromResource("AppBancoDigital.Assets.cpf.png");

            img__password__login.Source = ImageSource.FromResource("AppBancoDigital.Assets.senha.png");
            img__password__register.Source = ImageSource.FromResource("AppBancoDigital.Assets.senha.png");
            img__password__confirmar__register.Source = ImageSource.FromResource("AppBancoDigital.Assets.senha.png");

            img__nome__register.Source = ImageSource.FromResource("AppBancoDigital.Assets.nome.png");
            img__data__nascimento__register.Source = ImageSource.FromResource("AppBancoDigital.Assets.data.png");

            img__tipo__conta__register.Source = ImageSource.FromResource("AppBancoDigital.Assets.tipo.png");

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
            stc__tipo__conta__register.TranslateTo(-375, 0);
            stc__btn__register.TranslateTo(0, 140);
            //grid__register.TranslateTo(0, 800);

            //Adicionando itens no Picker para o register
            pck__tipo__conta__register.ItemsSource = new List<string> { "Corrente", "Poupança" };
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
            await stc__tipo__conta__register.TranslateTo(-375, 0, time_animation, Easing.CubicOut);
            await stc__btn__register.TranslateTo(0, 140, time_animation, Easing.CubicOut);
            //await grid__register.TranslateTo(0, 800, time_animation, Easing.CubicOut);

            grid__register.IsVisible = false;
            grid__login.IsVisible = true;

            await details.TranslateTo(0, -60, 200, Easing.CubicOut);
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
            await stc__tipo__conta__register.TranslateTo(0, 0, time_animation, Easing.CubicOut);
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
            await details.TranslateTo(0, -60, 200, Easing.Linear);

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

        private async void btn__register_Clicked(object sender, EventArgs e)
        {
            try
            {
                onOfLoader(true, "r");

                if (txt__password__register.Text != txt__password__confirmar__register.Text)
                {
                    SenhaConfirmarSenha pop_senha_confirmar_senha = new Popup.SenhaConfirmarSenha();
                    await Navigation.PushPopupAsync(pop_senha_confirmar_senha, true);
                }
                else
                {
                    string nome_digitado = txt__nome__register.Text;
                    string cpf_digitado = Regex.Replace(txt__cpf__register.Text, "[^0-9]", "");
                    string data_nascimento = dtpck__data__nascimento__register.Date.ToString("yyyy-MM-dd");
                    string tipo = pck__tipo__conta__register.SelectedItem.ToString().ToUpper();

                    string senha_sha1;
                    using (var sha1 = new SHA1Managed())
                    {
                        senha_sha1 = BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(txt__password__register.Text)));
                        senha_sha1 = string.Join("", senha_sha1.ToLower().Split('-'));
                    }

                    Correntista c = await DataServiceCorrentista.Cadastrar(new Correntista
                    {
                        nome = nome_digitado.ToUpper(),
                        cpf = cpf_digitado,
                        senha = senha_sha1,
                        data_nascimento = data_nascimento,
                        tipo = tipo
                    }, "/correntista/cadastrar");

                    CorrentistaCadastrado pop_correntista_cadastrado = new Popup.CorrentistaCadastrado();
                    await Navigation.PushPopupAsync(pop_correntista_cadastrado, true);

                    hideRegisterAndShowLogin();
                }
            }
            catch (Exception err)
            {
                ErroCadastrarCorrentistas pop_erro_cadastrar_correntista = new Popup.ErroCadastrarCorrentistas();
                await Navigation.PushPopupAsync(pop_erro_cadastrar_correntista, true);

                Console.WriteLine($"Erro: {err.Message}");
            }
            finally
            {
                onOfLoader(false, "r");
            }
        }

        private async void btn__logar_Clicked(object sender, EventArgs e)
        {
            try
            {
                onOfLoader(true, "l");

                string[] cpf_pontuado = txt__cpf__login.Text.Split('.', '-');
                string cpf_digitado = cpf_pontuado[0] + cpf_pontuado[1] + cpf_pontuado[2] + cpf_pontuado[3];
                string senha_digitada = txt__password__login.Text;

                string senha_sha1;
                using (var sha1 = new SHA1Managed())
                {
                    senha_sha1 = BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(senha_digitada)));
                    senha_sha1 = string.Join("", senha_sha1.ToLower().Split('-'));
                }

                Correntista c = await DataServiceCorrentista.Autenticar(new Correntista
                {
                    cpf = cpf_digitado,
                    senha = senha_sha1
                }, "/correntista/entrar");

                if (c != null)
                {
                    App.Current.Properties.Add("id_correntista", c.id);
                    App.Current.Properties.Add("nome_correntista", c.nome);
                    App.Current.MainPage = new NavigationPage(new Home()
                    {
                        //BindingContext = c
                    });
                }
                else
                {
                    DadosIncorretos pop_dados_incorretos = new Popup.DadosIncorretos();
                    await Navigation.PushPopupAsync(pop_dados_incorretos, true);
                }
            }
            catch (Exception err)
            {
                ErroLogar pop_erro_logar = new Popup.ErroLogar();
                await Navigation.PushPopupAsync(pop_erro_logar, true);

                Console.WriteLine($"Erro: {err.Message}");
            }
            finally
            {
                onOfLoader(false, "l");
            }
        }
    }
}