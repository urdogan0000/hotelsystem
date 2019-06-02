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
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        Yonetici_Giris r = new Yonetici_Giris();
        Resepsiyonist_Giriş b = new Resepsiyonist_Giriş();

        private void button1_Click(object sender, EventArgs e)
        {
            if (r.IsDisposed) r = new Yonetici_Giris();
            r.MdiParent = this.MdiParent;
            r.Show();
        }

        private void btnRecep_Click(object sender, EventArgs e)
        {
            if (b.IsDisposed) b = new Resepsiyonist_Giriş();
            b.MdiParent = this.MdiParent;
            b.Show();
        }

        private void Giris_Load(object sender, EventArgs e)
        {

        }
    }
 }

