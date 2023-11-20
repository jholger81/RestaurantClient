namespace RestaurantClient
{
    partial class payMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(payMenu));
            this.clbnotpayed = new System.Windows.Forms.CheckedListBox();
            this.lbpayed = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxpayrest = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rtbcost = new System.Windows.Forms.RichTextBox();
            this.rtbmoneygive = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rtbTips = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnpay = new System.Windows.Forms.Button();
            this.btnback = new System.Windows.Forms.Button();
            this.lbltable = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnprint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // clbnotpayed
            // 
            this.clbnotpayed.CheckOnClick = true;
            this.clbnotpayed.FormattingEnabled = true;
            this.clbnotpayed.Location = new System.Drawing.Point(16, 117);
            this.clbnotpayed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.clbnotpayed.Name = "clbnotpayed";
            this.clbnotpayed.Size = new System.Drawing.Size(427, 361);
            this.clbnotpayed.TabIndex = 0;
            this.clbnotpayed.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbnotpayed_ItemCheck);
            // 
            // lbpayed
            // 
            this.lbpayed.FormattingEnabled = true;
            this.lbpayed.ItemHeight = 16;
            this.lbpayed.Location = new System.Drawing.Point(477, 117);
            this.lbpayed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbpayed.Name = "lbpayed";
            this.lbpayed.Size = new System.Drawing.Size(317, 292);
            this.lbpayed.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 94);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Offen:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(473, 94);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Bezahlt:";
            // 
            // cbxpayrest
            // 
            this.cbxpayrest.AutoSize = true;
            this.cbxpayrest.Location = new System.Drawing.Point(477, 418);
            this.cbxpayrest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxpayrest.Name = "cbxpayrest";
            this.cbxpayrest.Size = new System.Drawing.Size(115, 20);
            this.cbxpayrest.TabIndex = 5;
            this.cbxpayrest.Text = "Rest bezahlen";
            this.cbxpayrest.UseVisualStyleBackColor = true;
            this.cbxpayrest.CheckedChanged += new System.EventHandler(this.cbxpayrest_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 529);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "zu begleichen:";
            // 
            // rtbcost
            // 
            this.rtbcost.BackColor = System.Drawing.SystemColors.Window;
            this.rtbcost.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbcost.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbcost.Location = new System.Drawing.Point(20, 550);
            this.rtbcost.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rtbcost.Name = "rtbcost";
            this.rtbcost.ReadOnly = true;
            this.rtbcost.Size = new System.Drawing.Size(200, 48);
            this.rtbcost.TabIndex = 7;
            this.rtbcost.Text = "0000,00";
            // 
            // rtbmoneygive
            // 
            this.rtbmoneygive.BackColor = System.Drawing.SystemColors.Window;
            this.rtbmoneygive.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbmoneygive.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbmoneygive.Location = new System.Drawing.Point(268, 550);
            this.rtbmoneygive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rtbmoneygive.MaxLength = 7;
            this.rtbmoneygive.Multiline = false;
            this.rtbmoneygive.Name = "rtbmoneygive";
            this.rtbmoneygive.Size = new System.Drawing.Size(200, 48);
            this.rtbmoneygive.TabIndex = 9;
            this.rtbmoneygive.Text = "";
            this.rtbmoneygive.TextChanged += new System.EventHandler(this.rtbmoneygive_TextChanged);
            this.rtbmoneygive.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtbmoneygive_KeyPress);
            this.rtbmoneygive.KeyUp += new System.Windows.Forms.KeyEventHandler(this.rtbmoneygive_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(264, 529);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Kunde zahlt:";
            // 
            // rtbTips
            // 
            this.rtbTips.BackColor = System.Drawing.SystemColors.Window;
            this.rtbTips.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbTips.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbTips.Location = new System.Drawing.Point(268, 622);
            this.rtbTips.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rtbTips.Name = "rtbTips";
            this.rtbTips.ReadOnly = true;
            this.rtbTips.Size = new System.Drawing.Size(200, 48);
            this.rtbTips.TabIndex = 11;
            this.rtbTips.Text = "0000,00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(264, 601);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Trinkgeld:";
            // 
            // btnpay
            // 
            this.btnpay.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnpay.Location = new System.Drawing.Point(547, 595);
            this.btnpay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnpay.Name = "btnpay";
            this.btnpay.Size = new System.Drawing.Size(247, 75);
            this.btnpay.TabIndex = 12;
            this.btnpay.Text = "Begleichen";
            this.btnpay.UseVisualStyleBackColor = false;
            this.btnpay.Click += new System.EventHandler(this.btnpay_Click);
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.Color.IndianRed;
            this.btnback.Location = new System.Drawing.Point(16, 15);
            this.btnback.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(204, 75);
            this.btnback.TabIndex = 13;
            this.btnback.Text = "Abbrechen";
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // lbltable
            // 
            this.lbltable.AutoSize = true;
            this.lbltable.Location = new System.Drawing.Point(297, 27);
            this.lbltable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltable.Name = "lbltable";
            this.lbltable.Size = new System.Drawing.Size(144, 16);
            this.lbltable.TabIndex = 14;
            this.lbltable.Text = "Ausgewählter Tisch: 00";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RestaurantClient.Properties.Resources.Gasthoficon;
            this.pictureBox1.Location = new System.Drawing.Point(692, 5);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(104, 105);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.Beige;
            this.btnprint.Location = new System.Drawing.Point(547, 512);
            this.btnprint.Margin = new System.Windows.Forms.Padding(4);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(247, 75);
            this.btnprint.TabIndex = 16;
            this.btnprint.Text = "Beleg drucken";
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // payMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 684);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbltable);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.btnpay);
            this.Controls.Add(this.rtbTips);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rtbmoneygive);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rtbcost);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxpayrest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbpayed);
            this.Controls.Add(this.clbnotpayed);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "payMenu";
            this.Text = "Abrechnung";
            this.Load += new System.EventHandler(this.payMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbnotpayed;
        private System.Windows.Forms.ListBox lbpayed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbxpayrest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtbcost;
        private System.Windows.Forms.RichTextBox rtbmoneygive;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox rtbTips;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnpay;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Label lbltable;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnprint;
    }
}