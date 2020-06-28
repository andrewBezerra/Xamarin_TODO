using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin_TODO.View;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace Xamarin_TODO
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            AppCenter.Start("android=771ce364-ee0c-419c-a9d4-75ed63691b0c;",
                  typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
