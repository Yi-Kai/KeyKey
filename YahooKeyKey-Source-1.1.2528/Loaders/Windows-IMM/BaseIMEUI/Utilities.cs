// [AUTO_HEADER]

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Text;

namespace BaseIMEUI
{
    /// <remarks>
    /// zonble's own small utilities
    /// </remarks>
    class Utilities
    {
        #region Debug Message
        /// <summary>
        /// To print a message on the debug console
        /// </summary>
        /// <param name="Message">The content of the message.</param>
        public static void msg(string Message)
        {
            System.Diagnostics.Debug.WriteLine(Message);
        }
        #endregion

        #region DrawRoundRect
        /// <summary>
        /// To generate a path of a rounded-corner rectangle.
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="radius"></param>
        /// <returns>The path od the rounded-corner rectangle.</returns>
        public static GraphicsPath DrawRoundRect(float X, float Y, float Width, float Height, float Radius)
        {
            GraphicsPath gp = new GraphicsPath();

            gp.AddLine(X + Radius, Y, X + Width - (Radius * 2), Y);
            gp.AddArc(X + Width - (Radius * 2), Y, Radius * 2, Radius * 2, 270, 90);
            gp.AddLine(X + Width, Y + Radius, X + Width, Y + Height - (Radius * 2));
            gp.AddArc(X + Width - (Radius * 2), Y + Height - (Radius * 2), Radius * 2, Radius * 2, 0, 90);
            gp.AddLine(X + Width - (Radius * 2), Y + Height, X + Radius, Y + Height);
            gp.AddArc(X, Y + Height - (Radius * 2), Radius * 2, Radius * 2, 90, 90);
            gp.AddLine(X, Y + Height - (Radius * 2), X, Y + Radius);
            gp.AddArc(X, Y, Radius * 2, Radius * 2, 180, 90);
            gp.CloseFigure();

            return gp;
        }
        /// <summary>
        /// To generate a path as the header part of a window.
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="radius"></param>
        /// <returns>The generqated path</returns>
        public static GraphicsPath DrawHeaderRect(float X, float Y, float Width, float Height, float Radius)
        {
            GraphicsPath gp = new GraphicsPath();

            gp.AddLine(X + Radius, Y, X + Width - (Radius * 2), Y);
            gp.AddArc(X + Width - (Radius * 2), Y, Radius * 2, Radius * 2, 270, 90);
            gp.AddLine(X + Width, Y + Radius, X + Width, Y + Height);
            gp.AddLine(X + Width - (Radius * 2), Y + Height, X, Y + Height);
            gp.AddLine(X, Y + Height - (Radius * 2), X, Y + Radius);
            gp.AddArc(X, Y, Radius * 2, Radius * 2, 180, 90);
            gp.CloseFigure();

            return gp;
        }

        public static GraphicsPath DrawBezelPath(float X, float Y, float Width, float Height, float Radius)
        {
            GraphicsPath gp = new GraphicsPath();

            gp.AddLine(X + Radius, Y, X + Width - Radius, Y);
            gp.AddLine(X + Width - Radius, Y, X + Width - Radius, Y + Radius);
            gp.AddLine(X + Width - Radius, Y + Radius, X + Width, Y + Radius);
            gp.AddLine(X + Width, Y + Radius, X + Width, Y + Height - Radius);
            gp.AddLine(X + Width, Y + Height - Radius, X + Width - Radius, Y + Height - Radius);
            gp.AddLine(X + Width - Radius, Y + Height - Radius, X + Width - Radius, Y + Height);
            gp.AddLine(X + Width - Radius, Y + Height, X + Radius, Y + Height);
            gp.AddLine(X + Radius, Y + Height, X + Radius, Y + Height - Radius);
            gp.AddLine(X + Radius, Y + Height - Radius, X, Y + Height - Radius);
            gp.AddLine(X, Y + Height - Radius, X, Y + Radius);
            gp.AddLine(X, Y + Radius, X + Radius, Y + Radius);
            gp.AddLine(X + Radius, Y + Radius, X + Radius, Y);
            gp.CloseFigure();

            return gp;
        }
        #endregion

        public static GraphicsPath DrawPageUp(float X, float Y, float size)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(X, Y + size, X + size, Y + size);
            gp.AddLine(X + size, Y + size, X + (size / 2), Y);
            gp.AddLine(X + (size / 2), Y, X, Y + size);
            gp.CloseFigure();
            return gp;
        }

        public static GraphicsPath DrawPageDown(float X, float Y, float size)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(X, Y, X + size, Y);
            gp.AddLine(X + size, Y, X + (size / 2), Y + size);
            gp.AddLine(X + (size / 2), Y + size, X, Y);
            gp.CloseFigure();
            return gp;
        }
    }
}
