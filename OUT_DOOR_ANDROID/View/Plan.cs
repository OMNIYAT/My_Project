using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using OUT_DOOR_ANDROID.Adapter;

namespace OUT_DOOR_ANDROID.View
{
    [Activity(Label = "Plan", Theme = "@style/android:Theme.Holo.Light.NoActionBar")]
    public class Plan : Activity
    {
        public ListView list_Plan;
        public int progressBarStatu;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Plans_Layout);

            //------------------------ 

            list_Plan = FindViewById<ListView>(Resource.Id.List_plans);
            list_Plan.Visibility = ViewStates.Invisible;
            //--------------progresse loading -----------------
            ProgressDialog progresse = new ProgressDialog(this);
            progresse.SetCancelable(true);
            progresse.SetMessage("loadin data from server ...");
            progresse.SetProgressStyle(ProgressDialogStyle.Horizontal);
            progresse.Progress = 0;
            progresse.Max = 100;
            progresse.Show();
            progressBarStatu = 1;
            new Thread(new ThreadStart(delegate {
                while (progressBarStatu < 100)
                {
                    progressBarStatu += 1;
                    progresse.Progress = progressBarStatu;
                    Thread.Sleep(100);
                }
                RunOnUiThread( ()=> { progresse.SetMessage("Data is Dowloaded.");
                                      list_Plan.Visibility = ViewStates.Visible;
                });
                
            })).Start();
            //--------------end progresse-----------------
            
           
            List<Plan_ListviewItem> lst = new List<Plan_ListviewItem>();
            list_Plan.Adapter = new CustomAdapter(this, lst);
        }
    }
}