namespace SongsAbout_DesktopApp
{
    partial class WebAuthForm
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
            this.internalBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // wbAuthForm
            // 
            this.internalBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.internalBrowser.Location = new System.Drawing.Point(0, 0);
            this.internalBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.internalBrowser.Name = "wbAuthForm";
            this.internalBrowser.Size = new System.Drawing.Size(282, 253);
            this.internalBrowser.TabIndex = 0;
            // 
            // WebAuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.internalBrowser);
            this.Name = "WebAuthForm";
            this.Text = "Authorization";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser internalBrowser;
    }
}