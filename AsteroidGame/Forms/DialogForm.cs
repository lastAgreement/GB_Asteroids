using System;
using System.Windows.Forms;

namespace AsteroidGame
{
    public partial class DialogForm : Form
    {
        public DialogForm()
        {
            InitializeComponent();
        }

        private void DialogForm_Load(object sender, EventArgs e)
        {

        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Text = NameTextBox.Text;
            this.Close();
        }
    }
}
