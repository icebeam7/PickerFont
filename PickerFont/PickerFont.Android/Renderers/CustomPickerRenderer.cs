using System;
using System.Linq;
using System.Collections.Generic;

using Android.App;
using Android.Views;
using Android.Widget;
using Android.Graphics;

using PickerFont.Custom;
using PickerFont.Models;
using PickerFont.Droid.Renderers;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using static Android.Widget.AdapterView;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace PickerFont.Droid.Renderers
{
    public class JavaObjectWrapper<T> : Java.Lang.Object
    {
        public T Obj { get; set; }
    }

    public class CustomPickerRenderer : PickerRenderer
    {
        private Dialog dialog;

        public CustomPickerRenderer() { }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            Control.Click += Control_Click;
        }

        protected override void Dispose(bool disposing)
        {
            Control.Click -= Control_Click;
            base.Dispose(disposing);
        }

        private void Control_Click(object sender, EventArgs e)
        {
            var model = Element;
            dialog = new Dialog(Forms.Context);
            dialog.SetContentView(Resource.Layout.custom_picker_dialog);

            var listView = (Android.Widget.ListView)dialog.FindViewById(Resource.Id.listview);

            // no funciona, marca error en el cast, así que tuve que asignarlos manualmente en un foreach
            //var items = (List<Monitos>)model.ItemsSource; 

            var items = new List<Monitos>();

            foreach (var item in model.ItemsSource)
                items.Add(item as Monitos);

            var adapter = new MyAdapter(items);

            listView.Adapter = adapter;

            listView.ItemClick += (object sender1, ItemClickEventArgs e1) =>
            {
                Element.SelectedIndex = e1.Position;
                dialog.Hide();
            };

            if (model.ItemsSource.Count > 3)
            {
                var height = Xamarin.Forms.Application.Current.MainPage.Height;
                var width = Xamarin.Forms.Application.Current.MainPage.Width;
                dialog.Window.SetLayout(700, 800);
            }

            dialog.Show();
        }

        class MyAdapter : BaseAdapter
        {
            private IList<Monitos> mList;

            public MyAdapter(IList<Monitos> itemsSource)
            {
                mList = itemsSource;
            }

            public override int Count => mList.Count;

            public override Java.Lang.Object GetItem(int position)
            {
                var myObj = mList.ElementAt(position);
                return new JavaObjectWrapper<Monitos>() { Obj = myObj };
            }

            public override long GetItemId(int position)
            {
                return position;
            }

            public override Android.Views.View GetView(int position, Android.Views.View convertView, ViewGroup parent)
            {
                var view = convertView;
                convertView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.celllayout, null);

                var assets = Forms.Context.Assets;
                var tvFont = Typeface.CreateFromAsset(assets, "Lobster-Regular.ttf");

                var text = convertView.FindViewById<TextView>(Resource.Id.textview1);
                text.Typeface = tvFont;
                text.Text = mList.ElementAt(position).NombreCorto;

                return convertView;
            }
        }
    }
}