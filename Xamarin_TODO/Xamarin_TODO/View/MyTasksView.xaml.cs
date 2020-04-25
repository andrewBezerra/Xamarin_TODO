using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin_TODO.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyTasksView : ContentPage
    {
        public MyTasksView()
        {
            
            InitializeComponent();
            this.collectionView.ChildAdded += 
                (sender, e) =>  collectionView_ChildAdded(sender, e);

            
        }

        private void collectionView_ChildAdded(object sender, ElementEventArgs e)
        {
            var child = e.Element;
            DisplayAlert("CollectionView", "ChildAdded", "Ok");
            
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
           
            DisplayAlert("CollectionView", "Item Tapped", "Ok");
        }
    }
}