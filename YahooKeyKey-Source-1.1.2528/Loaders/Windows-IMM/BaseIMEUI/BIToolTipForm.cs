// [AUTO_HEADER]

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseIMEUI;

namespace BaseIMEUI
{
    public partial class BIToolTipForm : BIForm
    {
        private float m_inputBufferHeightInPixel = 50;
        private Point m_targetPoint;

        /// <summary>
        /// The Tooltip Window.
        /// The tooltip provided is not created by using the system tooltip components, but we
        /// have to do it with using the Form class and apply visual effects by our self.
        /// </summary>
        public BIToolTipForm()
        {
            InitializeComponent();
            this.Font = new System.Drawing.Font("Tahoma", 8.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Paint += new PaintEventHandler(BIToolTipForm_Paint);
        }

        void BIToolTipForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            this.PaintTipForm(this.Text, this.Font, g);

        }

        private delegate void SetTextCallBack(string newText);
        /// <summary>
        /// Setting the content text of the tooltip
        /// </summary>
        /// <param name="newText">The new content text.</param>        
        public void SetText(string newText)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new SetTextCallBack(SetText), new object[] { newText });
                return;
            }
            this.Text = newText;
        }

        /// <summary>
        /// The Shadowed CreateParams
        /// The tooltip window should have drop-shadow
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= Win32FunctionHelper.ClassStyle.CS_DropSHADOW;
                return cp;
            }
        }

        protected void PaintTipForm(string text, Font font, Graphics g)
        {
            SizeF size = g.MeasureString(text, font);
            this.Size = new Size((int)size.Width + 4, (int)size.Height + 4);
            Size formSize = this.Size;
            this.AdjustLocation(formSize);

            Rectangle borderRect = new Rectangle(0, 0, formSize.Width - 1, formSize.Height - 1);
            SolidBrush textBrush = new SolidBrush(Color.Black);
            Pen textPen = new Pen(Color.Black);
            g.DrawRectangle(textPen, borderRect);

            SolidBrush backgroundBrush = new SolidBrush(Color.LightYellow);
            g.FillRectangle(backgroundBrush, new Rectangle(1, 1, formSize.Width - 2, formSize.Height - 2));
            backgroundBrush.Dispose();
            
            g.DrawString(text, font, textBrush, new Point(2, 2));
            textBrush.Dispose();
            textPen.Dispose();
        }

        public void SetInputBufferHeightInPixel(long newHeight)
        {
            this.m_inputBufferHeightInPixel = (float)newHeight;
        }

        #region Window Location
        private delegate void SetLocationCallBack(int x, int y);
        /// <summary>
        /// To set the location of the candidate window.
        /// The SetLocation() method is inherited from the BIForm class,
        /// however, the SetLocation() method of the candidate window do not
        /// move the window directly, but set a target location temporary,
        /// the window will move to the target location while re-drawing the 
        /// window and the on-paint event is launched.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>        
        public new void SetLocation(int x, int y)
        {
            this.m_targetPoint = new Point(x, y);
        }

        public void SetLocationDirectly(int x, int y)
        {
            if (this.InvokeRequired)
            {
                SetLocationCallBack aSetLocationCall = new SetLocationCallBack(SetLocationDirectly);
                this.Invoke(aSetLocationCall, new object[] { x, y });
                return;
            }

            this.Location = new Point(x, y);
            this.Invalidate();
        }
        #endregion

        protected void AdjustLocation(Size formSize)
        {
            #region Window Position

            try
            {
                Screen currentScreen;
                if (Screen.AllScreens.Length == 1)
                    currentScreen = Screen.PrimaryScreen;
                else
                    currentScreen = Screen.FromPoint(m_targetPoint);

                Rectangle tmpRect = new Rectangle(m_targetPoint, formSize);

                if (tmpRect.Top < 0)
                    tmpRect.Y = (int)m_inputBufferHeightInPixel;
                if (tmpRect.Bottom > currentScreen.WorkingArea.Bottom)
                {
                    tmpRect.Y = tmpRect.Top - tmpRect.Height - (int)m_inputBufferHeightInPixel - 10;
                    if (tmpRect.Bottom > currentScreen.WorkingArea.Bottom)
                        tmpRect.Y = currentScreen.WorkingArea.Bottom - tmpRect.Height - (int)m_inputBufferHeightInPixel - 5;
                }
                if (tmpRect.Right > currentScreen.WorkingArea.Right)
                    tmpRect.X = currentScreen.WorkingArea.Right - tmpRect.Width;

                this.Size = tmpRect.Size;
                this.Location = tmpRect.Location;
            }
            catch { }
            #endregion
        }

    }

}