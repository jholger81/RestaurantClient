using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using RestaurantClient.Properties;

namespace RestaurantClient
{
    public partial class index : Form
    {
        int intselectedTable = 0;

        public index()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

    

        private void btnadd_Click(object sender, EventArgs e)
        {
            Form addOrder = new addOrder(intselectedTable);

            // Show the settings form
            addOrder.Show();
        }

        private void btnpay_Click(object sender, EventArgs e)
        {
            Form payMenu = new payMenu(intselectedTable);

            // Show the settings form
            payMenu.Show();
        }

        private void tischwechselnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int dummy = intselectedTable;
            Button ctn = (Button)this.Controls.Find("btnTisch" + Convert.ToString(dummy), true)[0];
            int changetable = Convert.ToInt32(Interaction.InputBox("Zu welchem Tisch wird gewechselt?", "Tischwechsel", ""));
            ctn.BackColor = Color.DarkSeaGreen;
            ctn = (Button)this.Controls.Find("btnTisch" + Convert.ToString(changetable), true)[0];
            ctn.BackColor = Color.Khaki;
            //TODOo Farbwechsel


        }

        private void ButtonClick(object sender, EventArgs e)
        {
            
            
            intselectedTable = Int32.Parse(((Button)sender).Text.Remove(0, 6));
        }

        private void btndummy_Click(object sender, EventArgs e)
        {
            Restaurant.Models.Tisch tisch = new Restaurant.Models.Tisch();

            tisch = Restaurant.Database.DBAccess.GetTisch(2);
            MessageBox.Show(Convert.ToString(tisch.ID_Tisch));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SoundPlayer simpleSound = new SoundPlayer(@"H:\LF10\RestaurantClient\RestaurantClient\RestaurantClient\Resources\palim.wav");
            simpleSound.Play();
        }
    }
}
