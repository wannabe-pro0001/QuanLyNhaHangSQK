
namespace QuanLyNhaHangSQK.GUI
{
    partial class uctrItemMonAn
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTieuDeMA = new System.Windows.Forms.Label();
            this.pctAnhMA = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctAnhMA)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 40;
            this.guna2Elipse1.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.panel1.Controls.Add(this.pctAnhMA);
            this.panel1.Controls.Add(this.lbTieuDeMA);
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(176, 177);
            this.panel1.TabIndex = 6;
            this.panel1.Click += new System.EventHandler(this.pctAnhMA_Click);
            this.panel1.MouseEnter += new System.EventHandler(this.uctrItemMonAn_MouseEnter);
            this.panel1.MouseLeave += new System.EventHandler(this.uctrItemMonAn_MouseLeave);
            // 
            // lbTieuDeMA
            // 
            this.lbTieuDeMA.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTieuDeMA.Location = new System.Drawing.Point(3, 135);
            this.lbTieuDeMA.Name = "lbTieuDeMA";
            this.lbTieuDeMA.Size = new System.Drawing.Size(170, 42);
            this.lbTieuDeMA.TabIndex = 3;
            this.lbTieuDeMA.Text = "Nhà hàng Dubai\r\nNhà hàng Dubai";
            this.lbTieuDeMA.Click += new System.EventHandler(this.pctAnhMA_Click);
            this.lbTieuDeMA.MouseEnter += new System.EventHandler(this.uctrItemMonAn_MouseEnter);
            this.lbTieuDeMA.MouseLeave += new System.EventHandler(this.uctrItemMonAn_MouseLeave);
            // 
            // pctAnhMA
            // 
            this.pctAnhMA.BackgroundImage = global::QuanLyNhaHangSQK.Properties.Resources._63c3fc67_20200626_appvinid_bannerweb_vivu;
            this.pctAnhMA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pctAnhMA.Location = new System.Drawing.Point(0, 0);
            this.pctAnhMA.Name = "pctAnhMA";
            this.pctAnhMA.Size = new System.Drawing.Size(176, 132);
            this.pctAnhMA.TabIndex = 2;
            this.pctAnhMA.TabStop = false;
            this.pctAnhMA.Click += new System.EventHandler(this.pctAnhMA_Click);
            this.pctAnhMA.MouseEnter += new System.EventHandler(this.uctrItemMonAn_MouseEnter);
            this.pctAnhMA.MouseLeave += new System.EventHandler(this.uctrItemMonAn_MouseLeave);
            // 
            // uctrItemMonAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "uctrItemMonAn";
            this.Size = new System.Drawing.Size(176, 177);
            this.MouseEnter += new System.EventHandler(this.uctrItemMonAn_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.uctrItemMonAn_MouseLeave);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctAnhMA)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pctAnhMA;
        private System.Windows.Forms.Label lbTieuDeMA;
    }
}
