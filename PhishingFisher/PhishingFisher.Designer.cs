namespace PhishingFisher
{
    partial class PhishingFisher
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbURL = new System.Windows.Forms.TextBox();
            this.btnFisherman = new System.Windows.Forms.Button();
            this.rtbTests = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // tbURL
            // 
            this.tbURL.Location = new System.Drawing.Point(44, 34);
            this.tbURL.Name = "tbURL";
            this.tbURL.Size = new System.Drawing.Size(362, 31);
            this.tbURL.TabIndex = 1;
            this.tbURL.Text = "https://paypal.com";
            // 
            // btnFisherman
            // 
            this.btnFisherman.Location = new System.Drawing.Point(431, 34);
            this.btnFisherman.Name = "btnFisherman";
            this.btnFisherman.Size = new System.Drawing.Size(205, 40);
            this.btnFisherman.TabIndex = 2;
            this.btnFisherman.Text = "Search Fisherman";
            this.btnFisherman.UseVisualStyleBackColor = true;
            this.btnFisherman.Click += new System.EventHandler(this.btnFIsherman_Click);
            // 
            // rtbTests
            // 
            this.rtbTests.Location = new System.Drawing.Point(212, 127);
            this.rtbTests.Name = "rtbTests";
            this.rtbTests.Size = new System.Drawing.Size(386, 124);
            this.rtbTests.TabIndex = 3;
            this.rtbTests.Text = "";
            // 
            // PhishingFisher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 294);
            this.Controls.Add(this.rtbTests);
            this.Controls.Add(this.btnFisherman);
            this.Controls.Add(this.tbURL);
            this.Name = "PhishingFisher";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbURL;
        private System.Windows.Forms.Button btnFisherman;
        private System.Windows.Forms.RichTextBox rtbTests;
    }
}

