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
    public partial class ClientView : Form
    {
        public ClientView()
        {
            InitializeComponent();
        }
        #region Visible_buttons
        private void button1_Click(object sender, EventArgs e)
        {
            Wheel wheel = new Wheel();
            wheel.ShowDialog();
        }
        
        #endregion

        private void btwWord_MouseClick(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            button.Visible = false;
            string text = button.Text;
        }
    }
}
