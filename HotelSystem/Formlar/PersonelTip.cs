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
    public partial class PersonelTip : Form
    {
       
       
        //bu proc setup sırasında oluşturtulacak 
        /*
        public string proc2 = "CREATE PROCEDURE `hotel-db`.`prc_{0}_İnsert`(in id int,in type_name varchar(15))" +
       "BEGIN" +
          " insert into usertype values(id,type_name); " +
        "END";

    */


        
        public PersonelTip()
        {
            InitializeComponent();
        }
        
        UserType ut = new UserType();
        UserTypeOrm uto = new UserTypeOrm();
        private void button1_Click(object sender, EventArgs e)
        {
            
                                       
            try
            {
                ut.type_name = dataGridView1.CurrentRow.Cells[0].Value.ToString();                              
               if(uto.İnsert(ut))
                {
                    MessageBox.Show("Ekleme işlemşi başarılı");
                }

                dataGridView1.DataSource = uto.Select();

            }
            catch(Exception a)
            {
                MessageBox.Show("Ekleme işleminde bir sıkıntı meydana geldi" );
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PersonelTip_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = uto.Select();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {              
                
                
                    string y = string.Format("delete from users where type_name='{0}'", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    using (MySqlCommand veri = new MySqlCommand())
                    {
                        veri.CommandText = y;
                        veri.Connection = Tools.Baglanti;
                        Tools.Baglanti.Close();
                        Tools.Baglanti.Open();
                        int a = veri.ExecuteNonQuery();
                        
                        
                        string z = string.Format("delete from usertype where type_name='{0}'", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    if (dataGridView1.CurrentRow.Cells[0].Value.ToString()=="Yönetici")
                    {
                        MessageBox.Show("Yönetici Silinemez");

                    }else
                    {
                        MySqlCommand veri2 = new MySqlCommand();
                        veri2.CommandText = z;
                        veri2.Connection = Tools.Baglanti;
                        Tools.Baglanti.Close();
                        Tools.Baglanti.Open();
                        int b = veri2.ExecuteNonQuery();
                        if (b >= 1)
                        {
                            MessageBox.Show("Silme işlmei başarılı");
                            dataGridView1.DataSource = uto.Select();
                        }

                        else
                        {
                            MessageBox.Show("silme işlemi başarısız");

                        }
                    }
                        
                    
                }
                
            }
            catch (Exception E)
            {
                MessageBox.Show("Lütfen birimi seçtiğinizden emin olunuz" + E);
            }
        }
    }

}
