﻿using System;
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
using System.Drawing.Printing;
using System.Collections;

namespace RestaurantClient
{
    public partial class payMenu : Form
    {
        public int intselectedTable;
        public int inttopayinCent = 0;
        public payMenu(int intselectedTabledummy)
        {
            InitializeComponent();
            intselectedTable = intselectedTabledummy;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            lbltable.Text = "Ausgewählter Tisch: " + intselectedTable;
            inttopayinCent = 0;
            rtbcost.Text = inttopayinCent.ToString();
        }


        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void rtbmoneygive_TextChanged(object sender, EventArgs e)
        {
            // TODO kann weg?
        }


        private void rtbmoneygive_KeyPress(object sender, KeyPressEventArgs e)
        {
            // TODO kann weg?
        }


        private void rtbmoneygive_KeyUp(object sender, KeyEventArgs e)
        {

            if (string.IsNullOrEmpty(rtbmoneygive.Text))
            {
                e.Handled = false; // Erlaube leere Eingabe
            }

            if (!(char.IsDigit((char)e.KeyCode) || e.KeyCode == Keys.Oemcomma || e.KeyCode == Keys.Decimal))
            {
                e.SuppressKeyPress = true;
                var filteredChars = rtbmoneygive.Text.Where(c => char.IsDigit(c) || c == ',');
                rtbmoneygive.Text = new string(filteredChars.ToArray());
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
                    int costInCent = Convert.ToInt32(cost * 100);
                    int moneyGivenInCent = Convert.ToInt32(moneyGiven * 100);
                    int tipsInCent = moneyGivenInCent - costInCent;
                    double tipsInEuro = (double)tipsInCent / 100;
                    rtbTips.Text = string.Format("{0:N2}", tipsInEuro);
                }
            }
        }


        private async void payMenu_Load(object sender, EventArgs e)
        {
            ApiClient apiClient = new ApiClient();
            string apiUrl = "https://localhost:1337/orders/" + intselectedTable.ToString() + "/open";
            List<Bestellung> bestellungen = await apiClient.GetDataFromApiGeneric<List<Bestellung>>(apiUrl);

            if (bestellungen != null)
            {
                foreach (var bestellung in bestellungen)
                {
                    foreach (var pos in bestellung.Positionen)
                    {
                        clbnotpayed.Items.Add(pos.ID_Bestellposition + " - " + pos.ID_Artikel + " - " + pos.Artikel.Name);
                    }
                }
            }

            apiUrl = "https://localhost:1337/orders/" + intselectedTable.ToString() + "/closed";
            bestellungen = await apiClient.GetDataFromApiGeneric<List<Bestellung>>(apiUrl);
            if (bestellungen != null)
            {
                foreach (var bestellung in bestellungen)
                {
                    foreach (var pos in bestellung.Positionen)
                    {
                        lbpayed.Items.Add(pos.ID_Artikel + " - " + pos.Artikel.Name);
                    }
                    lbpayed.Items.Add("--------------------");
                }
            }
            if (clbnotpayed.Items.Count <= 0)
            {
                MessageBox.Show("Keine offenen Positionen", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            clbnotpayed.SelectedIndex = 0;
        }


        private async void clbnotpayed_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ApiClient apiClient = new ApiClient();
            string apiUrl = "https://localhost:1337/articles/id/" + clbnotpayed.SelectedItem.ToString().Split('-')[1];
            Artikel artikel = await apiClient.GetDataFromApiGeneric<Artikel>(apiUrl);

            if (artikel != null)
            {
                if (e.CurrentValue == CheckState.Checked)
                {
                    inttopayinCent -= artikel.Preis;
                    if (inttopayinCent < 0) inttopayinCent = 0;
                    rtbcost.Text = Math.Round((double)inttopayinCent / 100, 2).ToString();
                }
                else
                {
                    inttopayinCent += artikel.Preis;
                    rtbcost.Text = Math.Round((double)inttopayinCent / 100, 2).ToString();
                }
            }
        }


        private void cbxpayrest_CheckedChanged(object sender, EventArgs e)
        {
            int count = 0;

            if (cbxpayrest.Checked)
            {
                for (int i = 0; i < clbnotpayed.Items.Count; i++)
                {
                    if (!clbnotpayed.GetItemChecked(i))
                    {
                        clbnotpayed.SetSelected(i, true);
                        clbnotpayed.SetItemChecked(i, true);
                    }
                    count++;
                }
            }
            else
            {
                for (int i = (clbnotpayed.Items.Count - 1); i >= 0; i--)
                {
                    if (clbnotpayed.GetItemChecked(i))
                    {
                        clbnotpayed.SetSelected(i, true);
                        clbnotpayed.SetItemChecked(i, false);
                    }
                }
            }
        }


        private void btnprint_Click(object sender, EventArgs e)
        {
            PrintDocument docToPrint = new PrintDocument();
            string stringToPrint = "";
            string header = "Rechnung zum Goldenen Lindemann\r\n\r\n";
            stringToPrint += $"Datum: {DateTime.Now.ToString()}\r\n";
            stringToPrint += $"Tisch: {intselectedTable}\r\n";

            var selectedItems = clbnotpayed.CheckedItems;
            foreach (var item in selectedItems)
            {
                stringToPrint += $"{item.ToString()}\r\n";
            }

            stringToPrint += $"\r\nZu begleichender Betrag: {inttopayinCent/100}€";
            stringToPrint += $"\r\nBezahlter Betrag:{rtbmoneygive.Text}€";

            docToPrint.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            {
                e1.Graphics.DrawString(header, new Font("Times New Roman", 24), new SolidBrush(Color.Black), new RectangleF(0, 0, docToPrint.DefaultPageSettings.PrintableArea.Width, docToPrint.DefaultPageSettings.PrintableArea.Height));
                e1.Graphics.DrawString(stringToPrint, new Font("Times New Roman", 12), new SolidBrush(Color.Black), new RectangleF(0, 50, docToPrint.DefaultPageSettings.PrintableArea.Width, docToPrint.DefaultPageSettings.PrintableArea.Height));
            };

            PrintDialog printDialog = new PrintDialog();
            printDialog.AllowSomePages = true;
            printDialog.ShowHelp = true;
            printDialog.Document = docToPrint;

            DialogResult result = printDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                docToPrint.Print();
            }
        }


        private async void btnpay_Click(object sender, EventArgs e)
        {
            ArrayList list = new ArrayList();
            var trinkgeld = (int)(100 * Convert.ToDouble(rtbTips.Text));
            if (trinkgeld < 0)
            {
                MessageBox.Show($"Fehler beim Senden der Rechnung: Kein negativer Betrag möglich.", "Negativer Betrag", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (String.IsNullOrWhiteSpace(rtbmoneygive.Text))
            {
                MessageBox.Show($"Fehler beim Senden der Rechnung: Kein Betrag eingegeben.", "Fehlender Betrag", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Convert.ToInt32(rtbcost.Text) == 0)
            {
                MessageBox.Show($"Fehler beim Senden der Rechnung: Kein Artikel ausgewählt.", "Keine Artikel ausgewählt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<int> orderpositions = new List<int>();
            // get checked Checkboxes
            foreach (var item in clbnotpayed.CheckedItems)
            {
                list.Add(item.ToString());
            }
            // get list of orderposition ids of items from checked checkboxes
            foreach (var item in list)
            {
                orderpositions.Add(Convert.ToInt32(item.ToString().Split('-')[0]));
            }

            List<Bestellposition> orderpos = new List<Bestellposition>();
            // make dummy list of orderposition objects, since we only need the id to close them
            foreach (var pos in orderpositions)
            {
                orderpos.Add(
                    new Bestellposition()
                    {
                        ID_Bestellposition = pos
                    }
                );
            }

            ApiClient apiClient = new ApiClient();
            string apiUrl = $"https://localhost:1337/orders/pay/{trinkgeld}";
            var response = await apiClient.PostDataToApiGeneric<List<Bestellposition>>(apiUrl, orderpos);
            
            this.Close();
        }
    }
}