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
        protected override void OnAppearing()
        {
            System.Threading.Tasks.Task.Run(async () =>
            {
                while (true)
                {
                    await logo.ScaleTo(1, 200, Easing.CubicIn);
                    await logo.ScaleTo(1.2, 200, Easing.CubicIn);
                    await logo.ScaleTo(1, 200, Easing.CubicIn);

                    // Girando a Imagem em 360º
                    /*for(int i = 1; i < 10; i++)
                    {
                        if(logo.Rotation >= 360f) logo.Rotation = 0;

                        double rotation = i * (360 / 9);
                        await logo.RotateTo(i * (360 / 9), 1000, Easing.Linear);
                    }*/
                }
            });
        }
    }
}