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
        public addOrder(int intselectedTable1)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            nudcount.Controls[0].Hide();
            lbltable.Text = "Ausgewählter Tisch: " + intselectedTable1;
            intselectedTable = intselectedTable1;
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addOrder_Load(object sender, EventArgs e)
        {

        }

        private async void btnGetraenke_Click(object sender, EventArgs e)
        {
            ltbArticle.Items.Clear();
            ApiClient apiClient = new ApiClient();
            //string apiUrl = "https://localhost:1337/tables";
            string apiUrl = "https://localhost:1337/articles/drinks";
            //string result = ...
            List<Artikel> artikelliste = await apiClient.GetDataFromApiGeneric<List<Artikel>>(apiUrl);
            Console.WriteLine("");
            foreach (var article in artikelliste)
            {
                ltbArticle.Items.Add(article.ID_Artikel + " - " + article.Name);

            }
        }

        private async void btnSpeisen_Click(object sender, EventArgs e)
        {
            ltbArticle.Items.Clear();
            ApiClient apiClient = new ApiClient();
            //string apiUrl = "https://localhost:1337/tables";
            string apiUrl = "https://localhost:1337/articles/food";
            //string result = ...
            List<Artikel> artikelliste = await apiClient.GetDataFromApiGeneric<List<Artikel>>(apiUrl);
            Console.WriteLine("");
            foreach (var article in artikelliste)
            {
                ltbArticle.Items.Add(article.ID_Artikel + " - " + article.Name);

            }
        }

        private async void btnDessert_Click(object sender, EventArgs e)
        {
            ltbArticle.Items.Clear();
            ApiClient apiClient = new ApiClient();
            //string apiUrl = "https://localhost:1337/tables";
            string apiUrl = "https://localhost:1337/articles/dessert";
            //string result = ...
            List<Artikel> artikelliste = await apiClient.GetDataFromApiGeneric<List<Artikel>>(apiUrl);
            Console.WriteLine("");
            foreach (var article in artikelliste)
            {
                ltbArticle.Items.Add(article.ID_Artikel + " - " + article.Name);

            }
        }

        private async void btnsavenext_Click(object sender, EventArgs e)
        {
            

            ApiClient apiClient = new ApiClient();
            HttpClient httpClient = new HttpClient();
            string apiUrl = "https://localhost:1337/orders/new";

            Bestellung newOrder = new Bestellung
            {
                Datum = DateTime.Now,
                ID_Tisch = intselectedTable, // Beispielwert
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
                    ID_Artikel = Int32.Parse(parts[0]), // Beispielwert
                    Extras = extradump,
                    Geliefert = 0
                };

                newOrder.Positionen.Add(position);
            }

            var response = await apiClient.PostDataToApiGeneric<Bestellung>(apiUrl, newOrder);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Die Bestellung wurde erfolgreich an die API gesendet.");
            }
            else
            {
                MessageBox.Show($"Fehler beim Senden der Bestellung. HTTP-Statuscode: {response.StatusCode}");
            }
            ltbPlanned.Items.Clear();
            Console.WriteLine("");
        }

        private void btnCountmore_Click(object sender, EventArgs e)
        {
            nudcount.Value += 1;
        }

        private void btnCountless_Click(object sender, EventArgs e)
        {
            if (nudcount.Value > 1)
            {
                nudcount.Value -= 1;
            }
            
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
                var dummy = ltbPlanned.SelectedItem as string; // Annahme, dass die ListBox-Elemente Strings sind

                // Zeigen Sie das Einstellungsformular modal an und warten Sie auf Benutzereingabe
                if (extraornon.ShowDialog() == DialogResult.OK)
                {
                    if (extraornon.ReturnValue1 != String.Empty)
                    {
                        // Fügen Sie den übergebenen Text zum ausgewählten Element hinzu
                        dummy += " - " + extraornon.ReturnValue1.ToString();

                        // Aktualisieren Sie das ausgewählte Element in der ListBox
                        ltbPlanned.Items[ltbPlanned.SelectedIndex] = dummy;
                    }
                }
            }
        }

        private async void btnsaveclose_Click(object sender, EventArgs e)
        {
            

            ApiClient apiClient = new ApiClient();
            HttpClient httpClient = new HttpClient();
            //string apiUrl = "https://localhost:1337/tables";
            string apiUrl = "https://localhost:1337/orders/new";


            Bestellung newOrder = new Bestellung
            {
                Datum = DateTime.Now,
                ID_Tisch = intselectedTable, // Beispielwert
                Positionen = new List<Bestellposition>
                {
                    //new Bestellposition
                    //{
                    //    ID_Artikel = Int32.Parse(parts[0]), // Beispielwert
                    //    Extras = parts[2] + " " + parts[3],
                    //    Geliefert = 0
                    //},
                    // Fügen Sie weitere Bestellpositionen hinzu
                }



            };

            foreach (var item in ltbPlanned.Items)
            {
                string[] parts = item.ToString().Split('-');
                string extradump = "";
                

                if (parts.Count() == 4) { extradump = parts[2] + " " + parts[3]; }
                // Erstellen einer neuen Bestellposition und Hinzufügen zur Liste in newOrder
                Bestellposition position = new Bestellposition
                {
                    ID_Artikel = Int32.Parse(parts[0]), // Beispielwert
                    Extras = extradump,
                    Geliefert = 0
                };

                newOrder.Positionen.Add(position);
            }




            string jsonOrder = System.Text.Json.JsonSerializer.Serialize(newOrder);
            var request = new HttpRequestMessage(HttpMethod.Post, apiUrl);
            request.Content = new StringContent(jsonOrder, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Die Bestellung wurde erfolgreich an die API gesendet.");
            }
            else
            {
                MessageBox.Show($"Fehler beim Senden der Bestellung. HTTP-Statuscode: {response.StatusCode}");
            }

            this.Close();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            ltbPlanned.Items.Clear();
        }
    }
}
