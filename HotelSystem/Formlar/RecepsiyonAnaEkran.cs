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
    public partial class RecepsiyonAnaEkran : Form
    {
        public RecepsiyonAnaEkran()
        {
            InitializeComponent();
        }
        Müsteriİslemleri m = new Müsteriİslemleri();
        Rezervasyonİşlemleri r = new Rezervasyonİşlemleri();
        private void müşteriİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m.IsDisposed) m = new Müsteriİslemleri();
            m.MdiParent = this.MdiParent;
            m.Show();
        }

        private void rezervasyonİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (r.IsDisposed) r = new Rezervasyonİşlemleri();
            r.MdiParent = this.MdiParent;
            r.Show();
        }
    }
}
