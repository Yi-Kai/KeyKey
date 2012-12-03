// [AUTO_HEADER]

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace BaseIMEUI
{
    /// <remarks>
    /// The Notify Window. The window to display notify messages.
    /// </remarks>
    public partial class BINotifyForm : BIForm
    {
        private Font m_titleFont = new Font("Arial", 9.0F, FontStyle.Regular, GraphicsUnit.Point);
        private Brush m_defaultBursh = new SolidBrush(Color.Black);
        private string m_message;
        private int m_borderRadius = 6;
        private Color m_backgroundColor = System.Drawing.Color.FromArgb(40, 40, 40);
        private Color m_borderColor = System.Drawing.Color.DarkViolet;
        private Color m_titleColor = System.Drawing.Color.DarkViolet;
        private Color m_titleEndColor = System.Drawing.Color.Indigo;
        private Color m_foregroundColor = System.Drawing.Color.White;
        private Point m_originalPoint;

        // Class variables.
        private static int c_count;
        private static Point c_lastPosition;

        #region Class Methods
        /// <summary>
        /// Add the counting number of the instances of the Notify Winwdow class.
        /// </summary>
        public static void AddInstance()
        {
            BINotifyForm.c_count++;
        }
        /// Minus the counting number of the instances of the Notify Winwdow class.
        public static void RemoveInstance()
        {
            BINotifyForm.c_count--;
            if (BINotifyForm.c_count < 0)
                BINotifyForm.c_count = 0;
        }
        /// <summary>
        /// Restore the location of the last one of Notify windows.
        /// </summary>
        /// <param name="p"></param>
        public static void SetLastLocation(Point p)
        {
            BINotifyForm.c_lastPosition = p;
        }
        /// Get the location of the last one of Notify windows.
        public static Point GetLastLocation()
        {
            return BINotifyForm.c_lastPosition;
        }
        /// <summary>
        /// The location of the last one of Notify windows.
        /// </summary>
        public static Point LastLocation
        {
            get
            {
                return BINotifyForm.c_lastPosition;
            }
            set
            {
                BINotifyForm.c_lastPosition = value;
            }
        }
        /// <summary>
        /// The count of the Notify Windows.
        /// </summary>
        public static int Count
        {
            get { return BINotifyForm.c_count; }
        }

        #endregion

		/// Instance Methods
		
        /// <summary>
        /// The constructor.
        /// </summary>
        public BINotifyForm()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            this.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.Text = "";
            this.m_message = "";
            Rectangle mainArea = Screen.PrimaryScreen.WorkingArea;
        }

        private void InitLocation()
        {
            Rectangle mainArea = Screen.PrimaryScreen.WorkingArea;
            if (BINotifyForm.Count < 1)
            {
                this.Location = new Point(mainArea.Right - this.Width - 20, mainArea.Top + 10);
            }
            else
            {
                Point p = BINotifyForm.LastLocation;
                if (p.Y + this.Height + 10 > mainArea.Bottom)
                    p.Y = mainArea.Top + 10;
                else
                    p.Y += 10;
                this.Location = p;
            }
            Point bottomLeft = new Point(this.Left, this.Bottom);
            BINotifyForm.SetLastLocation(bottomLeft);
        }
        /// <summary>
        /// The shadowed Show() with animation effect.
        /// </summary>
        public new void Show()
        {
            this.InitLocation();
            this.m_originalPoint = this.Location;
            this.Top = this.Top - 10;
            this.Opacity = 0.5;
            base.Show();

            Timer moveInTimer = new Timer();
            moveInTimer.Interval = 10;
            moveInTimer.Tick += new EventHandler(m_moveInTimer_Tick);
            moveInTimer.Start();

            BINotifyForm.AddInstance();
        }

        private void m_moveInTimer_Tick(object sender, EventArgs e)
        {
            this.Top += 1;
            this.Opacity += 0.1;
            if (this.Top >= this.m_originalPoint.Y)
            {
                Timer timer = (Timer)sender;
                timer.Stop();
                timer.Dispose();
                this.Wait();
            }
        }

        private void Wait()
        {
            Timer waitTimer = new Timer();
            waitTimer.Tick += new EventHandler(this.m_waitTimer_Tick);
            waitTimer.Interval = 1000;
            waitTimer.Start();
        }

        private void m_waitTimer_Tick(object sender, EventArgs e)
        {
            Timer timer = (Timer)sender;
            timer.Stop();
            timer.Dispose();
            this.Fade();
        }

        public void Fade()
        {
            Timer fadeTimer = new Timer();
            fadeTimer.Interval = 50;
            fadeTimer.Tick += new EventHandler(fadeTimer_Tick);
            fadeTimer.Start();
        }

        private void fadeTimer_Tick(object sender, EventArgs e)
        {
			double opacity = this.Opacity;
            opacity = opacity - 0.2;
            if (opacity <= 0)
            {
                Timer timer = (Timer)sender;
                timer.Stop();
                timer.Dispose();
                BINotifyForm.RemoveInstance();
                this.Close();
                this.Dispose();
            }
			this.Opacity = opacity;
        }

        /// <summary>
        /// The message displayed in the notify window.
        /// </summary>
        public string Message
        {
            get { return m_message; }
            set { m_message = value; }
        }

        /// <summary>
        /// Set the message displayed in the notify window.
        /// </summary>
        /// <param name="NewMessage">The new message.</param>
        public void SetMesssage(string NewMessage)
        {
            this.m_message = NewMessage;
        }

        /// <summary>
        /// Set the title of the notify window.
        /// </summary>
        /// <param name="NewText">The new title.</param>
        public void SetText(string NewText)
        {
            this.Text = NewText;
            Invalidate();
        }

        #region Paint
        /// <summary>
        /// Paint the appearance of the notify window.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Rectangle backgroundRect = new Rectangle(0, 0, this.Width, this.Height);
            Rectangle borderRect = new Rectangle(2, 2, this.Width -2, this.Height - 2);
            Color backgroundColor = Color.Black;
            Color borderColor = Color.FromArgb(83, 1, 105);
			
			SolidBrush backgroundBrush = new SolidBrush(backgroundColor);
            g.FillRectangle(backgroundBrush, backgroundRect);
			backgroundBrush.Dispose();

            Pen borderPen = new Pen(borderColor, 2.0F);
            g.DrawRectangle(borderPen, borderRect);
			borderPen.Dispose();
			
            Rectangle headerRectHigherPart = new Rectangle(2, 2, this.Width - 4, 6);
            LinearGradientBrush gradientHigherPart = new LinearGradientBrush(headerRectHigherPart, Color.FromArgb(206, 31, 230), Color.FromArgb(116, 3, 126), LinearGradientMode.Vertical);
            g.FillRectangle(gradientHigherPart, headerRectHigherPart);
            gradientHigherPart.Dispose();
            
			Rectangle headerRectLowerPart = new Rectangle(2, 7, this.Width - 4, 12);
            LinearGradientBrush gradientLowerPart = new LinearGradientBrush(headerRectLowerPart, Color.FromArgb(83, 1, 105), Color.FromArgb(111, 0, 134), LinearGradientMode.Vertical);
            g.FillRectangle(gradientLowerPart, headerRectLowerPart);
            gradientLowerPart.Dispose();

			SolidBrush foregroundBrush = new SolidBrush(m_foregroundColor);
            g.DrawString(this.Text, m_titleFont, foregroundBrush, new PointF(this.m_borderRadius, 2));
			foregroundBrush.Dispose();

            StringFormat messageFormat =  new StringFormat();
            messageFormat.Alignment = StringAlignment.Center;
            RectangleF messageRect = new RectangleF(m_borderRadius / 2, 25, this.Width - m_borderRadius, this.Height - 30);
			SolidBrush messageBrush = new SolidBrush(Color.White);
            g.DrawString(this.m_message, this.Font, messageBrush, messageRect, messageFormat);
			messageBrush.Dispose();
			messageFormat.Dispose();
            
        }
        #endregion
    }
}