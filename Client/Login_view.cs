using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Login_view : Form
    {
        public Login_view()
        {
            InitializeComponent();
        }

        private void lbStart_Click(object sender, EventArgs e)
        {
            ClientView client = new ClientView();
            client.ShowDialog();

        }
    }
}
