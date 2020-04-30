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
        public MyTasksView()
        {

            InitializeComponent();
            this.collectionView.ChildAdded +=
                (sender, e) => collectionView_ChildAdded(sender, e);




        }

        private void collectionView_ChildAdded(object sender, ElementEventArgs e)
        {
            var child = e.Element;
            DisplayAlert("CollectionView", "ChildAdded", "Ok");

        }

        private async void collectionView_Scrolled(object sender, ItemsViewScrolledEventArgs e)
        {



        }

        private async Task AnimateHeader(double delta)
        {
           


            Debug.WriteLine($"---  Y: {delta}   Last Y:{lastY}   Movement:{movement}");
            Debug.WriteLine($"---  Image X: {ImageFrame.TranslationX}   Greet X:{ Greetings.TranslationX}  Greet Y:{Greetings.TranslationY}");
            Debug.WriteLine($"--- Headerline Y:{headerline.TranslationY }");

            if (delta < 69)
            {
                Header.HeightRequest = delta;
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

            if (delta < 20)
            {
                headerline.TranslationY = delta * (-1);
                headerline.Opacity = delta / 20;
            }
            else if (headerline.TranslationY > -19)
            {
                headerline.TranslationY = -20;
                headerline.Opacity = 1;
            }






            //boxHeader.HeightRequest -= delta;

                //if (delta == 0)
                //{
                //    //collectionView.HeightRequest = ((List<ItemsView>)collectionView.ItemsSource).Count*50;
                //    return;
                //}


                //if (headerTranslated > 80 && delta>=0)
                //    return;

                //if (headerTranslated <= 80)
                //    headerTranslated += delta;

                //isScrooling = isAnimating = true;
                //if (delta >= 1)
                //{


                //    Debug.WriteLine($"Animate UP");
                //    // await ImageFrame.TranslateTo(0, -400, 300, Easing.Linear);
                //    _ = await Task.WhenAll(
                //        Header.TranslateTo(0, -delta, 500, Easing.Linear)

                //    );
                //    Header.IsVisible = false;



                //}
                //else if (delta <= -1)
                //{
                //    Debug.WriteLine($"Animate Down");

                //    // await ImageFrame.TranslateTo(0, -400, 300, Easing.Linear);
                //    _ = await Task.WhenAll(
                //        Header.TranslateTo(0, delta, 500, Easing.Linear)

                //    );
                //    Header.IsVisible = true;


                //}
                //isScrooling = isAnimating = false;
            }

        private async void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {


            await AnimateHeader(e.ScrollY);



        }
    }
}