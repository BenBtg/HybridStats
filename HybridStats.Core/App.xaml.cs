using HybridStats.Core.Services;
using HybridStats.Core.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HybridStats
{
    public partial class App : Application
    {
        public static INavigationService Navigation { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new SecondPage();
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
