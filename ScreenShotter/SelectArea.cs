using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenShotter
{
    public partial class SelectArea : Form
    {
        public SelectArea()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.Opacity = .5D;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Green, Top);
            e.Graphics.FillRectangle(Brushes.Green, Left);
            e.Graphics.FillRectangle(Brushes.Green, Right);
            e.Graphics.FillRectangle(Brushes.Green, Bottom);
        }

        private const int
            HTLEFT = 10,
            HTRIGHT = 11,
            HTTOP = 12,
            HTTOPLEFT = 13,
            HTTOPRIGHT = 14,
            HTBOTTOM = 15,
            HTBOTTOMLEFT = 16,
            HTBOTTOMRIGHT = 17;

        const int size = 10;

        Rectangle Top { get { return new Rectangle(0, 0, this.ClientSize.Width, size); } }
        Rectangle Left { get { return new Rectangle(0, 0, size, this.ClientSize.Height); } }
        Rectangle Bottom { get { return new Rectangle(0, this.ClientSize.Height - size, this.ClientSize.Width, size); } }
        Rectangle Right { get { return new Rectangle(this.ClientSize.Width - size, 0, size, this.ClientSize.Height); } }
        Rectangle TopLeft { get { return new Rectangle(0, 0, size, size); } }
        Rectangle TopRight { get { return new Rectangle(this.ClientSize.Width - size, 0, size, size); } }
        Rectangle BottomLeft { get { return new Rectangle(0, this.ClientSize.Height - size, size, size); } }
        Rectangle BottomRight { get { return new Rectangle(this.ClientSize.Width - size, this.ClientSize.Height - size, size, size); } }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if(m.Msg == 0x84)
            {
                var cursor = this.PointToClient(Cursor.Position);

                if (TopLeft.Contains(cursor)) m.Result = (IntPtr)HTTOPLEFT;
                else if (TopRight.Contains(cursor)) m.Result = (IntPtr)HTTOPRIGHT;
                else if (BottomLeft.Contains(cursor)) m.Result = (IntPtr)HTBOTTOMLEFT;
                else if (BottomRight.Contains(cursor)) m.Result = (IntPtr)HTBOTTOMRIGHT;

                else if (Top.Contains(cursor)) m.Result = (IntPtr)HTTOP;
                else if (Left.Contains(cursor)) m.Result = (IntPtr)HTLEFT;
                else if (Right.Contains(cursor)) m.Result = (IntPtr)HTRIGHT;
                else if (Bottom.Contains(cursor)) m.Result = (IntPtr)HTBOTTOM;
            }
        }

    }
