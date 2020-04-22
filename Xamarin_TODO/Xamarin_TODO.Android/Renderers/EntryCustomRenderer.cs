using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin_TODO.Controls;
using Xamarin_TODO.Droid.Renderers;
using static Android.Arch.Core.Internal.SafeIterableMap;


[assembly: ExportRenderer(typeof(NoBorderEntry), typeof(EntryCustomRenderer))]

namespace Xamarin_TODO.Droid.Renderers
{
    public class EntryCustomRenderer : EntryRenderer
    {
        public EntryCustomRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
        {
            base.OnElementChanged(e);
            if (Control == null || Element == null || e.OldElement != null) return;
            var element = (NoBorderEntry)Element;

            Control.SetBackground(null);
            Control.SetPadding(0, 0, 0, 0);
        }
    }
}