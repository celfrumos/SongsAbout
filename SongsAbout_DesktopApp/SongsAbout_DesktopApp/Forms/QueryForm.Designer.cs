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
            this.fKAlbumsArtistsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSaveClose = new System.Windows.Forms.Button();
            this.btnSaveContinue = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.artistsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet = new SongsAbout_DesktopApp.DataSet();
            this.albumsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tracksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.genresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.trackGenresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableAdapterMngr = new SongsAbout_DesktopApp.DataSetTableAdapters.TableAdapterManager();
            this.albumsTableAdapter = new SongsAbout_DesktopApp.DataSetTableAdapters.AlbumsTableAdapter();
            this.artistsTableAdapter = new SongsAbout_DesktopApp.DataSetTableAdapters.ArtistsTableAdapter();
            this.genresTableAdapter = new SongsAbout_DesktopApp.DataSetTableAdapters.GenresTableAdapter();
            this.trackGenresTableAdapter = new SongsAbout_DesktopApp.DataSetTableAdapters.TrackGenresTableAdapter();
            this.tracksTableAdapter = new SongsAbout_DesktopApp.DataSetTableAdapters.TracksTableAdapter();
            this.tagsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tagsTableAdapter = new SongsAbout_DesktopApp.DataSetTableAdapters.TagsTableAdapter();
            this.tabLists = new System.Windows.Forms.TabPage();
            this.TrackTags = new System.Windows.Forms.TabPage();
            this.tabTags = new System.Windows.Forms.TabPage();
            this.tagsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabTrackGenres = new System.Windows.Forms.TabPage();
            this.trackGenresGridView = new System.Windows.Forms.DataGridView();
            this.genreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.trackidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tabGenres = new System.Windows.Forms.TabPage();
            this.genresDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabTracks = new System.Windows.Forms.TabPage();
            this.tracksDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tabAlbums = new System.Windows.Forms.TabPage();
            this.albumsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.artistsDataGridView = new System.Windows.Forms.DataGridView();
            this.aspotifyuriDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.awebsiteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.artistidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControls = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.fKAlbumsArtistsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.artistsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.albumsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tracksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.genresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackGenresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tagsBindingSource)).BeginInit();
            this.tabTags.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tagsDataGridView)).BeginInit();
            this.tabTrackGenres.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackGenresGridView)).BeginInit();
            this.tabGenres.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.genresDataGridView)).BeginInit();
            this.tabTracks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tracksDataGridView)).BeginInit();
            this.tabAlbums.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.albumsDataGridView)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.artistsDataGridView)).BeginInit();
            this.tabControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // fKAlbumsArtistsBindingSource
            // 
            this.fKAlbumsArtistsBindingSource.DataMember = "FK_Albums_Artists";
            this.fKAlbumsArtistsBindingSource.DataSource = this.artistsBindingSource;
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
            // albumsBindingSource
            // 
            this.albumsBindingSource.DataMember = "Albums";
            this.albumsBindingSource.DataSource = this.dataSet;
            // 
            // tracksBindingSource
            // 
            this.tracksBindingSource.DataMember = "Tracks";
            this.tracksBindingSource.DataSource = this.dataSet;
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
            // tableAdapterMngr
            // 
            this.tableAdapterMngr.AlbumsTableAdapter = this.albumsTableAdapter;
            this.tableAdapterMngr.ArtistsTableAdapter = this.artistsTableAdapter;
            this.tableAdapterMngr.BackupDataSetBeforeUpdate = false;
            this.tableAdapterMngr.GenresTableAdapter = this.genresTableAdapter;
            this.tableAdapterMngr.ListsTableAdapter = null;
            this.tableAdapterMngr.TagsTableAdapter = null;
            this.tableAdapterMngr.TrackGenresTableAdapter = this.trackGenresTableAdapter;
            this.tableAdapterMngr.TracksTableAdapter = this.tracksTableAdapter;
            this.tableAdapterMngr.TrackTagsTableAdapter = null;
            this.tableAdapterMngr.UpdateOrder = SongsAbout_DesktopApp.DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
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
            // tagsBindingSource
            // 
            this.tagsBindingSource.DataMember = "Tags";
            this.tagsBindingSource.DataSource = this.dataSet;
            // 
            // tagsTableAdapter
            // 
            this.tagsTableAdapter.ClearBeforeFill = true;
            // 
            // tabLists
            // 
            this.tabLists.Location = new System.Drawing.Point(4, 25);
            this.tabLists.Name = "tabLists";
            this.tabLists.Padding = new System.Windows.Forms.Padding(3);
            this.tabLists.Size = new System.Drawing.Size(1014, 450);
            this.tabLists.TabIndex = 7;
            this.tabLists.Text = "Lists";
            this.tabLists.UseVisualStyleBackColor = true;
            // 
            // TrackTags
            // 
            this.TrackTags.Location = new System.Drawing.Point(4, 25);
            this.TrackTags.Name = "TrackTags";
            this.TrackTags.Padding = new System.Windows.Forms.Padding(3);
            this.TrackTags.Size = new System.Drawing.Size(1014, 450);
            this.TrackTags.TabIndex = 6;
            this.TrackTags.Text = "TrackTags";
            this.TrackTags.UseVisualStyleBackColor = true;
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
            this.dataGridViewTextBoxColumn2});
            this.tagsDataGridView.DataSource = this.tagsBindingSource;
            this.tagsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tagsDataGridView.Location = new System.Drawing.Point(3, 3);
            this.tagsDataGridView.Name = "tagsDataGridView";
            this.tagsDataGridView.RowTemplate.Height = 24;
            this.tagsDataGridView.Size = new System.Drawing.Size(1008, 444);
            this.tagsDataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "tag_text";
            this.dataGridViewTextBoxColumn2.HeaderText = "tag_text";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
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
            this.trackidDataGridViewTextBoxColumn,
            this.genreDataGridViewTextBoxColumn});
            this.trackGenresGridView.DataSource = this.trackGenresBindingSource;
            this.trackGenresGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackGenresGridView.Location = new System.Drawing.Point(3, 3);
            this.trackGenresGridView.Name = "trackGenresGridView";
            this.trackGenresGridView.RowTemplate.Height = 24;
            this.trackGenresGridView.Size = new System.Drawing.Size(1008, 444);
            this.trackGenresGridView.TabIndex = 2;
            // 
            // genreDataGridViewTextBoxColumn
            // 
            this.genreDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.genreDataGridViewTextBoxColumn.DataPropertyName = "genre";
            this.genreDataGridViewTextBoxColumn.DataSource = this.genresBindingSource;
            this.genreDataGridViewTextBoxColumn.DisplayMember = "genre";
            this.genreDataGridViewTextBoxColumn.HeaderText = "Genre";
            this.genreDataGridViewTextBoxColumn.Name = "genreDataGridViewTextBoxColumn";
            this.genreDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.genreDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.genreDataGridViewTextBoxColumn.ValueMember = "genre";
            this.genreDataGridViewTextBoxColumn.Width = 77;
            // 
            // trackidDataGridViewTextBoxColumn
            // 
            this.trackidDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.trackidDataGridViewTextBoxColumn.DataPropertyName = "track_id";
            this.trackidDataGridViewTextBoxColumn.DataSource = this.tracksBindingSource;
            this.trackidDataGridViewTextBoxColumn.DisplayMember = "track_name";
            this.trackidDataGridViewTextBoxColumn.HeaderText = "Track";
            this.trackidDataGridViewTextBoxColumn.Name = "trackidDataGridViewTextBoxColumn";
            this.trackidDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.trackidDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.trackidDataGridViewTextBoxColumn.ValueMember = "track_id";
            this.trackidDataGridViewTextBoxColumn.Width = 73;
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
            this.dataGridViewTextBoxColumn1});
            this.genresDataGridView.DataSource = this.genresBindingSource;
            this.genresDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.genresDataGridView.Location = new System.Drawing.Point(3, 3);
            this.genresDataGridView.Name = "genresDataGridView";
            this.genresDataGridView.RowTemplate.Height = 24;
            this.genresDataGridView.Size = new System.Drawing.Size(1008, 444);
            this.genresDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "genre";
            this.dataGridViewTextBoxColumn1.HeaderText = "Genre";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 77;
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
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.tracksDataGridView.DataSource = this.tracksBindingSource;
            this.tracksDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tracksDataGridView.Location = new System.Drawing.Point(3, 3);
            this.tracksDataGridView.Name = "tracksDataGridView";
            this.tracksDataGridView.RowTemplate.Height = 24;
            this.tracksDataGridView.Size = new System.Drawing.Size(1008, 444);
            this.tracksDataGridView.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "track_length_minutes";
            this.dataGridViewTextBoxColumn6.HeaderText = "Length (minutes)";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 132;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "track_spotify_uri";
            this.dataGridViewTextBoxColumn5.HeaderText = "Spotify URI";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 99;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "track_name";
            this.dataGridViewTextBoxColumn4.HeaderText = "Track Name";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 105;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "album_id";
            this.dataGridViewTextBoxColumn3.DataSource = this.albumsBindingSource;
            this.dataGridViewTextBoxColumn3.DisplayMember = "al_title";
            this.dataGridViewTextBoxColumn3.HeaderText = "Album";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn3.ValueMember = "album_id";
            this.dataGridViewTextBoxColumn3.Width = 76;
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
            this.albumsDataGridView.AutoGenerateColumns = false;
            this.albumsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.albumsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11});
            this.albumsDataGridView.DataSource = this.albumsBindingSource;
            this.albumsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.albumsDataGridView.Location = new System.Drawing.Point(3, 3);
            this.albumsDataGridView.Name = "albumsDataGridView";
            this.albumsDataGridView.RowTemplate.Height = 24;
            this.albumsDataGridView.Size = new System.Drawing.Size(1008, 444);
            this.albumsDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn11.DataPropertyName = "al_spotify_uri";
            this.dataGridViewTextBoxColumn11.HeaderText = "Spotify URI";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 107;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn10.DataPropertyName = "al_year";
            this.dataGridViewTextBoxColumn10.HeaderText = "Year";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 67;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "al_title";
            this.dataGridViewTextBoxColumn9.HeaderText = "Title";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 64;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "artist_id";
            this.dataGridViewTextBoxColumn8.DataSource = this.artistsBindingSource;
            this.dataGridViewTextBoxColumn8.DisplayMember = "a_name";
            this.dataGridViewTextBoxColumn8.HeaderText = "Artist";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn8.ValueMember = "artist_id";
            this.dataGridViewTextBoxColumn8.Width = 69;
            // 
            // tabPage1
            // 
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
            this.artistsDataGridView.AutoGenerateColumns = false;
            this.artistsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.artistsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.artistidDataGridViewTextBoxColumn,
            this.anameDataGridViewTextBoxColumn,
            this.abioDataGridViewTextBoxColumn,
            this.awebsiteDataGridViewTextBoxColumn,
            this.aspotifyuriDataGridViewTextBoxColumn});
            this.artistsDataGridView.DataSource = this.artistsBindingSource;
            this.artistsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.artistsDataGridView.Location = new System.Drawing.Point(3, 3);
            this.artistsDataGridView.Name = "artistsDataGridView";
            this.artistsDataGridView.RowTemplate.Height = 24;
            this.artistsDataGridView.Size = new System.Drawing.Size(1008, 444);
            this.artistsDataGridView.TabIndex = 2;
            this.artistsDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.artistsDataGridView_CellContentClick);
            // 
            // aspotifyuriDataGridViewTextBoxColumn
            // 
            this.aspotifyuriDataGridViewTextBoxColumn.DataPropertyName = "a_spotify_uri";
            this.aspotifyuriDataGridViewTextBoxColumn.HeaderText = "Spotify URI";
            this.aspotifyuriDataGridViewTextBoxColumn.Name = "aspotifyuriDataGridViewTextBoxColumn";
            // 
            // awebsiteDataGridViewTextBoxColumn
            // 
            this.awebsiteDataGridViewTextBoxColumn.DataPropertyName = "a_website";
            this.awebsiteDataGridViewTextBoxColumn.HeaderText = "Website";
            this.awebsiteDataGridViewTextBoxColumn.Name = "awebsiteDataGridViewTextBoxColumn";
            // 
            // abioDataGridViewTextBoxColumn
            // 
            this.abioDataGridViewTextBoxColumn.DataPropertyName = "a_bio";
            this.abioDataGridViewTextBoxColumn.HeaderText = "Bio";
            this.abioDataGridViewTextBoxColumn.Name = "abioDataGridViewTextBoxColumn";
            // 
            // anameDataGridViewTextBoxColumn
            // 
            this.anameDataGridViewTextBoxColumn.DataPropertyName = "a_name";
            this.anameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.anameDataGridViewTextBoxColumn.Name = "anameDataGridViewTextBoxColumn";
            // 
            // artistidDataGridViewTextBoxColumn
            // 
            this.artistidDataGridViewTextBoxColumn.DataPropertyName = "artist_id";
            this.artistidDataGridViewTextBoxColumn.HeaderText = "artist_id";
            this.artistidDataGridViewTextBoxColumn.Name = "artistidDataGridViewTextBoxColumn";
            this.artistidDataGridViewTextBoxColumn.ReadOnly = true;
            this.artistidDataGridViewTextBoxColumn.Visible = false;
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
            this.tabControls.Location = new System.Drawing.Point(0, 12);
            this.tabControls.Name = "tabControls";
            this.tabControls.SelectedIndex = 0;
            this.tabControls.Size = new System.Drawing.Size(1022, 479);
            this.tabControls.TabIndex = 1;
            // 
            // QueryForm
            // 
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
            ((System.ComponentModel.ISupportInitialize)(this.fKAlbumsArtistsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.artistsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.albumsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tracksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.genresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackGenresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tagsBindingSource)).EndInit();
            this.tabTags.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tagsDataGridView)).EndInit();
            this.tabTrackGenres.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackGenresGridView)).EndInit();
            this.tabGenres.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.genresDataGridView)).EndInit();
            this.tabTracks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tracksDataGridView)).EndInit();
            this.tabAlbums.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.albumsDataGridView)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.artistsDataGridView)).EndInit();
            this.tabControls.ResumeLayout(false);
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
        private System.Windows.Forms.BindingSource fKAlbumsArtistsBindingSource;
        private System.Windows.Forms.Button btnSaveClose;
        private System.Windows.Forms.Button btnSaveContinue;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.BindingSource tagsBindingSource;
        private DataSetTableAdapters.TagsTableAdapter tagsTableAdapter;
        private System.Windows.Forms.TabPage tabLists;
        private System.Windows.Forms.TabPage TrackTags;
        private System.Windows.Forms.TabPage tabTags;
        private System.Windows.Forms.DataGridView tagsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.TabPage tabTrackGenres;
        private System.Windows.Forms.DataGridView trackGenresGridView;
        private System.Windows.Forms.DataGridViewComboBoxColumn trackidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn genreDataGridViewTextBoxColumn;
        private System.Windows.Forms.TabPage tabGenres;
        private System.Windows.Forms.DataGridView genresDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.TabPage tabTracks;
        private System.Windows.Forms.DataGridView tracksDataGridView;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.TabPage tabAlbums;
        private System.Windows.Forms.DataGridView albumsDataGridView;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView artistsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn artistidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn anameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn abioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn awebsiteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aspotifyuriDataGridViewTextBoxColumn;
        private System.Windows.Forms.TabControl tabControls;
    }
}