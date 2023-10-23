using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using RestaurantClient.Properties;
using System.Text.Json;
using Restaurant.Models;

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

        private async void button3_MouseDown(object sender, MouseEventArgs e)
        {
            //ApiClient apiClient = new ApiClient();
            //string apiUrl = "https://localhost:1337/orders/7";
            //string result = await apiClient.GetDataFromApi(apiUrl);
            //Bestellung bestellung = new Bestellung();
            //Bestellung bestellung2 = await apiClient.GetDataFromApiGeneric<Bestellung>(apiUrl);

            //if (result != null)
            //{
            //    Console.WriteLine("API response:");
            //    Console.WriteLine(result);
            //    bestellung = JsonSerializer.Deserialize<Bestellung>(result);
            //}
            //else
            //{
            //    Console.WriteLine("API request failed or encountered an error.");
            //}
            //Console.WriteLine("");

            ApiClient apiClient = new ApiClient();
            string apiUrl = "https://localhost:1337/tables";
            //string result = ...
            List<Tisch> tische = await apiClient.GetDataFromApiGeneric<List<Tisch>>(apiUrl);
            Console.WriteLine("");
        }
    }
}
