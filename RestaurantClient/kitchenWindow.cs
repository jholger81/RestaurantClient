using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantClient
{
    public partial class kitchenWindow : Form
    {
        Timer updateKitchenViewTimer;
        int numberOfTicks = 0;

        public kitchenWindow()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            LoadPositionsAsync();
            InitUpdateKitchenViewTimer();
        }

        public void InitUpdateKitchenViewTimer()
        {
            if (updateKitchenViewTimer == null)
            {
                updateKitchenViewTimer = new Timer();
                updateKitchenViewTimer.Tick += UpdateKitchenViewTimer_Tick;
            }
            updateKitchenViewTimer.Interval = 1000; // 30 sec
            updateKitchenViewTimer.Start();
        }

        private void UpdateKitchenViewTimer_Tick(object sender, EventArgs args)
        {
            LoadPositionsAsync();
        }

        private async Task LoadPositionsAsync()
        {
            ApiClient apiClient = new ApiClient();
            string apiUrl = "https://localhost:1337/orders/open";
            string apiUrlArticle;
            string newlabel = "";
            List<Bestellposition> positions = await apiClient.GetDataFromApiGeneric<List<Bestellposition>>(apiUrl);

            lbl_DateAndTime.Text = $"{DateTime.Now.ToString("dd.MM.yyyy - HH:mm:ss")}\r\n\r\n";

            if (numberOfTicks == 0)
            {
                foreach (Bestellposition position in positions)
                {
                    apiUrlArticle = $"https://localhost:1337/articles/id/{position.ID_Artikel}";
                    var article = await apiClient.GetDataFromApiGeneric<Artikel>(apiUrlArticle);

                    newlabel += $"{position.ID_Artikel} - {article.Name}";
                    newlabel += (position.Extras != null) ? $", Extras: {position.Extras}\r\n" : "\r\n";
                }
                lbl_openPositions.Text = newlabel;
            }
            else if (numberOfTicks > 9)
            {
                numberOfTicks = -1;
            }
            numberOfTicks++;
        }
    }
}
