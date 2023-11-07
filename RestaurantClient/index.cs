using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using Restaurant.Models;
using RestaurantClient.Properties;

namespace RestaurantClient
{
    public partial class index : Form
    {
        int intselectedTable = 0;
        int inteac = 0;
        public int kellnerID = 0;


        public index()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;





        }



        private void btnadd_Click(object sender, EventArgs e)
        {

            if (intselectedTable != 0)
            {
                Form addOrder = new addOrder(intselectedTable);

                // Show the settings form
                addOrder.Show();
            }

        }

        private void btnpay_Click(object sender, EventArgs e)
        {
            if (intselectedTable != 0)
            {
                Form payMenu = new payMenu(intselectedTable);

                // Show the settings form
                payMenu.Show();
            }

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

        private async void ButtonClick(object sender, EventArgs e)
        {

            ltbshoworderd.Items.Clear();
            intselectedTable = Int32.Parse(((Button)sender).Text.Remove(0, 6));

            ApiClient apiClient = new ApiClient();
            //string apiUrl = "https://localhost:1337/tables";
            string apiUrl = "https://localhost:1337/orders/" + intselectedTable.ToString();
            //string result = ...
            Bestellung bestellung = await apiClient.GetDataFromApiGeneric<Bestellung>(apiUrl);
            Console.WriteLine("");
            if (bestellung != null)
            {
                foreach (var pos in bestellung.Positionen)
                {

                    ltbshoworderd.Items.Add(pos.Artikel.Name);

                }
            }
        }
            

        private async void btndummy_Click(object sender, EventArgs e)
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
            //string apiUrl = "https://localhost:1337/tables";
            string apiUrl = "https://localhost:1337/articles/drinks";
            //string result = ...
            List<Artikel> Artikel = await apiClient.GetDataFromApiGeneric<List<Artikel>>(apiUrl);
            Console.WriteLine("");
            MessageBox.Show(Artikel.First().Name);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            inteac++;
            if (inteac >= 5)
            {

                SoundPlayer simpleSound = new SoundPlayer(@".\palim.wav");
                simpleSound.Play();
            }

        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            inteac = 0;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
          
        }

        private async void index_Load(object sender, EventArgs e)
        {
            ApiClient apiClient = new ApiClient();
            //string apiUrl = "https://localhost:1337/tables";
            string apiUrl = "https://localhost:1337/tables";
            //string result = ...
            List<Tisch> tischliste = await apiClient.GetDataFromApiGeneric<List<Tisch>>(apiUrl);
            Console.WriteLine("");
            foreach (var tisch in tischliste)
            {
                if (tisch.ID_Kellner != kellnerID)
                {
                    Button ctn = (Button)this.Controls.Find("btnTisch" + Convert.ToString(tisch.ID_Tisch), true)[0];
                    ctn.BackColor = Color.Salmon;
                }
                

            }



            apiClient = new ApiClient();
            //string apiUrl = "https://localhost:1337/tables";
            apiUrl = "https://localhost:1337/tables/open";
            //string result = ...
            tischliste = await apiClient.GetDataFromApiGeneric<List<Tisch>>(apiUrl);
            Console.WriteLine("");
            foreach (var tisch in tischliste)
            {
                if (tisch.ID_Kellner == kellnerID)
                {
                    Button ctn = (Button)this.Controls.Find("btnTisch" + Convert.ToString(tisch.ID_Tisch), true)[0];
                    ctn.BackColor = Color.Khaki;
                }
            }
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form report = new report();

            // Show the settings form
            report.Show();
        }

        private async void kellnerEinloggenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kellnerID = Convert.ToInt32(Interaction.InputBox("Welche Kellner ID loggt sich ein?", "Kellner Login", ""));


            ApiClient apiClient = new ApiClient();
            //string apiUrl = "https://localhost:1337/tables";
            string apiUrl = "https://localhost:1337/tables";
            //string result = ...
            List<Tisch> tischliste = await apiClient.GetDataFromApiGeneric<List<Tisch>>(apiUrl);
            Console.WriteLine("");
            foreach (var tisch in tischliste)
            {
                if (tisch.ID_Kellner != kellnerID)
                {
                    Button ctn = (Button)this.Controls.Find("btnTisch" + Convert.ToString(tisch.ID_Tisch), true)[0];
                    ctn.BackColor = Color.Salmon;
                }
                else
                {
                    Button ctn = (Button)this.Controls.Find("btnTisch" + Convert.ToString(tisch.ID_Tisch), true)[0];
                    ctn.BackColor = Color.DarkSeaGreen;
                }
            }


           

            
            //string apiUrl = "https://localhost:1337/tables";
            apiUrl = "https://localhost:1337/tables/open";
            //string result = ...
            tischliste = await apiClient.GetDataFromApiGeneric<List<Tisch>>(apiUrl);
            Console.WriteLine("");
            foreach (var tisch in tischliste)
            {
                if (tisch.ID_Kellner == kellnerID)
                {
                    Button ctn = (Button)this.Controls.Find("btnTisch" + Convert.ToString(tisch.ID_Tisch), true)[0];
                    ctn.BackColor = Color.Khaki;
                }
            }
        }
    }
    
}
