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
    public partial class addOrder : Form
    {
        public addOrder(int intselectedTable)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            nudcount.Controls[0].Hide();
            lbltable.Text = "Ausgewählter Tisch: " + intselectedTable;
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addOrder_Load(object sender, EventArgs e)
        {

        }
    }
}
