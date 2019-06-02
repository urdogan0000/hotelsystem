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
    public partial class Rezervasyonİşlemleri : Form
    {
        public Rezervasyonİşlemleri()
        {
            InitializeComponent();
        }



        public void loadRoom()
        {

        }

        private void Rezervasyonİşlemleri_Load(object sender, EventArgs e)
        {
            btnOda101.BackColor = Color.GreenYellow;
            btnOda102.BackColor = Color.GreenYellow;
            btnOda201.BackColor = Color.GreenYellow;
            btnOda202.BackColor = Color.GreenYellow;
            btnOda203.BackColor = Color.GreenYellow;
            btnOda301.BackColor = Color.GreenYellow;
            btnOda302.BackColor = Color.GreenYellow;

            MySqlDataAdapter adp = new MySqlDataAdapter("select * from rezervasyon ", Tools.Baglanti);
            Tools.Baglanti.Open();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            int c = dataGridView1.Rows.Count;
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.Yellow;
            loadRoom();
            hesapla();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        void button_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            txtOda.Text = btn.Name;
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtOda.Text == "" | txtTc.Text == "")
                {
                    MessageBox.Show("LÜtfen derğerleri doldurunuz");
                }
                MySqlCommand com = new MySqlCommand();
                com.CommandText = "insert into rezervasyon(Checkin, Checkout, ücret, Tcno, room_number)values(@checkin, @checkout,@ucret, @tcNo , @room) ";
                com.Parameters.AddWithValue("@checkin", dtpGirisTarihi.Value.ToString("yyyy-MM-dd"));
                com.Parameters.AddWithValue("@checkout", dtpCıkısTarihi.Value.ToString("yyyy-MM-dd"));
                com.Parameters.AddWithValue("@ucret", double.Parse(txtucret.Text));
                com.Parameters.AddWithValue("@tcNo", txtTc.Text);
                com.Parameters.AddWithValue("@room", Int32.Parse(txtOda.Text));
                if (int.Parse(txtToplam.Text) <= 0)
                {
                    MessageBox.Show("please apply proper dates");
                }
                else
                {
                    com.Connection = Tools.Baglanti;

                    int a = com.ExecuteNonQuery();
                    if (a >= 1)
                    {
                        MySqlCommand my = new MySqlCommand();
                        my.CommandText = String.Format("update odalar set durumu='Dolu' where oda_id={0}", txtOda.Text);
                        my.Connection = Tools.Baglanti;
                        int b = my.ExecuteNonQuery();
                        if (b >= 1)
                        {
                            loadRoom();
                            MessageBox.Show("Ekleme İşlemi başarılı");
                        }
                        else
                        {
                            MessageBox.Show("Ekleme Başarısız");

                        }

                    }
                    else
                    {
                        MessageBox.Show("Ekleme Başarısız");
                    }
                }
            }
            catch (Exception E)
            {
                MessageBox.Show("exception is + " + E);
            }


        }

        private void dtpCıkısTarihi_ValueChanged(object sender, EventArgs e)
        {
            DateTime kucukTarıh = Convert.ToDateTime(dtpGirisTarihi.Text);
            DateTime buyukTarıh = Convert.ToDateTime(dtpCıkısTarihi.Text);
            TimeSpan sonuc = buyukTarıh - kucukTarıh;
            txtToplam.Text = sonuc.TotalDays.ToString();
            hesapla();
        }
        public void hesapla()
        {
            int c = dataGridView1.Rows.Count;

            for (int i = 0; i < c - 1; i++)
            {
                DateTime kucukTarıh1 = Convert.ToDateTime(dtpGirisTarihi.Value.ToString("yyyy-MM-dd"));
                DateTime buyukTarıh1 = Convert.ToDateTime(dataGridView1.Rows[i].Cells[1].Value.ToString());
                TimeSpan time = kucukTarıh1 - buyukTarıh1;
                string a = dataGridView1.Rows[i].Cells[4].Value.ToString();
                double z = time.TotalDays;

                if (z > 0)
                {
                    if (a == "101")
                    {
                        btnOda101.BackColor = Color.GreenYellow;
                        btnOda101.Enabled = true;

                    }
                    if (a == "102")
                    {
                        btnOda102.BackColor = Color.GreenYellow;
                        btnOda102.Enabled = true;

                    }

                    if (a == "201")
                    {

                        btnOda201.BackColor = Color.GreenYellow;
                        btnOda201.Enabled = true;
                    }
                    if (a == "202")
                    {

                        btnOda202.BackColor = Color.GreenYellow;
                        btnOda202.Enabled = true;
                    }
                    if (a == "203")
                    {

                        btnOda203.BackColor = Color.GreenYellow;
                        btnOda203.Enabled = true;
                    }
                    if (a== "301")
                    {

                        btnOda301.BackColor = Color.GreenYellow;
                        btnOda301.Enabled = true;
                    }

                }
                else
                {
                    if (a == "101")
                    {

                        btnOda101.BackColor = Color.Red;
                        btnOda101.Enabled = false;
                    }
                    if (a== "102")
                    {

                        btnOda102.BackColor = Color.Red;
                        btnOda102.Enabled = false;
                    }

                    if (a== "201")
                    {

                        btnOda201.BackColor = Color.Red;
                        btnOda201.Enabled = false;
                    }
                    if (a== "202")
                    {

                        btnOda202.BackColor = Color.Red;
                        btnOda202.Enabled = false;
                    }
                    if (a == "203")
                    {

                        btnOda203.BackColor = Color.Red;
                        btnOda203.Enabled = false;
                    }
                    if (a == "301")
                    {

                        btnOda301.BackColor = Color.Red;
                        btnOda301.Enabled = false;
                    }
                    if (a == "302")
                    {

                        btnOda302.BackColor = Color.Red;
                        btnOda302.Enabled = false;
                    }

                }
            }

        }

        private void dtpGirisTarihi_ValueChanged(object sender, EventArgs e)
        {

            hesapla();




            /*
            loadRoom(); int x = 0;
            int y = 2;
            try
            {
                using (MySqlCommand veri = new MySqlCommand())
                {



                    veri.CommandText = "select * from odalar ";
                    veri.Connection = Tools.Baglanti;
                    Tools.Baglanti.Close();
                    Tools.Baglanti.Open();
                    MySqlDataReader read = veri.ExecuteReader();
                    while (read.Read())
                    {
                        if (x == 4)
                        {
                            x = 0;
                            y++;
                        }
                        Button btn = new Button();
                        btn.Text = read["oda_id"].ToString();
                        btn.Name = read["oda_id"].ToString();
                        btn.Size = new Size(70, 60);
                        btn.Location = new Point(100 * (x + 1), 60 * y);
                        btn.Margin = new Padding(50, 60, 50, 30);
                        btn.Click += new EventHandler(this.button_click);
                        Controls.Add(btn);
                        x++;


                    }
                }
            }
            catch (Exception E)
            {
                MessageBox.Show("Exception is = " + E);
            }
            */

        }
        protected void YeniButon_Click(object sender, EventArgs e)

        {

            

        }

        private void btnOda101_Click(object sender, EventArgs e)
        {
            txtOda.Text = "101";
        }

        private void btnOda102_Click(object sender, EventArgs e)
        {
            txtOda.Text = "102";
        }

        private void btnOda201_Click(object sender, EventArgs e)
        {
            txtOda.Text = "201";
        }

        private void btnOda202_Click(object sender, EventArgs e)
        {
            txtOda.Text = "202";
        }

        private void btnOda203_Click(object sender, EventArgs e)
        {
            txtOda.Text = "203";
        }

        private void btnOda301_Click(object sender, EventArgs e)
        {
            txtOda.Text = "301";
        }

        private void btnOda302_Click(object sender, EventArgs e)
        {
            txtOda.Text = "302";
        }

        private void txtOda_TextChanged(object sender, EventArgs e)
        {
            hesapla();
            using (MySqlCommand veri = new MySqlCommand())
            {
                string t = string.Format("select * from odalar where room_number='{0}'", txtOda.Text);
                veri.CommandText = t;
                veri.Connection = Tools.Baglanti;
               
                MySqlDataReader read = veri.ExecuteReader();
                while (read.Read())
                {
                    txtucret.Text = read["ücreti"].ToString();

                }
            }

        }

        private void txtucret_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
    

