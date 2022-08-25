using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Ingenieros_Commerce_Manager_v2._0.Controls
{
    class EllipseControl : Control
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
   (
      int nLeftRect,
      int nTopRect,
      int nRightRect,
      int nBottomRect,
      int nWidthEllipse,
      int nHeightEllipse
   );

        [DllImport("Gdi32.dll", EntryPoint = "DeleteObject")]
        public static extern bool DeleteObject(IntPtr hObject);


        private void RecreateRegion()
        {
            IntPtr handle = CreateRoundRectRgn(0, 0, Width, Height, _CornerRadius, _CornerRadius);
            Region = Region.FromHrgn(handle);
            DeleteObject(handle);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.RecreateRegion();
        }

        private int _CornerRadius = 30;

        public int CornerRadius
        {
            get { return _CornerRadius; }
            set
            {
                _CornerRadius = value;
                this.RecreateRegion();
            }
        }
    }
}
