using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBancoDigital.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Loader : ContentPage
    {
        public Loader()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            logo.Source = ImageSource.FromResource("AppBancoDigital.Assets.logo_back_purple.png");
        }

        // Metodo chamado toda vez que a tela é exibida
        protected async override void OnAppearing()
        {
            for (int i = 0; i < 6; i++)
            {
                await logo.ScaleTo(1, 200, Easing.CubicIn);
                await logo.ScaleTo(1.2, 200, Easing.CubicIn);
                await logo.ScaleTo(1, 200, Easing.CubicIn);
            }

            await Navigation.PushAsync(new Login());
        }
    }
}