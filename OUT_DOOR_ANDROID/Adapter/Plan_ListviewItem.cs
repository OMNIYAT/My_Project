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

namespace OUT_DOOR_ANDROID.Adapter
{
    public class Plan_ListviewItem
    {
        public string plan { get; set; }
        public DateTime date { get; set; }

        public Plan_ListviewItem(string plan, DateTime date)
        {
            this.plan = plan;
            this.date = date ;
        }
    }
}