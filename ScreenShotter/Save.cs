using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ScreenShotter
{
    public partial class Save : Form
    {
        Bitmap bmp;
        public Save(Int32 x, Int32 y, Int32 w, Int32 h, Size s)
        {
            InitializeComponent();

            Rectangle rect = new Rectangle(x, y, w, h);

            bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, s, CopyPixelOperation.SourceCopy);
            bmp.Save(@"C:\Users\harri\Pictures\screen.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
            pbCapture.Image = bmp;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.CheckPathExists = true;
            sfd.FileName = "Capture";
            sfd.Filter = "PNG Image(*.png)|*.png|JPG Image(*.jpg)|*.jpg|BMP Image(*.bmp)|*.bmp";
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                pbCapture.Image.Save(sfd.FileName);
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            frmHome home = new frmHome();
            this.Hide();
            home.Show();
        }
    }
}
