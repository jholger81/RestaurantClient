namespace RestaurantClient
{
    partial class extrasornon
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
            this.rtbRemove = new System.Windows.Forms.RichTextBox();
            this.rtbExtras = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnsave = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbRemove
            // 
            this.rtbRemove.Location = new System.Drawing.Point(446, 41);
            this.rtbRemove.Name = "rtbRemove";
            this.rtbRemove.Size = new System.Drawing.Size(283, 268);
            this.rtbRemove.TabIndex = 0;
            this.rtbRemove.Text = "";
            // 
            // rtbExtras
            // 
            this.rtbExtras.Location = new System.Drawing.Point(27, 41);
            this.rtbExtras.Name = "rtbExtras";
            this.rtbExtras.Size = new System.Drawing.Size(283, 268);
            this.rtbExtras.TabIndex = 1;
            this.rtbExtras.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(443, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Entfernen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Extras";
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnsave.Location = new System.Drawing.Point(507, 315);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(165, 102);
            this.btnsave.TabIndex = 13;
            this.btnsave.Text = "Speichern";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btndelete
            // 
            this.btndelete.BackColor = System.Drawing.Color.Salmon;
            this.btndelete.Location = new System.Drawing.Point(88, 315);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(165, 102);
            this.btndelete.TabIndex = 14;
            this.btndelete.Text = "Abbrechen";
            this.btndelete.UseVisualStyleBackColor = false;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // extrasornon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 428);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbExtras);
            this.Controls.Add(this.rtbRemove);
            this.Name = "extrasornon";
            this.Text = "Extras oder Entfernen?";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbRemove;
        private System.Windows.Forms.RichTextBox rtbExtras;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btndelete;
    }
}