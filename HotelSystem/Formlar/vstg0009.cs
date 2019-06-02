using $safeprojectname$.Entity;
using $safeprojectname$.Facade;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace $safeprojectname$.Formlar
{
    public partial class Oda_Tipi_İşlemleri : Form
    {
        int x;
        int y;
        
        public Oda_Tipi_İşlemleri()
        {
            InitializeComponent();
        }
        RoomType rt = new RoomType();
        RoomTypeOrm rto = new RoomTypeOrm();
        public int bak()
        {
            int y = 0;
            
            MySqlCommand logname = new MySqlCommand();
            logname.CommandText = "select * from roomtype";
            logname.Connection = Tools.Baglanti;
            Tools.Baglanti.Close();
            Tools.Baglanti.Open();
            

            MySqlDataReader oku = logname.ExecuteReader();
            while (oku.Read())
            {
                x = int.Parse(oku["id"].ToString());
                if (x > y)
                {
                    y = x;
                    y++;
                }
                y++;
                                  
            }

            return y;
        }
        private void Oda_Tipi_İşlemleri_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = rto.Select();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            /*
            MySqlCommand logname2 = new MySqlCommand();
            logname2.CommandText = "insert into roomtype values(id=@id,typename=@typename)";
            logname2.Parameters.AddWithValue("@id", this.bak());
            logname2.Parameters.AddWithValue("@typename", dataGridView1.CurrentRow.Cells[1].Value.ToString());
            logname2.Connection = Tools.Baglanti;
            Tools.Baglanti.Close();
            Tools.Baglanti.Open();
            int a=logname2.ExecuteNonQuery();
            if (a >= 1)
            {
                MessageBox.Show("Ekleme işlemi başarılı");
                dataGridView1.DataSource = rto.Select();
            }else
            {
                MessageBox.Show("Ekleme işlemi başarısızzz");

            }
            */
            try
            {
                rt.id = bak();
                rt.type = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                rto.İnsert(rt);
                dataGridView1.DataSource = rto.Select();
            }catch(Exception E)
            {
                MessageBox.Show("Hatanız " + E);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string z = string.Format("delete from roomtype where id='{0}'", dataGridView1.CurrentRow.Cells[0].Value.ToString());
            MySqlCommand veri2 = new MySqlCommand();
            veri2.CommandText = z;
            veri2.Connection = Tools.Baglanti;
            Tools.Baglanti.Close();
            Tools.Baglanti.Open();
            int b = veri2.ExecuteNonQuery();
            if (b >= 1)
            {
                MessageBox.Show("Silme işlmei başarılı");
                dataGridView1.DataSource = rto.Select();
            }

            else
            {
                MessageBox.Show("silme işlemi başarısız");

            }
        }
    }
}
