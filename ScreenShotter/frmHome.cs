using System;
using System.Windows.Forms;

namespace ScreenShotter
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            SelectArea area = new SelectArea();
            this.Hide();
            area.Show();
        }
    }
}
