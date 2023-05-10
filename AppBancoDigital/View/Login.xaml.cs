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
            loader.IsVisible = s;
            loader.IsRunning = s;
        }

        public Login()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            logo.Source = ImageSource.FromResource("AppBancoDigital.Assets.logo_back_white.png");
        }

        private void btn_logar_Clicked(object sender, EventArgs e)
        {
            onOfLoader(true);
        }
    }
}