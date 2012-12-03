using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace BaseIMEUI
{
    public partial class BIToolStripDropDown : ToolStripDropDownMenu
    {
        public BIToolStripDropDown()
        {
            InitializeComponent();
            this.ShowCheckMargin = false;
        }

        public BIToolStripDropDown(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.ShowCheckMargin = false;
        }

        //@defgroup CreateParams overriding for a non-activatable control.
        //@{
        #region WS_EX_NOACTIVATE
        /// <summary>
        /// Sets WS_EX_NOACTIVATE to prevent it from gaining focus.
        /// Since it is a UserControl, the Parent relation is broken to cut
        /// messsage flow off; WS_EX_NOPARENTNOTIFY (0x00000004) seems not work
        /// for this purpose...
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |=
                    Win32FunctionHelper.WindowExStyle.WS_EX_NOACTIVATE;
                cp.Parent = IntPtr.Zero;
                return cp;
            }
        }
        #endregion
        //@}

        #region The shadowed Show()
        public new void Show()
        {
            if (this.Handle == IntPtr.Zero)
                base.CreateControl();

            Win32FunctionHelper.SetParent(base.Handle, IntPtr.Zero);
            Win32FunctionHelper.ShowWindow(
                base.Handle, Win32FunctionHelper.CmdShow.SW_SHOWNOACTIVATE);
            this.Visible = true;
        }
        #endregion

    }
}
