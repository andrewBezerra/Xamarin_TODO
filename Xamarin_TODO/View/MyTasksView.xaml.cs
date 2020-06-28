using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin_TODO.Model;

namespace Xamarin_TODO.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyTasksView : ContentPage
    {
        private bool isAnimating = false;
        private bool isScrooling = false;
        private double lastY = 0;
        private double movement = 0;
        private string user = "Andrew";
        public MyTasksView()
        {

            InitializeComponent();
            this.collectionView.ChildAdded +=
                (sender, e) => collectionView_ChildAdded(sender, e);




        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            HeaderFrame.HasShadow = false;
            if (DateTime.Now.Hour > 3 && DateTime.Now.Hour < 12)
                Greetings.Text = $"Good morning, {user}";
            else if (DateTime.Now.Hour > 12 && DateTime.Now.Hour < 18)
                Greetings.Text = $"Good afternoon, {user}";
            else if (DateTime.Now.Hour > 18 || DateTime.Now.Hour < 3)
                Greetings.Text = $"Good evening, {user}";
        }

        private void collectionView_ChildAdded(object sender, ElementEventArgs e)
        {
            var child = e.Element;
            DisplayAlert("CollectionView", "ChildAdded", "Ok");

        }

   

        private async Task AnimateHeader(double delta)
        {


#if DEBUG
            Debug.WriteLine($"---  Y: {delta}   Last Y:{lastY}   Movement:{movement}");
            Debug.WriteLine($"---  Image X: {ImageFrame.TranslationX}   Greet X:{ Greetings.TranslationX}  Greet Y:{Greetings.TranslationY}");

            // Debug.WriteLine($"--- HeaderFrame Heigth:{  HeaderFrame.HeightRequest }");
#endif
            HeaderFrame.HasShadow = delta > 40 ? true : false;
            if (delta < 69)
            {
                
               
                Debug.WriteLine($"--- HeaderFrame Shadow:{   HeaderFrame.HasShadow.ToString() }");
               // Header.HeightRequest = delta;
                Debug.WriteLine($"--- HeaderFrame Heigth:{  HeaderFrame.HeightRequest }");
                ImageFrame.TranslationX = delta * 2;
            }
            else  if(ImageFrame.TranslationX<=137)
            {
                ImageFrame.TranslationX = 137.33;
            }

            if (delta < 68)
            {
                Greetings.TranslationX = delta * (-1);
                Greetings.TranslationY = (delta / 1.8) * -1;
            }
            else if (Greetings.TranslationX < 65)
            {
                Greetings.TranslationX = -68;
                Greetings.TranslationY = -35;
            }

          
            
         





        }

        private async void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {


            await AnimateHeader(e.ScrollY);



        }
    }
}