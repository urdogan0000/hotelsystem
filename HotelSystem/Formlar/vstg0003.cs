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
    
    public partial class Fİrma_İşlemleri : Form
    {
        firmalar fm = new firmalar();
        FirmalarOrm fmo = new FirmalarOrm();
        public Fİrma_İşlemleri()
        {
            InitializeComponent();
        }
        bool x;

        private void Fİrma_İşlemleri_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = fmo.Select();
           
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                //checking the datagrid columns if it is empty or not
               
                       // Tools.GiveValues(fm, dataGridView1); //bu komut aşağıdaki koddaki değerleri otomatikman atıyor.
                                                 
                                fm.id = int.Parse((dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                                fm.name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                                fm.type = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                                fm.Sorumlu_kisi= dataGridView1.CurrentRow.Cells[3].Value.ToString();
                                fm.anlasma_tarihi = Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                               
                                
                        

                    
                

               
                    bool sonuc = fmo.İnsert(fm);

                    if (sonuc)
                    {
                        MessageBox.Show("Ekleme işlemi başarılı");

                        dataGridView1.DataSource = fmo.Select();
                        dataGridView1.Columns[0].Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("işlem başarısız");
                        
                    }
               
            }
            catch (Exception E)
            {
                MessageBox.Show("Lütfen işlem yapmak istediğiniz birimi kontrol edeniz..." +E);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string y = string.Format("delete from firmalar where id='{0}'", dataGridView1.CurrentRow.Cells[0].Value.ToString());
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
                    dataGridView1.DataSource = fmo.Select();
                  
                }
                else
                {
                    MessageBox.Show("silme işlemi başarısız");
                    
                }
            }
        }
    }
}
