using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Musica.View;

namespace Musica
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ReproductorPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
