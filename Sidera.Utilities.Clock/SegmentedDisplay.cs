using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sidera.Utilities.Clock
{
    internal partial class SegmentedDisplay : UserControl
    {
        private int _length;
        private Color _fgcolor0, _fgcolor1;

        public SegmentedDisplay()
        {
            InitializeComponent();
        }

        private SegmentedDigit[] Digits
        {
            get
            {
                List<SegmentedDigit> list = new List<SegmentedDigit>();

                foreach (Control control in fpnlDisplay.Controls)
                {
                    if (control is SegmentedDigit)
                    {
                        list.Add(control as SegmentedDigit);
                    }
                }

                return list.ToArray();
            }
        }

        public Color OffColor
        {
            get { return _fgcolor0; }
            set
            {
                _fgcolor0 = value;
                foreach (SegmentedDigit digit in Digits)
                {
                    digit.OffColor = value;
                }
            }
        }

        public Color OnColor
        {
            get { return _fgcolor1; }
            set
            {
                _fgcolor1 = value;
                foreach (SegmentedDigit digit in Digits)
                {
                    digit.OnColor = value;
                }
            }
        }

        public int Length
        {
            get { return _length; }
            set
            {
                _length = value;
                
                fpnlDisplay.Controls.Clear();
                for (int i = 0; i < value; i++)
                {
                    SegmentedDigit digit = new SegmentedDigit()
                    {
                        OffColor = OffColor,
                        OnColor = OnColor,
                        Margin = fpnlDisplay.Padding,
                    };

                    fpnlDisplay.Controls.Add(digit);
                }
            }
        }

        public int SegmentWeight
        {
            get
            {
                try
                {
                    return Digits[0].SegmentWeight;
                }
                catch
                {
                    return -1;
                }
            }
        }

        public Size DigitSize
        {
            get
            {
                try
                {
                    return Digits[0].Size;
                }
                catch
                {
                    return default;
                }
            }
        }

        public void SetSegmentedDigitProperties(int weight, Size size)
        {
            
            fpnlDisplay.SuspendLayout();

            foreach (var digit in Digits)
            {
                digit.SetProperties(weight, size);
            }

            fpnlDisplay.ResumeLayout();
        }

        private void fpnlDisplay_Paint(object sender, PaintEventArgs e)
        {
            Pen penBlack, penWhite;
            penBlack = new Pen(Color.Black, 1);
            penWhite = new Pen(Color.White, 1);

            Rectangle rect1, rect2;
            rect1 = new Rectangle(new Point(0, 0),
                new Size(fpnlDisplay.Width - 1, fpnlDisplay.Height - 1));
            rect2 = new Rectangle(new Point(rect1.X + 1, rect1.Y + 1),
                new Size(rect1.Width - 2, rect1.Height - 2));

            e.Graphics.DrawRectangle(penBlack, rect1);
            e.Graphics.DrawRectangle(penWhite, rect2);
        }

        public new string Text
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (SegmentedDigit digit in Digits)
                {
                    sb.Append(digit.Value);
                }

                return sb.ToString();
            }
            set
            {
                string text = value.PadLeft(_length, ' ');

                if (text.Length <= _length)
                {
                    for (int i = 0; i < _length; i++)
                    {
                        Digits[i].Value = text[i].ToString();
                    }
                }
            }
        }
    }
}
