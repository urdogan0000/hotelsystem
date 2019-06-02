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
    public partial class Müsteriİslemleri : Form
    {
        public Müsteriİslemleri()
        {
            InitializeComponent();
        }
        UsersOrm uso = new UsersOrm();
        Users us = new Users();

        private void Müsteriİslemleri_Load(object sender, EventArgs e)
        {
            string x = "select * from users where type_name='Müsteri'";
            MySqlDataAdapter adp = new MySqlDataAdapter(x, Tools.Baglanti);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // adding user for this case it is müşteri


              // Tools.GiveValues(us, dataGridView1);              //ekleme işlemi

                
                us.Tcno = (dataGridView1.CurrentRow.Cells[0].Value.ToString());
                us.Namess = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                us.Surname = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                us.Tel_no = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                us.Email_adres = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                us.Adres = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                us.Salary = "";
                us.type_name = "Müsteri";
               
                
    
                bool sonuc = uso.İnsert(us);
                if (sonuc )
                {
                    MessageBox.Show("Ekleme işlemi başarılı");
                   
                }
                else
                {
                    MessageBox.Show("işlem başarısız");
                    
                }
               
            }
            catch (Exception E)
            {
                MessageBox.Show("Exception is = " + E);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            us.Tcno = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            uso.Delete(us);
        }
    }
}
