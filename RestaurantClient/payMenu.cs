using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Restaurant;
using Restaurant.Models;

namespace RestaurantClient
{
    public partial class payMenu : Form
    {
        public int intselectedTable;
        public double inttopay;
        public payMenu(int intselectedTabledummy)
        {
            InitializeComponent();
            intselectedTable = intselectedTabledummy;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            lbltable.Text = "Ausgewählter Tisch: " + intselectedTable;
            inttopay = 0;
            rtbcost.Text = inttopay.ToString();
            
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
            
          
            
        }

        private void rtbmoneygive_KeyUp(object sender, KeyEventArgs e)
        {

            if (string.IsNullOrEmpty(rtbmoneygive.Text))
            {
                e.Handled = false; // Erlaube leere Eingabe
            }
            else
            {
                if (!(char.IsDigit((char)e.KeyCode) || e.KeyCode == Keys.Oemcomma || e.KeyCode == Keys.Decimal))
                {
                    e.SuppressKeyPress = true;
                }
            }

            if (rtbmoneygive.Text.Contains(","))
            {
                string[] parts = rtbmoneygive.Text.Split(',');

                if (parts.Length > 1 && parts[1].Length > 2)
                {
                    // Entfernen der dritten Nachkommastelle
                    rtbmoneygive.Text = string.Format("{0},{1}{2}", parts[0], parts[1].Substring(0, 2), parts.Length > 2 ? "," + parts[2] : "");
                }
            }


            if (!string.IsNullOrEmpty(rtbmoneygive.Text))
            {
                double moneyGiven = 0;
                double cost = 0;



                if (double.TryParse(rtbmoneygive.Text, out moneyGiven) &&
                    double.TryParse(rtbcost.Text, out cost))
                {

                    double tipsInEuro = moneyGiven - cost;
                    rtbTips.Text = Convert.ToString(tipsInEuro);
                }
            }
            
        }

        private async void payMenu_Load(object sender, EventArgs e)
        {
            ApiClient apiClient = new ApiClient();
            //string apiUrl = "https://localhost:1337/tables";
            string apiUrl = "https://localhost:1337/orders/" + intselectedTable.ToString() + "/open";
            //string result = ...
            List<Bestellung> bestellungen = await apiClient.GetDataFromApiGeneric<List<Bestellung>>(apiUrl);
            Console.WriteLine("");

            

            if (bestellungen != null)
            {
                foreach (var bestellung in bestellungen)
                {
                    foreach (var pos in bestellung.Positionen)
                    {
                        clbnotpayed.Items.Add(pos.ID_Artikel + " - " + pos.Artikel.Name);

                    }
                }
            }

            apiUrl = "https://localhost:1337/orders/" + intselectedTable.ToString() + "/closed";
            bestellungen = await apiClient.GetDataFromApiGeneric<List<Bestellung>>(apiUrl);
            Console.WriteLine("");
            if (bestellungen != null)
            {
                foreach (var bestellung in bestellungen)
                {
                    foreach (var pos in bestellung.Positionen)
                    {

                        lbpayed.Items.Add(pos.ID_Artikel + " - " + pos.Artikel.Name);

                    }
                }
            }

            
            clbnotpayed.SelectedIndex = 0;


        }

        private async void clbnotpayed_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
            ApiClient apiClient = new ApiClient();
            //string apiUrl = "https://localhost:1337/tables";
            if (clbnotpayed.SelectedItem != null)
            {
                string apiUrl = "https://localhost:1337/articles/id/" + clbnotpayed.SelectedItem.ToString().Split('-')[0];
                //string result = ...
                Artikel artikel = await apiClient.GetDataFromApiGeneric<Artikel>(apiUrl);
                Console.WriteLine("");
                if (artikel != null)
                {
                    if (e.CurrentValue == CheckState.Checked)
                    {
                        inttopay -= (double)Math.Round((double)artikel.Preis / 100, 2);
                        if (inttopay < 0) inttopay = 0;
                        rtbcost.Text = inttopay.ToString();
                    }
                    else
                    {
                        inttopay += (double)Math.Round((double)artikel.Preis / 100, 2);
                        rtbcost.Text = inttopay.ToString();
                    }

                }
            }
        }
            

        private void cbxpayrest_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxpayrest.Checked)
            {
                for (int i = 0; i < clbnotpayed.Items.Count; i++)
                {
                    if (clbnotpayed.GetItemChecked(i) == false)
                    {
                        clbnotpayed.SetItemChecked(i, true);
                    }
                    
                }

            }
            else
            {
                for (int i = 0; i < clbnotpayed.Items.Count; i++)
                {
                    clbnotpayed.SetItemChecked(i, false);
                   
                }
            }
           
        }
    }
}
