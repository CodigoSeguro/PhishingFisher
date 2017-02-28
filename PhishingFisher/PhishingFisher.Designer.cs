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
            this.components = new System.ComponentModel.Container();
            this.tbURL = new System.Windows.Forms.TextBox();
            this.btnFisherman = new System.Windows.Forms.Button();
            this.rtbTests = new System.Windows.Forms.RichTextBox();
            this.btnCompareImg = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tbURL
            // 
            this.tbURL.Location = new System.Drawing.Point(55, 41);
            this.tbURL.Name = "tbURL";
            this.tbURL.Size = new System.Drawing.Size(362, 31);
            this.tbURL.TabIndex = 1;
            this.tbURL.Text = "https://paypal.com";
            // 
            // btnFisherman
            // 
            this.btnFisherman.Location = new System.Drawing.Point(442, 41);
            this.btnFisherman.Name = "btnFisherman";
            this.btnFisherman.Size = new System.Drawing.Size(205, 40);
            this.btnFisherman.TabIndex = 2;
            this.btnFisherman.Text = "Search Fisherman";
            this.btnFisherman.UseVisualStyleBackColor = true;
            this.btnFisherman.Click += new System.EventHandler(this.btnFIsherman_Click);
            // 
            // rtbTests
            // 
            this.rtbTests.Location = new System.Drawing.Point(36, 134);
            this.rtbTests.Name = "rtbTests";
            this.rtbTests.Size = new System.Drawing.Size(611, 124);
            this.rtbTests.TabIndex = 3;
            this.rtbTests.Text = "";
            // 
            // btnCompareImg
            // 
            this.btnCompareImg.Location = new System.Drawing.Point(442, 88);
            this.btnCompareImg.Name = "btnCompareImg";
            this.btnCompareImg.Size = new System.Drawing.Size(205, 40);
            this.btnCompareImg.TabIndex = 4;
            this.btnCompareImg.Text = "Analyze Img";
            this.btnCompareImg.UseVisualStyleBackColor = true;
            this.btnCompareImg.Click += new System.EventHandler(this.btnCompareImg_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PhishingFisher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 286);
            this.Controls.Add(this.btnCompareImg);
            this.Controls.Add(this.rtbTests);
            this.Controls.Add(this.btnFisherman);
            this.Controls.Add(this.tbURL);
            this.Name = "PhishingFisher";
            this.Text = "ServicioCheckea";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbURL;
        private System.Windows.Forms.Button btnFisherman;
        private System.Windows.Forms.RichTextBox rtbTests;
        private System.Windows.Forms.Button btnCompareImg;
        private System.Windows.Forms.Timer timer1;
    }
}

