namespace RestaurantClient
{
    partial class Mainform
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_Example = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // btn_Example
            // 
            btn_Example.Location = new System.Drawing.Point(344, 215);
            btn_Example.Name = "btn_Example";
            btn_Example.Size = new System.Drawing.Size(94, 29);
            btn_Example.TabIndex = 0;
            btn_Example.Text = "Beispielknopf";
            btn_Example.UseVisualStyleBackColor = true;
            // 
            // Mainform
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(btn_Example);
            Name = "Mainform";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btn_Example;
    }
}
