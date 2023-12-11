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
        Timer updateTableViewTimer;


        public index()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            InitUpdateTableViewTimer();
        }


        public void InitUpdateTableViewTimer()
        {
            if (updateTableViewTimer == null)
            {
                updateTableViewTimer = new Timer();
                updateTableViewTimer.Tick += UpdateTableViewTimer_Tick;
            }
            updateTableViewTimer.Interval = 10000; // 10 sec
            updateTableViewTimer.Start();
        }


        private void UpdateTableViewTimer_Tick(object sender, EventArgs args)
        {
            RefreshTableOverview();
        }


        private void btnadd_Click(object sender, EventArgs e)
        {
            if (intselectedTable != 0)
            {
                Form addOrder = new addOrder(intselectedTable);
                addOrder.FormClosed += Refresh;
                addOrder.Show();
            }
        }


        private void btnpay_Click(object sender, EventArgs e)
        {
            if (intselectedTable != 0)
            {
                Form payMenu = new payMenu(intselectedTable);
                payMenu.FormClosed += Refresh;
                payMenu.Show();
            }
        }

        private void Refresh(object sender, FormClosedEventArgs e)
        {
            RefreshTableOverview();
        }

        private async void tischwechselnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (intselectedTable == 0)
                return;

            int fromTableId = intselectedTable;
            Tisch fromTable = new Tisch() { ID_Tisch = fromTableId };
            Button ctn = (Button)this.Controls.Find("btnTisch" + Convert.ToString(fromTableId), true)[0];
            string dummy = Interaction.InputBox("Zu welchem Tisch wird gewechselt?", "Tischwechsel", "");
            if (dummy.Length >0)
            {
                int toTableId = Int32.Parse(dummy);
                Tisch toTable = new Tisch() { ID_Tisch = toTableId };
                ctn.BackColor = Color.DarkSeaGreen;
                ctn = (Button)this.Controls.Find("btnTisch" + Convert.ToString(toTableId), true)[0];
                ctn.BackColor = Color.Khaki;

                ApiClient apiClient = new ApiClient();

                string apiUrl = "https://localhost:1337/tables/switch";
                await apiClient.PutDataToApiGeneric<Tisch>(apiUrl, fromTable, toTable);
            }
        }


        private async void ButtonClick(object sender, EventArgs e)
        {
            ltbshoworderd.Items.Clear();
            intselectedTable = Int32.Parse(((Button)sender).Text.Remove(0, 6));
            UpdateListData();
        }


        private async void UpdateListData()
        {
            ApiClient apiClient = new ApiClient();
            string apiUrl = "https://localhost:1337/orders/" + intselectedTable.ToString() + "/open";
            List<Bestellung> bestellungen = await apiClient.GetDataFromApiGeneric<List<Bestellung>>(apiUrl);

            ltbshoworderd.Items.Clear();
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
            ApiClient apiClient = new ApiClient();
            string apiUrl = "https://localhost:1337/articles/drinks";
            List<Artikel> Artikel = await apiClient.GetDataFromApiGeneric<List<Artikel>>(apiUrl);
            MessageBox.Show(Artikel.First().Name);
        }
        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            inteac++;
            if (inteac >= 5)
            {
                SoundPlayer simpleSound = new SoundPlayer(@".\palim.wav");
                simpleSound.Play();
                inteac = 0;
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
            RefreshTableOverview();
        }


        private async void RefreshTableOverview()
        {
            ApiClient apiClient = new ApiClient();
            string apiUrl = "https://localhost:1337/tables";
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
                    Button ctn;
                    apiClient = new ApiClient();
                    apiUrl = "https://localhost:1337/orders/" + tisch.ID_Tisch.ToString() + "/open";
                    List<Bestellung> bestellungen = await apiClient.GetDataFromApiGeneric<List<Bestellung>>(apiUrl);

                    ctn = (Button)this.Controls.Find("btnTisch" + Convert.ToString(tisch.ID_Tisch), true)[0];
                    if (tisch.ID_Kellner != kellnerID)
                    {
                        ctn.BackColor = Color.Salmon;
                        continue;
                    }
                    else
                    {
                        
                        ctn.BackColor = Color.DarkSeaGreen;
                    }
                    
                    List<Bestellposition> bpos = new List<Bestellposition>();
                    if (bestellungen != null && bestellungen.Count != 0)
                    {
                        foreach (var bestellung in bestellungen)
                        {
                            foreach (var pos in bestellung.Positionen)
                            {
                                bpos.Add(pos);
                                ctn = (Button)this.Controls.Find("btnTisch" + Convert.ToString(tisch.ID_Tisch), true)[0];
                                ctn.BackColor = Color.Khaki;
                            }
                        }
                    }
                }
            }
            UpdateListData();
        }


        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form report = new report();
            report.Show();
        }


        private async Task<bool> CheckEnter(object sender, KeyPressEventArgs e, string loginName, string passwort)
        {
            if (e.KeyChar != Convert.ToChar(Keys.Enter) || e.KeyChar != Convert.ToChar(Keys.Return))
                return false;
            return true;
        }


        private async Task TextBoxWithReturn(string titel = "Login")
        {
            bool enterPressed;
            TextBox loginNameTextBox, passwordTextBox;
            Button okayButton;
            
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
            inputForm.KeyPress += async (sender, EventArgs) =>
            {
                enterPressed = await CheckEnter(sender, EventArgs, loginNameTextBox.Text, passwordTextBox.Text);
                if (enterPressed)
                {
                    await OkayButton_Click(sender, EventArgs, loginNameTextBox.Text, passwordTextBox.Text);
                    inputForm.Close();
                }
            };
            passwordTextBox.KeyPress += async (sender, EventArgs) =>
            {
                enterPressed = await CheckEnter(sender, EventArgs, loginNameTextBox.Text, passwordTextBox.Text);
                if (enterPressed)
                {
                    await OkayButton_Click(sender, EventArgs, loginNameTextBox.Text, passwordTextBox.Text);
                    inputForm.Close();
                }
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

            RefreshTableOverview();
        }


        private async void kellnerZuweisenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (intselectedTable == 0)
                return;
           ApiClient apiClient = new ApiClient();
            string apiUrl = "https://localhost:1337/waiter/switch/" + kellnerID + "/" + intselectedTable;

            await apiClient.GetDataFromApiGeneric<Tisch>(apiUrl);
        }


        private void kücheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var kuechenAnzeigeFenster = new kitchenWindow();
            kuechenAnzeigeFenster.Show();
        }
    }
}
