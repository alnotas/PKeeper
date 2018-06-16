using System;
using System.Windows.Forms;

namespace PKeeper
{
    public partial class PinForm : Form
    {
        private GridForm prntForm;
        private bool bShowRetries;

        public PinForm(GridForm ParentForm, bool BShowRetries)
        {
            InitializeComponent();
            prntForm = ParentForm;
            label1.Visible = BShowRetries;
            bShowRetries = BShowRetries;
        }

        private void PinForm_Shown(object sender, EventArgs e)
        {
            this.BringToFront();
            label1.Text = "Tries left : " + Program.PINRetries.ToString();
            maskedPIN.Text = "123456789";
            maskedPIN.SelectAll();
            maskedPIN.Focus();
            DialogResult = DialogResult.None;
        }

        private void maskedPIN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Program.PINRetries -= 1;
                DialogResult = DialogResult.OK;
            }
            else if(e.KeyCode == Keys.Escape)
                DialogResult = DialogResult.Cancel;
        }

        private void PinForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(DialogResult!= DialogResult.OK)
               DialogResult = DialogResult.Cancel;
        }
    }
}
