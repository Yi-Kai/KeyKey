// [AUTO_HEADER]

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace BaseIMEUI
{
    public partial class BIInputBufferForm : BIForm
    {
        private string m_bufferText = "";
        private string m_prompt = "";
        private string m_promptDescription = "";
        private int m_readingTextStart = 0;
        private int m_readingTextRange = 0;
        private int m_cursorIndex = 0;
        private int m_fontHeight = 0;
        private int m_bufferHeight = 0;
        private Point m_cursorPosition = new Point();
        private float m_fontSize = 14.0F;
        private Font m_promptFont;
        private Font m_promptDescriptionFont;
        private ArrayList m_underlines = new ArrayList();

        // The basic setting of the visual style.
        private TextFormatFlags m_textFormatFlag = TextFormatFlags.NoPadding | TextFormatFlags.NoClipping;
        private Color m_bufferTextColor = Color.Black;
        private Color m_readingTextColor = Color.DarkRed;
        private Color m_cursorBackgroundColor = Color.DarkViolet;
        private Color m_cursorTextColor = Color.White;
        private Color m_underlineColor = Color.Blue;
        private Color m_borderColor = Color.FromArgb(149, 149, 149);
        
        private int m_textPadding = 2;

        public BIInputBufferForm()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
			FontFamily fontFamily = Win32FontHelper.DefaultFontFamily();
            this.Font = new Font(fontFamily, this.m_fontSize, FontStyle.Regular, GraphicsUnit.Point, ((byte)(136)));
            this.m_promptFont = new Font(fontFamily, 10.0F);
            this.m_promptDescriptionFont = new Font(fontFamily, 9.0F);
			fontFamily.Dispose();
        }

        public new void SetLocation(int x, int y)
        {
            base.SetLocation(x, y);
            this.Invalidate();
        }

        public void SetFontHeight(long newHeightInPixel)
        {
            using (Graphics g = this.CreateGraphics())
			{
	            // @zonble
	            // The unit of the height passed within the variable
	 			// "newHeightInPixel" is pixel, however, we need to know 
				// the hieght in point, and then we are able to set the height
				// of a font object. So, we need to convert itfrom pixel to 
				// point. BTW, during this conversion, we need to know the 
                // current screen resolution (DPI). 

                // the input is in px, but Font needs pt, so scale back
                float newHeight = (float)newHeightInPixel * 72.0F / g.DpiX;
                BIServerConnector callback = BIServerConnector.SharedInstance;
                if (callback != null) {
                    if (callback.hasLoaderConfigKey("IMEUnawareComposingBufferHeightPt")) {
                        // take this in ppt
                        newHeight = (float)Int64.Parse(callback.stringValueForLoaderConfigKey("IMEUnawareComposingBufferHeightPt"));
                    }
                }                

                FontFamily fontFamily = Win32FontHelper.DefaultFontFamily();
                Font font = new Font(fontFamily, newHeight, FontStyle.Regular, GraphicsUnit.Point, ((byte)(136)));
                this.Font = font;
                fontFamily.Dispose();
                font.Dispose();
				g.Dispose();
			}
        }

        public int BufferHeight
        {
            get { return m_bufferHeight; }
        }

        public Point CursorPosition
        {
            get { return m_cursorPosition; }
        }

        public void ClearUnderlines()
        {
            this.m_underlines.Clear();
        }

        public void AddUnderline(int start, int length)
        {
            Underline u = new Underline(start, length);
            this.m_underlines.Add(u);
        }

        public string Buffer
        {
            get { return m_bufferText; }
        }

        private delegate void SetBufferAndCursorIndexCallBack(string newBufferText, int cursorIndex);

        public void SetBufferAndCursorIndex(string newBufferText, int cursorIndex)
		{
            if (this.InvokeRequired)
            {
                SetBufferAndCursorIndexCallBack aCall = new SetBufferAndCursorIndexCallBack(SetBufferAndCursorIndex);
                this.Invoke(aCall, new object[] { newBufferText, cursorIndex });
                return;
            }
		    
            this.m_bufferText = newBufferText;
            if (this.m_bufferText.Length == 0)
            {
                this.m_readingTextStart = 0;
                this.m_readingTextRange = 0;
                this.m_cursorIndex = 0;
            }
			else {
	            this.m_cursorIndex = cursorIndex;
			}
        }

        public void ClearBuffer()
        {
            this.m_bufferText = "";
            this.m_readingTextStart = 0;
            this.m_readingTextRange = 0;
            this.m_cursorIndex = 0;
        }

        public string Prompt
        {
            get { return this.m_prompt; }
            set { this.SetPrompt(value); }
        }


        private delegate void SetPromptCallBack(string newPrompt);
        
        public void SetPrompt(string newPrompt)
        {
            if (this.InvokeRequired)
            {
                SetPromptCallBack aCall = new SetPromptCallBack(SetPrompt);
                this.Invoke(aCall, new object[] { newPrompt });
                return;
            }
            
            this.m_prompt = newPrompt;
        }

        public void ClearPrompt()
        {
            this.m_prompt = "";
        }

        public string PromptDescription
        {
            get { return m_promptDescription; }
            set { this.SetPromptDescription(value); }
        }

        public void SetPromptDescription(string newPromptDescription)
        {
            this.m_promptDescription = newPromptDescription;
        }

        public void CleatPromptDescription()
        {
            this.m_promptDescription = "";
        }

        public int CursorIndex
        {
            get { return this.m_cursorIndex; }
        }

        public void SetReading(int start, int range)
        {
            this.m_readingTextStart = start;
            this.m_readingTextRange = range;
        }

        #region Private methods
		// private delegate Size StringSizeCallBack(string text, Graphics g);
        private Size StringSize(string text, Graphics g)
        {
			if (text == null)
				return new Size(0, 0);
			if (text.Length == 0)
				return new Size(0, 0);
					
            Size proposedSize =
                new Size(
                    Math.Abs(this.m_fontHeight) * text.Length,
                    Math.Abs(this.m_fontHeight));

	        Font thisFont = this.Font;
	        Size stringSize =
	            TextRenderer.MeasureText(
	                g, text, thisFont, proposedSize,
	                this.m_textFormatFlag);
	        thisFont.Dispose();
	        return stringSize;
        }

        private float StringWidth(string text, Graphics g)
        {
            return this.StringSize(text, g).Width;
        }

        private float StringHeight(string text, Graphics g)
        {
            return this.StringSize(text, g).Height;
        }
        #endregion

        #region Event handlers

        protected void PaintInputBufferForm(string bufferText, string prompt, string promptDescription, int cursorIndex, int readingTextStart, int readingTextRange, ArrayList underlines, Graphics g)
        {
            #region Split string
            // We would like to seperate the buffer text into three parts: the 
            // string before, of, and after the reading part.
            string stringBeforeReading = "";
            string stringReading = "";
            string stringAfterReading = "";

            if (readingTextStart >= 0 && cursorIndex >= 0) {
                if (bufferText.Length - readingTextStart >= 0) {
                    stringBeforeReading = bufferText.Remove(readingTextStart, (bufferText.Length - readingTextStart));
                }
            
                if (bufferText.Length - readingTextStart - readingTextRange >= 0) {
                    stringReading = bufferText.Remove(readingTextStart + readingTextRange, bufferText.Length - readingTextStart - readingTextRange).Remove(0, readingTextStart);
                }
                
                if (readingTextStart + readingTextRange <= bufferText.Length) {
                    stringAfterReading = bufferText.Remove(0, readingTextStart + readingTextRange);
                }
            }

            // Calulatiting the start position of each string
            float widthBeforeReading = StringWidth(stringBeforeReading, g);
            float widthOfReading = StringWidth(stringReading, g);
            float widthAfterReading = StringWidth(stringAfterReading, g);
            // Draw the background
            float height = StringHeight(" ", g);
            float width = widthBeforeReading + widthOfReading + widthAfterReading;

            #endregion

            #region Set window size

            Font thisFont = this.Font;
            int fontsize = (int)thisFont.Size;

            Rectangle bufferTextBackground;

            if (prompt.Length > 0)
            {
                SizeF promptSizeF = g.MeasureString(prompt, this.m_promptFont);
                if (width < promptSizeF.Width + 10)
                    width = (int)promptSizeF.Width + 10;

                promptSizeF = g.MeasureString(promptDescription, this.m_promptDescriptionFont);
                if (width < promptSizeF.Width + 10)
                    width = (int)promptSizeF.Width + 10;
                promptSizeF.Height += 10;

                GraphicsPath round = Utilities.DrawRoundRect(0, 0, (int)(width + fontsize + m_textPadding * 2) + 10, (int)(height) + m_textPadding * 2 + 30 + (int)promptSizeF.Height, 2);
                GraphicsPath roundBorder = Utilities.DrawRoundRect(0, 0, (int)(width + fontsize + m_textPadding * 2) + 10 - 1, (int)(height) + m_textPadding * 2 + 30 + (int)promptSizeF.Height - 1, 2);

                Rectangle darkSide = new Rectangle(
                    (int)round.GetBounds().Left,
                    (int)round.GetBounds().Top + (int)round.GetBounds().Height / 2,
                    (int)round.GetBounds().Left + (int)round.GetBounds().Width,
                    (int)round.GetBounds().Top + (int)round.GetBounds().Height / 2);

                LinearGradientBrush gradientBrush = new LinearGradientBrush(
                    new Point((int)round.GetBounds().Left, (int)round.GetBounds().Top),
                    new Point((int)round.GetBounds().Left, (int)round.GetBounds().Top + (int)(round.GetBounds().Height / 2) + 2),
                    Color.Black, Color.DarkGray);
                g.FillPath(gradientBrush, round);
                gradientBrush.Dispose();

                SolidBrush darkBrush = new SolidBrush(Color.Black);
                g.FillRectangle(darkBrush, darkSide);
                darkBrush.Dispose();

                Pen borderPen = new Pen(m_borderColor);
                g.DrawPath(borderPen, roundBorder);
                borderPen.Dispose();

                SolidBrush promptBrush = new SolidBrush(Color.White);
                g.DrawString(prompt, this.m_promptFont, promptBrush, new PointF(5F, 3F));
                promptBrush.Dispose();

                if (promptDescription.Length > 0)
                {
                    SolidBrush textBrush = new SolidBrush(Color.White);
                    g.DrawString(promptDescription, this.m_promptDescriptionFont, textBrush, new PointF(5F, round.GetBounds().Height - promptSizeF.Height));
                    textBrush.Dispose();
                }

                bufferTextBackground = new Rectangle(5, 24, (int)(width + fontsize + this.m_textPadding * 2), (int)(height) + this.m_textPadding * 2 + 2);
                this.Size = new Size((int)round.GetBounds().Width + 10, (int)round.GetBounds().Height + 10);

                Region windowRegion = new Region(round);
                this.Region = windowRegion;
                windowRegion.Dispose();

                round.Dispose();
                roundBorder.Dispose();
            }
            else
            {
                bufferTextBackground = new Rectangle(0, 0, (int)(width + fontsize + this.m_textPadding * 2), (int)(height) + this.m_textPadding * 2 + 2);
                this.Size = new Size(bufferTextBackground.Width + 10, bufferTextBackground.Height + 10);

                using (Region windowRegion = new Region(bufferTextBackground))
                {
                    this.Region = windowRegion;
                }
            }

            this.m_bufferHeight = bufferTextBackground.Height; 
            #endregion

            #region Draw background
            this.DrawBackground(prompt, bufferTextBackground, g);       
            #endregion

            #region Set window location
            Screen currentScreen;
            if (Screen.AllScreens.Length == 1)
                currentScreen = Screen.PrimaryScreen;
            else
                currentScreen = Screen.FromPoint(this.Location);

            if (this.Top > currentScreen.WorkingArea.Bottom || this.Bottom > currentScreen.WorkingArea.Bottom)
                this.Top = currentScreen.WorkingArea.Bottom - this.Height;

            if (this.Left > currentScreen.WorkingArea.Right || this.Right > currentScreen.WorkingArea.Right)
                this.Left = currentScreen.WorkingArea.Right - this.Width; 
            #endregion

            #region Draw text
            TextRenderer.DrawText(g, stringBeforeReading, thisFont,
        new Point(bufferTextBackground.Left + this.m_textPadding, bufferTextBackground.Top + this.m_textPadding),
        this.m_bufferTextColor,
        Color.Transparent,
        this.m_textFormatFlag);
            TextRenderer.DrawText(g, stringReading, thisFont,
                new Point(bufferTextBackground.Left + (int)widthBeforeReading + this.m_textPadding, bufferTextBackground.Top + this.m_textPadding),
                this.m_readingTextColor,
                Color.Transparent,
                this.m_textFormatFlag);
            TextRenderer.DrawText(g, stringAfterReading, thisFont,
                new Point((int)(bufferTextBackground.Left + widthBeforeReading + widthOfReading + this.m_textPadding), bufferTextBackground.Top + this.m_textPadding),
                this.m_bufferTextColor,
                Color.Transparent,
                this.m_textFormatFlag); 
            #endregion

            this.DrawCaret(bufferText, cursorIndex, thisFont, bufferTextBackground, g);
            this.DrawUnderlines(bufferText, bufferTextBackground, height, underlines, g); 
        }

        protected void DrawBackground(string prompt, Rectangle bufferTextBackground, Graphics g)
        {
            LinearGradientBrush currentBackgroundBrush;

            if (prompt != null && prompt.Length > 0)
                currentBackgroundBrush = new LinearGradientBrush(new Point(bufferTextBackground.Left, bufferTextBackground.Top), new Point(bufferTextBackground.Left, bufferTextBackground.Top + bufferTextBackground.Height), Color.LightGray, Color.White);
            else
                currentBackgroundBrush = new LinearGradientBrush(new Point(bufferTextBackground.Left, bufferTextBackground.Top), new Point(bufferTextBackground.Left, bufferTextBackground.Top + bufferTextBackground.Height), Color.White, Color.LightGray);

            g.FillRectangle(currentBackgroundBrush, bufferTextBackground);
            currentBackgroundBrush.Dispose();

            if (prompt != null && prompt.Length > 0)
            {
                Pen blackPen = new Pen(Color.Black);
                Pen lightGrayPen = new Pen(Color.LightGray);
                g.DrawLine(blackPen, bufferTextBackground.Left, bufferTextBackground.Top, bufferTextBackground.Left + bufferTextBackground.Width - 1, bufferTextBackground.Top);
                g.DrawLine(blackPen, bufferTextBackground.Left, bufferTextBackground.Top, bufferTextBackground.Left, bufferTextBackground.Top + bufferTextBackground.Height - 1);
                g.DrawLine(lightGrayPen, bufferTextBackground.Left + bufferTextBackground.Width - 1, bufferTextBackground.Top + bufferTextBackground.Height - 1, bufferTextBackground.Left + bufferTextBackground.Width - 1, bufferTextBackground.Top);
                g.DrawLine(lightGrayPen, bufferTextBackground.Left + bufferTextBackground.Width - 1, bufferTextBackground.Top + bufferTextBackground.Height - 1, bufferTextBackground.Left, bufferTextBackground.Top + bufferTextBackground.Height - 1);
                blackPen.Dispose();
                lightGrayPen.Dispose();
            }
            else
            {
                Pen grayPen = new Pen(Color.Gray);
                Pen lightGrayPen = new Pen(Color.LightGray);
                g.DrawLine(lightGrayPen, bufferTextBackground.Left, bufferTextBackground.Top, bufferTextBackground.Left + bufferTextBackground.Width - 1, bufferTextBackground.Top);
                g.DrawLine(lightGrayPen, bufferTextBackground.Left, bufferTextBackground.Top, bufferTextBackground.Left, bufferTextBackground.Top + bufferTextBackground.Height - 1);
                g.DrawLine(grayPen, bufferTextBackground.Left + bufferTextBackground.Width - 1, bufferTextBackground.Top + bufferTextBackground.Height - 1, bufferTextBackground.Left + bufferTextBackground.Width - 1, bufferTextBackground.Top);
                g.DrawLine(grayPen, bufferTextBackground.Left + bufferTextBackground.Width - 1, bufferTextBackground.Top + bufferTextBackground.Height - 1, bufferTextBackground.Left, bufferTextBackground.Top + bufferTextBackground.Height - 1);
                grayPen.Dispose();
                lightGrayPen.Dispose();
            } 
        }

        protected void DrawCaret(string bufferText, int cursorIndex, Font thisFont, Rectangle bufferTextBackground, Graphics g)
        {
            // Draw the caret
            string caretText = " ";
            string stringBeforeCaret = "";
            
            if (cursorIndex >= 0) {
                if (cursorIndex < bufferText.Length)
                {
                    caretText = new string(bufferText[cursorIndex], 1);
                }
                if (cursorIndex <= bufferText.Length)
                {
                    stringBeforeCaret = bufferText.Remove(cursorIndex, bufferText.Length - cursorIndex);
                }
            }

            float widthBeforeCaret = StringWidth(stringBeforeCaret, g);

            Size caretSize = this.StringSize(caretText, g);
            Rectangle caretRectangle = new Rectangle(new Point(bufferTextBackground.Left + (int)widthBeforeCaret + this.m_textPadding, bufferTextBackground.Top + this.m_textPadding), caretSize);
            LinearGradientBrush currentCaretBrush = new LinearGradientBrush(new Point(bufferTextBackground.Left, bufferTextBackground.Top), new Point(bufferTextBackground.Left, bufferTextBackground.Top + caretSize.Height), Color.Violet, Color.Indigo);
            g.FillRectangle(currentCaretBrush, caretRectangle);

            TextRenderer.DrawText(g, caretText, thisFont, caretRectangle, this.m_cursorTextColor, this.m_textFormatFlag);
            thisFont.Dispose();
            currentCaretBrush.Dispose();

            this.m_cursorPosition = new Point(this.Left + caretRectangle.Left, this.Top + bufferTextBackground.Bottom);
        }

        protected void DrawUnderlines(string bufferText, Rectangle bufferTextBackground, float height, ArrayList underlines, Graphics g)
        {
            if (underlines.Count > 0)
            {
                foreach (Underline underline in underlines)
                {
                    if (underline.Range < 1)
                    {
                        continue;
                    }
                    string stringBeforeBeginOfUnderline = "";
                    string stringBeforeEndOfUnderline = "";
                    
                    if (bufferText.Length - underline.Begin >= 0) {
                        stringBeforeBeginOfUnderline = bufferText.Remove(underline.Begin, bufferText.Length - underline.Begin);
                    }
                    
                    if (bufferText.Length - underline.End >= 0) {
                        stringBeforeEndOfUnderline = bufferText.Remove(underline.End, bufferText.Length - underline.End);
                    }

                    int widthOfStringBeforeBeginOfUnderline = (int)StringWidth(stringBeforeBeginOfUnderline, g);
                    int widthOfStringBeforeEndOfUnderline = (int)StringWidth(stringBeforeEndOfUnderline, g);
                    using (SolidBrush penBrush = new SolidBrush(this.m_underlineColor))
                    {
                        Pen linePen = new Pen(penBrush, 1.3F);
                        g.DrawLine(linePen,
                            new Point(bufferTextBackground.Left + widthOfStringBeforeBeginOfUnderline + this.m_textPadding + 2, bufferTextBackground.Top + (int)height + this.m_textPadding),
                            new Point(bufferTextBackground.Left + widthOfStringBeforeEndOfUnderline + this.m_textPadding - 2, bufferTextBackground.Top + (int)height + this.m_textPadding));
                        linePen.Dispose();
                    }
                }
            }
        }


 		protected override void OnPaint(PaintEventArgs e)
        {
            if (!this.Visible)
                return;

            Graphics g = e.Graphics;

            int readingTextStart = this.m_readingTextStart;
            int readingTextRange = this.m_readingTextRange;
            string bufferText = this.m_bufferText;
			if (bufferText == null)
			{
				bufferText = "";
			}
            string prompt = this.m_prompt;
            string promptDescription = this.m_promptDescription;
            int cursorIndex = this.m_cursorIndex;
            ArrayList underlines = this.m_underlines;
			if (underlines == null)
			{
                underlines = new ArrayList();
			}

            this.PaintInputBufferForm(bufferText, prompt, promptDescription, cursorIndex, readingTextStart, readingTextRange, underlines, g);
            
        }
        #endregion
    }

    #region Class to draw the underlines.
    class Underline
    {
        private int underlineBegin;
        private int underlineRange;
        private int underlineEnd;

        public Underline(int newUnderlineBegin, int newUnderlineRange)
        {
            this.underlineBegin = newUnderlineBegin;
            this.underlineRange = newUnderlineRange;
            this.underlineEnd = newUnderlineBegin + newUnderlineRange;
        }

        public int Begin
        {
            get { return this.underlineBegin; }
            set
            {
                this.underlineBegin = value;
                this.underlineEnd = this.underlineBegin + this.underlineRange;
            }
        }

        public int Range
        {
            get { return this.underlineRange; }
            set
            {
                this.underlineRange = value;
                this.underlineEnd = this.underlineBegin + this.underlineRange;
            }
        }

        public int End
        {
            get { return this.underlineEnd; }
        }
    } 
    #endregion
}