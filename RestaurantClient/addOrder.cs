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
    }
}
