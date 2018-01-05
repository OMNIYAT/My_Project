//Required assemblies
using Android.Database.Sqlite;
using Android.Util;
using OUT_DOOR_ANDROID.Helper;
using System.Collections.Generic;
using System.IO;


namespace OUT_DOOR_ANDROID.Data
{
    class Database
    {
        
        static SQLiteDatabase sqldb;
        static string         sqldb_path ;
        public bool CreateDatabase()
        {
            try
            {
                string sqldb_location = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                sqldb_path = Path.Combine(sqldb_location, "Out_Door_Android.db");
                bool sqldb_exists = File.Exists(sqldb_path);
                if (!sqldb_exists)
                { 
                    sqldb = SQLiteDatabase.OpenOrCreateDatabase(sqldb_path, null);
                    Log.Info("Data base ==>", "Created ");
                }
                else
                {
                    sqldb = SQLiteDatabase.OpenDatabase(sqldb_path, null, DatabaseOpenFlags.OpenReadwrite);
                    Log.Info("Data base ==>", "Already exist ");
                }

                return true;
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteException ", ex.Message);
                return false;
            }
        }

        public bool Createtable(string xml)
        {
            try
            {
                Helpers help = new Helpers(); 
                List<string> res = help.Craetiontable(xml);
                for (int i = 0; i < res.Count; i++)
                {
                    sqldb.ExecSQL(res[i]);
                }
                Log.Info("all Table ==>", " Created ");
                return true;
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteException ", ex.Message);
                return false;
            }
           
        }

        public bool InsertIntoTables(string table,string requete)
        {
            try
            {
                Helpers help = new Helpers();
                string requet = help.RequetInsert(table,requete);
                sqldb.ExecSQL(requet);
                Log.Info("Result  : ", " lines added succes ");
                return true;
            } catch (SQLiteException ex )
            {
                Log.Info("SQLiteException ",ex.Message);
                return false;
            }
        }


        public Android.Database.ICursor Select_From_Table(string table, string requete)
        {
            Android.Database.ICursor sqldb_cursor = null;
            string sqldb_query = "SELECT * FROM " + table + " WHERE " + requete; ;
            try
            {//"SELECT name FROM sqlite_temp_master WHERE type='table';";//  
                sqldb_cursor = sqldb.RawQuery(sqldb_query, null);
                if (!(sqldb_cursor != null))
                {
                    Log.Info("Result  ", "Not Found"); 
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteException ", ex.Message);
            }
            return sqldb_cursor;
        }

        //Adds a new record with the given parameters
        /* public void AddRecord(string sName, string sLastName, int iAge)
         {
             try
             {
                 sqldb_query = "INSERT INTO MyTable(Name, LastName, Age) VALUES('" +sName + "', '" + sLastName + "'," + iAge + ");";

                sqldb.ExecSQL(sqldb_query);
                 sqldb_message = "Record saved";
             }
             catch (SQLiteException ex)
             {
                 sqldb_message = ex.Message;
             }
         }
         //Updates an existing record with the given parameters depending on id parameter
         public void UpdateRecord(int iId, string sName, string sLastName, int iAge)
         {
             try
             {
                 sqldb_query ="UPDATE MyTable SET Name = '" + sName + "', LastName ='" +sLastName + "', Age = '" + iAge + "' WHERE _id ='" +iId + "';";
                 sqldb.ExecSQL(sqldb_query);
                 sqldb_message = "Record "+iId + " updated";
             }
             catch (SQLiteException ex)
             {
                 sqldb_message = ex.Message;
             }
         }
         //Deletes the record associated to id parameter
         public void DeleteRecord(int iId)
         {
             try
             {
                 sqldb_query = "DELETE FROM MyTable WHERE _id = '" + iId + "';";
                 sqldb.ExecSQL(sqldb_query);
                 sqldb_message = "Record "+iId + " deleted";
             }
             catch (SQLiteException ex)
             {
                 sqldb_message = ex.Message;
             }
         }
         //Searches a record and returns an Android.Database.ICursor cursor
         //Shows all the records from the table
         public Android.Database.ICursor GetRecordCursor()
         {
             Android.Database.ICursor sqldb_cursor = null;
             try
             {
                 sqldb_query = "SELECT* FROM MyTable;";
                 sqldb_cursor = sqldb.RawQuery(sqldb_query, null);
                 if (!(sqldb_cursor != null))
                 {
                     sqldb_message = "Record not found";
                 }
             }
             catch (SQLiteException ex)
             {
                 sqldb_message = ex.Message;
             }
             return sqldb_cursor;
         }
         //Searches a record and returns an Android.Database.ICursor cursor
         //Shows records according to search criteria
         public Android.Database.ICursor GetRecordCursor(string sColumn, string sValue)
         {
             Android.Database.ICursor sqldb_cursor = null;
             try
             {
                 sqldb_query = "SELECT* FROM MyTable WHERE " +sColumn +" LIKE '" +sValue + "%';";
                 sqldb_cursor = sqldb.RawQuery(sqldb_query, null);
                 if (!(sqldb_cursor != null))
                 {
                     sqldb_message = "Record not found";
                 }
             }
             catch (SQLiteException ex)
             {
                 sqldb_message = ex.Message;
             }
             return sqldb_cursor;
         }*/
    }
}

