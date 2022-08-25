using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ingenieros_Commerce_Manager_v2._0.Components
{
    internal class EllipseComponent : Component
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
        private Control _control;
        private int _CornerRadius = 30;

        public Control TargetControl
        {
            get { return _control; }
            set
            {
                _control = value;
                _control.SizeChanged += (sender, EventArgs) =>
                {
                    IntPtr handle = CreateRoundRectRgn
                    (
                        0,
                        0,
                        _control.Width,
                        _control.Height,
                        _CornerRadius,
                        _CornerRadius
                    );
                    _control.Region = Region.FromHrgn(handle);
                    DeleteObject(handle);
                };
            }
        }
        public int CornerRadius
        {
            get { return _CornerRadius; }
            set
            {
                _CornerRadius = value;
                if (_control != null)
                {
                    IntPtr handle = CreateRoundRectRgn
                    (
                        0,
                        0,
                        _control.Width,
                        _control.Height,
                        _CornerRadius,
                        _CornerRadius
                    );
                    _control.Region = Region.FromHrgn(handle);
                    DeleteObject(handle);
                }
            }
        }
    }
}
