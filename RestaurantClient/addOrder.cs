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
                ltbArticle.Items.Add(article.ID_Artikel + "- " + article.Name);

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
            MessageBox.Show(ltbArticle.SelectedItem.ToString().Split('-')[0]);
            
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
                new Bestellposition
                {
                    ID_Artikel = Int32.Parse(ltbArticle.SelectedItem.ToString().Split('-')[0]), // Beispielwert
                    Extras = rtbextras.Text,
                    Geliefert = 0
                },
                // Fügen Sie weitere Bestellpositionen hinzu
            }



            };



            //string jsonOrder = System.Text.Json.JsonSerializer.Serialize(newOrder);
            //var request = new HttpRequestMessage(HttpMethod.Post, apiUrl);
            //request.Content = new StringContent(jsonOrder, Encoding.UTF8, "application/json");
            //HttpResponseMessage response = await httpClient.SendAsync(request);
            //if (response.IsSuccessStatusCode)
            //{
            //    MessageBox.Show("Die Bestellung wurde erfolgreich an die API gesendet.");
            //}
            //else
            //{
            //    MessageBox.Show($"Fehler beim Senden der Bestellung. HTTP-Statuscode: {response.StatusCode}");
            //}
            apiClient.PostDataToApiGeneric(apiUrl, newOrder);

            Console.WriteLine("");
        }
    }
}
