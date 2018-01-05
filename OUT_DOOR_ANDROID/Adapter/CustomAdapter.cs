using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;

namespace OUT_DOOR_ANDROID.Adapter
{
    public class CustomAdapter : BaseAdapter<Plan_ListviewItem>
    {
        List<Plan_ListviewItem> items;
        Activity context;

        public CustomAdapter(Activity context, List<Plan_ListviewItem> items):base()
        {
            this.context = context;
            this.items = items;
        }

        public override Plan_ListviewItem this[int position]
        {
            get
            {
                return items[position];
            }
        }

        public override int Count 
        {
            get
            {
                return items.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Android.Views.View GetView(int position, Android.Views.View convertView, ViewGroup parent)
        {
            var item                = items[position];
            Android.Views.View view = convertView;
            if (view == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.ListView_Plan,null);
                view.FindViewById<TextView>(Resource.Id.name).Text = item.plan;
                view.FindViewById<TextView>(Resource.Id.date).Text = item.date.ToString();
            }

            return view;
        }
    }
}