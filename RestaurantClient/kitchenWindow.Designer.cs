namespace RestaurantClient
{
    partial class kitchenWindow
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
            this.lbl_openPositions = new System.Windows.Forms.Label();
            this.lbl_DateAndTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_openPositions
            // 
            this.lbl_openPositions.AutoSize = true;
            this.lbl_openPositions.Location = new System.Drawing.Point(12, 55);
            this.lbl_openPositions.Name = "lbl_openPositions";
            this.lbl_openPositions.Size = new System.Drawing.Size(98, 16);
            this.lbl_openPositions.TabIndex = 0;
            this.lbl_openPositions.Text = "Open Positions";
            // 
            // lbl_DateAndTime
            // 
            this.lbl_DateAndTime.AutoSize = true;
            this.lbl_DateAndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DateAndTime.Location = new System.Drawing.Point(12, 9);
            this.lbl_DateAndTime.Name = "lbl_DateAndTime";
            this.lbl_DateAndTime.Size = new System.Drawing.Size(140, 25);
            this.lbl_DateAndTime.TabIndex = 1;
            this.lbl_DateAndTime.Text = "Date and Time";
            // 
            // kitchenWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_DateAndTime);
            this.Controls.Add(this.lbl_openPositions);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "kitchenWindow";
            this.ShowIcon = false;
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_openPositions;
        private System.Windows.Forms.Label lbl_DateAndTime;
    }
}