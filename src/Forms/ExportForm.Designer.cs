﻿namespace KiCadPanelAssyFG
{
    partial class ExportForm
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportForm));
            MainSplitContainer = new SplitContainer();
            DataPanel = new Panel();
            DataSplitcontainer = new SplitContainer();
            tableSplitcontainer = new SplitContainer();
            BOMTable = new DataGridView();
            BomValueCol = new DataGridViewTextBoxColumn();
            BomDesignatorsCol = new DataGridViewTextBoxColumn();
            BomFootprintCol = new DataGridViewTextBoxColumn();
            BomPartnoCol = new DataGridViewTextBoxColumn();
            PlacementsTable = new DataGridView();
            PlacementRefCol = new DataGridViewTextBoxColumn();
            PlacementValueCol = new DataGridViewTextBoxColumn();
            PlacementFootprintCol = new DataGridViewTextBoxColumn();
            PlacementPosXCol = new DataGridViewTextBoxColumn();
            PlacementPosYCol = new DataGridViewTextBoxColumn();
            PlacementRotCol = new DataGridViewTextBoxColumn();
            PlacementSideCol = new DataGridViewComboBoxColumn();
            PlacementPreviewPanel = new Panel();
            lProjectName = new Label();
            ProjectNamePanel = new Panel();
            ProjectNameTextbox = new TextBox();
            propertiesPanel = new Panel();
            selectionColorTextbox = new TextBox();
            lSelectionColor = new Label();
            bReloadFootprints = new Button();
            fpDirsTextbox = new TextBox();
            lFootprintDirs = new Label();
            lExportProperties = new Label();
            separateFilesCheckbox = new CheckBox();
            lFillOpacity = new Label();
            bgOpacityTrackbar = new TrackBar();
            bottomOutlineColorTextbox = new TextBox();
            lBottomColor = new Label();
            bottomVisibleCheckbox = new CheckBox();
            lBottomComponents = new Label();
            topOutlineColorTextbox = new TextBox();
            lTopColor = new Label();
            topVisibleCheckbox = new CheckBox();
            lTopComponents = new Label();
            lGeneralProperties = new Label();
            bExport = new Button();
            PreviewBlinkTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)MainSplitContainer).BeginInit();
            MainSplitContainer.Panel1.SuspendLayout();
            MainSplitContainer.Panel2.SuspendLayout();
            MainSplitContainer.SuspendLayout();
            DataPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataSplitcontainer).BeginInit();
            DataSplitcontainer.Panel1.SuspendLayout();
            DataSplitcontainer.Panel2.SuspendLayout();
            DataSplitcontainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tableSplitcontainer).BeginInit();
            tableSplitcontainer.Panel1.SuspendLayout();
            tableSplitcontainer.Panel2.SuspendLayout();
            tableSplitcontainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)BOMTable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PlacementsTable).BeginInit();
            ProjectNamePanel.SuspendLayout();
            propertiesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bgOpacityTrackbar).BeginInit();
            SuspendLayout();
            // 
            // MainSplitContainer
            // 
            MainSplitContainer.Dock = DockStyle.Fill;
            MainSplitContainer.Location = new Point(0, 0);
            MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            MainSplitContainer.Panel1.Controls.Add(DataPanel);
            MainSplitContainer.Panel1MinSize = 200;
            // 
            // MainSplitContainer.Panel2
            // 
            MainSplitContainer.Panel2.Controls.Add(lProjectName);
            MainSplitContainer.Panel2.Controls.Add(ProjectNamePanel);
            MainSplitContainer.Panel2.Controls.Add(propertiesPanel);
            MainSplitContainer.Panel2.Controls.Add(bExport);
            MainSplitContainer.Panel2MinSize = 200;
            MainSplitContainer.Size = new Size(1100, 661);
            MainSplitContainer.SplitterDistance = 812;
            MainSplitContainer.TabIndex = 0;
            // 
            // DataPanel
            // 
            DataPanel.Controls.Add(DataSplitcontainer);
            DataPanel.Dock = DockStyle.Fill;
            DataPanel.Location = new Point(0, 0);
            DataPanel.Name = "DataPanel";
            DataPanel.Size = new Size(812, 661);
            DataPanel.TabIndex = 0;
            // 
            // DataSplitcontainer
            // 
            DataSplitcontainer.Dock = DockStyle.Fill;
            DataSplitcontainer.Location = new Point(0, 0);
            DataSplitcontainer.Name = "DataSplitcontainer";
            DataSplitcontainer.Orientation = Orientation.Horizontal;
            // 
            // DataSplitcontainer.Panel1
            // 
            DataSplitcontainer.Panel1.Controls.Add(tableSplitcontainer);
            // 
            // DataSplitcontainer.Panel2
            // 
            DataSplitcontainer.Panel2.Controls.Add(PlacementPreviewPanel);
            DataSplitcontainer.Size = new Size(812, 661);
            DataSplitcontainer.SplitterDistance = 448;
            DataSplitcontainer.TabIndex = 0;
            // 
            // tableSplitcontainer
            // 
            tableSplitcontainer.Dock = DockStyle.Fill;
            tableSplitcontainer.Location = new Point(0, 0);
            tableSplitcontainer.Name = "tableSplitcontainer";
            // 
            // tableSplitcontainer.Panel1
            // 
            tableSplitcontainer.Panel1.Controls.Add(BOMTable);
            // 
            // tableSplitcontainer.Panel2
            // 
            tableSplitcontainer.Panel2.Controls.Add(PlacementsTable);
            tableSplitcontainer.Size = new Size(812, 448);
            tableSplitcontainer.SplitterDistance = 406;
            tableSplitcontainer.TabIndex = 0;
            // 
            // BOMTable
            // 
            BOMTable.AllowUserToAddRows = false;
            BOMTable.AllowUserToDeleteRows = false;
            BOMTable.AllowUserToOrderColumns = true;
            BOMTable.BackgroundColor = Color.FromArgb(31, 31, 31);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(31, 31, 31);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            BOMTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            BOMTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            BOMTable.Columns.AddRange(new DataGridViewColumn[] { BomValueCol, BomDesignatorsCol, BomFootprintCol, BomPartnoCol });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(31, 31, 31);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            BOMTable.DefaultCellStyle = dataGridViewCellStyle2;
            BOMTable.Dock = DockStyle.Fill;
            BOMTable.GridColor = Color.FromArgb(66, 66, 66);
            BOMTable.Location = new Point(0, 0);
            BOMTable.Name = "BOMTable";
            BOMTable.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(31, 31, 31);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.Control;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            BOMTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            BOMTable.RowHeadersVisible = false;
            BOMTable.Size = new Size(406, 448);
            BOMTable.TabIndex = 0;
            BOMTable.SelectionChanged += BOMTable_SelectionChanged;
            // 
            // BomValueCol
            // 
            BomValueCol.HeaderText = "Value";
            BomValueCol.Name = "BomValueCol";
            BomValueCol.ReadOnly = true;
            // 
            // BomDesignatorsCol
            // 
            BomDesignatorsCol.HeaderText = "Designators";
            BomDesignatorsCol.Name = "BomDesignatorsCol";
            BomDesignatorsCol.ReadOnly = true;
            // 
            // BomFootprintCol
            // 
            BomFootprintCol.HeaderText = "Footprint";
            BomFootprintCol.Name = "BomFootprintCol";
            BomFootprintCol.ReadOnly = true;
            // 
            // BomPartnoCol
            // 
            BomPartnoCol.HeaderText = "LCSC Part Number";
            BomPartnoCol.Name = "BomPartnoCol";
            BomPartnoCol.ReadOnly = true;
            // 
            // PlacementsTable
            // 
            PlacementsTable.AllowUserToAddRows = false;
            PlacementsTable.AllowUserToDeleteRows = false;
            PlacementsTable.AllowUserToOrderColumns = true;
            PlacementsTable.BackgroundColor = Color.FromArgb(31, 31, 31);
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(31, 31, 31);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.Control;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            PlacementsTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            PlacementsTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PlacementsTable.Columns.AddRange(new DataGridViewColumn[] { PlacementRefCol, PlacementValueCol, PlacementFootprintCol, PlacementPosXCol, PlacementPosYCol, PlacementRotCol, PlacementSideCol });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(31, 31, 31);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = SystemColors.Control;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            PlacementsTable.DefaultCellStyle = dataGridViewCellStyle5;
            PlacementsTable.Dock = DockStyle.Fill;
            PlacementsTable.GridColor = Color.FromArgb(66, 66, 66);
            PlacementsTable.Location = new Point(0, 0);
            PlacementsTable.Name = "PlacementsTable";
            PlacementsTable.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(31, 31, 31);
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = SystemColors.Control;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            PlacementsTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            PlacementsTable.RowHeadersVisible = false;
            PlacementsTable.Size = new Size(402, 448);
            PlacementsTable.TabIndex = 1;
            PlacementsTable.SelectionChanged += PlacementsTable_SelectionChanged;
            // 
            // PlacementRefCol
            // 
            PlacementRefCol.HeaderText = "Ref";
            PlacementRefCol.Name = "PlacementRefCol";
            PlacementRefCol.ReadOnly = true;
            // 
            // PlacementValueCol
            // 
            PlacementValueCol.HeaderText = "Value";
            PlacementValueCol.Name = "PlacementValueCol";
            PlacementValueCol.ReadOnly = true;
            // 
            // PlacementFootprintCol
            // 
            PlacementFootprintCol.HeaderText = "Footprint";
            PlacementFootprintCol.Name = "PlacementFootprintCol";
            PlacementFootprintCol.ReadOnly = true;
            // 
            // PlacementPosXCol
            // 
            PlacementPosXCol.HeaderText = "X";
            PlacementPosXCol.Name = "PlacementPosXCol";
            PlacementPosXCol.ReadOnly = true;
            // 
            // PlacementPosYCol
            // 
            PlacementPosYCol.HeaderText = "Y";
            PlacementPosYCol.Name = "PlacementPosYCol";
            PlacementPosYCol.ReadOnly = true;
            // 
            // PlacementRotCol
            // 
            PlacementRotCol.HeaderText = "Rotation";
            PlacementRotCol.Name = "PlacementRotCol";
            PlacementRotCol.ReadOnly = true;
            // 
            // PlacementSideCol
            // 
            PlacementSideCol.HeaderText = "Side";
            PlacementSideCol.Items.AddRange(new object[] { "Undef", "Top", "Bottom" });
            PlacementSideCol.Name = "PlacementSideCol";
            PlacementSideCol.ReadOnly = true;
            // 
            // PlacementPreviewPanel
            // 
            PlacementPreviewPanel.BackColor = Color.Black;
            PlacementPreviewPanel.Dock = DockStyle.Fill;
            PlacementPreviewPanel.Location = new Point(0, 0);
            PlacementPreviewPanel.Name = "PlacementPreviewPanel";
            PlacementPreviewPanel.Size = new Size(812, 209);
            PlacementPreviewPanel.TabIndex = 0;
            PlacementPreviewPanel.Paint += PlacementPreviewPanel_Paint;
            // 
            // lProjectName
            // 
            lProjectName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lProjectName.AutoSize = true;
            lProjectName.Location = new Point(11, 566);
            lProjectName.Name = "lProjectName";
            lProjectName.Size = new Size(79, 15);
            lProjectName.TabIndex = 9;
            lProjectName.Text = "Project Name";
            // 
            // ProjectNamePanel
            // 
            ProjectNamePanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ProjectNamePanel.BackColor = Color.FromArgb(31, 31, 31);
            ProjectNamePanel.BorderStyle = BorderStyle.FixedSingle;
            ProjectNamePanel.Controls.Add(ProjectNameTextbox);
            ProjectNamePanel.Location = new Point(11, 589);
            ProjectNamePanel.Name = "ProjectNamePanel";
            ProjectNamePanel.Size = new Size(261, 25);
            ProjectNamePanel.TabIndex = 8;
            // 
            // ProjectNameTextbox
            // 
            ProjectNameTextbox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ProjectNameTextbox.BackColor = Color.FromArgb(31, 31, 31);
            ProjectNameTextbox.BorderStyle = BorderStyle.None;
            ProjectNameTextbox.Font = new Font("Segoe UI", 9.75F);
            ProjectNameTextbox.ForeColor = SystemColors.Control;
            ProjectNameTextbox.Location = new Point(4, 3);
            ProjectNameTextbox.Name = "ProjectNameTextbox";
            ProjectNameTextbox.Size = new Size(252, 18);
            ProjectNameTextbox.TabIndex = 1;
            // 
            // propertiesPanel
            // 
            propertiesPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            propertiesPanel.AutoScroll = true;
            propertiesPanel.Controls.Add(selectionColorTextbox);
            propertiesPanel.Controls.Add(lSelectionColor);
            propertiesPanel.Controls.Add(bReloadFootprints);
            propertiesPanel.Controls.Add(fpDirsTextbox);
            propertiesPanel.Controls.Add(lFootprintDirs);
            propertiesPanel.Controls.Add(lExportProperties);
            propertiesPanel.Controls.Add(separateFilesCheckbox);
            propertiesPanel.Controls.Add(lFillOpacity);
            propertiesPanel.Controls.Add(bgOpacityTrackbar);
            propertiesPanel.Controls.Add(bottomOutlineColorTextbox);
            propertiesPanel.Controls.Add(lBottomColor);
            propertiesPanel.Controls.Add(bottomVisibleCheckbox);
            propertiesPanel.Controls.Add(lBottomComponents);
            propertiesPanel.Controls.Add(topOutlineColorTextbox);
            propertiesPanel.Controls.Add(lTopColor);
            propertiesPanel.Controls.Add(topVisibleCheckbox);
            propertiesPanel.Controls.Add(lTopComponents);
            propertiesPanel.Controls.Add(lGeneralProperties);
            propertiesPanel.Location = new Point(0, 0);
            propertiesPanel.Name = "propertiesPanel";
            propertiesPanel.Size = new Size(284, 563);
            propertiesPanel.TabIndex = 4;
            // 
            // selectionColorTextbox
            // 
            selectionColorTextbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            selectionColorTextbox.BackColor = Color.Yellow;
            selectionColorTextbox.ForeColor = Color.Black;
            selectionColorTextbox.Location = new Point(118, 266);
            selectionColorTextbox.Name = "selectionColorTextbox";
            selectionColorTextbox.ReadOnly = true;
            selectionColorTextbox.Size = new Size(154, 23);
            selectionColorTextbox.TabIndex = 18;
            selectionColorTextbox.Text = "#FFFF00";
            selectionColorTextbox.TextAlign = HorizontalAlignment.Center;
            selectionColorTextbox.DoubleClick += selectionColorTextbox_DoubleClick;
            // 
            // lSelectionColor
            // 
            lSelectionColor.AutoSize = true;
            lSelectionColor.Location = new Point(25, 270);
            lSelectionColor.Name = "lSelectionColor";
            lSelectionColor.Size = new Size(87, 15);
            lSelectionColor.TabIndex = 17;
            lSelectionColor.Text = "Selection Color";
            // 
            // bReloadFootprints
            // 
            bReloadFootprints.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            bReloadFootprints.BackColor = Color.FromArgb(31, 31, 31);
            bReloadFootprints.FlatAppearance.BorderColor = Color.FromArgb(66, 66, 66);
            bReloadFootprints.FlatStyle = FlatStyle.Flat;
            bReloadFootprints.Location = new Point(30, 438);
            bReloadFootprints.Name = "bReloadFootprints";
            bReloadFootprints.Size = new Size(242, 28);
            bReloadFootprints.TabIndex = 14;
            bReloadFootprints.Text = "Reload Footprints";
            bReloadFootprints.UseVisualStyleBackColor = false;
            bReloadFootprints.Click += bReloadFootprints_Click;
            // 
            // fpDirsTextbox
            // 
            fpDirsTextbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            fpDirsTextbox.BackColor = Color.FromArgb(31, 31, 31);
            fpDirsTextbox.ForeColor = SystemColors.Control;
            fpDirsTextbox.Location = new Point(30, 332);
            fpDirsTextbox.Multiline = true;
            fpDirsTextbox.Name = "fpDirsTextbox";
            fpDirsTextbox.Size = new Size(242, 100);
            fpDirsTextbox.TabIndex = 13;
            // 
            // lFootprintDirs
            // 
            lFootprintDirs.AutoSize = true;
            lFootprintDirs.Location = new Point(25, 305);
            lFootprintDirs.Name = "lFootprintDirs";
            lFootprintDirs.Size = new Size(188, 15);
            lFootprintDirs.TabIndex = 12;
            lFootprintDirs.Text = "Footprint Directories (one per line)";
            // 
            // lExportProperties
            // 
            lExportProperties.AutoSize = true;
            lExportProperties.Location = new Point(11, 481);
            lExportProperties.Name = "lExportProperties";
            lExportProperties.Size = new Size(97, 15);
            lExportProperties.TabIndex = 2;
            lExportProperties.Text = "Export Properties";
            // 
            // separateFilesCheckbox
            // 
            separateFilesCheckbox.AutoSize = true;
            separateFilesCheckbox.Location = new Point(25, 504);
            separateFilesCheckbox.Name = "separateFilesCheckbox";
            separateFilesCheckbox.Size = new Size(220, 19);
            separateFilesCheckbox.TabIndex = 0;
            separateFilesCheckbox.Text = "Separate top/bottom placement files";
            separateFilesCheckbox.UseVisualStyleBackColor = true;
            // 
            // lFillOpacity
            // 
            lFillOpacity.AutoSize = true;
            lFillOpacity.Location = new Point(25, 205);
            lFillOpacity.Name = "lFillOpacity";
            lFillOpacity.Size = new Size(182, 15);
            lFillOpacity.TabIndex = 16;
            lFillOpacity.Text = "Preview Components Fill Opacity";
            // 
            // bgOpacityTrackbar
            // 
            bgOpacityTrackbar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            bgOpacityTrackbar.LargeChange = 10;
            bgOpacityTrackbar.Location = new Point(30, 223);
            bgOpacityTrackbar.Maximum = 100;
            bgOpacityTrackbar.Name = "bgOpacityTrackbar";
            bgOpacityTrackbar.Size = new Size(238, 45);
            bgOpacityTrackbar.SmallChange = 5;
            bgOpacityTrackbar.TabIndex = 15;
            bgOpacityTrackbar.TickFrequency = 5;
            bgOpacityTrackbar.Scroll += bgOppacityTrackbar_Scroll;
            // 
            // bottomOutlineColorTextbox
            // 
            bottomOutlineColorTextbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            bottomOutlineColorTextbox.BackColor = Color.FromArgb(36, 236, 252);
            bottomOutlineColorTextbox.ForeColor = Color.Black;
            bottomOutlineColorTextbox.Location = new Point(114, 166);
            bottomOutlineColorTextbox.Name = "bottomOutlineColorTextbox";
            bottomOutlineColorTextbox.ReadOnly = true;
            bottomOutlineColorTextbox.Size = new Size(158, 23);
            bottomOutlineColorTextbox.TabIndex = 11;
            bottomOutlineColorTextbox.Text = "#24ECFC";
            bottomOutlineColorTextbox.TextAlign = HorizontalAlignment.Center;
            bottomOutlineColorTextbox.DoubleClick += bottomOutlineColorTextbox_DoubleClick;
            // 
            // lBottomColor
            // 
            lBottomColor.AutoSize = true;
            lBottomColor.Location = new Point(30, 170);
            lBottomColor.Name = "lBottomColor";
            lBottomColor.Size = new Size(78, 15);
            lBottomColor.TabIndex = 10;
            lBottomColor.Text = "Outline Color";
            // 
            // bottomVisibleCheckbox
            // 
            bottomVisibleCheckbox.AutoSize = true;
            bottomVisibleCheckbox.Checked = true;
            bottomVisibleCheckbox.CheckState = CheckState.Checked;
            bottomVisibleCheckbox.Location = new Point(30, 145);
            bottomVisibleCheckbox.Name = "bottomVisibleCheckbox";
            bottomVisibleCheckbox.Size = new Size(60, 19);
            bottomVisibleCheckbox.TabIndex = 9;
            bottomVisibleCheckbox.Text = "Visible";
            bottomVisibleCheckbox.UseVisualStyleBackColor = true;
            bottomVisibleCheckbox.CheckedChanged += VisibilityCheckbox_CheckedChanged;
            // 
            // lBottomComponents
            // 
            lBottomComponents.AutoSize = true;
            lBottomComponents.Location = new Point(25, 120);
            lBottomComponents.Name = "lBottomComponents";
            lBottomComponents.Size = new Size(119, 15);
            lBottomComponents.TabIndex = 8;
            lBottomComponents.Text = "Bottom Components";
            // 
            // topOutlineColorTextbox
            // 
            topOutlineColorTextbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            topOutlineColorTextbox.BackColor = Color.FromArgb(255, 38, 226);
            topOutlineColorTextbox.ForeColor = Color.Black;
            topOutlineColorTextbox.Location = new Point(114, 81);
            topOutlineColorTextbox.Name = "topOutlineColorTextbox";
            topOutlineColorTextbox.ReadOnly = true;
            topOutlineColorTextbox.Size = new Size(158, 23);
            topOutlineColorTextbox.TabIndex = 7;
            topOutlineColorTextbox.Text = "#FC24E4";
            topOutlineColorTextbox.TextAlign = HorizontalAlignment.Center;
            topOutlineColorTextbox.DoubleClick += topOutlineColorTextbox_DoubleClick;
            // 
            // lTopColor
            // 
            lTopColor.AutoSize = true;
            lTopColor.Location = new Point(30, 85);
            lTopColor.Name = "lTopColor";
            lTopColor.Size = new Size(78, 15);
            lTopColor.TabIndex = 6;
            lTopColor.Text = "Outline Color";
            // 
            // topVisibleCheckbox
            // 
            topVisibleCheckbox.AutoSize = true;
            topVisibleCheckbox.Checked = true;
            topVisibleCheckbox.CheckState = CheckState.Checked;
            topVisibleCheckbox.Location = new Point(30, 60);
            topVisibleCheckbox.Name = "topVisibleCheckbox";
            topVisibleCheckbox.Size = new Size(60, 19);
            topVisibleCheckbox.TabIndex = 5;
            topVisibleCheckbox.Text = "Visible";
            topVisibleCheckbox.UseVisualStyleBackColor = true;
            topVisibleCheckbox.CheckedChanged += VisibilityCheckbox_CheckedChanged;
            // 
            // lTopComponents
            // 
            lTopComponents.AutoSize = true;
            lTopComponents.Location = new Point(25, 35);
            lTopComponents.Name = "lTopComponents";
            lTopComponents.Size = new Size(98, 15);
            lTopComponents.TabIndex = 3;
            lTopComponents.Text = "Top Components";
            // 
            // lGeneralProperties
            // 
            lGeneralProperties.AutoSize = true;
            lGeneralProperties.Location = new Point(11, 10);
            lGeneralProperties.Name = "lGeneralProperties";
            lGeneralProperties.Size = new Size(103, 15);
            lGeneralProperties.TabIndex = 1;
            lGeneralProperties.Text = "General Properties";
            // 
            // bExport
            // 
            bExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            bExport.BackColor = Color.FromArgb(31, 31, 31);
            bExport.FlatAppearance.BorderColor = Color.FromArgb(66, 66, 66);
            bExport.FlatStyle = FlatStyle.Flat;
            bExport.Location = new Point(11, 620);
            bExport.Name = "bExport";
            bExport.Size = new Size(261, 30);
            bExport.TabIndex = 3;
            bExport.Text = "Export All Files";
            bExport.UseVisualStyleBackColor = false;
            bExport.Click += bExport_Click;
            // 
            // PreviewBlinkTimer
            // 
            PreviewBlinkTimer.Interval = 500;
            PreviewBlinkTimer.Tick += PreviewBlinkTimer_Tick;
            // 
            // ExportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 26);
            ClientSize = new Size(1100, 661);
            Controls.Add(MainSplitContainer);
            ForeColor = SystemColors.Control;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(600, 400);
            Name = "ExportForm";
            Text = "Export BOM and Placement Files";
            FormClosing += ExportForm_FormClosing;
            MainSplitContainer.Panel1.ResumeLayout(false);
            MainSplitContainer.Panel2.ResumeLayout(false);
            MainSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)MainSplitContainer).EndInit();
            MainSplitContainer.ResumeLayout(false);
            DataPanel.ResumeLayout(false);
            DataSplitcontainer.Panel1.ResumeLayout(false);
            DataSplitcontainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DataSplitcontainer).EndInit();
            DataSplitcontainer.ResumeLayout(false);
            tableSplitcontainer.Panel1.ResumeLayout(false);
            tableSplitcontainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tableSplitcontainer).EndInit();
            tableSplitcontainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)BOMTable).EndInit();
            ((System.ComponentModel.ISupportInitialize)PlacementsTable).EndInit();
            ProjectNamePanel.ResumeLayout(false);
            ProjectNamePanel.PerformLayout();
            propertiesPanel.ResumeLayout(false);
            propertiesPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bgOpacityTrackbar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer MainSplitContainer;
        private SplitContainer DataSplitcontainer;
        private Panel PlacementPreviewPanel;
        private Panel DataPanel;
        private SplitContainer tableSplitcontainer;
        private DataGridView BOMTable;
        private DataGridView PlacementsTable;
        private DataGridViewTextBoxColumn PlacementRefCol;
        private DataGridViewTextBoxColumn PlacementValueCol;
        private DataGridViewTextBoxColumn PlacementFootprintCol;
        private DataGridViewTextBoxColumn PlacementPosXCol;
        private DataGridViewTextBoxColumn PlacementPosYCol;
        private DataGridViewTextBoxColumn PlacementRotCol;
        private DataGridViewComboBoxColumn PlacementSideCol;
        private Label lExportProperties;
        private Label lGeneralProperties;
        private CheckBox separateFilesCheckbox;
        private DataGridViewTextBoxColumn BomValueCol;
        private DataGridViewTextBoxColumn BomDesignatorsCol;
        private DataGridViewTextBoxColumn BomFootprintCol;
        private DataGridViewTextBoxColumn BomPartnoCol;
        private Button bExport;
        private Panel propertiesPanel;
        private Label lTopComponents;
        private Label lTopColor;
        private CheckBox topVisibleCheckbox;
        private TextBox topOutlineColorTextbox;
        private TextBox bottomOutlineColorTextbox;
        private Label lBottomColor;
        private CheckBox bottomVisibleCheckbox;
        private Label lBottomComponents;
        private Label lFootprintDirs;
        private TextBox fpDirsTextbox;
        private Button bReloadFootprints;
        private Panel ProjectNamePanel;
        private TextBox ProjectNameTextbox;
        private Label lProjectName;
        private TrackBar bgOpacityTrackbar;
        private Label lFillOpacity;
        private TextBox selectionColorTextbox;
        private Label lSelectionColor;
        private System.Windows.Forms.Timer PreviewBlinkTimer;
    }
}