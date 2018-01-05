using Android.App;
using Android.Widget;
using Android.OS;
using System;
using OUT_DOOR_ANDROID.Sync_;
using System.Collections.Generic;
using System.Xml.Linq;
using Android.Util;
using OUT_DOOR_ANDROID.Data;
using OUT_DOOR_ANDROID.Helper;
using OUT_DOOR_ANDROID.View;

namespace OUT_DOOR_ANDROID
{
    [Activity(Label = "Login", MainLauncher = true, Theme = "@style/android:Theme.Holo.Light.NoActionBar")]
    public class MainActivity : Activity
    {
        public EditText name, password;
        public TextView txt;
        public Button btn_cnx, btn_sync;
        static Database database;
        static Helpers help;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            database = new Database();
            help = new Helpers();
            database.CreateDatabase();
            name = FindViewById<EditText>(Resource.Id.username);
            password = FindViewById<EditText>(Resource.Id.pwd);
            btn_cnx = FindViewById<Button>(Resource.Id.cnx);

            btn_cnx.Click += (object sender, EventArgs e) => {
                Sync_.Sync trc = new Sync_.Sync();
                trc.getDataBaseDefinitionsAsync("Chauffeur");
                trc.getDataBaseDefinitionsCompleted += CreateTables;
            };

        }

        private void CreateTables(object sender, getDataBaseDefinitionsCompletedEventArgs e)
        {
            string Result = e.Result.ToString();
           // database.Createtable(Result);
            Sync_.Sync trc = new Sync_.Sync();
            trc.getTableDataAsync("Chauffeur", "getuser", name.Text.ToString());
            trc.getTableDataCompleted += Synchron;
        }

        private void Synchron(object sender, getTableDataCompletedEventArgs e)
        {
            string Result = e.Result.ToString();
            database.InsertIntoTables("USERS", Result);
            verifierUser();        
        }

        public void verifierUser()
        {
            string pass, usernam,requette;
            usernam  = name.Text.ToString();
            pass     = password.Text.ToString();
            if (usernam.Equals("") || pass.Equals(""))
            {
               Toast.MakeText(this, "veillez Remplir votre Champs ...",ToastLength.Short).Show();
            }
            else
            { 
                requette = "Login = '"+ usernam + "' and pwd = '"+pass+"' ;";
                Android.Database.ICursor cursor = database.Select_From_Table("USERS",requette);
                if (cursor != null)
                {
                    Toast.MakeText(this, "bienVenue", ToastLength.Short).Show();
                    StartActivity(typeof(Plan));
                }
                else
                {
                    Toast.MakeText(this, "Login ou mot de passe invalide", ToastLength.Short).Show();
                    name.Text = "" ;
                    password.Text= "";
                }
            }

        }
    }
}

