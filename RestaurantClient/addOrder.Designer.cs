namespace RestaurantClient
{
    partial class addOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addOrder));
            this.ltbArticle = new System.Windows.Forms.ListBox();
            this.btnGetraenke = new System.Windows.Forms.Button();
            this.btnSpeisen = new System.Windows.Forms.Button();
            this.btnreset = new System.Windows.Forms.Button();
            this.btnremovearticle = new System.Windows.Forms.Button();
            this.btnsavenext = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnback = new System.Windows.Forms.Button();
            this.lbltable = new System.Windows.Forms.Label();
            this.btnDessert = new System.Windows.Forms.Button();
            this.ltbPlanned = new System.Windows.Forms.ListBox();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.lbl_status = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ltbArticle
            // 
            this.ltbArticle.FormattingEnabled = true;
            this.ltbArticle.ItemHeight = 16;
            this.ltbArticle.Location = new System.Drawing.Point(15, 176);
            this.ltbArticle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ltbArticle.Name = "ltbArticle";
            this.ltbArticle.Size = new System.Drawing.Size(376, 404);
            this.ltbArticle.TabIndex = 0;
            this.ltbArticle.DoubleClick += new System.EventHandler(this.ltbArticle_DoubleClick);
            // 
            // btnGetraenke
            // 
            this.btnGetraenke.Location = new System.Drawing.Point(15, 104);
            this.btnGetraenke.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGetraenke.Name = "btnGetraenke";
            this.btnGetraenke.Size = new System.Drawing.Size(193, 67);
            this.btnGetraenke.TabIndex = 1;
            this.btnGetraenke.Text = "Getränke";
            this.btnGetraenke.UseVisualStyleBackColor = true;
            this.btnGetraenke.Click += new System.EventHandler(this.btnGetraenke_Click);
            // 
            // btnSpeisen
            // 
            this.btnSpeisen.Location = new System.Drawing.Point(239, 104);
            this.btnSpeisen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSpeisen.Name = "btnSpeisen";
            this.btnSpeisen.Size = new System.Drawing.Size(193, 67);
            this.btnSpeisen.TabIndex = 2;
            this.btnSpeisen.Text = "Speisen";
            this.btnSpeisen.UseVisualStyleBackColor = true;
            this.btnSpeisen.Click += new System.EventHandler(this.btnSpeisen_Click);
            // 
            // btnreset
            // 
            this.btnreset.BackColor = System.Drawing.Color.IndianRed;
            this.btnreset.Location = new System.Drawing.Point(620, 495);
            this.btnreset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(176, 80);
            this.btnreset.TabIndex = 6;
            this.btnreset.Text = "Bestellung leeren";
            this.btnreset.UseVisualStyleBackColor = false;
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // btnremovearticle
            // 
            this.btnremovearticle.BackColor = System.Drawing.Color.Khaki;
            this.btnremovearticle.Location = new System.Drawing.Point(419, 495);
            this.btnremovearticle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnremovearticle.Name = "btnremovearticle";
            this.btnremovearticle.Size = new System.Drawing.Size(176, 80);
            this.btnremovearticle.TabIndex = 7;
            this.btnremovearticle.Text = "Artikel entfernen";
            this.btnremovearticle.UseVisualStyleBackColor = false;
            this.btnremovearticle.Click += new System.EventHandler(this.btnremovearticle_Click);
            // 
            // btnsavenext
            // 
            this.btnsavenext.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnsavenext.Location = new System.Drawing.Point(281, 632);
            this.btnsavenext.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnsavenext.Name = "btnsavenext";
            this.btnsavenext.Size = new System.Drawing.Size(233, 111);
            this.btnsavenext.TabIndex = 8;
            this.btnsavenext.Text = "Speichern\r\nund\r\nWeiter";
            this.btnsavenext.UseVisualStyleBackColor = false;
            this.btnsavenext.Click += new System.EventHandler(this.btnsavenext_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RestaurantClient.Properties.Resources.Gasthoficon;
            this.pictureBox1.Location = new System.Drawing.Point(665, 22);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(131, 147);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.Color.IndianRed;
            this.btnback.Location = new System.Drawing.Point(15, 15);
            this.btnback.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(316, 75);
            this.btnback.TabIndex = 14;
            this.btnback.Text = "Abbrechen";
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // lbltable
            // 
            this.lbltable.AutoSize = true;
            this.lbltable.Location = new System.Drawing.Point(357, 74);
            this.lbltable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltable.Name = "lbltable";
            this.lbltable.Size = new System.Drawing.Size(144, 16);
            this.lbltable.TabIndex = 15;
            this.lbltable.Text = "Ausgewählter Tisch: 00";
            // 
            // btnDessert
            // 
            this.btnDessert.Location = new System.Drawing.Point(463, 104);
            this.btnDessert.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDessert.Name = "btnDessert";
            this.btnDessert.Size = new System.Drawing.Size(193, 67);
            this.btnDessert.TabIndex = 16;
            this.btnDessert.Text = "Desserts";
            this.btnDessert.UseVisualStyleBackColor = true;
            this.btnDessert.Click += new System.EventHandler(this.btnDessert_Click);
            // 
            // ltbPlanned
            // 
            this.ltbPlanned.FormattingEnabled = true;
            this.ltbPlanned.ItemHeight = 16;
            this.ltbPlanned.Location = new System.Drawing.Point(419, 179);
            this.ltbPlanned.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ltbPlanned.Name = "ltbPlanned";
            this.ltbPlanned.Size = new System.Drawing.Size(376, 308);
            this.ltbPlanned.TabIndex = 17;
            this.ltbPlanned.DoubleClick += new System.EventHandler(this.ltbPlanned_DoubleClick);
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Location = new System.Drawing.Point(721, 726);
            this.lbl_status.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(55, 16);
            this.lbl_status.TabIndex = 18;
            this.lbl_status.Text = "                ";
            this.lbl_status.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // addOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 755);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.ltbPlanned);
            this.Controls.Add(this.btnDessert);
            this.Controls.Add(this.lbltable);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnsavenext);
            this.Controls.Add(this.btnremovearticle);
            this.Controls.Add(this.btnreset);
            this.Controls.Add(this.btnSpeisen);
            this.Controls.Add(this.btnGetraenke);
            this.Controls.Add(this.ltbArticle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "addOrder";
            this.Text = "Artikel hinzufügen";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ltbArticle;
        private System.Windows.Forms.Button btnGetraenke;
        private System.Windows.Forms.Button btnSpeisen;
        private System.Windows.Forms.Button btnreset;
        private System.Windows.Forms.Button btnremovearticle;
        private System.Windows.Forms.Button btnsavenext;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Label lbltable;
        private System.Windows.Forms.Button btnDessert;
        private System.Windows.Forms.ListBox ltbPlanned;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.Label lbl_status;
    }
}