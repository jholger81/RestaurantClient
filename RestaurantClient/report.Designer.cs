namespace RestaurantClient
{
    partial class report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(report));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mtcLabel = new System.Windows.Forms.Label();
            this.btnStartReport = new System.Windows.Forms.Button();
            this.dtpReportDay = new System.Windows.Forms.DateTimePicker();
            this.btnDTPback = new System.Windows.Forms.Button();
            this.btnDTPnext = new System.Windows.Forms.Button();
            this.rtbeinnahmen = new System.Windows.Forms.RichTextBox();
            this.rtbTrinkgeld = new System.Windows.Forms.RichTextBox();
            this.lblRTBeinnahme = new System.Windows.Forms.Label();
            this.lblRTBTrinkgeld = new System.Windows.Forms.Label();
            this.btnDTPlastweek = new System.Windows.Forms.Button();
            this.btnDTPnextweek = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RestaurantClient.Properties.Resources.Gasthoficon;
            this.pictureBox1.Location = new System.Drawing.Point(564, 224);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(169, 212);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // mtcLabel
            // 
            this.mtcLabel.AutoSize = true;
            this.mtcLabel.Location = new System.Drawing.Point(36, 29);
            this.mtcLabel.Name = "mtcLabel";
            this.mtcLabel.Size = new System.Drawing.Size(147, 13);
            this.mtcLabel.TabIndex = 2;
            this.mtcLabel.Text = "Datum für Statistik auswählen";
            // 
            // btnStartReport
            // 
            this.btnStartReport.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnStartReport.Location = new System.Drawing.Point(550, 45);
            this.btnStartReport.Name = "btnStartReport";
            this.btnStartReport.Size = new System.Drawing.Size(197, 162);
            this.btnStartReport.TabIndex = 3;
            this.btnStartReport.Text = "Anzeigen";
            this.btnStartReport.UseVisualStyleBackColor = false;
            this.btnStartReport.Click += new System.EventHandler(this.btnStartReport_Click);
            // 
            // dtpReportDay
            // 
            this.dtpReportDay.CustomFormat = "dd-MM-yyyy";
            this.dtpReportDay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReportDay.Location = new System.Drawing.Point(39, 45);
            this.dtpReportDay.Name = "dtpReportDay";
            this.dtpReportDay.Size = new System.Drawing.Size(461, 20);
            this.dtpReportDay.TabIndex = 4;
            // 
            // btnDTPback
            // 
            this.btnDTPback.BackColor = System.Drawing.Color.Salmon;
            this.btnDTPback.Location = new System.Drawing.Point(160, 71);
            this.btnDTPback.Name = "btnDTPback";
            this.btnDTPback.Size = new System.Drawing.Size(92, 136);
            this.btnDTPback.TabIndex = 5;
            this.btnDTPback.Text = "-1 Tag";
            this.btnDTPback.UseVisualStyleBackColor = false;
            this.btnDTPback.Click += new System.EventHandler(this.btnDTPback_Click);
            // 
            // btnDTPnext
            // 
            this.btnDTPnext.BackColor = System.Drawing.Color.PaleGreen;
            this.btnDTPnext.Location = new System.Drawing.Point(284, 71);
            this.btnDTPnext.Name = "btnDTPnext";
            this.btnDTPnext.Size = new System.Drawing.Size(92, 136);
            this.btnDTPnext.TabIndex = 6;
            this.btnDTPnext.Text = "+1 Tag";
            this.btnDTPnext.UseVisualStyleBackColor = false;
            this.btnDTPnext.Click += new System.EventHandler(this.btnDTPnext_Click);
            // 
            // rtbeinnahmen
            // 
            this.rtbeinnahmen.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbeinnahmen.Location = new System.Drawing.Point(36, 243);
            this.rtbeinnahmen.Name = "rtbeinnahmen";
            this.rtbeinnahmen.Size = new System.Drawing.Size(464, 61);
            this.rtbeinnahmen.TabIndex = 7;
            this.rtbeinnahmen.Text = "";
            // 
            // rtbTrinkgeld
            // 
            this.rtbTrinkgeld.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.rtbTrinkgeld.Location = new System.Drawing.Point(36, 361);
            this.rtbTrinkgeld.Name = "rtbTrinkgeld";
            this.rtbTrinkgeld.Size = new System.Drawing.Size(464, 61);
            this.rtbTrinkgeld.TabIndex = 8;
            this.rtbTrinkgeld.Text = "";
            // 
            // lblRTBeinnahme
            // 
            this.lblRTBeinnahme.AutoSize = true;
            this.lblRTBeinnahme.Location = new System.Drawing.Point(36, 224);
            this.lblRTBeinnahme.Name = "lblRTBeinnahme";
            this.lblRTBeinnahme.Size = new System.Drawing.Size(136, 13);
            this.lblRTBeinnahme.TabIndex = 9;
            this.lblRTBeinnahme.Text = "Einnahmen an diesem Tag:";
            // 
            // lblRTBTrinkgeld
            // 
            this.lblRTBTrinkgeld.AutoSize = true;
            this.lblRTBTrinkgeld.Location = new System.Drawing.Point(36, 345);
            this.lblRTBTrinkgeld.Name = "lblRTBTrinkgeld";
            this.lblRTBTrinkgeld.Size = new System.Drawing.Size(127, 13);
            this.lblRTBTrinkgeld.TabIndex = 10;
            this.lblRTBTrinkgeld.Text = "Trinkgeld an diesem Tag:";
            // 
            // btnDTPlastweek
            // 
            this.btnDTPlastweek.BackColor = System.Drawing.Color.Salmon;
            this.btnDTPlastweek.Location = new System.Drawing.Point(36, 71);
            this.btnDTPlastweek.Name = "btnDTPlastweek";
            this.btnDTPlastweek.Size = new System.Drawing.Size(92, 136);
            this.btnDTPlastweek.TabIndex = 11;
            this.btnDTPlastweek.Text = "-1 Woche";
            this.btnDTPlastweek.UseVisualStyleBackColor = false;
            this.btnDTPlastweek.Click += new System.EventHandler(this.btnDTPlastweek_Click);
            // 
            // btnDTPnextweek
            // 
            this.btnDTPnextweek.BackColor = System.Drawing.Color.PaleGreen;
            this.btnDTPnextweek.Location = new System.Drawing.Point(408, 71);
            this.btnDTPnextweek.Name = "btnDTPnextweek";
            this.btnDTPnextweek.Size = new System.Drawing.Size(92, 136);
            this.btnDTPnextweek.TabIndex = 12;
            this.btnDTPnextweek.Text = "+1 Woche";
            this.btnDTPnextweek.UseVisualStyleBackColor = false;
            this.btnDTPnextweek.Click += new System.EventHandler(this.btnDTPnextweek_Click);
            // 
            // report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 501);
            this.Controls.Add(this.btnDTPnextweek);
            this.Controls.Add(this.btnDTPlastweek);
            this.Controls.Add(this.lblRTBTrinkgeld);
            this.Controls.Add(this.lblRTBeinnahme);
            this.Controls.Add(this.rtbTrinkgeld);
            this.Controls.Add(this.rtbeinnahmen);
            this.Controls.Add(this.btnDTPnext);
            this.Controls.Add(this.btnDTPback);
            this.Controls.Add(this.dtpReportDay);
            this.Controls.Add(this.btnStartReport);
            this.Controls.Add(this.mtcLabel);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "report";
            this.Text = "Tägliche Einnahme und Statistik";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label mtcLabel;
        private System.Windows.Forms.Button btnStartReport;
        private System.Windows.Forms.DateTimePicker dtpReportDay;
        private System.Windows.Forms.Button btnDTPback;
        private System.Windows.Forms.Button btnDTPnext;
        private System.Windows.Forms.RichTextBox rtbeinnahmen;
        private System.Windows.Forms.RichTextBox rtbTrinkgeld;
        private System.Windows.Forms.Label lblRTBeinnahme;
        private System.Windows.Forms.Label lblRTBTrinkgeld;
        private System.Windows.Forms.Button btnDTPlastweek;
        private System.Windows.Forms.Button btnDTPnextweek;
    }
}