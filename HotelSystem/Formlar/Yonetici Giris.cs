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
    public partial class Yonetici_Giris : Form
    {
        public Yonetici_Giris()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Yonetici_Giris_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtUser.Text == "" | txtPw.Text == "")
                {
                    MessageBox.Show("Kullanıcı ad veya şifre boş bırakılamazzzz");


                }
                else
                {

                    //Recepsiyon ana ekranına giriş kontrolü
                    try
                    {
                        using (MySqlCommand logname = new MySqlCommand())
                        {

                            logname.CommandText = "select * from login where Tcno=@Tcno and Password=@Password and type_name='Yönetici' ";
                            logname.Parameters.AddWithValue("@Password", txtPw.Text);
                            logname.Parameters.AddWithValue("@Tcno", txtUser.Text);


                            logname.Connection = Tools.Baglanti;
                            Tools.Baglanti.Open();

                            MySqlDataReader oku = logname.ExecuteReader();


                            if (oku.Read())
                            {
                                MessageBox.Show("başarılı bir şekilde giriş yapıldı.");
                                YöneticiAnaEkran ra = new YöneticiAnaEkran();
                                ra.Show();
                            }
                            else
                            {
                                int c = 0;
                                MessageBox.Show("kullanıcı adı , parola  veya code hatalı");
                                c++;
                                if (c >= 2)
                                {
                                    Application.Exit();
                                }
                            }
                            logname.Dispose();
                        }
                    }
                    catch (Exception E)
                    {
                        MessageBox.Show("There is a error which is =" + E);

                    }
                    finally
                    {
                        Tools.Baglanti.Close();

                    }



                }
            }
            catch
            {
                MessageBox.Show("girilin bilgiler yanlıştır");
            }

        }
    }
}
          
    

            

    
