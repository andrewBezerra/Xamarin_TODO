using System;
using System.Collections.Generic;
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
        private bool animating = false;
        private double lastY = 0;
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
            if (lastY > delta)
            {

                animating = true;

                // await ImageFrame.TranslateTo(0, -400, 300, Easing.Linear);
                await Task.WhenAll(
                    Header.TranslateTo(0, -400, 300, Easing.Linear),
                    Content.ScaleYTo(-75,300,Easing.Linear)
                   
                );
                animating = false;
                lastY = delta;

            }
            else
            {

                animating = true;
                // await ImageFrame.TranslateTo(0, -400, 300, Easing.Linear);
                await Task.WhenAll(
                    Header.TranslateTo(0, 0, 300, Easing.Linear),
                    Content.TranslateTo(0, 0, 300, Easing.Linear)
                );
                animating = false;
                lastY = delta;
            }
        }

        private async void SwipeGestureRecognizer_SwipedDown(object sender, SwipedEventArgs e)
        {
            Header.IsVisible = true;
            animating = true;
            await ImageFrame.TranslateTo(0, 0, 300, Easing.Linear);
            animating = false;
        }
        private async void SwipeGestureRecognizer_SwipedUp(object sender, SwipedEventArgs e)
        {

            animating = true;
            await ImageFrame.TranslateTo(0, -400, 300, Easing.Linear);
            Header.IsVisible = false;
            animating = false;
        }

        private async void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            if (sender is ScrollView scrollview)
            {

                if (!animating)
                {

                    await AnimateHeader(e.ScrollY);

                }


            }
        }
    }
}