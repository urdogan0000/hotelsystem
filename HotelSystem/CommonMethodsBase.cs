using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Reflection;


namespace $safeprojectname$
{
    public class CommonMethodsBase<T> : CommonMethods<T> where T : class
    {

        public string Classname
        {
            get
            {
                //tipi belli olmayan jenerikler için kullanılır typeof medodu
                return typeof(T).Name;
            }
        }
        public bool Delete(T entity)
        {
            MySqlCommand cmd = new MySqlCommand(string.Format("prc_{0}_Delete", Classname.ToLower()), Tools.Baglanti);
            cmd.CommandType = CommandType.StoredProcedure;
            //T elamanı içerisindeli property leri bir dizi olarak döndürür.
            Tools.ParametreOlustur(cmd, KomutTip.Delete, entity);
            return Tools.Exec(cmd);           
        }
        MySqlDataAdapter adp;

        public DataTable Select()
        {
            adp = new MySqlDataAdapter(string.Format("prc_{0}_Select", Classname.ToLower()), Tools.Baglanti);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;           
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
            
        }
        public bool Update(T entity)
        {
            MySqlCommand cmd = new MySqlCommand(string.Format("prc_{0}_Update", Classname), Tools.Baglanti);
            cmd.CommandType = CommandType.StoredProcedure;
            //T elamanı içerisindeli property leri bir dizi olarak döndürür.
            Tools.ParametreOlustur<T>(cmd, KomutTip.Update, entity);
            return Tools.Exec(cmd);
        }
        public bool İnsert(T entity)
        {
            MySqlCommand cmd = new MySqlCommand(string.Format("prc_{0}_İnsert", Classname.ToLower()), Tools.Baglanti);
            cmd.CommandType = CommandType.StoredProcedure;
            //T elamanı içerisindeli property leri bir dizi olarak döndürür.
            Tools.ParametreOlustur<T>(cmd, KomutTip.İnsert, entity);    
            return Tools.Exec(cmd);
        }

      
       
        /// <summary>
        /// Class to handle the spInsert stored procedure
        /// </summary>

        public bool Deneme(String x)
        {
            MySqlCommand cmd = new MySqlCommand(x, Tools.Baglanti);
            cmd.CommandType = System.Data.CommandType.Text;
            Tools.Baglanti.Open();

            int i=cmd.ExecuteNonQuery();
            if (i >= 1)
            {
               
            }


            Tools.Baglanti.Close();
          return Tools.Exec(cmd);
        }
    }
}

