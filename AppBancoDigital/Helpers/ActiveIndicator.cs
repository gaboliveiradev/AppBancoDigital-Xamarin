using System;
using System.Collections.Generic;
using System.Text;
using AppBancoDigital.View;
using Xamarin.Forms;

namespace AppBancoDigital.Helpers
{
    public class ActiveIndicator
    {
        public void onOfLoader(bool s)
        { 
            Login l = new Login();

            l.loader.IsVisible = s;
            l.loader.IsRunning = s;
        }
    }
}
