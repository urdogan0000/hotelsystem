namespace $safeprojectname$.Formlar
{
    partial class Giris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Giris));
            this.btnYonet = new System.Windows.Forms.Button();
            this.btnRecep = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnYonet
            // 
            this.btnYonet.Location = new System.Drawing.Point(104, 25);
            this.btnYonet.Name = "btnYonet";
            this.btnYonet.Size = new System.Drawing.Size(117, 68);
            this.btnYonet.TabIndex = 0;
            this.btnYonet.Text = "Yönetici Girişi";
            this.btnYonet.UseVisualStyleBackColor = true;
            this.btnYonet.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRecep
            // 
            this.btnRecep.Location = new System.Drawing.Point(341, 25);
            this.btnRecep.Name = "btnRecep";
            this.btnRecep.Size = new System.Drawing.Size(117, 68);
            this.btnRecep.TabIndex = 0;
            this.btnRecep.Text = "Resepsiyonist Girişi";
            this.btnRecep.UseVisualStyleBackColor = true;
            this.btnRecep.Click += new System.EventHandler(this.btnRecep_Click);
            // 
            // Giris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(569, 392);
            this.Controls.Add(this.btnRecep);
            this.Controls.Add(this.btnYonet);
            this.Name = "Giris";
            this.Text = "Giris";
            this.Load += new System.EventHandler(this.Giris_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnYonet;
        private System.Windows.Forms.Button btnRecep;
    }
}