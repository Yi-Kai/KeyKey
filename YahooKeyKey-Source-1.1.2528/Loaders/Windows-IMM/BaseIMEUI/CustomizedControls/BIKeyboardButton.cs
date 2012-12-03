using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace BaseIMEUI
{
    public partial class BIKeyboardButton : Button
    {
        public BIKeyboardButton()
        {
            InitializeComponent();
        }

        public string KeyName;
        public string Symbol;
        
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Font keyFont = new Font("Arial", 6);
            Font titleFont = new Font("PMingLiU", 11);
            Graphics g = e.Graphics;
            g.DrawString(KeyName, keyFont, Brushes.Green, new PointF(3, 3));
            g.DrawString(Symbol, titleFont, Brushes.Black, new PointF(6, 4));

        }
    }
}
