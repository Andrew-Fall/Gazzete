using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gazette.CustomControls
{
    public class MyVScrollBar : VScrollBar
    {
        
        public bool IsUsingThumbtrack { get; private set; }

        // https://referencesource.microsoft.com/#System.Windows.Forms/winforms/Managed/System/WinForms/NativeMethods.cs,e75041b5218ff60b,references
        // Reflect WM_VSCROLL so we can determine if the user is scrolling the bar or not.
        private const int WM_USER = 0x0400;
        private const int WM_REFLECT = WM_USER + 0x1C00;
        private const int WM_VSCROLL = 0x0115;

        private const int VSCROLL_REFLECT = WM_REFLECT + WM_VSCROLL;
        private const int SB_THUMBTRACK = 5;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == VSCROLL_REFLECT)
            {

                short loword = (short)(m.WParam.ToInt32() & 0xFFFF);

                IsUsingThumbtrack = loword == SB_THUMBTRACK;
            }
            base.WndProc(ref m);
        }
    }
}