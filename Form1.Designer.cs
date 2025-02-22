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
            bExport = new Button();
            splitContainer1 = new SplitContainer();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
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
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Size = new Size(784, 413);
            splitContainer1.SplitterDistance = 261;
            splitContainer1.TabIndex = 0;
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
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button bExport;
        private SplitContainer splitContainer1;
    }
}
