using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantClient
{
    public partial class extrasornon : Form
    {
        public string ReturnValue1 { get; set; }

        public extrasornon(string existingText)
        {
            InitializeComponent();

            // Füge den bereits existierenden Text in die RichTextBoxes ein
            string[] parts = existingText.Split(new string[] { " - " }, StringSplitOptions.None);
            if (parts.Length == 4 )
            {
                string removeText = parts[2].Substring(6); // Entferne "Kein: " vom Anfang
                string extraText = parts[3].Substring(7);  // Entferne "Extra: " vom Anfang

                rtbRemove.Text = removeText;
                rtbExtras.Text = extraText;
                //dummylable.Text = parts.Count().ToString();
            }
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            if (rtbExtras.Text == string.Empty && rtbRemove.Text == string.Empty)
            {
                this.ReturnValue1 = null;
            }
            else
            {
                this.ReturnValue1 = "Kein: " + rtbRemove.Text + " - Extra: " + rtbExtras.Text;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
