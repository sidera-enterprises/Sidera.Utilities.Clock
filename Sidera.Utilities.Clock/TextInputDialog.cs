using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sidera.Utilities.Clock
{
    internal partial class TextInputDialog : Form
    {
        public TextInputDialog(string prompt) : this(prompt, "") { }

        public TextInputDialog(string prompt, string title)
        {
            InitializeComponent();

            Prompt = prompt;
            Text = title;
        }

        public string Prompt
        {
            get { return lblPrompt.Text; }
            set { lblPrompt.Text = value; }
        }

        public string Input
        {
            get { return txtInput.Text; }
            set { txtInput.Text = value; }
        }
    }
}
