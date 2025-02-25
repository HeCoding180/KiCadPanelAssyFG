using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KiCadPanelAssyFG
{
    public partial class DoubleProgressbarWindow : Form
    {
        public string PrimaryText
        {
            set
            {
                lPrimaryTitle.Text = value;
            }
            get
            {
                return lPrimaryTitle.Text;
            }
        }
        public string SecondaryText
        {
            set
            {
                lSecondaryTitle.Text = value;
            }
            get
            {
                return lSecondaryTitle.Text;
            }
        }

        public int PrimaryProgress
        {
            set
            {
                primaryProgressBar.Value = value;
            }
            get
            {
                return primaryProgressBar.Value;
            }
        }
        public int PrimaryMaxProgress
        {
            set
            {
                primaryProgressBar.Maximum = value;
            }
            get
            {
                return primaryProgressBar.Maximum;
            }
        }
        public int SecondaryProgress
        {
            set
            {
                secondaryProgressBar.Value = value;
            }
            get
            {
                return secondaryProgressBar.Value;
            }
        }
        public int SecondaryMaxProgress
        {
            set
            {
                secondaryProgressBar.Maximum = value;
            }
            get
            {
                return secondaryProgressBar.Maximum;
            }
        }

        public DoubleProgressbarWindow(string title, string primaryText, string secondaryText)
        {
            InitializeComponent();
        }
    }
}
