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
using System.Net.Http;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RestaurantClient
{
    public partial class addOrder : Form
    {
        public int intselectedTable;
        Timer updateStatusLabelTimer;

        public addOrder(int intselectedTable1)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            lbltable.Text = "Ausgewählter Tisch: " + intselectedTable1;
            intselectedTable = intselectedTable1;
            InitUpdateStatusLabelTimer();
        }

        public void InitUpdateStatusLabelTimer()
        {
            if (updateStatusLabelTimer == null)
            {
                updateStatusLabelTimer = new Timer();
                updateStatusLabelTimer.Tick += updateStatusLabelTimer_Tick;
            }
            updateStatusLabelTimer.Interval = 3000; // 3 sec
        }

        private void updateStatusLabelTimer_Tick(object sender, EventArgs e)
        {
            this.lbl_status.Text = "";
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnGetraenke_Click(object sender, EventArgs e)
        {
            ltbArticle.Items.Clear();
            ApiClient apiClient = new ApiClient();
            string apiUrl = "https://localhost:1337/articles/drinks";
            List<Artikel> artikelliste = await apiClient.GetDataFromApiGeneric<List<Artikel>>(apiUrl);
            foreach (var article in artikelliste)
            {
                ltbArticle.Items.Add(article.ID_Artikel + " - " + article.Name);
            }
        }

        private async void btnSpeisen_Click(object sender, EventArgs e)
        {
            ltbArticle.Items.Clear();
            ApiClient apiClient = new ApiClient();
            string apiUrl = "https://localhost:1337/articles/food";
            List<Artikel> artikelliste = await apiClient.GetDataFromApiGeneric<List<Artikel>>(apiUrl);
            foreach (var article in artikelliste)
            {
                ltbArticle.Items.Add(article.ID_Artikel + " - " + article.Name);
            }
        }

        private async void btnDessert_Click(object sender, EventArgs e)
        {
            ltbArticle.Items.Clear();
            ApiClient apiClient = new ApiClient();
            string apiUrl = "https://localhost:1337/articles/dessert";
            List<Artikel> artikelliste = await apiClient.GetDataFromApiGeneric<List<Artikel>>(apiUrl);
            foreach (var article in artikelliste)
            {
                ltbArticle.Items.Add(article.ID_Artikel + " - " + article.Name);
            }
        }

        private async void btnsavenext_Click(object sender, EventArgs e)
        {
            if (ltbPlanned.Items.Count > 0)
            {
                ApiClient apiClient = new ApiClient();
                string apiUrl = "https://localhost:1337/orders/new";

                Bestellung newOrder = new Bestellung
                {
                    Datum = DateTime.Now,
                    ID_Tisch = intselectedTable,
                    Positionen = new List<Bestellposition>()
                };

                foreach (var item in ltbPlanned.Items)
                {
                    string[] parts = item.ToString().Split('-');
                    string extradump = "";


                    if (parts.Count() == 4) { extradump = parts[2] + " " + parts[3]; }
                    // Erstellen einer neuen Bestellposition und Hinzufügen zur Liste in newOrder
                    Bestellposition position = new Bestellposition
                    {
                        ID_Artikel = Int32.Parse(parts[0]),
                        Extras = extradump,
                        Geliefert = 0
                    };

                    newOrder.Positionen.Add(position);
                }

                var response = await apiClient.PostDataToApiGeneric<Bestellung>(apiUrl, newOrder);
                if (response.IsSuccessStatusCode)
                {
                    ShowStatus();
                }
                else
                {
                    MessageBox.Show($"Fehler beim Senden der Bestellung. HTTP-Statuscode: {response.StatusCode}");
                }
                ltbPlanned.Items.Clear();
            }
            else
            {
                MessageBox.Show("Keine Artikel ausgewählt");
            }
        }

        private void ShowStatus()
        {
            this.lbl_status.Text = "Gesendet.";
            // reset Timer, then start it
            updateStatusLabelTimer.Stop();
            updateStatusLabelTimer.Start();
        }

        private void ltbArticle_DoubleClick(object sender, EventArgs e)
        {
            if (ltbArticle.SelectedItem != null)
            {
                ltbPlanned.Items.Add(ltbArticle.SelectedItem);
            }
        }

        private void ltbPlanned_DoubleClick(object sender, EventArgs e)
        {
            using (var extraornon = new extrasornon(ltbPlanned.SelectedItem.ToString()))
            {
                var dummy = ltbPlanned.SelectedItem as string;

                if (extraornon.ShowDialog() == DialogResult.OK)
                {
                    if (extraornon.ReturnValue1 != String.Empty)
                    {
                        dummy += " - " + extraornon.ReturnValue1.ToString();
                        ltbPlanned.Items[ltbPlanned.SelectedIndex] = dummy;
                    }
                }
            }
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            ltbPlanned.Items.Clear();
        }

        private void btnremovearticle_Click(object sender, EventArgs e)
        {
            ltbPlanned.Items.Remove(ltbPlanned.SelectedItem);
        }
    }
}