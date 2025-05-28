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
        public TextInputDialog(string prompt) : this(prompt, "", null) { }

        public TextInputDialog(string prompt, string[] autoCompleteSource) : this(prompt, "", autoCompleteSource) { }

        public TextInputDialog(string prompt, string title) : this(prompt, title, null) { }

        public TextInputDialog(string prompt, string title, string[] autoCompleteSource)
        {
            InitializeComponent();

            Prompt = prompt;
            Text = title;
            SetSuggestions(autoCompleteSource);
        }

        public string Prompt
        {
            get { return grpPrompt.Text; }
            set { grpPrompt.Text = value; }
        }

        public string Input
        {
            get { return txtInput.Text; }
            set { txtInput.Text = value; }
        }

        public void SetSuggestions(string[] suggestions)
        {
            if (suggestions != null)
            {
                txtInput.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtInput.AutoCompleteSource = AutoCompleteSource.CustomSource;

                txtInput.AutoCompleteCustomSource.Clear();
                txtInput.AutoCompleteCustomSource.AddRange(suggestions);
            }
        }

        private void TextInputDialog_Load(object sender, EventArgs e)
        {
            txtInput.Focus();
        }
    }
}
