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
    public partial class SegmentedDigit : UserControl
    {
        private const string _LEGAL_CHARS = "0123456789-: ";

        private Dictionary<Panel, bool> _segments;
        private Color _fgcolor0, _fgcolor1;
        private char _value;
        private int _weight;

        public SegmentedDigit()
        {
            InitializeComponent();

            _segments = new Dictionary<Panel, bool>
            {
                { pnlH1, false },
                { pnlH2, false },
                { pnlH3, false },
                { pnlV1, false },
                { pnlV2, false },
                { pnlV3, false },
                { pnlV4, false },
                { pnlX1, false },
                { pnlX2, false },
            };

            foreach (var segment in _segments)
            {
                segment.Key.BackColor = BackColor;
                segment.Key.Paint += Segment_Paint;
            }

            //

            OffColor = Color.Black;
            OnColor = Color.Lime;
            Value = " ";
            SegmentWeight = 10;
        }

        private void RefreshSegments()
        {
            foreach (var segment in _segments)
            {
                segment.Key.Invalidate();
            }
        }

        public Color OffColor
        {
            get
            {
                return _fgcolor0;
            }
            set
            {
                _fgcolor0 = value;
                RefreshSegments();
            }
        }

        public Color OnColor
        {
            get
            {
                return _fgcolor1;
            }
            set
            {
                _fgcolor1 = value;
                RefreshSegments();
            }
        }

        public string Value
        {
            get
            {
                return _value.ToString();
            }
            set
            {
                if (_LEGAL_CHARS.Contains(value))
                {
                    if (_value != value[0])
                    {
                        _value = value[0];
                        RefreshSegments();
                    }
                }
                else
                {
                    string fArr = string.Join(", ", _LEGAL_CHARS.Select(c => $"'{c}'"));

                    throw new ArgumentException($"Invalid character {value}. Value must be from the set {{{fArr}}}.");
                }
            }
        }

        public int SegmentWeight
        {
            get { return _weight; }
            private set
            {
                _weight = value;

                SetSegmentSizes();
            }
        }

        public void SetProperties(int weight, Size size)
        {
            tpnlGrid.SuspendLayout();

            Size = size;
            SegmentWeight = weight;

            tpnlGrid.ResumeLayout();
        }

        private void SetSegmentSizes()
        {
            //MessageBox.Show(string.Join("\n", _segments.ToArray().Select(kvp => string.Join(" : ", kvp.Key.Name, kvp.Key.Size))));

            foreach (var segment in _segments)
            {
                Panel pnlSegment = segment.Key;

                //if (pnlSegment != pnlH2)
                //    continue;

                Size size;
                string name = pnlSegment.Name;
                char cOrientation = name[3];
                switch (cOrientation)
                {
                    case 'H':
                        size = new Size(0, _weight);
                        break;
                    case 'V':
                        size = new Size(_weight, 0);
                        break;
                    default:
                        size = new Size(_weight, _weight);
                        break;
                }

                pnlSegment.MinimumSize
                    = pnlSegment.MaximumSize = size;

                pnlSegment.Size = size;

                pnlSegment.Invalidate();
            }
        }

        private Panel[] ActivatedSegments
        {
            get
            {
                List<Panel> segments = new List<Panel>();

                switch (_value)
                {
                    case '0':
                        segments.AddRange(new Panel[] { pnlH1, pnlH3, pnlV1, pnlV2, pnlV3, pnlV4 });
                        break;
                    case '1':
                        segments.AddRange(new Panel[] { pnlV2, pnlV4 });
                        break;
                    case '2':
                        segments.AddRange(new Panel[] { pnlH1, pnlH2, pnlH3, pnlV2, pnlV3 });
                        break;
                    case '3':
                        segments.AddRange(new Panel[] { pnlH1, pnlH2, pnlH3, pnlV2, pnlV4 });
                        break;
                    case '4':
                        segments.AddRange(new Panel[] { pnlH2, pnlV1, pnlV2, pnlV4 });
                        break;
                    case '5':
                        segments.AddRange(new Panel[] { pnlH1, pnlH2, pnlH3, pnlV1, pnlV4 });
                        break;
                    case '6':
                        segments.AddRange(new Panel[] { pnlH1, pnlH2, pnlH3, pnlV1, pnlV3, pnlV4 });
                        break;
                    case '7':
                        segments.AddRange(new Panel[] { pnlH1, pnlV2, pnlV4 });
                        break;
                    case '8':
                        segments.AddRange(new Panel[] { pnlH1, pnlH2, pnlH3, pnlV1, pnlV2, pnlV3, pnlV4 });
                        break;
                    case '9':
                        segments.AddRange(new Panel[] { pnlH1, pnlH2, pnlH3, pnlV1, pnlV2, pnlV4 });
                        break;
                    case 'A':
                        segments.AddRange(new Panel[] { pnlH1, pnlH2, pnlV1, pnlV2, pnlV3, pnlV4 });
                        break;
                    case 'P':
                        segments.AddRange(new Panel[] { pnlH1, pnlH2, pnlV1, pnlV2, pnlV3 });
                        break;
                    case '-':
                        segments.AddRange(new Panel[] { pnlH2 });
                        break;
                    case ':':
                        segments.AddRange(new Panel[] { pnlX1, pnlX2 });
                        break;
                    case ' ':
                        break;
                }

                return segments.ToArray();
            }
        }

        private void SegmentedDigit_BackColorChanged(object sender, EventArgs e)
        {
            //foreach (Panel panel in tpnlGrid.Controls)
            //{
            //    Graphics g = panel.CreateGraphics();
            //    g.Clear(BackColor);
            //}
        }

        private void Segment_Paint(object sender, PaintEventArgs e)
        {
            if (sender is Panel)
            {
                Panel pSender = sender as Panel;

                Brush brush0, brush1;
                brush0 = new SolidBrush(_fgcolor0);
                brush1 = new SolidBrush(_fgcolor1);

                int width, height;
                width = pSender.Width;
                height = pSender.Height;

                e.Graphics.Clear(BackColor);

                Point[] polygon;
                if (width > height)
                {
                    polygon = new Point[]
                    {
                        new Point(height / 2, 0),
                        new Point(width - height / 2, 0),
                        new Point(width, height / 2),
                        new Point(width - height / 2, height),
                        new Point(height / 2, height),
                        new Point(0, height / 2),
                    };
                }
                else if (width < height)
                {
                    polygon = new Point[]
                    {
                        new Point(width / 2, 0),
                        new Point(width, width / 2),
                        new Point(height - width / 2, width / 2),
                        new Point(width / 2, height),
                        new Point(0, height - width / 2),
                        new Point(0, width / 2),
                    };
                }
                else
                {
                    polygon = new Point[]
                    {
                        new Point(0, 0),
                        new Point(width, 0),
                        new Point(width, height),
                        new Point(0, height),
                    };
                }

                e.Graphics.FillPolygon(ActivatedSegments.Contains(pSender) ? brush1 : brush0,
                    polygon);
            }
        }
    }
}
