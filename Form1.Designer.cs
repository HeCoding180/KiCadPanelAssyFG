namespace KiCad_Panel_Assembly_Files_Generator
{
    partial class InputFilesForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputFilesForm));
            panel1 = new Panel();
            mainSplitcontainer = new SplitContainer();
            bRemoveDesign = new Button();
            bAddDesign = new Button();
            designListBox = new ListBox();
            lDesigns = new Label();
            bRemovePlacement = new Button();
            bAddPlacements = new Button();
            placementsListBox = new ListBox();
            lPlacementPos = new Label();
            bExport = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainSplitcontainer).BeginInit();
            mainSplitcontainer.Panel1.SuspendLayout();
            mainSplitcontainer.Panel2.SuspendLayout();
            mainSplitcontainer.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(mainSplitcontainer);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(784, 413);
            panel1.TabIndex = 0;
            // 
            // mainSplitcontainer
            // 
            mainSplitcontainer.Dock = DockStyle.Fill;
            mainSplitcontainer.Location = new Point(0, 0);
            mainSplitcontainer.Name = "mainSplitcontainer";
            // 
            // mainSplitcontainer.Panel1
            // 
            mainSplitcontainer.Panel1.Controls.Add(bRemoveDesign);
            mainSplitcontainer.Panel1.Controls.Add(bAddDesign);
            mainSplitcontainer.Panel1.Controls.Add(designListBox);
            mainSplitcontainer.Panel1.Controls.Add(lDesigns);
            // 
            // mainSplitcontainer.Panel2
            // 
            mainSplitcontainer.Panel2.Controls.Add(bRemovePlacement);
            mainSplitcontainer.Panel2.Controls.Add(bAddPlacements);
            mainSplitcontainer.Panel2.Controls.Add(placementsListBox);
            mainSplitcontainer.Panel2.Controls.Add(lPlacementPos);
            mainSplitcontainer.Size = new Size(784, 413);
            mainSplitcontainer.SplitterDistance = 389;
            mainSplitcontainer.TabIndex = 0;
            // 
            // bRemoveDesign
            // 
            bRemoveDesign.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            bRemoveDesign.BackColor = Color.FromArgb(31, 31, 31);
            bRemoveDesign.BackgroundImageLayout = ImageLayout.Zoom;
            bRemoveDesign.Enabled = false;
            bRemoveDesign.FlatAppearance.BorderColor = Color.FromArgb(66, 66, 66);
            bRemoveDesign.FlatStyle = FlatStyle.Flat;
            bRemoveDesign.Location = new Point(48, 378);
            bRemoveDesign.Name = "bRemoveDesign";
            bRemoveDesign.Size = new Size(30, 30);
            bRemoveDesign.TabIndex = 3;
            bRemoveDesign.UseVisualStyleBackColor = false;
            bRemoveDesign.Click += bRemoveDesign_Click;
            bRemoveDesign.Paint += RemoveButton_Paint;
            // 
            // bAddDesign
            // 
            bAddDesign.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            bAddDesign.BackColor = Color.FromArgb(31, 31, 31);
            bAddDesign.BackgroundImageLayout = ImageLayout.Zoom;
            bAddDesign.FlatAppearance.BorderColor = Color.FromArgb(66, 66, 66);
            bAddDesign.FlatStyle = FlatStyle.Flat;
            bAddDesign.Location = new Point(12, 378);
            bAddDesign.Name = "bAddDesign";
            bAddDesign.Size = new Size(30, 30);
            bAddDesign.TabIndex = 2;
            bAddDesign.UseVisualStyleBackColor = false;
            bAddDesign.Click += bAddDesign_Click;
            bAddDesign.Paint += AddButton_Paint;
            // 
            // designListBox
            // 
            designListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            designListBox.BackColor = Color.FromArgb(31, 31, 31);
            designListBox.BorderStyle = BorderStyle.FixedSingle;
            designListBox.DrawMode = DrawMode.OwnerDrawVariable;
            designListBox.ForeColor = SystemColors.Control;
            designListBox.IntegralHeight = false;
            designListBox.ItemHeight = 15;
            designListBox.Location = new Point(12, 34);
            designListBox.Name = "designListBox";
            designListBox.Size = new Size(362, 333);
            designListBox.TabIndex = 1;
            designListBox.DrawItem += ListBox_DrawItem;
            designListBox.MeasureItem += ListBox_MeasureItem;
            designListBox.SelectedIndexChanged += designListBox_SelectedIndexChanged;
            // 
            // lDesigns
            // 
            lDesigns.AutoSize = true;
            lDesigns.ForeColor = SystemColors.Control;
            lDesigns.Location = new Point(12, 9);
            lDesigns.Name = "lDesigns";
            lDesigns.Size = new Size(51, 15);
            lDesigns.TabIndex = 0;
            lDesigns.Text = "Designs:";
            // 
            // bRemovePlacement
            // 
            bRemovePlacement.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            bRemovePlacement.BackColor = Color.FromArgb(31, 31, 31);
            bRemovePlacement.BackgroundImageLayout = ImageLayout.Zoom;
            bRemovePlacement.Enabled = false;
            bRemovePlacement.FlatAppearance.BorderColor = Color.FromArgb(66, 66, 66);
            bRemovePlacement.FlatStyle = FlatStyle.Flat;
            bRemovePlacement.Location = new Point(50, 378);
            bRemovePlacement.Name = "bRemovePlacement";
            bRemovePlacement.Size = new Size(30, 30);
            bRemovePlacement.TabIndex = 6;
            bRemovePlacement.UseVisualStyleBackColor = false;
            bRemovePlacement.Click += bRemovePlacement_Click;
            bRemovePlacement.Paint += RemoveButton_Paint;
            // 
            // bAddPlacements
            // 
            bAddPlacements.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            bAddPlacements.BackColor = Color.FromArgb(31, 31, 31);
            bAddPlacements.BackgroundImageLayout = ImageLayout.Zoom;
            bAddPlacements.Enabled = false;
            bAddPlacements.FlatAppearance.BorderColor = Color.FromArgb(66, 66, 66);
            bAddPlacements.FlatStyle = FlatStyle.Flat;
            bAddPlacements.Location = new Point(14, 378);
            bAddPlacements.Name = "bAddPlacements";
            bAddPlacements.Size = new Size(30, 30);
            bAddPlacements.TabIndex = 5;
            bAddPlacements.UseVisualStyleBackColor = false;
            bAddPlacements.Click += bAddPlacements_Click;
            bAddPlacements.Paint += AddButton_Paint;
            // 
            // placementsListBox
            // 
            placementsListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            placementsListBox.BackColor = Color.FromArgb(31, 31, 31);
            placementsListBox.BorderStyle = BorderStyle.FixedSingle;
            placementsListBox.DrawMode = DrawMode.OwnerDrawVariable;
            placementsListBox.ForeColor = SystemColors.Control;
            placementsListBox.IntegralHeight = false;
            placementsListBox.ItemHeight = 15;
            placementsListBox.Location = new Point(14, 34);
            placementsListBox.Name = "placementsListBox";
            placementsListBox.Size = new Size(365, 333);
            placementsListBox.TabIndex = 4;
            placementsListBox.DrawItem += ListBox_DrawItem;
            placementsListBox.MeasureItem += ListBox_MeasureItem;
            placementsListBox.SelectedIndexChanged += placementsListBox_SelectedIndexChanged;
            // 
            // lPlacementPos
            // 
            lPlacementPos.AutoSize = true;
            lPlacementPos.ForeColor = SystemColors.Control;
            lPlacementPos.Location = new Point(14, 9);
            lPlacementPos.Name = "lPlacementPos";
            lPlacementPos.Size = new Size(138, 15);
            lPlacementPos.TabIndex = 1;
            lPlacementPos.Text = "Placement Position Files:";
            // 
            // bExport
            // 
            bExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            bExport.BackColor = Color.FromArgb(31, 31, 31);
            bExport.FlatAppearance.BorderColor = Color.FromArgb(66, 66, 66);
            bExport.FlatStyle = FlatStyle.Flat;
            bExport.ForeColor = SystemColors.Control;
            bExport.Location = new Point(7, 419);
            bExport.Name = "bExport";
            bExport.Size = new Size(770, 35);
            bExport.TabIndex = 7;
            bExport.Text = "Export BOM and Placement File";
            bExport.UseVisualStyleBackColor = false;
            bExport.Click += bExport_Click;
            // 
            // InputFilesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 26);
            ClientSize = new Size(784, 461);
            Controls.Add(bExport);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(500, 300);
            Name = "InputFilesForm";
            Text = "KiCad Panel Assembly Files Generator";
            panel1.ResumeLayout(false);
            mainSplitcontainer.Panel1.ResumeLayout(false);
            mainSplitcontainer.Panel1.PerformLayout();
            mainSplitcontainer.Panel2.ResumeLayout(false);
            mainSplitcontainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)mainSplitcontainer).EndInit();
            mainSplitcontainer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button bExport;
        private SplitContainer mainSplitcontainer;
        private Label lDesigns;
        private Label lPlacementPos;
        private ListBox designListBox;
        private Button bRemoveDesign;
        private Button bAddDesign;
        private Button bRemovePlacement;
        private Button bAddPlacements;
        private ListBox placementsListBox;
    }
}
