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
        private void btnA_Click(object sender, EventArgs e)
        {
            btnA.Visible = false;
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            btnB.Visible = false;
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            btnC.Visible = false;
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            btnD.Visible = false;
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            btnE.Visible = false;
        }

        private void btnG_Click(object sender, EventArgs e)
        {
            btnG.Visible = false;
        }

        private void btnH_Click(object sender, EventArgs e)
        {
            btnH.Visible = false;
        }

        private void btnI_Click(object sender, EventArgs e)
        {
            btnI.Visible = false;
        }

        private void btnK_Click(object sender, EventArgs e)
        {
            btnK.Visible = false;
        }

        private void btnL_Click(object sender, EventArgs e)
        {
            btnL.Visible = false;
        }

        private void btnM_Click(object sender, EventArgs e)
        {
            btnM.Visible = false;
        }
        private void btnN_Click_1(object sender, EventArgs e)
        {
            btnN.Visible = false;
        }

        private void btnO_Click(object sender, EventArgs e)
        {
            btnO.Visible = false;
        }

        private void btnP_Click(object sender, EventArgs e)
        {
            btnP.Visible = false;
        }

        private void btnQ_Click(object sender, EventArgs e)
        {
            btnQ.Visible = false;
        }

        private void btnR_Click(object sender, EventArgs e)
        {
            btnR.Visible = false;
        }

        private void btnT_Click(object sender, EventArgs e)
        {
            btnT.Visible = false;
        }

        private void btnU_Click(object sender, EventArgs e)
        {
            btnU.Visible = false;
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            btnS.Visible = false;
        }

        private void btnV_Click(object sender, EventArgs e)
        {
            btnV.Visible = false;
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            btnX.Visible = false;
        }

        private void btnY_Click(object sender, EventArgs e)
        {
            btnY.Visible = false;
        }
        #endregion
    }
}
