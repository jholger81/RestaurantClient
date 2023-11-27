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

        private async void tischwechselnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int fromTableId = intselectedTable;
            Tisch fromTable = new Tisch() { ID_Tisch = fromTableId };
            Button ctn = (Button)this.Controls.Find("btnTisch" + Convert.ToString(fromTableId), true)[0];
            string dummy = Interaction.InputBox("Zu welchem Tisch wird gewechselt?", "Tischwechsel", "");
            if (dummy.Length >0)
            {
                int toTableId = Int32.Parse(dummy);
                MessageBox.Show(toTableId.ToString());
                Tisch toTable = new Tisch() { ID_Tisch = toTableId };
                ctn.BackColor = Color.DarkSeaGreen;
                ctn = (Button)this.Controls.Find("btnTisch" + Convert.ToString(toTableId), true)[0];
                ctn.BackColor = Color.Khaki;

                ApiClient apiClient = new ApiClient();

                string apiUrl = "https://localhost:1337/tables/switch";
                await apiClient.PutDataToApiGeneric<Tisch>(apiUrl, fromTable, toTable);
            }
           
   
           
            

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
            List<Bestellung> bestellungen = await apiClient.GetDataFromApiGeneric<List<Bestellung>>(apiUrl);
            Console.WriteLine("");
            
            if (bestellungen != null)
            {
                foreach (var bestellung in bestellungen)
                {
                    foreach (var pos in bestellung.Positionen)
                    {

                        ltbshoworderd.Items.Add(pos.Artikel.Name);

                    }
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

            if (tischliste == null)
            {
                MessageBox.Show("Keine Verbindung zum Server, beende das Programm", "Fehler", MessageBoxButtons.OK);
                this.Close();
                Application.Exit();
            }
            else
            {
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
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form report = new report();

            // Show the settings form
            report.Show();
        }

        private async Task TextBoxWithReturn(string titel = "Login")
        {
            TextBox loginNameTextBox, passwordTextBox;
            Button okayButton;
            //int kellnerID = 0;

            Form inputForm = new Form();
            inputForm.Size = new Size(300, 150);
            inputForm.Text = titel;
            inputForm.FormBorderStyle = FormBorderStyle.FixedSingle;

            loginNameTextBox = new TextBox();
            loginNameTextBox.Location = new Point(10, 10);
            loginNameTextBox.Size = new Size(260, 20);
            loginNameTextBox.Text = "Login Name";
            inputForm.Controls.Add(loginNameTextBox);

            passwordTextBox = new TextBox();
            passwordTextBox.Location = new Point(10, 40);
            passwordTextBox.Size = new Size(260, 20);
            passwordTextBox.Text = "Passwort";
            inputForm.Controls.Add(passwordTextBox);

            okayButton = new Button();
            okayButton.Location = new Point(10, 70);
            okayButton.Size = new Size(75, 23);
            okayButton.Text = "OK";
            okayButton.Click += async (sender, EventArgs) =>
            {
                await OkayButton_Click(sender, EventArgs, loginNameTextBox.Text, passwordTextBox.Text);
                inputForm.Close();
            };
            inputForm.Controls.Add(okayButton);
            inputForm.ShowDialog();
        }

        private async Task OkayButton_Click(object sender, EventArgs e, string loginName, string passwort)
        {
            ApiClient apiClient = new ApiClient();
            string apiUrl = "https://localhost:1337/waiter/login";
            Kellner loginData = new Kellner
            {
                LoginName = loginName,
                Passwort = passwort
            };
            var response = await apiClient.GetDataFromApiGeneric<Kellner>(apiUrl, loginData);

            kellnerID = response?.ID_Kellner ?? 0;
        }

        private async void kellnerEinloggenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await TextBoxWithReturn();
            if (kellnerID == 0)
            {
                MessageBox.Show("Kein Kellner mit den angegebenen Login-Daten gefunden", "Login-Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ApiClient apiClient = new ApiClient();
            string apiUrl = "https://localhost:1337/tables";
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

            apiUrl = "https://localhost:1337/tables/open";
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

        private async void kellnerZuweisenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //todoo switch/{id_Kellner}/{id_Tisch
           ApiClient apiClient = new ApiClient();
            string apiUrl = "https://localhost:1337/waiter/switch/" + kellnerID + "/" + intselectedTable;

            await apiClient.GetDataFromApiGeneric<string>(apiUrl);



    }
    }
}
