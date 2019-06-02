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
    public partial class Personelİslemleri : Form
    {
        public static bool x;
        public Personelİslemleri()
        {
            InitializeComponent();
        }

        UsersOrm us1 = new UsersOrm();
        Users us = new Users();


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
           
            try
            {
                //checking the datagrid columns if it is empty or not
                for (int i = 0; i < dataGridView1.ColumnCount -1; i++)
                {
                    if (string.IsNullOrEmpty(dataGridView1.CurrentRow.Cells[i].Value.ToString()))
                    {
                        if (i == 7)
                        {
                            continue;
                        }else
                        {
                            MessageBox.Show("Boş değer girilemez");
                            x = false;
                            break;
                        }
                      
                    }
                    else
                    {
                      
                                                   
                                us.Tcno = (dataGridView1.CurrentRow.Cells[0].Value.ToString());
                                us.Namess = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                                us.Surname = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                                us.Tel_no = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                                us.Email_adres = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                                us.Adres = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                                us.Salary = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                                us.type_name = comboBox1.SelectedItem.ToString();
                                
                                x = true;                      

                    }
                }

                if (x)
                {
                    bool sonuc = us1.İnsert(us);

                    if (sonuc)
                    {
                        MessageBox.Show("Ekleme işlemi başarılı");
                        göster();

                    }
                    else
                    {
                        MessageBox.Show("işlem başarısız");
                        göster();
                    }
                }
                else
                {
                    MessageBox.Show("işlem başarısız");
                }
            }
            catch (Exception E)
            {
                MessageBox.Show("Lütfen işlem yapmak istediğiniz birimi kontrol edeniz..."+E);
            }
        }

        private void Personelİslemleri_Load(object sender, EventArgs e)
        {


            dataGridView1.DataSource = us1.Select(); //verileri databaseden çekme işlemi stored procedure ile
            //verileri comboboxa atama işlemini yapıyoruz.
            try
            {
                using (MySqlCommand veri = new MySqlCommand())
                {
                    veri.CommandText = "select * from usertype ";
                    veri.Connection = Tools.Baglanti;
                    Tools.Baglanti.Open();
                    MySqlDataReader read = veri.ExecuteReader();
                    while (read.Read())
                    {
                        if ((read["type_name"]).ToString() == "Müsteri" | (read["type_name"]).ToString() == "Yönetici")
                        {
                            continue;
                        }
                        else
                        {
                        }
                        {
                            comboBox1.Items.Add(read["type_name"]);
                        }

                    }
                }
            }
            catch
            {

            }
        }

        public void göster()
        {
            try
            {
                string x = string.Format("select * from users where type_name='{0}'", comboBox1.SelectedItem.ToString());
                MySqlDataAdapter adp = new MySqlDataAdapter(x, Tools.Baglanti);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[7].Visible = false;
            }
            catch (Exception E)
            {
                MessageBox.Show("Exception is " + E);
            }


        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            göster();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedItem.ToString() == "")
                {
                    MessageBox.Show("Lütfen işlem yapmak istediğiniz birimiz seçiniz...");
                }
                else
                {
                    string y = string.Format("delete from users where Tcno='{0}'", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    using (MySqlCommand veri = new MySqlCommand())
                    {
                        veri.CommandText = y;
                        veri.Connection = Tools.Baglanti;
                        Tools.Baglanti.Close();
                        Tools.Baglanti.Open();
                        int a = veri.ExecuteNonQuery();
                        if (a >= 1)
                        {
                            MessageBox.Show("silme işlemş başarılı");
                            göster();
                        }
                        else
                        {
                            MessageBox.Show("silme işlemi başarısız");
                            göster();
                        }
                    }
                }
            }
            catch(Exception E)
            {
                MessageBox.Show("Lütfen birimi seçtiğinizden emin olunuz" +E);
            }                 
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {

            try
            {
                string z = string.Format("update users set Tcno='{0}',Namess='{1}',Surname='{2}',Tel_no='{3}',Email_adres='{4}',Adres='{5}',Salary={6} where Tcno='{0}'", dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView1.CurrentRow.Cells[1].Value.ToString(), dataGridView1.CurrentRow.Cells[2].Value.ToString(), dataGridView1.CurrentRow.Cells[3].Value.ToString(), dataGridView1.CurrentRow.Cells[4].Value.ToString(), dataGridView1.CurrentRow.Cells[5].Value.ToString(), double.Parse(dataGridView1.CurrentRow.Cells[6].Value.ToString()), dataGridView1.CurrentRow.Cells[0].Value.ToString());
                using (MySqlCommand veri = new MySqlCommand())
                {
                    veri.CommandText = z;
                    veri.Connection = Tools.Baglanti;
                    Tools.Baglanti.Close();
                    Tools.Baglanti.Open();
                    int a = veri.ExecuteNonQuery();
                    if (a >= 1)
                    {
                        MessageBox.Show("Güncelleme işlemş başarılı");
                        göster();
                    }
                    else
                    {
                        MessageBox.Show("Güncelleme işlemi başarısız");
                        göster();
                    }
                }
            }
            catch (Exception E)
            {
                MessageBox.Show("EXCEPTİON İS " + E);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = us1.Select();
        }
    }
}
