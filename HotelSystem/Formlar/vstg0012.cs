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
    public partial class Odalarımız : Form
    {
        public Odalarımız()
        {
            InitializeComponent();
        }
        bool x;


        public void loadRoom()
        {
            //  int x = 1;
            //  int y = 4;
            try
            {


                string t = string.Format("select * from odalar where typename='{0}'", comboBox1.SelectedItem.ToString());
                MySqlDataAdapter adp = new MySqlDataAdapter(t, Tools.Baglanti);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;



                /*otomatik verileri buton şekline getirme işlemi için
                while (read.Read())
                {

                    MySqlDataReader read = veri.ExecuteReader();
                    Button btn = new Button();
                    btn.Text = read["oda_id"].ToString();
                    btn.Name = read["oda_id"].ToString();
                    btn.Size = new Size(50, 50);
                    btn.Location = new Point(70 * (x + 1), 60 * y);

                    Controls.Add(btn);

                    if (x == 3)
                    {
                        x = 0;
                        y++;
                    }
                    x++;



            }
            */

            }
            catch (Exception E)
            {
                MessageBox.Show("Exception is = " + E);
            }

        }

        Odalar od = new Odalar();
        OdalarOrm odo = new OdalarOrm();

        private void Odalar_Load(object sender, EventArgs e)
        {
            try
            {
                using (MySqlCommand veri = new MySqlCommand())
                {
                    veri.CommandText = "select * from roomtype ";
                    veri.Connection = Tools.Baglanti;

                    Tools.Baglanti.Open();
                    MySqlDataReader read = veri.ExecuteReader();
                    while (read.Read())
                    {
                        comboBox1.Items.Add(read["typename"]);
                    }
                }
            }
            catch
            {
                Tools.Baglanti.Close();
            }



        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadRoom();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Lütfen yapacağınız işlemi seçiniz...");
            }
            else if (comboBox2.SelectedItem.ToString() == "Ekle")
            {
                try
                {
                    //checking the datagrid columns if it is empty or not
                    for (int i = 0; i < dataGridView1.ColumnCount - 1; i++)
                    {
                        if (string.IsNullOrEmpty(dataGridView1.CurrentRow.Cells[i].Value.ToString()))
                        {
                            MessageBox.Show("Boş değer girilemez");
                            x = false;
                            break;
                        }
                        else
                        {

                            od.oda_id = (dataGridView1.CurrentRow.Cells[0].Value.ToString());
                            od.room_number = (dataGridView1.CurrentRow.Cells[0].Value.ToString());
                            od.kisi_sayisi = int.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                            od.ücreti = double.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());
                            od.durumu = "Bos";
                            od.typename = comboBox1.SelectedItem.ToString();

                            x = true;

                        }
                    }

                    if (x)
                    {
                        bool sonuc = odo.İnsert(od);

                        if (sonuc)
                        {
                            MessageBox.Show("Ekleme işlemi başarılı");
                            loadRoom();

                        }
                        else
                        {
                            MessageBox.Show("işlem başarısız");
                            loadRoom();
                        }
                    }
                    else
                    {
                        MessageBox.Show("işlem başarısız");
                    }
                }
                catch (Exception E)
                {
                    MessageBox.Show("Lütfen işlem yapmak istediğiniz birimi kontrol edeniz...");
                }
            }
            else if (comboBox2.SelectedItem.ToString() == "Çıkar")
            {
                try
                {
                    
                    /*
                     
                     
                    od.oda_id = (dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    odo.Delete(od);

                     */
                    string y = string.Format("delete from odalar where room_number='{0}'", dataGridView1.CurrentRow.Cells[0].Value.ToString());
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
                            loadRoom();
                        }
                        else
                        {
                            MessageBox.Show("silme işlemi başarısız");
                            loadRoom();

                        }
                    }
                }
                catch (Exception E)
                {
                    MessageBox.Show("Lütfen birimi seçtiğinizden emin olunuz" + E);
                }
            }
            else
            {
                try
                {

                    /* 
                       
                            od.room_number = (dataGridView1.CurrentRow.Cells[0].Value.ToString());
                            od.kisi_sayisi = int.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());
                            od.ücreti = double.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());
                            
                             odo.Update(od);
                            */
                    string z = string.Format("update odalar set room_number='{0}',kisi_sayisi='{1}',ücreti='{2}' where oda_id='{3}'", dataGridView1.CurrentRow.Cells[0].Value.ToString(), int.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString()), double.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString()),dataGridView1.CurrentRow.Cells[1].Value.ToString());
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
                            loadRoom();
                        }
                        else
                        {
                            MessageBox.Show("Güncelleme işlemi başarısız");
                            loadRoom();
                        }
                    }
                }
                catch (Exception E)
                {
                    MessageBox.Show("EXCEPTİON İS " + E);
                }
            }
        }
    }
}
