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
    public partial class Wheel : Form
    {
        int spin_count = 0;
        bool wheelIsMoved;
        float wheelTimes;
        Timer wheelTimer;
        LuckyCirlce koloFortuny;
        public Wheel()
        {
            InitializeComponent();
            wheelTimer = new Timer();
            wheelTimer.Interval = 30; // speed 
            wheelTimer.Tick += wheelTimer_Tick;
            koloFortuny = new LuckyCirlce();
        }
        public class LuckyCirlce
        {
            public Bitmap obrazek;
            public Bitmap tempObrazek;
            public float kat;
            public string[] wartosciStanu;
            public int stan;

            public LuckyCirlce()
            {
                tempObrazek = new Bitmap(Properties.Resources.wheel_new);
                obrazek = new Bitmap(Properties.Resources.wheel_new);
                wartosciStanu = new string[] { "+100", "x2", "+200", "Chia đôi", "+100", "+300", "x2", "+200", "Chia đôi", "+100" };
                kat = 0.0f;
            }

        }
        public static Bitmap RotateImage(Image image, float angle)
        {
            return RotateImage(image, new PointF((float)image.Width / 2, (float)image.Height / 2), angle);
        }

        public static Bitmap RotateImage(Image image, PointF offset, float angle)
        {
            if (image == null)
                throw new ArgumentNullException("image");


            Bitmap rotatedBmp = new Bitmap(image.Width, image.Height);
            rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            Graphics g = Graphics.FromImage(rotatedBmp);
            g.TranslateTransform(offset.X, offset.Y);
            g.RotateTransform(angle);
            g.TranslateTransform(-offset.X, -offset.Y);
            g.DrawImage(image, new PointF(0, 0));

            return rotatedBmp;
        }
        private void wheelTimer_Tick(object sender, EventArgs e)
        {

            if (wheelIsMoved && wheelTimes > 0)
            {
                koloFortuny.kat += wheelTimes / 10;
                koloFortuny.kat = koloFortuny.kat % 360;
                RotateImage(pictureBox1, koloFortuny.obrazek, koloFortuny.kat);
                wheelTimes--;
            }

            koloFortuny.stan = Convert.ToInt32(Math.Ceiling(koloFortuny.kat / 36));

            if (koloFortuny.stan == 0)
            {
                koloFortuny.stan = 0;
            }
            else
            {
                koloFortuny.stan -= 1;
            }

            label1.Text = Convert.ToString(koloFortuny.wartosciStanu[koloFortuny.stan]);


        }
        private void RotateImage(PictureBox pb, Image img, float angle)
        {
            if (img == null || pb.Image == null)
                return;

            Image oldImage = pb.Image;
            pb.Image = RotateImage(img, angle);
            if (oldImage != null)
            {
                oldImage.Dispose();
            }
        }
        private void btSpin_Click(object sender, EventArgs e)
        {
            if (spin_count == 0)
                btSpin.Enabled = false;
            wheelIsMoved = true;
            Random rand = new Random();
            wheelTimes = rand.Next(150, 200);    //random số vòng quay     
            wheelTimer.Start();
        }
    }
}
