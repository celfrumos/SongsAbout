namespace SongsAbout.Forms
{
    partial class QueryForm
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
            this.artistsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet = new SongsAbout.DataSet();
            this.btnSaveClose = new System.Windows.Forms.Button();
            this.btnSaveContinue = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabLists = new System.Windows.Forms.TabPage();
            this.dgvLists = new System.Windows.Forms.DataGridView();
            this.col_list_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TrackTags = new System.Windows.Forms.TabPage();
            this.dgvTrackTags = new System.Windows.Forms.DataGridView();
            this.tracksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tagsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.trackTagsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabTags = new System.Windows.Forms.TabPage();
            this.dgvTags = new System.Windows.Forms.DataGridView();
            this.col_tag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabTrackGenres = new System.Windows.Forms.TabPage();
            this.dgvTrackGenres = new System.Windows.Forms.DataGridView();
            this.genresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.trackGenresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabGenres = new System.Windows.Forms.TabPage();
            this.dgvGenres = new System.Windows.Forms.DataGridView();
            this.col_genre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabTracks = new System.Windows.Forms.TabPage();
            this.dgvTracks = new System.Windows.Forms.DataGridView();
            this.albumsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabAlbums = new System.Windows.Forms.TabPage();
            this.dgvAlbums = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_al_artist_Id = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.col_al_year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_al_cover_art = new System.Windows.Forms.DataGridViewImageColumn();
            this.col_al_spotify_uri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvArtists = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.tabControls = new System.Windows.Forms.TabControl();
            this.tabAlbumGenres = new System.Windows.Forms.TabPage();
            this.dgvAlbumGenres = new System.Windows.Forms.DataGridView();
            this.albumGenresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.albumsTableAdapter = new SongsAbout.DataSetTableAdapters.AlbumsTableAdapter();
            this.artistsTableAdapter = new SongsAbout.DataSetTableAdapters.ArtistsTableAdapter();
            this.genresTableAdapter = new SongsAbout.DataSetTableAdapters.GenresTableAdapter();
            this.trackGenresTableAdapter = new SongsAbout.DataSetTableAdapters.TrackGenresTableAdapter();
            this.tracksTableAdapter = new SongsAbout.DataSetTableAdapters.TracksTableAdapter();
            this.tagsTableAdapter = new SongsAbout.DataSetTableAdapters.TagsTableAdapter();
            this.trackTagsTableAdapter = new SongsAbout.DataSetTableAdapters.TrackTagsTableAdapter();
            this.listsTableAdapter = new SongsAbout.DataSetTableAdapters.ListsTableAdapter();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tag_text = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.track_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tableAdapterMngr = new SongsAbout.DataSetTableAdapters.TableAdapterManager();
            this.albumGenresTableAdapter = new SongsAbout.DataSetTableAdapters.AlbumGenresTableAdapter();
            this.trackArtistsTableAdapter = new SongsAbout.DataSetTableAdapters.TrackArtistsTableAdapter();
            this.fKArtistTracksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.trackArtistsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.col_tg_track_id = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.col_tg_genre = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.col_ttags_track_id = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.col_ttag_tag_text = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.artistsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            this.tabLists.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLists)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listsBindingSource)).BeginInit();
            this.TrackTags.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrackTags)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tracksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tagsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackTagsBindingSource)).BeginInit();
            this.tabTags.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTags)).BeginInit();
            this.tabTrackGenres.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrackGenres)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.genresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackGenresBindingSource)).BeginInit();
            this.tabGenres.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGenres)).BeginInit();
            this.tabTracks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTracks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.albumsBindingSource)).BeginInit();
            this.tabAlbums.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlbums)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArtists)).BeginInit();
            this.tabControls.SuspendLayout();
            this.tabAlbumGenres.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlbumGenres)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.albumGenresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKArtistTracksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackArtistsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // artistsBindingSource
            // 
            this.artistsBindingSource.DataMember = "Artists";
            this.artistsBindingSource.DataSource = this.dataSet;
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "DataSet";
            this.dataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveClose.Location = new System.Drawing.Point(861, 495);
            this.btnSaveClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(156, 24);
            this.btnSaveClose.TabIndex = 2;
            this.btnSaveClose.Text = "Save and Close";
            this.btnSaveClose.UseVisualStyleBackColor = true;
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // btnSaveContinue
            // 
            this.btnSaveContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveContinue.Location = new System.Drawing.Point(663, 495);
            this.btnSaveContinue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveContinue.Name = "btnSaveContinue";
            this.btnSaveContinue.Size = new System.Drawing.Size(156, 24);
            this.btnSaveContinue.TabIndex = 3;
            this.btnSaveContinue.Text = "Save and Continue";
            this.btnSaveContinue.UseVisualStyleBackColor = true;
            this.btnSaveContinue.Click += new System.EventHandler(this.btnSaveContinue_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(12, 495);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(156, 24);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel and E&xit";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabLists
            // 
            this.tabLists.Controls.Add(this.dgvLists);
            this.tabLists.Location = new System.Drawing.Point(4, 25);
            this.tabLists.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabLists.Name = "tabLists";
            this.tabLists.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabLists.Size = new System.Drawing.Size(1013, 450);
            this.tabLists.TabIndex = 7;
            this.tabLists.Text = "Lists";
            this.tabLists.UseVisualStyleBackColor = true;
            // 
            // dgvLists
            // 
            this.dgvLists.AutoGenerateColumns = false;
            this.dgvLists.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLists.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_list_name});
            this.dgvLists.DataSource = this.listsBindingSource;
            this.dgvLists.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLists.Location = new System.Drawing.Point(3, 2);
            this.dgvLists.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvLists.Name = "dgvLists";
            this.dgvLists.RowTemplate.Height = 24;
            this.dgvLists.Size = new System.Drawing.Size(1007, 446);
            this.dgvLists.TabIndex = 0;
            // 
            // col_list_name
            // 
            this.col_list_name.DataPropertyName = "list_name";
            this.col_list_name.HeaderText = "List Name";
            this.col_list_name.Name = "col_list_name";
            // 
            // listsBindingSource
            // 
            this.listsBindingSource.DataMember = "Lists";
            this.listsBindingSource.DataSource = this.dataSet;
            // 
            // TrackTags
            // 
            this.TrackTags.Controls.Add(this.dgvTrackTags);
            this.TrackTags.Location = new System.Drawing.Point(4, 25);
            this.TrackTags.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TrackTags.Name = "TrackTags";
            this.TrackTags.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TrackTags.Size = new System.Drawing.Size(1013, 450);
            this.TrackTags.TabIndex = 6;
            this.TrackTags.Text = "TrackTags";
            this.TrackTags.UseVisualStyleBackColor = true;
            // 
            // dgvTrackTags
            // 
            this.dgvTrackTags.AutoGenerateColumns = false;
            this.dgvTrackTags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrackTags.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_ttags_track_id,
            this.col_ttag_tag_text});
            this.dgvTrackTags.DataSource = this.trackTagsBindingSource;
            this.dgvTrackTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTrackTags.Location = new System.Drawing.Point(3, 2);
            this.dgvTrackTags.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvTrackTags.Name = "dgvTrackTags";
            this.dgvTrackTags.RowTemplate.Height = 24;
            this.dgvTrackTags.Size = new System.Drawing.Size(1007, 446);
            this.dgvTrackTags.TabIndex = 0;
            // 
            // tracksBindingSource
            // 
            this.tracksBindingSource.DataMember = "Tracks";
            this.tracksBindingSource.DataSource = this.dataSet;
            // 
            // tagsBindingSource
            // 
            this.tagsBindingSource.DataMember = "Tags";
            this.tagsBindingSource.DataSource = this.dataSet;
            // 
            // trackTagsBindingSource
            // 
            this.trackTagsBindingSource.DataMember = "TrackTags";
            this.trackTagsBindingSource.DataSource = this.dataSet;
            // 
            // tabTags
            // 
            this.tabTags.Controls.Add(this.dgvTags);
            this.tabTags.Location = new System.Drawing.Point(4, 25);
            this.tabTags.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabTags.Name = "tabTags";
            this.tabTags.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabTags.Size = new System.Drawing.Size(1013, 450);
            this.tabTags.TabIndex = 5;
            this.tabTags.Text = "Tags";
            this.tabTags.UseVisualStyleBackColor = true;
            // 
            // dgvTags
            // 
            this.dgvTags.AutoGenerateColumns = false;
            this.dgvTags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTags.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_tag});
            this.dgvTags.DataSource = this.tagsBindingSource;
            this.dgvTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTags.Location = new System.Drawing.Point(3, 2);
            this.dgvTags.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvTags.Name = "dgvTags";
            this.dgvTags.RowTemplate.Height = 24;
            this.dgvTags.Size = new System.Drawing.Size(1007, 446);
            this.dgvTags.TabIndex = 0;
            // 
            // col_tag
            // 
            this.col_tag.DataPropertyName = "tag_text";
            this.col_tag.HeaderText = "tag_text";
            this.col_tag.Name = "col_tag";
            // 
            // tabTrackGenres
            // 
            this.tabTrackGenres.Controls.Add(this.dgvTrackGenres);
            this.tabTrackGenres.Location = new System.Drawing.Point(4, 25);
            this.tabTrackGenres.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabTrackGenres.Name = "tabTrackGenres";
            this.tabTrackGenres.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabTrackGenres.Size = new System.Drawing.Size(1013, 450);
            this.tabTrackGenres.TabIndex = 4;
            this.tabTrackGenres.Text = "TrackGenres";
            this.tabTrackGenres.UseVisualStyleBackColor = true;
            // 
            // dgvTrackGenres
            // 
            this.dgvTrackGenres.AutoGenerateColumns = false;
            this.dgvTrackGenres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrackGenres.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_tg_track_id,
            this.col_tg_genre});
            this.dgvTrackGenres.DataSource = this.trackGenresBindingSource;
            this.dgvTrackGenres.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTrackGenres.Location = new System.Drawing.Point(3, 2);
            this.dgvTrackGenres.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvTrackGenres.Name = "dgvTrackGenres";
            this.dgvTrackGenres.RowTemplate.Height = 24;
            this.dgvTrackGenres.Size = new System.Drawing.Size(1007, 446);
            this.dgvTrackGenres.TabIndex = 2;
            // 
            // genresBindingSource
            // 
            this.genresBindingSource.DataMember = "Genres";
            this.genresBindingSource.DataSource = this.dataSet;
            // 
            // trackGenresBindingSource
            // 
            this.trackGenresBindingSource.DataMember = "TrackGenres";
            this.trackGenresBindingSource.DataSource = this.dataSet;
            // 
            // tabGenres
            // 
            this.tabGenres.Controls.Add(this.dgvGenres);
            this.tabGenres.Location = new System.Drawing.Point(4, 25);
            this.tabGenres.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabGenres.Name = "tabGenres";
            this.tabGenres.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabGenres.Size = new System.Drawing.Size(1013, 450);
            this.tabGenres.TabIndex = 3;
            this.tabGenres.Text = "Genres";
            this.tabGenres.UseVisualStyleBackColor = true;
            // 
            // dgvGenres
            // 
            this.dgvGenres.AutoGenerateColumns = false;
            this.dgvGenres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGenres.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_genre});
            this.dgvGenres.DataSource = this.genresBindingSource;
            this.dgvGenres.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGenres.Location = new System.Drawing.Point(3, 2);
            this.dgvGenres.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvGenres.Name = "dgvGenres";
            this.dgvGenres.RowTemplate.Height = 24;
            this.dgvGenres.Size = new System.Drawing.Size(1007, 446);
            this.dgvGenres.TabIndex = 1;
            // 
            // col_genre
            // 
            this.col_genre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_genre.DataPropertyName = "genre";
            this.col_genre.HeaderText = "Genre";
            this.col_genre.Name = "col_genre";
            this.col_genre.Width = 77;
            // 
            // tabTracks
            // 
            this.tabTracks.Controls.Add(this.dgvTracks);
            this.tabTracks.Location = new System.Drawing.Point(4, 25);
            this.tabTracks.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabTracks.Name = "tabTracks";
            this.tabTracks.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabTracks.Size = new System.Drawing.Size(1013, 450);
            this.tabTracks.TabIndex = 2;
            this.tabTracks.Text = "Tracks";
            this.tabTracks.UseVisualStyleBackColor = true;
            // 
            // dgvTracks
            // 
            this.dgvTracks.AutoGenerateColumns = false;
            this.dgvTracks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTracks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn20,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn17});
            this.dgvTracks.DataSource = this.tracksBindingSource;
            this.dgvTracks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTracks.Location = new System.Drawing.Point(3, 2);
            this.dgvTracks.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvTracks.Name = "dgvTracks";
            this.dgvTracks.RowTemplate.Height = 24;
            this.dgvTracks.Size = new System.Drawing.Size(1007, 446);
            this.dgvTracks.TabIndex = 0;
            // 
            // albumsBindingSource
            // 
            this.albumsBindingSource.DataMember = "Albums";
            this.albumsBindingSource.DataSource = this.dataSet;
            // 
            // tabAlbums
            // 
            this.tabAlbums.Controls.Add(this.dgvAlbums);
            this.tabAlbums.Location = new System.Drawing.Point(4, 25);
            this.tabAlbums.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabAlbums.Name = "tabAlbums";
            this.tabAlbums.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabAlbums.Size = new System.Drawing.Size(1013, 450);
            this.tabAlbums.TabIndex = 1;
            this.tabAlbums.Text = "Albums";
            this.tabAlbums.UseVisualStyleBackColor = true;
            // 
            // dgvAlbums
            // 
            this.dgvAlbums.AllowUserToOrderColumns = true;
            this.dgvAlbums.AutoGenerateColumns = false;
            this.dgvAlbums.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlbums.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.col_al_artist_Id,
            this.col_al_year,
            this.col_al_cover_art,
            this.col_al_spotify_uri});
            this.dgvAlbums.DataSource = this.albumsBindingSource;
            this.dgvAlbums.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlbums.Location = new System.Drawing.Point(3, 2);
            this.dgvAlbums.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvAlbums.Name = "dgvAlbums";
            this.dgvAlbums.RowTemplate.Height = 24;
            this.dgvAlbums.Size = new System.Drawing.Size(1007, 446);
            this.dgvAlbums.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn7.HeaderText = "Name";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // col_al_artist_Id
            // 
            this.col_al_artist_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_al_artist_Id.DataPropertyName = "artist_id";
            this.col_al_artist_Id.DataSource = this.artistsBindingSource;
            this.col_al_artist_Id.DisplayMember = "name";
            this.col_al_artist_Id.DisplayStyleForCurrentCellOnly = true;
            this.col_al_artist_Id.HeaderText = "Artist";
            this.col_al_artist_Id.Name = "col_al_artist_Id";
            this.col_al_artist_Id.ReadOnly = true;
            this.col_al_artist_Id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_al_artist_Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_al_artist_Id.ValueMember = "ID";
            this.col_al_artist_Id.Width = 69;
            // 
            // col_al_year
            // 
            this.col_al_year.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_al_year.DataPropertyName = "al_year";
            this.col_al_year.HeaderText = "Year";
            this.col_al_year.Name = "col_al_year";
            this.col_al_year.Width = 67;
            // 
            // col_al_cover_art
            // 
            this.col_al_cover_art.DataPropertyName = "al_cover_art";
            this.col_al_cover_art.HeaderText = "Cover Art";
            this.col_al_cover_art.Name = "col_al_cover_art";
            // 
            // col_al_spotify_uri
            // 
            this.col_al_spotify_uri.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_al_spotify_uri.DataPropertyName = "al_spotify_uri";
            this.col_al_spotify_uri.HeaderText = "Spotify URI";
            this.col_al_spotify_uri.Name = "col_al_spotify_uri";
            this.col_al_spotify_uri.Width = 107;
            // 
            // tabPage1
            // 
            this.tabPage1.AllowDrop = true;
            this.tabPage1.Controls.Add(this.dgvArtists);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(1013, 450);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Artists";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvArtists
            // 
            this.dgvArtists.AutoGenerateColumns = false;
            this.dgvArtists.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArtists.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewImageColumn1});
            this.dgvArtists.DataSource = this.artistsBindingSource;
            this.dgvArtists.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvArtists.Location = new System.Drawing.Point(3, 2);
            this.dgvArtists.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvArtists.Name = "dgvArtists";
            this.dgvArtists.RowTemplate.Height = 24;
            this.dgvArtists.Size = new System.Drawing.Size(1007, 446);
            this.dgvArtists.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn9.HeaderText = "name";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "a_bio";
            this.dataGridViewTextBoxColumn10.HeaderText = "a_bio";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "a_website";
            this.dataGridViewTextBoxColumn11.HeaderText = "a_website";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "a_spotify_uri";
            this.dataGridViewTextBoxColumn13.HeaderText = "a_spotify_uri";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.DataPropertyName = "a_profile_pic";
            this.dataGridViewImageColumn1.HeaderText = "a_profile_pic";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // tabControls
            // 
            this.tabControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControls.Controls.Add(this.tabPage1);
            this.tabControls.Controls.Add(this.tabAlbums);
            this.tabControls.Controls.Add(this.tabTracks);
            this.tabControls.Controls.Add(this.tabGenres);
            this.tabControls.Controls.Add(this.tabTrackGenres);
            this.tabControls.Controls.Add(this.tabTags);
            this.tabControls.Controls.Add(this.TrackTags);
            this.tabControls.Controls.Add(this.tabLists);
            this.tabControls.Controls.Add(this.tabAlbumGenres);
            this.tabControls.Location = new System.Drawing.Point(0, 12);
            this.tabControls.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControls.Name = "tabControls";
            this.tabControls.SelectedIndex = 0;
            this.tabControls.Size = new System.Drawing.Size(1021, 479);
            this.tabControls.TabIndex = 1;
            // 
            // tabAlbumGenres
            // 
            this.tabAlbumGenres.Controls.Add(this.dgvAlbumGenres);
            this.tabAlbumGenres.Location = new System.Drawing.Point(4, 25);
            this.tabAlbumGenres.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabAlbumGenres.Name = "tabAlbumGenres";
            this.tabAlbumGenres.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabAlbumGenres.Size = new System.Drawing.Size(1013, 450);
            this.tabAlbumGenres.TabIndex = 9;
            this.tabAlbumGenres.Text = "Album Genres";
            this.tabAlbumGenres.UseVisualStyleBackColor = true;
            // 
            // dgvAlbumGenres
            // 
            this.dgvAlbumGenres.AutoGenerateColumns = false;
            this.dgvAlbumGenres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlbumGenres.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dgvAlbumGenres.DataSource = this.albumGenresBindingSource;
            this.dgvAlbumGenres.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlbumGenres.Location = new System.Drawing.Point(3, 2);
            this.dgvAlbumGenres.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvAlbumGenres.Name = "dgvAlbumGenres";
            this.dgvAlbumGenres.RowTemplate.Height = 24;
            this.dgvAlbumGenres.Size = new System.Drawing.Size(1007, 446);
            this.dgvAlbumGenres.TabIndex = 0;
            // 
            // albumGenresBindingSource
            // 
            this.albumGenresBindingSource.DataMember = "AlbumGenres";
            this.albumGenresBindingSource.DataSource = this.dataSet;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "track_id";
            this.dataGridViewTextBoxColumn1.HeaderText = "track_id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "artist_id";
            this.dataGridViewTextBoxColumn2.HeaderText = "artist_id";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "album_id";
            this.dataGridViewTextBoxColumn3.HeaderText = "album_id";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // albumsTableAdapter
            // 
            this.albumsTableAdapter.ClearBeforeFill = true;
            // 
            // artistsTableAdapter
            // 
            this.artistsTableAdapter.ClearBeforeFill = true;
            // 
            // genresTableAdapter
            // 
            this.genresTableAdapter.ClearBeforeFill = true;
            // 
            // trackGenresTableAdapter
            // 
            this.trackGenresTableAdapter.ClearBeforeFill = true;
            // 
            // tracksTableAdapter
            // 
            this.tracksTableAdapter.ClearBeforeFill = true;
            // 
            // tagsTableAdapter
            // 
            this.tagsTableAdapter.ClearBeforeFill = true;
            // 
            // trackTagsTableAdapter
            // 
            this.trackTagsTableAdapter.ClearBeforeFill = true;
            // 
            // listsTableAdapter
            // 
            this.listsTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "tag_text";
            this.dataGridViewTextBoxColumn12.DataSource = this.tagsBindingSource;
            this.dataGridViewTextBoxColumn12.DisplayMember = "tag_text";
            this.dataGridViewTextBoxColumn12.DisplayStyleForCurrentCellOnly = true;
            this.dataGridViewTextBoxColumn12.HeaderText = "Tag Text";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn12.ValueMember = "tag_text";
            // 
            // tag_text
            // 
            this.tag_text.DataPropertyName = "tag_text";
            this.tag_text.DataSource = this.trackTagsBindingSource;
            this.tag_text.DisplayMember = "tag_text";
            this.tag_text.DisplayStyleForCurrentCellOnly = true;
            this.tag_text.HeaderText = "Tag Text";
            this.tag_text.Name = "tag_text";
            this.tag_text.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tag_text.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tag_text.ValueMember = "tag_text";
            // 
            // track_id
            // 
            this.track_id.DataPropertyName = "track_id";
            this.track_id.HeaderText = "track_id";
            this.track_id.Name = "track_id";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "Select an Image";
            // 
            // tableAdapterMngr
            // 
            this.tableAdapterMngr.AlbumGenresTableAdapter = this.albumGenresTableAdapter;
            this.tableAdapterMngr.AlbumsTableAdapter = this.albumsTableAdapter;
            this.tableAdapterMngr.AlbumTracksTableAdapter = null;
            this.tableAdapterMngr.ArtistsTableAdapter = this.artistsTableAdapter;
            this.tableAdapterMngr.BackupDataSetBeforeUpdate = false;
            this.tableAdapterMngr.GenresTableAdapter = this.genresTableAdapter;
            this.tableAdapterMngr.ListsTableAdapter = this.listsTableAdapter;
            this.tableAdapterMngr.TagsTableAdapter = this.tagsTableAdapter;
            this.tableAdapterMngr.TopicsTableAdapter = null;
            this.tableAdapterMngr.TrackArtistsTableAdapter = this.trackArtistsTableAdapter;
            this.tableAdapterMngr.TrackGenresTableAdapter = this.trackGenresTableAdapter;
            this.tableAdapterMngr.TracksTableAdapter = this.tracksTableAdapter;
            this.tableAdapterMngr.TrackTagsTableAdapter = this.trackTagsTableAdapter;
            this.tableAdapterMngr.TrackTopicsTableAdapter = null;
            this.tableAdapterMngr.UpdateOrder = SongsAbout.DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // albumGenresTableAdapter
            // 
            this.albumGenresTableAdapter.ClearBeforeFill = true;
            // 
            // trackArtistsTableAdapter
            // 
            this.trackArtistsTableAdapter.ClearBeforeFill = true;
            // 
            // trackArtistsBindingSource
            // 
            this.trackArtistsBindingSource.DataMember = "TrackArtists";
            this.trackArtistsBindingSource.DataSource = this.dataSet;
            // 
            // col_tg_track_id
            // 
            this.col_tg_track_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_tg_track_id.DataPropertyName = "track_id";
            this.col_tg_track_id.DataSource = this.tracksBindingSource;
            this.col_tg_track_id.DisplayMember = "name";
            this.col_tg_track_id.DisplayStyleForCurrentCellOnly = true;
            this.col_tg_track_id.HeaderText = "Track";
            this.col_tg_track_id.Name = "col_tg_track_id";
            this.col_tg_track_id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_tg_track_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_tg_track_id.ValueMember = "ID";
            this.col_tg_track_id.Width = 73;
            // 
            // col_tg_genre
            // 
            this.col_tg_genre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_tg_genre.DataPropertyName = "genre";
            this.col_tg_genre.DataSource = this.genresBindingSource;
            this.col_tg_genre.DisplayMember = "genre";
            this.col_tg_genre.DisplayStyleForCurrentCellOnly = true;
            this.col_tg_genre.HeaderText = "Genre";
            this.col_tg_genre.Name = "col_tg_genre";
            this.col_tg_genre.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_tg_genre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_tg_genre.ValueMember = "genre";
            this.col_tg_genre.Width = 77;
            // 
            // col_ttags_track_id
            // 
            this.col_ttags_track_id.DataPropertyName = "track_id";
            this.col_ttags_track_id.DataSource = this.tracksBindingSource;
            this.col_ttags_track_id.DisplayMember = "name";
            this.col_ttags_track_id.DisplayStyleForCurrentCellOnly = true;
            this.col_ttags_track_id.HeaderText = "Track";
            this.col_ttags_track_id.Name = "col_ttags_track_id";
            this.col_ttags_track_id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_ttags_track_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_ttags_track_id.ValueMember = "ID";
            // 
            // col_ttag_tag_text
            // 
            this.col_ttag_tag_text.DataPropertyName = "tag_text";
            this.col_ttag_tag_text.DataSource = this.tagsBindingSource;
            this.col_ttag_tag_text.DisplayMember = "tag_text";
            this.col_ttag_tag_text.DisplayStyleForCurrentCellOnly = true;
            this.col_ttag_tag_text.HeaderText = "Tag Text";
            this.col_ttag_tag_text.Name = "col_ttag_tag_text";
            this.col_ttag_tag_text.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_ttag_tag_text.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_ttag_tag_text.ValueMember = "tag_text";
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn19.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn19.HeaderText = "Name";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.Width = 74;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn16.DataPropertyName = "track_artist_id";
            this.dataGridViewTextBoxColumn16.DataSource = this.artistsBindingSource;
            this.dataGridViewTextBoxColumn16.DisplayMember = "name";
            this.dataGridViewTextBoxColumn16.HeaderText = "Artist";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn16.ValueMember = "ID";
            this.dataGridViewTextBoxColumn16.Width = 69;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn20.DataPropertyName = "track_album_id";
            this.dataGridViewTextBoxColumn20.DataSource = this.albumsBindingSource;
            this.dataGridViewTextBoxColumn20.DisplayMember = "name";
            this.dataGridViewTextBoxColumn20.HeaderText = "Album";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn20.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn20.ValueMember = "ID";
            this.dataGridViewTextBoxColumn20.Width = 76;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "track_spotify_uri";
            this.dataGridViewTextBoxColumn14.HeaderText = "Spotify URI";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "track_length_minutes";
            this.dataGridViewTextBoxColumn15.HeaderText = "Length";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "can_play";
            this.dataGridViewTextBoxColumn17.FalseValue = "0";
            this.dataGridViewTextBoxColumn17.HeaderText = "Can Play";
            this.dataGridViewTextBoxColumn17.IndeterminateValue = "NULL";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn17.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn17.TrueValue = "1";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "album_id";
            this.dataGridViewTextBoxColumn5.DataSource = this.albumsBindingSource;
            this.dataGridViewTextBoxColumn5.DisplayMember = "name";
            this.dataGridViewTextBoxColumn5.HeaderText = "Album";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn5.ValueMember = "ID";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "genre";
            this.dataGridViewTextBoxColumn6.DataSource = this.genresBindingSource;
            this.dataGridViewTextBoxColumn6.DisplayMember = "genre";
            this.dataGridViewTextBoxColumn6.HeaderText = "Genre";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn6.ValueMember = "genre";
            // 
            // QueryForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 530);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveContinue);
            this.Controls.Add(this.btnSaveClose);
            this.Controls.Add(this.tabControls);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "QueryForm";
            this.Text = "QueryForm";
            this.Load += new System.EventHandler(this.QueryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.artistsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            this.tabLists.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLists)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listsBindingSource)).EndInit();
            this.TrackTags.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrackTags)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tracksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tagsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackTagsBindingSource)).EndInit();
            this.tabTags.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTags)).EndInit();
            this.tabTrackGenres.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrackGenres)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.genresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackGenresBindingSource)).EndInit();
            this.tabGenres.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGenres)).EndInit();
            this.tabTracks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTracks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.albumsBindingSource)).EndInit();
            this.tabAlbums.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlbums)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArtists)).EndInit();
            this.tabControls.ResumeLayout(false);
            this.tabAlbumGenres.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlbumGenres)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.albumGenresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKArtistTracksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackArtistsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DataSetTableAdapters.TableAdapterManager tableAdapterMngr;
        private DataSet dataSet;
        private System.Windows.Forms.BindingSource genresBindingSource;
        private DataSetTableAdapters.GenresTableAdapter genresTableAdapter;
        private System.Windows.Forms.BindingSource tracksBindingSource;
        private DataSetTableAdapters.TracksTableAdapter tracksTableAdapter;
        private System.Windows.Forms.BindingSource albumsBindingSource;
        private DataSetTableAdapters.AlbumsTableAdapter albumsTableAdapter;
        private System.Windows.Forms.BindingSource artistsBindingSource;
        private DataSetTableAdapters.ArtistsTableAdapter artistsTableAdapter;
        private System.Windows.Forms.BindingSource trackGenresBindingSource;
        private DataSetTableAdapters.TrackGenresTableAdapter trackGenresTableAdapter;
        private System.Windows.Forms.Button btnSaveClose;
        private System.Windows.Forms.Button btnSaveContinue;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.BindingSource tagsBindingSource;
        private DataSetTableAdapters.TagsTableAdapter tagsTableAdapter;
        private System.Windows.Forms.TabPage tabLists;
        private System.Windows.Forms.TabPage TrackTags;
        private System.Windows.Forms.TabPage tabTags;
        private System.Windows.Forms.DataGridView dgvTags;
        private System.Windows.Forms.TabPage tabTrackGenres;
        private System.Windows.Forms.DataGridView dgvTrackGenres;
        private System.Windows.Forms.TabPage tabGenres;
        private System.Windows.Forms.DataGridView dgvGenres;
        private System.Windows.Forms.TabPage tabTracks;
        private System.Windows.Forms.TabPage tabAlbums;
        private System.Windows.Forms.DataGridView dgvAlbums;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControls;
        private System.Windows.Forms.BindingSource trackTagsBindingSource;
        private DataSetTableAdapters.TrackTagsTableAdapter trackTagsTableAdapter;
        private System.Windows.Forms.BindingSource listsBindingSource;
        private DataSetTableAdapters.ListsTableAdapter listsTableAdapter;
        private System.Windows.Forms.DataGridView dgvLists;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewComboBoxColumn tag_text;
        private System.Windows.Forms.DataGridViewTextBoxColumn track_id;
        private System.Windows.Forms.DataGridView dgvTrackTags;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_al_title;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_genre;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tag; 
        private System.Windows.Forms.DataGridViewTextBoxColumn col_list_name;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_a_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.TabPage tabAlbumGenres;
        private System.Windows.Forms.BindingSource albumGenresBindingSource;
        private DataSetTableAdapters.AlbumGenresTableAdapter albumGenresTableAdapter;
        private System.Windows.Forms.DataGridView dgvAlbumGenres;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_track_name;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_track_album_id;
        private System.Windows.Forms.BindingSource fKAlbumsArtists1BindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_al_artist_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_al_year;
        private System.Windows.Forms.DataGridViewImageColumn col_al_cover_art;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_al_spotify_uri;
        private System.Windows.Forms.BindingSource fKArtistTracksBindingSource;
        private DataSetTableAdapters.TrackArtistsTableAdapter trackArtistsTableAdapter;
        private System.Windows.Forms.BindingSource trackArtistsBindingSource;
        private System.Windows.Forms.DataGridView dgvTracks;
        private System.Windows.Forms.DataGridView dgvArtists;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_ttags_track_id;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_ttag_tag_text;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_tg_track_id;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_tg_genre;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn6;
        // private SchoolDataSetTableAdapters.AlbumTracksTableAdapter albumTracksTableAdapter;
    }
}