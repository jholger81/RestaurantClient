using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Restaurant.Models;
using RestaurantClient.Properties;

namespace RestaurantClient
{
    public partial class report : Form
    {
        public report()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void btnDTPnext_Click(object sender, EventArgs e)
        {
            dtpReportDay.Value = dtpReportDay.Value.AddDays(1);
            
        }

        private void btnDTPback_Click(object sender, EventArgs e)
        {
            dtpReportDay.Value = dtpReportDay.Value.AddDays(-1);
         
        }

        private void btnDTPnextweek_Click(object sender, EventArgs e)
        {
            dtpReportDay.Value = dtpReportDay.Value.AddDays(7);
        }

        private void btnDTPlastweek_Click(object sender, EventArgs e)
        {
            dtpReportDay.Value = dtpReportDay.Value.AddDays(-7);
        }
    }
}
