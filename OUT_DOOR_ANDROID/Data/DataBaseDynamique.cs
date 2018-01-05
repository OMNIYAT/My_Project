using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace OUT_DOOR_ANDROID.Data
{
    class DataBaseDynamique
    {
       /* public static SqliteConnection connection;
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        public bool CreateDataBase()
        {
            try
            {
                string dbpath;
                dbpath = Path.Combine(folder, "adodemo.db3");
                bool exists = File.Exists(dbpath);
                if (!exists)
                {
                    Log.Info("Creating database", ".............");
                    SqliteConnection.CreateFile(dbpath);
                    connection = new SqliteConnection("Data Source=" + dbpath);
                }
                else
                    Log.Info("Database already exists", "!!!!!");
                return true;
            }
            catch (SqliteException ex)
            {
                Log.Info("SqliteException", ex.Message);
                return false;
            }
        }



        public bool CreateTable(string Requete)
        {
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = Requete;
                var rowcount = command.ExecuteNonQuery();
                Log.Info("\tExecuted ", command.ToString());
                return true;
            }
            catch (SqliteException ex)
            {
                Log.Info("SqliteException", ex.Message);
                return false;
            }
        }*/

    }
}