namespace KiCadPanelAssyFG
{
    partial class DoubleProgressbarWindow
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
            lPrimaryTitle = new Label();
            lSecondaryTitle = new Label();
            primaryProgressBar = new ProgressBar();
            secondaryProgressBar = new ProgressBar();
            SuspendLayout();
            // 
            // lPrimaryTitle
            // 
            lPrimaryTitle.AutoSize = true;
            lPrimaryTitle.Location = new Point(12, 10);
            lPrimaryTitle.Name = "lPrimaryTitle";
            lPrimaryTitle.Size = new Size(116, 15);
            lPrimaryTitle.TabIndex = 0;
            lPrimaryTitle.Text = "Primary Progress Bar";
            // 
            // lSecondaryTitle
            // 
            lSecondaryTitle.AutoSize = true;
            lSecondaryTitle.Location = new Point(12, 76);
            lSecondaryTitle.Name = "lSecondaryTitle";
            lSecondaryTitle.Size = new Size(130, 15);
            lSecondaryTitle.TabIndex = 1;
            lSecondaryTitle.Text = "Secondary Progress Bar";
            // 
            // primaryProgressBar
            // 
            primaryProgressBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            primaryProgressBar.Location = new Point(12, 37);
            primaryProgressBar.Name = "primaryProgressBar";
            primaryProgressBar.Size = new Size(513, 25);
            primaryProgressBar.TabIndex = 2;
            // 
            // secondaryProgressBar
            // 
            secondaryProgressBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            secondaryProgressBar.Location = new Point(12, 105);
            secondaryProgressBar.Name = "secondaryProgressBar";
            secondaryProgressBar.Size = new Size(513, 25);
            secondaryProgressBar.TabIndex = 3;
            // 
            // DoubleProgressbarWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 26);
            ClientSize = new Size(533, 140);
            ControlBox = false;
            Controls.Add(secondaryProgressBar);
            Controls.Add(primaryProgressBar);
            Controls.Add(lSecondaryTitle);
            Controls.Add(lPrimaryTitle);
            ForeColor = SystemColors.Control;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DoubleProgressbarWindow";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "Double Progress Bar Window";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lPrimaryTitle;
        private Label lSecondaryTitle;
        private ProgressBar primaryProgressBar;
        private ProgressBar secondaryProgressBar;
    }
}