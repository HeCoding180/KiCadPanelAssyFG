using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KiCadPanelAssyFG
{
    public partial class AddFileForm : Form
    {
        public string fileName { set; get; }
        public string fileDir { private set; get; }

        public AddFileForm(string title, string nameText, string fileText)
        {
            InitializeComponent();

            this.Text = title;

            lName.Text = nameText;

            lFile.Text = fileText;

            // Default dialog result
            this.DialogResult = DialogResult.Cancel;
        }

        private void bBrowse_Click(object sender, EventArgs e)
        {
            string initialDirectory = Path.GetDirectoryName(fileTextbox.Text);

            if (Directory.Exists(initialDirectory)) // Validate directory
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    InitialDirectory = initialDirectory,
                    Filter = "CSV Files (*.csv)|*.csv",
                    DefaultExt = "csv"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileTextbox.Text = openFileDialog.FileName;
                }
            }
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog()
                {
                    Filter = "CSV Files (*.csv)|*.csv",
                    DefaultExt = "csv"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileTextbox.Text = openFileDialog.FileName;
                }
            }
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            if (nameTextbox.Text == "")
            {
                MessageBox.Show("Name field cannot be empty", "Name Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (fileTextbox.Text == "")
            {
                MessageBox.Show("No file has been selected", "No File Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!File.Exists(fileTextbox.Text))
            {
                MessageBox.Show("The following path is either invalid or the entered file does not exist:" + Environment.NewLine + "\"" + fileTextbox.Text + "\"", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!fileTextbox.Text.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("The file is not of type \".csv\"", "Invalid File Ending", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            fileName = nameTextbox.Text;
            fileDir = fileTextbox.Text;

            this.DialogResult = DialogResult.OK;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddFileForm_Shown(object sender, EventArgs e)
        {
            // Focus name textbox when the form is shown for improved user experience
            nameTextbox.Focus();
        }
    }
}
