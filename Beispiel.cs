using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Restaurant.Models;
using Restaurant.Database;
using Restaurant;
using System.Text.Json;

namespace RestaurantClient
{
    public partial class Beispiel : Form
    {
        Bestellung Bestellung { get; set; }
        public Beispiel()
        {
            InitializeComponent();
            FillWithExampleData();
        }

        private void FillWithExampleData()
        {
            Bestellung = DBAccess.GetOrder(7);
            Label Example = new Label();
            Example.Text = JsonSerializer.Serialize<Bestellung>(Bestellung);
            Example.AutoSize = true;
            Example.Location = new System.Drawing.Point(1, 1);
            this.Controls.Add(Example);
        }
    }
}
