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
    public partial class Winner : Form
    {
        public Winner()
        {
            InitializeComponent();
        }
        public void UpdateWinner(string name)
        {
            lbWinnerName.Text = name;
        }
    }
}
