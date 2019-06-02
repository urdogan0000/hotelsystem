namespace $safeprojectname$.Formlar
{
    partial class RecepsiyonAnaEkran
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.müşteriİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rezervasyonİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ekonomikİşlemlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.müşteriİşlemleriToolStripMenuItem,
            this.rezervasyonİşlemleriToolStripMenuItem,
            this.ekonomikİşlemlerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(699, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // müşteriİşlemleriToolStripMenuItem
            // 
            this.müşteriİşlemleriToolStripMenuItem.Name = "müşteriİşlemleriToolStripMenuItem";
            this.müşteriİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.müşteriİşlemleriToolStripMenuItem.Text = "Müşteri İşlemleri";
            this.müşteriİşlemleriToolStripMenuItem.Click += new System.EventHandler(this.müşteriİşlemleriToolStripMenuItem_Click);
            // 
            // rezervasyonİşlemleriToolStripMenuItem
            // 
            this.rezervasyonİşlemleriToolStripMenuItem.Name = "rezervasyonİşlemleriToolStripMenuItem";
            this.rezervasyonİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(131, 20);
            this.rezervasyonİşlemleriToolStripMenuItem.Text = "Rezervasyon İşlemleri";
            this.rezervasyonİşlemleriToolStripMenuItem.Click += new System.EventHandler(this.rezervasyonİşlemleriToolStripMenuItem_Click);
            // 
            // ekonomikİşlemlerToolStripMenuItem
            // 
            this.ekonomikİşlemlerToolStripMenuItem.Name = "ekonomikİşlemlerToolStripMenuItem";
            this.ekonomikİşlemlerToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.ekonomikİşlemlerToolStripMenuItem.Text = "Ekonomik işlemler";
            // 
            // RecepsiyonAnaEkran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(699, 421);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "RecepsiyonAnaEkran";
            this.Text = "RecepsiyonAnaEkran";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem müşteriİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rezervasyonİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ekonomikİşlemlerToolStripMenuItem;
    }
}