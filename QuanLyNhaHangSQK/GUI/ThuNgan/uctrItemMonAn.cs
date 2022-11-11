using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHangSQK.GUI
{
    public partial class uctrItemMonAn : UserControl
    {
        public uctrItemMonAn()
        {
            InitializeComponent();
        }

        private string tieuDeMA;
        private Image anhMA;
        public event EventHandler ButtonClick;

        [Category("Custom Props")]
        public string TieuDeMA 
        { 
            get => tieuDeMA;
            set { tieuDeMA = value; lbTieuDeMA.Text = value; }
        }

        [Category("Custom Props")]
        public Image AnhMA 
        { 
            get => anhMA;
            set { anhMA = value; pctAnhMA.BackgroundImage = value; }
        }

        private void uctrItemMonAn_MouseEnter(object sender, EventArgs e)
        {
            lbTieuDeMA.ForeColor = Color.FromArgb(27, 30, 46);
            panel1.BackColor = Color.Gray;
        }

        private void uctrItemMonAn_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(27, 30, 46);
            lbTieuDeMA.ForeColor = Color.White;
        }

        private void pctAnhMA_Click(object sender, EventArgs e)
        {
            if (this.ButtonClick != null)
                this.ButtonClick(this, e);
        }
    }
}
