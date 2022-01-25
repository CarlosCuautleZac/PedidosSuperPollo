using PedidosSuperPollo.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


[assembly: ExportFont("GothamBold.ttf", Alias = "GothamBold")]
[assembly: ExportFont("Gotham-Black.otf", Alias = "GothamBlack")]
namespace PedidosSuperPollo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Home();
            
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
