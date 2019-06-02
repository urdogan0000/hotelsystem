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
    public partial class YöneticiAnaEkran : Form
    {
        Personelİslemleri pi = new Personelİslemleri();
        public YöneticiAnaEkran()
        {
            InitializeComponent();
        }



        private void personelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pi.IsDisposed) pi = new Personelİslemleri();
            pi.MdiParent = this.MdiParent;
            pi.Show();
        }

        private void odalarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void odaTipiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void YöneticiAnaEkran_Load(object sender, EventArgs e)
        {

        }
    }
}
