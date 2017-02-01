using SongsAbout.Desktop.Properties;
namespace SongsAbout.Controls
{
    partial class AttributeViewer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ListBox = new System.Windows.Forms.CheckedListBox();
            this.txtboxNewItem = new System.Windows.Forms.TextBox();
            this.lblTitleAddNew = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListBox
            // 
            this.ListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBox.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBox.ForeColor = System.Drawing.Color.White;
            this.ListBox.FormattingEnabled = true;
            this.ListBox.Location = new System.Drawing.Point(8, 34);
            this.ListBox.Name = "ListBox";
            this.ListBox.Size = new System.Drawing.Size(246, 190);
            this.ListBox.TabIndex = 0;
            this.ListBox.UseCompatibleTextRendering = true;
            this.ListBox.Click += new System.EventHandler(this.ListBox_Click);
            // 
            // txtboxNewItem
            // 
            this.txtboxNewItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtboxNewItem.BackColor = System.Drawing.Color.White;
            this.txtboxNewItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtboxNewItem.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtboxNewItem.Location = new System.Drawing.Point(85, 266);
            this.txtboxNewItem.Name = "txtboxNewItem";
            this.txtboxNewItem.Size = new System.Drawing.Size(171, 15);
            this.txtboxNewItem.TabIndex = 1;
            this.txtboxNewItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBxNewItem_KeyPress);
            // 
            // lblTitleAddNew
            // 
            this.lblTitleAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitleAddNew.AutoSize = true;
            this.lblTitleAddNew.BackColor = System.Drawing.SystemColors.HotTrack;
            this.lblTitleAddNew.ForeColor = System.Drawing.Color.White;
            this.lblTitleAddNew.Location = new System.Drawing.Point(7, 264);
            this.lblTitleAddNew.Name = "lblTitleAddNew";
            this.lblTitleAddNew.Size = new System.Drawing.Size(64, 17);
            this.lblTitleAddNew.TabIndex = 2;
            this.lblTitleAddNew.Text = "Add New";
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.SystemColors.HotTrack;
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(114, 4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(35, 17);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Title";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(76, 30);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(75, 26);
            // 
            // AttributeViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblTitleAddNew);
            this.Controls.Add(this.txtboxNewItem);
            this.Controls.Add(this.ListBox);
            this.Name = "AttributeViewer";
            this.Size = new System.Drawing.Size(263, 290);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox ListBox;
        private System.Windows.Forms.TextBox txtboxNewItem;
        private System.Windows.Forms.Label lblTitleAddNew;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}
