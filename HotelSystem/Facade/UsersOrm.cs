using $safeprojectname$.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace $safeprojectname$.Facade
{
    public class UsersOrm : CommonMethodsBase<Users>
    {
        public new DataTable Select()
        {
            MySqlDataAdapter adp = new MySqlDataAdapter(string.Format("prc_{0}_Select", Classname.ToLower()), Tools.Baglanti);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
    }
}
