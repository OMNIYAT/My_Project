using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace OUT_DOOR_ANDROID.Helper
{
    class Helpers
    {

        public string RequetInsert(string table,string xml)
        {
            string requete="Insert Into ";
            string param = "",champs="(";
            XDocument doc = XDocument.Parse(xml);
            var lst = doc.Descendants("Row");
            foreach (var items in lst)
            {
                var listcolumn = items.Descendants("Column");
                foreach(var column in listcolumn)
                { 
                    if(column.Element("Value").Value != null && column.Element("Value").Value != "")
                    {
                        param  += column.Element("Type").Value+"#"+ column.Element("Value").Value+"@";
                        champs += column.Element("Name").Value + ",";
                    }
                }
            }
            champs = champs.Remove(champs.Length - 1);
            champs += ") ";
            requete += table +" "+champs +" values ( ";
            string[] separ = param.Split('@');
            for (int i = 0; i < separ.Length; i++)
            {
                string[] val_separ = separ[i].Split('#');
                if (val_separ[0].Equals("System.Int32"))
                {
                    requete += Int32.Parse(val_separ[1])+",";
                }
                if (val_separ[0].Equals("System.Int64"))
                {
                    requete += Int64.Parse(val_separ[1]) + ",";
                }
                if (val_separ[0].Equals("System.String"))
                {
                    requete += "'"+val_separ[1] + "',";
                } 
                if (val_separ[0].Equals("System.DateTime"))
                {
                    requete += "'"+Convert.ToDateTime(val_separ[1]) + "',";
                }
                if (val_separ[0].Equals("System.Double"))
                {
                    requete += "" + Double.Parse(val_separ[1]) + ",";
                }
            }
            requete = requete.Remove(requete.Length - 1);
            requete += ");";

            Log.Info("la requete ",requete);
            return requete;
        }

        public List<string> Craetiontable(string xml)
        {
            List<string> array = new List<string>();
            XDocument doc = XDocument.Parse(xml);
            foreach (var item in doc.Descendants("Definition"))
            {
                string name = item.Element("Name").Value.ToString();
                string sql = item.Element("Sql").Value.ToString();
                array.Add(sql);
            }
            return array;
        }


    }
}