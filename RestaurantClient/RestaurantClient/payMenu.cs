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
    public partial class payMenu : Form
    {
        public payMenu(int intselectedTable)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            lbltable.Text = "Ausgewählter Tisch: " + intselectedTable;
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rtbmoneygive_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void rtbmoneygive_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !(e.KeyChar == ',');
            
        }
    }
}
