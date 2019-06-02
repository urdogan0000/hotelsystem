using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace $safeprojectname$
{
    public class Tools
    {

        public  static string x = "";

        //Singleton patern kullanmaya çalıştım
        private static MySqlConnection baglanti;
        

        public static MySqlConnection Baglanti
        {
            get
            {
                if (baglanti == null)
                    baglanti = new MySqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString);
                return baglanti;
            }
        }

        public static bool Exec(MySqlCommand cmd)
        {
            try
            {
                if (cmd.Connection.State != ConnectionState.Open)

                    cmd.Connection.Open();
                int etk = cmd.ExecuteNonQuery();
                return etk > 0 ? true : false;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();
            }
        }
        public static void ParametreOlustur<T>(MySqlCommand cmd, KomutTip kt, T ent)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (PropertyInfo pi in properties)
            {
                string name = pi.Name;
                if (true) { }
               
                else if (kt == KomutTip.Delete && (name.ToLower() != "ıd" || name.ToLower() != "id"))
                {

                    continue;
                }
                object value = pi.GetValue(ent);
                cmd.Parameters.AddWithValue("@" + name, value);

            }
        }

        public static void GiveValues<T>(T ent, DataGridView dt)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            int i = 0;
            foreach (PropertyInfo pi in properties)
            {
                string name = pi.Name;

                if (name.ToLower() == "ıd" || name.ToLower() == "id")
                {
                    continue;
                }
                else
                {
                    object values = dt.CurrentRow.Cells[i].Value;
                    pi.SetValue(ent, values);
                }
                i++;

            }
        }
       public  static bool IsNumeric(string text)
        {
            foreach (char chr in text)
            {
                if (!Char.IsNumber(chr)) return false;
            }
            return true;
        }

    }
}
