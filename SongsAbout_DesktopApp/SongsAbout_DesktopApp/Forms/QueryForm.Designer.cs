namespace SongsAbout_DesktopApp
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
            this.dataSet = new SongsAbout_DesktopApp.DataSet();
            this.btnSaveClose = new System.Windows.Forms.Button();
            this.btnSaveContinue = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabLists = new System.Windows.Forms.TabPage();
            this.listsDataGridView = new System.Windows.Forms.DataGridView();
            this.col_list_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TrackTags = new System.Windows.Forms.TabPage();
            this.trackTagsDataGridView = new System.Windows.Forms.DataGridView();
            this.col_ttags_track_id = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tracksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.col_ttag_tag_text = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tagsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.trackTagsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabTags = new System.Windows.Forms.TabPage();
            this.tagsDataGridView = new System.Windows.Forms.DataGridView();
            this.col_tag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabTrackGenres = new System.Windows.Forms.TabPage();
            this.trackGenresGridView = new System.Windows.Forms.DataGridView();
            this.col_tg_track_id = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.col_tg_genre = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.genresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.trackGenresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabGenres = new System.Windows.Forms.TabPage();
            this.genresDataGridView = new System.Windows.Forms.DataGridView();
            this.col_genre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabTracks = new System.Windows.Forms.TabPage();
            this.tracksDataGridView = new System.Windows.Forms.DataGridView();
            this.col_track_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_track_album_id = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.albumsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.col_track_artist_id = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.col_can_play = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_track_spotify_uri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_list_id = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tabAlbums = new System.Windows.Forms.TabPage();
            this.albumsDataGridView = new System.Windows.Forms.DataGridView();
            this.col_al_artist_Id = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.col_al_title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_al_year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_al_cover_art = new System.Windows.Forms.DataGridViewImageColumn();
            this.col_al_spotify_uri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.artistsDataGridView = new System.Windows.Forms.DataGridView();
            this.col_a_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_a_bio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_a_website = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_a_profile_pic = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_a_spotify_uri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControls = new System.Windows.Forms.TabControl();
            this.tabAlbumGenres = new System.Windows.Forms.TabPage();
            this.albumGenresDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.albumGenresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.trackArtistAlbumDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trackArtistAlbumBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.albumsTableAdapter = new SongsAbout_DesktopApp.DataSetTableAdapters.AlbumsTableAdapter();
            this.artistsTableAdapter = new SongsAbout_DesktopApp.DataSetTableAdapters.ArtistsTableAdapter();
            this.genresTableAdapter = new SongsAbout_DesktopApp.DataSetTableAdapters.GenresTableAdapter();
            this.trackGenresTableAdapter = new SongsAbout_DesktopApp.DataSetTableAdapters.TrackGenresTableAdapter();
            this.tracksTableAdapter = new SongsAbout_DesktopApp.DataSetTableAdapters.TracksTableAdapter();
            this.tagsTableAdapter = new SongsAbout_DesktopApp.DataSetTableAdapters.TagsTableAdapter();
            this.trackTagsTableAdapter = new SongsAbout_DesktopApp.DataSetTableAdapters.TrackTagsTableAdapter();
            this.listsTableAdapter = new SongsAbout_DesktopApp.DataSetTableAdapters.ListsTableAdapter();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tag_text = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.track_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tableAdapterMngr = new SongsAbout_DesktopApp.DataSetTableAdapters.TableAdapterManager();
            this.albumGenresTableAdapter = new SongsAbout_DesktopApp.DataSetTableAdapters.AlbumGenresTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.artistsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            this.tabLists.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listsBindingSource)).BeginInit();
            this.TrackTags.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackTagsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tracksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tagsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackTagsBindingSource)).BeginInit();
            this.tabTags.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tagsDataGridView)).BeginInit();
            this.tabTrackGenres.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackGenresGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.genresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackGenresBindingSource)).BeginInit();
            this.tabGenres.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.genresDataGridView)).BeginInit();
            this.tabTracks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tracksDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.albumsBindingSource)).BeginInit();
            this.tabAlbums.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.albumsDataGridView)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.artistsDataGridView)).BeginInit();
            this.tabControls.SuspendLayout();
            this.tabAlbumGenres.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.albumGenresDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.albumGenresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackArtistAlbumDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackArtistAlbumBindingSource)).BeginInit();
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
            this.btnSaveClose.Location = new System.Drawing.Point(862, 495);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(156, 23);
            this.btnSaveClose.TabIndex = 2;
            this.btnSaveClose.Text = "Save and Close";
            this.btnSaveClose.UseVisualStyleBackColor = true;
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // btnSaveContinue
            // 
            this.btnSaveContinue.Location = new System.Drawing.Point(663, 495);
            this.btnSaveContinue.Name = "btnSaveContinue";
            this.btnSaveContinue.Size = new System.Drawing.Size(156, 23);
            this.btnSaveContinue.TabIndex = 3;
            this.btnSaveContinue.Text = "Save and Continue";
            this.btnSaveContinue.UseVisualStyleBackColor = true;
            this.btnSaveContinue.Click += new System.EventHandler(this.btnSaveContinue_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 495);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(156, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel and E&xit";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabLists
            // 
            this.tabLists.Controls.Add(this.listsDataGridView);
            this.tabLists.Location = new System.Drawing.Point(4, 25);
            this.tabLists.Name = "tabLists";
            this.tabLists.Padding = new System.Windows.Forms.Padding(3);
            this.tabLists.Size = new System.Drawing.Size(1014, 450);
            this.tabLists.TabIndex = 7;
            this.tabLists.Text = "Lists";
            this.tabLists.UseVisualStyleBackColor = true;
            // 
            // listsDataGridView
            // 
            this.listsDataGridView.AutoGenerateColumns = false;
            this.listsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_list_name});
            this.listsDataGridView.DataSource = this.listsBindingSource;
            this.listsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listsDataGridView.Location = new System.Drawing.Point(3, 3);
            this.listsDataGridView.Name = "listsDataGridView";
            this.listsDataGridView.RowTemplate.Height = 24;
            this.listsDataGridView.Size = new System.Drawing.Size(1008, 444);
            this.listsDataGridView.TabIndex = 0;
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
            this.TrackTags.Controls.Add(this.trackTagsDataGridView);
            this.TrackTags.Location = new System.Drawing.Point(4, 25);
            this.TrackTags.Name = "TrackTags";
            this.TrackTags.Padding = new System.Windows.Forms.Padding(3);
            this.TrackTags.Size = new System.Drawing.Size(1014, 450);
            this.TrackTags.TabIndex = 6;
            this.TrackTags.Text = "TrackTags";
            this.TrackTags.UseVisualStyleBackColor = true;
            // 
            // trackTagsDataGridView
            // 
            this.trackTagsDataGridView.AutoGenerateColumns = false;
            this.trackTagsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.trackTagsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_ttags_track_id,
            this.col_ttag_tag_text});
            this.trackTagsDataGridView.DataSource = this.trackTagsBindingSource;
            this.trackTagsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackTagsDataGridView.Location = new System.Drawing.Point(3, 3);
            this.trackTagsDataGridView.Name = "trackTagsDataGridView";
            this.trackTagsDataGridView.RowTemplate.Height = 24;
            this.trackTagsDataGridView.Size = new System.Drawing.Size(1008, 444);
            this.trackTagsDataGridView.TabIndex = 0;
            // 
            // col_ttags_track_id
            // 
            this.col_ttags_track_id.DataPropertyName = "track_id";
            this.col_ttags_track_id.DataSource = this.tracksBindingSource;
            this.col_ttags_track_id.DisplayMember = "track_name";
            this.col_ttags_track_id.DisplayStyleForCurrentCellOnly = true;
            this.col_ttags_track_id.HeaderText = "Track";
            this.col_ttags_track_id.Name = "col_ttags_track_id";
            this.col_ttags_track_id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_ttags_track_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_ttags_track_id.ValueMember = "track_id";
            // 
            // tracksBindingSource
            // 
            this.tracksBindingSource.DataMember = "Tracks";
            this.tracksBindingSource.DataSource = this.dataSet;
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
            this.tabTags.Controls.Add(this.tagsDataGridView);
            this.tabTags.Location = new System.Drawing.Point(4, 25);
            this.tabTags.Name = "tabTags";
            this.tabTags.Padding = new System.Windows.Forms.Padding(3);
            this.tabTags.Size = new System.Drawing.Size(1014, 450);
            this.tabTags.TabIndex = 5;
            this.tabTags.Text = "Tags";
            this.tabTags.UseVisualStyleBackColor = true;
            // 
            // tagsDataGridView
            // 
            this.tagsDataGridView.AutoGenerateColumns = false;
            this.tagsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tagsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_tag});
            this.tagsDataGridView.DataSource = this.tagsBindingSource;
            this.tagsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tagsDataGridView.Location = new System.Drawing.Point(3, 3);
            this.tagsDataGridView.Name = "tagsDataGridView";
            this.tagsDataGridView.RowTemplate.Height = 24;
            this.tagsDataGridView.Size = new System.Drawing.Size(1008, 444);
            this.tagsDataGridView.TabIndex = 0;
            // 
            // col_tag
            // 
            this.col_tag.DataPropertyName = "tag_text";
            this.col_tag.HeaderText = "tag_text";
            this.col_tag.Name = "col_tag";
            // 
            // tabTrackGenres
            // 
            this.tabTrackGenres.Controls.Add(this.trackGenresGridView);
            this.tabTrackGenres.Location = new System.Drawing.Point(4, 25);
            this.tabTrackGenres.Name = "tabTrackGenres";
            this.tabTrackGenres.Padding = new System.Windows.Forms.Padding(3);
            this.tabTrackGenres.Size = new System.Drawing.Size(1014, 450);
            this.tabTrackGenres.TabIndex = 4;
            this.tabTrackGenres.Text = "TrackGenres";
            this.tabTrackGenres.UseVisualStyleBackColor = true;
            // 
            // trackGenresGridView
            // 
            this.trackGenresGridView.AutoGenerateColumns = false;
            this.trackGenresGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.trackGenresGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_tg_track_id,
            this.col_tg_genre});
            this.trackGenresGridView.DataSource = this.trackGenresBindingSource;
            this.trackGenresGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackGenresGridView.Location = new System.Drawing.Point(3, 3);
            this.trackGenresGridView.Name = "trackGenresGridView";
            this.trackGenresGridView.RowTemplate.Height = 24;
            this.trackGenresGridView.Size = new System.Drawing.Size(1008, 444);
            this.trackGenresGridView.TabIndex = 2;
            // 
            // col_tg_track_id
            // 
            this.col_tg_track_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_tg_track_id.DataPropertyName = "track_id";
            this.col_tg_track_id.DataSource = this.tracksBindingSource;
            this.col_tg_track_id.DisplayMember = "track_name";
            this.col_tg_track_id.DisplayStyleForCurrentCellOnly = true;
            this.col_tg_track_id.HeaderText = "Track";
            this.col_tg_track_id.Name = "col_tg_track_id";
            this.col_tg_track_id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_tg_track_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_tg_track_id.ValueMember = "track_id";
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
            this.tabGenres.Controls.Add(this.genresDataGridView);
            this.tabGenres.Location = new System.Drawing.Point(4, 25);
            this.tabGenres.Name = "tabGenres";
            this.tabGenres.Padding = new System.Windows.Forms.Padding(3);
            this.tabGenres.Size = new System.Drawing.Size(1014, 450);
            this.tabGenres.TabIndex = 3;
            this.tabGenres.Text = "Genres";
            this.tabGenres.UseVisualStyleBackColor = true;
            // 
            // genresDataGridView
            // 
            this.genresDataGridView.AutoGenerateColumns = false;
            this.genresDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.genresDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_genre});
            this.genresDataGridView.DataSource = this.genresBindingSource;
            this.genresDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.genresDataGridView.Location = new System.Drawing.Point(3, 3);
            this.genresDataGridView.Name = "genresDataGridView";
            this.genresDataGridView.RowTemplate.Height = 24;
            this.genresDataGridView.Size = new System.Drawing.Size(1008, 444);
            this.genresDataGridView.TabIndex = 1;
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
            this.tabTracks.Controls.Add(this.tracksDataGridView);
            this.tabTracks.Location = new System.Drawing.Point(4, 25);
            this.tabTracks.Name = "tabTracks";
            this.tabTracks.Padding = new System.Windows.Forms.Padding(3);
            this.tabTracks.Size = new System.Drawing.Size(1014, 450);
            this.tabTracks.TabIndex = 2;
            this.tabTracks.Text = "Tracks";
            this.tabTracks.UseVisualStyleBackColor = true;
            // 
            // tracksDataGridView
            // 
            this.tracksDataGridView.AutoGenerateColumns = false;
            this.tracksDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tracksDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_track_name,
            this.col_length,
            this.col_track_album_id,
            this.col_track_artist_id,
            this.col_can_play,
            this.col_track_spotify_uri,
            this.col_list_id});
            this.tracksDataGridView.DataSource = this.tracksBindingSource;
            this.tracksDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tracksDataGridView.Location = new System.Drawing.Point(3, 3);
            this.tracksDataGridView.Name = "tracksDataGridView";
            this.tracksDataGridView.RowTemplate.Height = 24;
            this.tracksDataGridView.Size = new System.Drawing.Size(1008, 444);
            this.tracksDataGridView.TabIndex = 2;
            // 
            // col_track_name
            // 
            this.col_track_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_track_name.DataPropertyName = "track_name";
            this.col_track_name.HeaderText = "Track Name";
            this.col_track_name.Name = "col_track_name";
            this.col_track_name.Width = 105;
            // 
            // col_length
            // 
            this.col_length.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_length.DataPropertyName = "track_length_minutes";
            this.col_length.HeaderText = "Length (minutes)";
            this.col_length.Name = "col_length";
            this.col_length.Width = 132;
            // 
            // col_track_album_id
            // 
            this.col_track_album_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.col_track_album_id.DataPropertyName = "album_id";
            this.col_track_album_id.DataSource = this.albumsBindingSource;
            this.col_track_album_id.DisplayMember = "al_title";
            this.col_track_album_id.DisplayStyleForCurrentCellOnly = true;
            this.col_track_album_id.HeaderText = "Album";
            this.col_track_album_id.MaxDropDownItems = 20;
            this.col_track_album_id.Name = "col_track_album_id";
            this.col_track_album_id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_track_album_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_track_album_id.ValueMember = "album_id";
            this.col_track_album_id.Width = 76;
            // 
            // albumsBindingSource
            // 
            this.albumsBindingSource.DataMember = "Albums";
            this.albumsBindingSource.DataSource = this.dataSet;
            // 
            // col_track_artist_id
            // 
            this.col_track_artist_id.DataPropertyName = "track_artist_id";
            this.col_track_artist_id.DataSource = this.artistsBindingSource;
            this.col_track_artist_id.DisplayMember = "a_name";
            this.col_track_artist_id.DisplayStyleForCurrentCellOnly = true;
            this.col_track_artist_id.HeaderText = "Artist";
            this.col_track_artist_id.Name = "col_track_artist_id";
            this.col_track_artist_id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_track_artist_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_track_artist_id.ValueMember = "artist_id";
            // 
            // col_can_play
            // 
            this.col_can_play.DataPropertyName = "can_play";
            this.col_can_play.FalseValue = "n";
            this.col_can_play.HeaderText = "Can Play?";
            this.col_can_play.IndeterminateValue = "n";
            this.col_can_play.Name = "col_can_play";
            this.col_can_play.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_can_play.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_can_play.TrueValue = "y";
            // 
            // col_track_spotify_uri
            // 
            this.col_track_spotify_uri.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_track_spotify_uri.DataPropertyName = "track_spotify_uri";
            this.col_track_spotify_uri.HeaderText = "Spotify URI";
            this.col_track_spotify_uri.Name = "col_track_spotify_uri";
            this.col_track_spotify_uri.Width = 99;
            // 
            // col_list_id
            // 
            this.col_list_id.DataPropertyName = "list_id";
            this.col_list_id.DataSource = this.listsBindingSource;
            this.col_list_id.DisplayMember = "list_name";
            this.col_list_id.DisplayStyleForCurrentCellOnly = true;
            this.col_list_id.HeaderText = "List";
            this.col_list_id.Name = "col_list_id";
            this.col_list_id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_list_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_list_id.ValueMember = "list_id";
            // 
            // tabAlbums
            // 
            this.tabAlbums.Controls.Add(this.albumsDataGridView);
            this.tabAlbums.Location = new System.Drawing.Point(4, 25);
            this.tabAlbums.Name = "tabAlbums";
            this.tabAlbums.Padding = new System.Windows.Forms.Padding(3);
            this.tabAlbums.Size = new System.Drawing.Size(1014, 450);
            this.tabAlbums.TabIndex = 1;
            this.tabAlbums.Text = "Albums";
            this.tabAlbums.UseVisualStyleBackColor = true;
            // 
            // albumsDataGridView
            // 
            this.albumsDataGridView.AllowUserToOrderColumns = true;
            this.albumsDataGridView.AutoGenerateColumns = false;
            this.albumsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.albumsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_al_artist_Id,
            this.col_al_title,
            this.col_al_year,
            this.col_al_cover_art,
            this.col_al_spotify_uri});
            this.albumsDataGridView.DataSource = this.albumsBindingSource;
            this.albumsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.albumsDataGridView.Location = new System.Drawing.Point(3, 3);
            this.albumsDataGridView.Name = "albumsDataGridView";
            this.albumsDataGridView.RowTemplate.Height = 24;
            this.albumsDataGridView.Size = new System.Drawing.Size(1008, 444);
            this.albumsDataGridView.TabIndex = 1;
            // 
            // col_al_artist_Id
            // 
            this.col_al_artist_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_al_artist_Id.DataPropertyName = "artist_id";
            this.col_al_artist_Id.DataSource = this.artistsBindingSource;
            this.col_al_artist_Id.DisplayMember = "a_name";
            this.col_al_artist_Id.DisplayStyleForCurrentCellOnly = true;
            this.col_al_artist_Id.HeaderText = "Artist";
            this.col_al_artist_Id.Name = "col_al_artist_Id";
            this.col_al_artist_Id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_al_artist_Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_al_artist_Id.ValueMember = "artist_id";
            this.col_al_artist_Id.Width = 69;
            // 
            // col_al_title
            // 
            this.col_al_title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_al_title.DataPropertyName = "al_title";
            this.col_al_title.HeaderText = "Title";
            this.col_al_title.Name = "col_al_title";
            this.col_al_title.Width = 64;
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
            this.tabPage1.Controls.Add(this.artistsDataGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1014, 450);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Artists";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // artistsDataGridView
            // 
            this.artistsDataGridView.AllowDrop = true;
            this.artistsDataGridView.AutoGenerateColumns = false;
            this.artistsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.artistsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_a_name,
            this.col_a_bio,
            this.col_a_website,
            this.col_a_profile_pic,
            this.col_a_spotify_uri});
            this.artistsDataGridView.DataSource = this.artistsBindingSource;
            this.artistsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.artistsDataGridView.Location = new System.Drawing.Point(3, 3);
            this.artistsDataGridView.Name = "artistsDataGridView";
            this.artistsDataGridView.RowTemplate.Height = 24;
            this.artistsDataGridView.Size = new System.Drawing.Size(1008, 444);
            this.artistsDataGridView.TabIndex = 2;
            this.artistsDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.artistsDataGridView_CellContentClick);
            this.artistsDataGridView.DragDrop += new System.Windows.Forms.DragEventHandler(this.Artist_Drop);
            // 
            // col_a_name
            // 
            this.col_a_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.col_a_name.DataPropertyName = "a_name";
            this.col_a_name.HeaderText = "Name";
            this.col_a_name.Name = "col_a_name";
            this.col_a_name.Width = 74;
            // 
            // col_a_bio
            // 
            this.col_a_bio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_a_bio.DataPropertyName = "a_bio";
            this.col_a_bio.HeaderText = "Bio";
            this.col_a_bio.MinimumWidth = 60;
            this.col_a_bio.Name = "col_a_bio";
            this.col_a_bio.Width = 60;
            // 
            // col_a_website
            // 
            this.col_a_website.DataPropertyName = "a_website";
            this.col_a_website.HeaderText = "Website";
            this.col_a_website.Name = "col_a_website";
            // 
            // col_a_profile_pic
            // 
            this.col_a_profile_pic.DataPropertyName = "a_profile_pic";
            this.col_a_profile_pic.HeaderText = "Profile Pic";
            this.col_a_profile_pic.Name = "col_a_profile_pic";
            this.col_a_profile_pic.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_a_profile_pic.Text = "Add";
            // 
            // col_a_spotify_uri
            // 
            this.col_a_spotify_uri.DataPropertyName = "a_spotify_uri";
            this.col_a_spotify_uri.HeaderText = "Spotify URI";
            this.col_a_spotify_uri.Name = "col_a_spotify_uri";
            // 
            // tabControls
            // 
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
            this.tabControls.Name = "tabControls";
            this.tabControls.SelectedIndex = 0;
            this.tabControls.Size = new System.Drawing.Size(1022, 479);
            this.tabControls.TabIndex = 1;
            // 
            // tabAlbumGenres
            // 
            this.tabAlbumGenres.Controls.Add(this.albumGenresDataGridView);
            this.tabAlbumGenres.Location = new System.Drawing.Point(4, 25);
            this.tabAlbumGenres.Name = "tabAlbumGenres";
            this.tabAlbumGenres.Padding = new System.Windows.Forms.Padding(3);
            this.tabAlbumGenres.Size = new System.Drawing.Size(1014, 450);
            this.tabAlbumGenres.TabIndex = 9;
            this.tabAlbumGenres.Text = "Album Genres";
            this.tabAlbumGenres.UseVisualStyleBackColor = true;
            // 
            // albumGenresDataGridView
            // 
            this.albumGenresDataGridView.AutoGenerateColumns = false;
            this.albumGenresDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.albumGenresDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.albumGenresDataGridView.DataSource = this.albumGenresBindingSource;
            this.albumGenresDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.albumGenresDataGridView.Location = new System.Drawing.Point(3, 3);
            this.albumGenresDataGridView.Name = "albumGenresDataGridView";
            this.albumGenresDataGridView.RowTemplate.Height = 24;
            this.albumGenresDataGridView.Size = new System.Drawing.Size(1008, 444);
            this.albumGenresDataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "al_g_id";
            this.dataGridViewTextBoxColumn4.HeaderText = "al_g_id";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "album_id";
            this.dataGridViewTextBoxColumn5.HeaderText = "album_id";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "genre";
            this.dataGridViewTextBoxColumn6.HeaderText = "genre";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // albumGenresBindingSource
            // 
            this.albumGenresBindingSource.DataMember = "AlbumGenres";
            this.albumGenresBindingSource.DataSource = this.dataSet;
            // 
            // trackArtistAlbumDataGridView
            // 
            this.trackArtistAlbumDataGridView.Location = new System.Drawing.Point(0, 0);
            this.trackArtistAlbumDataGridView.Name = "trackArtistAlbumDataGridView";
            this.trackArtistAlbumDataGridView.Size = new System.Drawing.Size(240, 150);
            this.trackArtistAlbumDataGridView.TabIndex = 0;
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
            // trackArtistAlbumBindingSource
            // 
            this.trackArtistAlbumBindingSource.DataMember = "TrackArtistAlbum";
            this.trackArtistAlbumBindingSource.DataSource = this.dataSet;
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
            this.tableAdapterMngr.AlbumGenresTableAdapter = null;
            this.tableAdapterMngr.AlbumsTableAdapter = this.albumsTableAdapter;
            this.tableAdapterMngr.ArtistsTableAdapter = this.artistsTableAdapter;
            this.tableAdapterMngr.BackupDataSetBeforeUpdate = false;
            this.tableAdapterMngr.GenresTableAdapter = this.genresTableAdapter;
            this.tableAdapterMngr.ListsTableAdapter = this.listsTableAdapter;
            this.tableAdapterMngr.TagsTableAdapter = this.tagsTableAdapter;
            this.tableAdapterMngr.TrackGenresTableAdapter = this.trackGenresTableAdapter;
            this.tableAdapterMngr.TracksTableAdapter = this.tracksTableAdapter;
            this.tableAdapterMngr.TrackTagsTableAdapter = this.trackTagsTableAdapter;
            this.tableAdapterMngr.UpdateOrder = SongsAbout_DesktopApp.DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // albumGenresTableAdapter
            // 
            this.albumGenresTableAdapter.ClearBeforeFill = true;
            // 
            // QueryForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 530);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveContinue);
            this.Controls.Add(this.btnSaveClose);
            this.Controls.Add(this.tabControls);
            this.Name = "QueryForm";
            this.Text = "QueryForm";
            this.Load += new System.EventHandler(this.QueryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.artistsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            this.tabLists.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listsBindingSource)).EndInit();
            this.TrackTags.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackTagsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tracksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tagsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackTagsBindingSource)).EndInit();
            this.tabTags.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tagsDataGridView)).EndInit();
            this.tabTrackGenres.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackGenresGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.genresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackGenresBindingSource)).EndInit();
            this.tabGenres.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.genresDataGridView)).EndInit();
            this.tabTracks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tracksDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.albumsBindingSource)).EndInit();
            this.tabAlbums.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.albumsDataGridView)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.artistsDataGridView)).EndInit();
            this.tabControls.ResumeLayout(false);
            this.tabAlbumGenres.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.albumGenresDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.albumGenresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackArtistAlbumDataGridView)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.trackArtistAlbumBindingSource)).EndInit();
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
        private System.Windows.Forms.DataGridView tagsDataGridView;
        private System.Windows.Forms.TabPage tabTrackGenres;
        private System.Windows.Forms.DataGridView trackGenresGridView;
        private System.Windows.Forms.TabPage tabGenres;
        private System.Windows.Forms.DataGridView genresDataGridView;
        private System.Windows.Forms.TabPage tabTracks;
        private System.Windows.Forms.DataGridView tracksDataGridView;
        private System.Windows.Forms.TabPage tabAlbums;
        private System.Windows.Forms.DataGridView albumsDataGridView;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView artistsDataGridView;
        private System.Windows.Forms.TabControl tabControls;
        private System.Windows.Forms.BindingSource trackTagsBindingSource;
        private DataSetTableAdapters.TrackTagsTableAdapter trackTagsTableAdapter;
        private System.Windows.Forms.BindingSource listsBindingSource;
        private DataSetTableAdapters.ListsTableAdapter listsTableAdapter;
        private System.Windows.Forms.DataGridView listsDataGridView;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewComboBoxColumn tag_text;
        private System.Windows.Forms.DataGridViewTextBoxColumn track_id;
        private System.Windows.Forms.DataGridView trackTagsDataGridView;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_al_artist_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_al_title;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_al_year;
        private System.Windows.Forms.DataGridViewImageColumn col_al_cover_art;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_al_spotify_uri;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_tg_track_id;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_tg_genre;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_genre;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_ttags_track_id;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_ttag_tag_text;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tag;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_list_name;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_a_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_a_bio;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_a_website;
        private System.Windows.Forms.DataGridViewButtonColumn col_a_profile_pic;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_a_spotify_uri;
        private System.Windows.Forms.BindingSource trackArtistAlbumBindingSource;
        private System.Windows.Forms.DataGridView trackArtistAlbumDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.TabPage tabAlbumGenres;
        private System.Windows.Forms.BindingSource albumGenresBindingSource;
        private DataSetTableAdapters.AlbumGenresTableAdapter albumGenresTableAdapter;
        private System.Windows.Forms.DataGridView albumGenresDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_track_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_length;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_track_album_id;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_track_artist_id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_can_play;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_track_spotify_uri;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_list_id;
    }
}