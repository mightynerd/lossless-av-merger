namespace lossless_av_merge
{
    partial class FormHelp
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
            this.browserHelp = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // browserHelp
            // 
            this.browserHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserHelp.Location = new System.Drawing.Point(0, 0);
            this.browserHelp.MinimumSize = new System.Drawing.Size(20, 20);
            this.browserHelp.Name = "browserHelp";
            this.browserHelp.Size = new System.Drawing.Size(480, 285);
            this.browserHelp.TabIndex = 0;
            // 
            // FormHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 285);
            this.Controls.Add(this.browserHelp);
            this.Name = "FormHelp";
            this.Text = "FormHelp";
            this.Load += new System.EventHandler(this.FormHelp_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser browserHelp;
    }
}