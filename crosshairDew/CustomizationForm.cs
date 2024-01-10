using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class CustomizationForm : Form
    {
        public Color SelectedColor { get; private set; } // Property to hold the selected color
        public int CrosshairSize { get; private set; }   // Property to hold the crosshair size

        public CustomizationForm(Color initialColor, int initialSize)
        {
            InitializeComponent();

            // Initialize properties with initial values
            SelectedColor = initialColor;
            CrosshairSize = initialSize;
            txtSize.Text = initialSize.ToString();

            // Subscribe to the TextChanged event
            txtSize.TextChanged += TxtSize_TextChanged;
        }

        private void btnChooseColor_Click(object sender, EventArgs e)
        {
            // Show the color dialog
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                // Update the SelectedColor
                SelectedColor = colorDialog1.Color;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Indicate success and close the form
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Indicate cancellation and close the form
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void TxtSize_TextChanged(object sender, EventArgs e)
        {
            // Attempt to parse the text as an integer
            if (int.TryParse(txtSize.Text, out int newSize) && newSize > 0)
            {
                CrosshairSize = newSize;
            }
        }

        private void btnChooseColor_Click_1(object sender, EventArgs e)
        {
            // Show the color dialog
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                // Update the SelectedColor
                SelectedColor = colorDialog1.Color;
            }
        }

        private void btnOK_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtSize_TextChanged_1(object sender, EventArgs e)
        {
            if (int.TryParse(txtSize.Text, out int newSize) && newSize > 0)
            {
                CrosshairSize = newSize;
            }
        }
    }
}
