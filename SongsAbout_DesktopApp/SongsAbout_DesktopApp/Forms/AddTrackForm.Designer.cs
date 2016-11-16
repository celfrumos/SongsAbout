namespace SongsAbout
{
    partial class AddTrackForm
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
            this.components = new System.ComponentModel.Container();
            this.lstBxGenres = new System.Windows.Forms.ListBox();
            this.genresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet = new SongsAbout.DataSet();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxLength = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cBoxAlbum = new System.Windows.Forms.ComboBox();
            this.albumsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.albumsTableAdapter = new SongsAbout.DataSetTableAdapters.AlbumsTableAdapter();
            this.cBoxMainArtist = new System.Windows.Forms.ComboBox();
            this.artistsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.artistsTableAdapter = new SongsAbout.DataSetTableAdapters.ArtistsTableAdapter();
            this.btnNewAlbum = new System.Windows.Forms.Button();
            this.btnNewArtist = new System.Windows.Forms.Button();
            this.genresTableAdapter = new SongsAbout.DataSetTableAdapters.GenresTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.genresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.albumsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.artistsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lstBxGenres
            // 
            this.lstBxGenres.DataSource = this.genresBindingSource;
            this.lstBxGenres.DisplayMember = "genre";
            this.lstBxGenres.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBxGenres.FormattingEnabled = true;
            this.lstBxGenres.ItemHeight = 17;
            this.lstBxGenres.Location = new System.Drawing.Point(382, 39);
            this.lstBxGenres.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstBxGenres.Name = "lstBxGenres";
            this.lstBxGenres.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstBxGenres.Size = new System.Drawing.Size(166, 157);
            this.lstBxGenres.Sorted = true;
            this.lstBxGenres.TabIndex = 4;
            this.lstBxGenres.ValueMember = "genre";
            // 
            // genresBindingSource
            // 
            this.genresBindingSource.DataMember = "Genres";
            this.genresBindingSource.DataSource = this.dataSet;
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "DataSet";
            this.dataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(378, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 23);
            this.label2.TabIndex = 24;
            this.label2.Text = "Genre(s)";
            // 
            // txtBoxLength
            // 
            this.txtBoxLength.Location = new System.Drawing.Point(140, 41);
            this.txtBoxLength.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBoxLength.Name = "txtBoxLength";
            this.txtBoxLength.Size = new System.Drawing.Size(216, 22);
            this.txtBoxLength.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label11.Location = new System.Drawing.Point(15, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 23);
            this.label11.TabIndex = 26;
            this.label11.Text = "Length";
            // 
            // txtBoxName
            // 
            this.txtBoxName.Location = new System.Drawing.Point(140, 11);
            this.txtBoxName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(216, 22);
            this.txtBoxName.TabIndex = 0;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label14.Location = new System.Drawing.Point(15, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 23);
            this.label14.TabIndex = 26;
            this.label14.Text = "Name";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnClose.Location = new System.Drawing.Point(563, 159);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(104, 32);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "&Cancel";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSave.Location = new System.Drawing.Point(564, 13);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(103, 50);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(15, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 31;
            this.label4.Text = "Main Artist";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(15, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 23);
            this.label1.TabIndex = 35;
            this.label1.Text = "Album";
            // 
            // cBoxAlbum
            // 
            this.cBoxAlbum.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.albumsBindingSource, "album_id", true));
            this.cBoxAlbum.DataSource = this.albumsBindingSource;
            this.cBoxAlbum.DisplayMember = "al_title";
            this.cBoxAlbum.FormattingEnabled = true;
            this.cBoxAlbum.Location = new System.Drawing.Point(140, 137);
            this.cBoxAlbum.Name = "cBoxAlbum";
            this.cBoxAlbum.Size = new System.Drawing.Size(216, 24);
            this.cBoxAlbum.TabIndex = 3;
            this.cBoxAlbum.ValueMember = "album_id";
            // 
            // albumsBindingSource
            // 
            this.albumsBindingSource.DataMember = "Albums";
            this.albumsBindingSource.DataSource = this.dataSet;
            // 
            // albumsTableAdapter
            // 
            this.albumsTableAdapter.ClearBeforeFill = true;
            // 
            // cBoxMainArtist
            // 
            this.cBoxMainArtist.DataSource = this.artistsBindingSource;
            this.cBoxMainArtist.DisplayMember = "a_name";
            this.cBoxMainArtist.FormattingEnabled = true;
            this.cBoxMainArtist.Location = new System.Drawing.Point(140, 71);
            this.cBoxMainArtist.Name = "cBoxMainArtist";
            this.cBoxMainArtist.Size = new System.Drawing.Size(216, 24);
            this.cBoxMainArtist.TabIndex = 2;
            this.cBoxMainArtist.ValueMember = "artist_id";
            // 
            // artistsBindingSource
            // 
            this.artistsBindingSource.DataMember = "Artists";
            this.artistsBindingSource.DataSource = this.dataSet;
            // 
            // artistsTableAdapter
            // 
            this.artistsTableAdapter.ClearBeforeFill = true;
            // 
            // btnNewAlbum
            // 
            this.btnNewAlbum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewAlbum.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnNewAlbum.Location = new System.Drawing.Point(140, 168);
            this.btnNewAlbum.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewAlbum.Name = "btnNewAlbum";
            this.btnNewAlbum.Size = new System.Drawing.Size(92, 28);
            this.btnNewAlbum.TabIndex = 8;
            this.btnNewAlbum.Text = "New A&lbum";
            this.btnNewAlbum.UseVisualStyleBackColor = true;
            this.btnNewAlbum.Click += new System.EventHandler(this.btnNewAlbum_Click);
            // 
            // btnNewArtist
            // 
            this.btnNewArtist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewArtist.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnNewArtist.Location = new System.Drawing.Point(140, 102);
            this.btnNewArtist.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewArtist.Name = "btnNewArtist";
            this.btnNewArtist.Size = new System.Drawing.Size(92, 28);
            this.btnNewArtist.TabIndex = 7;
            this.btnNewArtist.Text = "New &Artist";
            this.btnNewArtist.UseVisualStyleBackColor = true;
            this.btnNewArtist.Click += new System.EventHandler(this.btnNewArtist_Click);
            // 
            // genresTableAdapter
            // 
            this.genresTableAdapter.ClearBeforeFill = true;
            // 
            // AddTrackForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(680, 204);
            this.Controls.Add(this.btnNewAlbum);
            this.Controls.Add(this.btnNewArtist);
            this.Controls.Add(this.cBoxMainArtist);
            this.Controls.Add(this.cBoxAlbum);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstBxGenres);
            this.Controls.Add(this.txtBoxName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtBoxLength);
            this.Controls.Add(this.btnSave);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddTrackForm";
            this.Text = "Add New Track";
            this.Load += new System.EventHandler(this.AddTrackForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.genresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.albumsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.artistsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lstBxGenres;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxLength;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cBoxAlbum;
        private DataSet dataSet;
        private System.Windows.Forms.BindingSource albumsBindingSource;
        private DataSetTableAdapters.AlbumsTableAdapter albumsTableAdapter;
        private System.Windows.Forms.ComboBox cBoxMainArtist;
        private System.Windows.Forms.BindingSource artistsBindingSource;
        private DataSetTableAdapters.ArtistsTableAdapter artistsTableAdapter;
        private System.Windows.Forms.Button btnNewAlbum;
        private System.Windows.Forms.Button btnNewArtist;
        private System.Windows.Forms.BindingSource genresBindingSource;
        private DataSetTableAdapters.GenresTableAdapter genresTableAdapter;
    }
}