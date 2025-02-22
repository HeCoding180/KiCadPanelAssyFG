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
            panel1 = new Panel();
            splitContainer1 = new SplitContainer();
            bRemoveDesign = new Button();
            bAddDesign = new Button();
            designListBox = new ListBox();
            lDesigns = new Label();
            lPlacementPos = new Label();
            bExport = new Button();
            bRemovePlacement = new Button();
            bAddPlacements = new Button();
            placementsListBox = new ListBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(splitContainer1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(784, 413);
            panel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(bRemoveDesign);
            splitContainer1.Panel1.Controls.Add(bAddDesign);
            splitContainer1.Panel1.Controls.Add(designListBox);
            splitContainer1.Panel1.Controls.Add(lDesigns);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(bRemovePlacement);
            splitContainer1.Panel2.Controls.Add(bAddPlacements);
            splitContainer1.Panel2.Controls.Add(placementsListBox);
            splitContainer1.Panel2.Controls.Add(lPlacementPos);
            splitContainer1.Size = new Size(784, 413);
            splitContainer1.SplitterDistance = 377;
            splitContainer1.TabIndex = 0;
            // 
            // bRemoveDesign
            // 
            bRemoveDesign.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            bRemoveDesign.BackColor = Color.FromArgb(31, 31, 31);
            bRemoveDesign.FlatAppearance.BorderColor = Color.FromArgb(66, 66, 66);
            bRemoveDesign.FlatStyle = FlatStyle.Flat;
            bRemoveDesign.Location = new Point(46, 373);
            bRemoveDesign.Name = "bRemoveDesign";
            bRemoveDesign.Size = new Size(28, 27);
            bRemoveDesign.TabIndex = 3;
            bRemoveDesign.UseVisualStyleBackColor = false;
            // 
            // bAddDesign
            // 
            bAddDesign.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            bAddDesign.BackColor = Color.FromArgb(31, 31, 31);
            bAddDesign.FlatAppearance.BorderColor = Color.FromArgb(66, 66, 66);
            bAddDesign.FlatStyle = FlatStyle.Flat;
            bAddDesign.Location = new Point(12, 373);
            bAddDesign.Name = "bAddDesign";
            bAddDesign.Size = new Size(28, 27);
            bAddDesign.TabIndex = 2;
            bAddDesign.UseVisualStyleBackColor = false;
            // 
            // designListBox
            // 
            designListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            designListBox.BackColor = Color.FromArgb(31, 31, 31);
            designListBox.BorderStyle = BorderStyle.FixedSingle;
            designListBox.ForeColor = SystemColors.Control;
            designListBox.FormattingEnabled = true;
            designListBox.IntegralHeight = false;
            designListBox.ItemHeight = 15;
            designListBox.Location = new Point(12, 34);
            designListBox.Name = "designListBox";
            designListBox.Size = new Size(350, 328);
            designListBox.TabIndex = 1;
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
            bExport.TabIndex = 1;
            bExport.Text = "Export BOM and Placement File";
            bExport.UseVisualStyleBackColor = false;
            // 
            // bRemovePlacement
            // 
            bRemovePlacement.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            bRemovePlacement.BackColor = Color.FromArgb(31, 31, 31);
            bRemovePlacement.FlatAppearance.BorderColor = Color.FromArgb(66, 66, 66);
            bRemovePlacement.FlatStyle = FlatStyle.Flat;
            bRemovePlacement.Location = new Point(48, 373);
            bRemovePlacement.Name = "bRemovePlacement";
            bRemovePlacement.Size = new Size(28, 27);
            bRemovePlacement.TabIndex = 6;
            bRemovePlacement.UseVisualStyleBackColor = false;
            // 
            // bAddPlacements
            // 
            bAddPlacements.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            bAddPlacements.BackColor = Color.FromArgb(31, 31, 31);
            bAddPlacements.FlatAppearance.BorderColor = Color.FromArgb(66, 66, 66);
            bAddPlacements.FlatStyle = FlatStyle.Flat;
            bAddPlacements.Location = new Point(14, 373);
            bAddPlacements.Name = "bAddPlacements";
            bAddPlacements.Size = new Size(28, 27);
            bAddPlacements.TabIndex = 5;
            bAddPlacements.UseVisualStyleBackColor = false;
            // 
            // placementsListBox
            // 
            placementsListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            placementsListBox.BackColor = Color.FromArgb(31, 31, 31);
            placementsListBox.BorderStyle = BorderStyle.FixedSingle;
            placementsListBox.ForeColor = SystemColors.Control;
            placementsListBox.FormattingEnabled = true;
            placementsListBox.IntegralHeight = false;
            placementsListBox.ItemHeight = 15;
            placementsListBox.Location = new Point(14, 34);
            placementsListBox.Name = "placementsListBox";
            placementsListBox.Size = new Size(377, 328);
            placementsListBox.TabIndex = 4;
            // 
            // InputFilesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 26);
            ClientSize = new Size(784, 461);
            Controls.Add(bExport);
            Controls.Add(panel1);
            Name = "InputFilesForm";
            ShowIcon = false;
            Text = "KiCad Panel Assembly Files Generator";
            panel1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button bExport;
        private SplitContainer splitContainer1;
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
