namespace KiCad_Panel_Assembly_Files_Generator
{
    partial class AddFileForm
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
            lName = new Label();
            lFile = new Label();
            nameTextbox = new TextBox();
            fileTextbox = new TextBox();
            bOk = new Button();
            bCancel = new Button();
            bBrowse = new Button();
            nameTextboxPanel = new Panel();
            fileTextboxPanel = new Panel();
            lPlacement = new Label();
            topRadioButton = new RadioButton();
            bottomRadioButton = new RadioButton();
            nameTextboxPanel.SuspendLayout();
            fileTextboxPanel.SuspendLayout();
            SuspendLayout();
            // 
            // lName
            // 
            lName.AutoSize = true;
            lName.Location = new Point(12, 9);
            lName.Name = "lName";
            lName.Size = new Size(39, 15);
            lName.TabIndex = 0;
            lName.Text = "Name";
            // 
            // lFile
            // 
            lFile.AutoSize = true;
            lFile.Location = new Point(12, 64);
            lFile.Name = "lFile";
            lFile.Size = new Size(25, 15);
            lFile.TabIndex = 1;
            lFile.Text = "File";
            // 
            // nameTextbox
            // 
            nameTextbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            nameTextbox.BackColor = Color.FromArgb(31, 31, 31);
            nameTextbox.BorderStyle = BorderStyle.None;
            nameTextbox.Font = new Font("Segoe UI", 9.75F);
            nameTextbox.ForeColor = SystemColors.Control;
            nameTextbox.Location = new Point(4, 3);
            nameTextbox.Name = "nameTextbox";
            nameTextbox.Size = new Size(400, 18);
            nameTextbox.TabIndex = 2;
            // 
            // fileTextbox
            // 
            fileTextbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            fileTextbox.BackColor = Color.FromArgb(31, 31, 31);
            fileTextbox.BorderStyle = BorderStyle.None;
            fileTextbox.Font = new Font("Segoe UI", 9.75F);
            fileTextbox.ForeColor = SystemColors.Control;
            fileTextbox.Location = new Point(4, 3);
            fileTextbox.Name = "fileTextbox";
            fileTextbox.Size = new Size(294, 18);
            fileTextbox.TabIndex = 3;
            // 
            // bOk
            // 
            bOk.BackColor = Color.FromArgb(31, 31, 31);
            bOk.FlatAppearance.BorderColor = Color.FromArgb(66, 66, 66);
            bOk.FlatStyle = FlatStyle.Flat;
            bOk.Location = new Point(12, 124);
            bOk.Name = "bOk";
            bOk.Size = new Size(100, 25);
            bOk.TabIndex = 4;
            bOk.Text = "OK";
            bOk.UseVisualStyleBackColor = false;
            bOk.Click += bOk_Click;
            // 
            // bCancel
            // 
            bCancel.BackColor = Color.FromArgb(31, 31, 31);
            bCancel.FlatAppearance.BorderColor = Color.FromArgb(66, 66, 66);
            bCancel.FlatStyle = FlatStyle.Flat;
            bCancel.Location = new Point(118, 124);
            bCancel.Name = "bCancel";
            bCancel.Size = new Size(100, 25);
            bCancel.TabIndex = 5;
            bCancel.Text = "Cancel";
            bCancel.UseVisualStyleBackColor = false;
            bCancel.Click += bCancel_Click;
            // 
            // bBrowse
            // 
            bBrowse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bBrowse.BackColor = Color.FromArgb(31, 31, 31);
            bBrowse.FlatAppearance.BorderColor = Color.FromArgb(66, 66, 66);
            bBrowse.FlatStyle = FlatStyle.Flat;
            bBrowse.Location = new Point(322, 86);
            bBrowse.Name = "bBrowse";
            bBrowse.Size = new Size(100, 25);
            bBrowse.TabIndex = 6;
            bBrowse.Text = "Browse";
            bBrowse.UseVisualStyleBackColor = false;
            bBrowse.Click += bBrowse_Click;
            // 
            // nameTextboxPanel
            // 
            nameTextboxPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            nameTextboxPanel.BackColor = Color.FromArgb(31, 31, 31);
            nameTextboxPanel.BorderStyle = BorderStyle.FixedSingle;
            nameTextboxPanel.Controls.Add(nameTextbox);
            nameTextboxPanel.Location = new Point(12, 31);
            nameTextboxPanel.Name = "nameTextboxPanel";
            nameTextboxPanel.Size = new Size(410, 25);
            nameTextboxPanel.TabIndex = 7;
            // 
            // fileTextboxPanel
            // 
            fileTextboxPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            fileTextboxPanel.BackColor = Color.FromArgb(31, 31, 31);
            fileTextboxPanel.BorderStyle = BorderStyle.FixedSingle;
            fileTextboxPanel.Controls.Add(fileTextbox);
            fileTextboxPanel.Location = new Point(12, 86);
            fileTextboxPanel.Name = "fileTextboxPanel";
            fileTextboxPanel.Size = new Size(304, 25);
            fileTextboxPanel.TabIndex = 8;
            // 
            // lPlacement
            // 
            lPlacement.AutoSize = true;
            lPlacement.Location = new Point(235, 129);
            lPlacement.Name = "lPlacement";
            lPlacement.Size = new Size(66, 15);
            lPlacement.TabIndex = 9;
            lPlacement.Text = "Placement:";
            // 
            // topRadioButton
            // 
            topRadioButton.AutoSize = true;
            topRadioButton.Location = new Point(307, 127);
            topRadioButton.Name = "topRadioButton";
            topRadioButton.Size = new Size(44, 19);
            topRadioButton.TabIndex = 10;
            topRadioButton.TabStop = true;
            topRadioButton.Text = "Top";
            topRadioButton.UseVisualStyleBackColor = true;
            // 
            // bottomRadioButton
            // 
            bottomRadioButton.AutoSize = true;
            bottomRadioButton.Location = new Point(357, 127);
            bottomRadioButton.Name = "bottomRadioButton";
            bottomRadioButton.Size = new Size(65, 19);
            bottomRadioButton.TabIndex = 11;
            bottomRadioButton.TabStop = true;
            bottomRadioButton.Text = "Bottom";
            bottomRadioButton.UseVisualStyleBackColor = true;
            // 
            // AddFileForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 26);
            ClientSize = new Size(434, 161);
            Controls.Add(bottomRadioButton);
            Controls.Add(topRadioButton);
            Controls.Add(lPlacement);
            Controls.Add(fileTextboxPanel);
            Controls.Add(nameTextboxPanel);
            Controls.Add(bBrowse);
            Controls.Add(bCancel);
            Controls.Add(bOk);
            Controls.Add(lFile);
            Controls.Add(lName);
            ForeColor = SystemColors.Control;
            MaximumSize = new Size(2000, 200);
            MinimumSize = new Size(450, 200);
            Name = "AddFileForm";
            ShowIcon = false;
            Text = "AddFileForm";
            nameTextboxPanel.ResumeLayout(false);
            nameTextboxPanel.PerformLayout();
            fileTextboxPanel.ResumeLayout(false);
            fileTextboxPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lName;
        private Label lFile;
        private TextBox nameTextbox;
        private TextBox fileTextbox;
        private Button bOk;
        private Button bCancel;
        private Button bBrowse;
        private Panel nameTextboxPanel;
        private Panel fileTextboxPanel;
        private Label lPlacement;
        private RadioButton topRadioButton;
        private RadioButton bottomRadioButton;
    }
}