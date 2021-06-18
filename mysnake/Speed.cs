using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mysnake
{
    class Speed
    {
        public int rXXX, rYYY;
        int p,pp;
        int width = 600;
        int sizesnake = 40;

        public void Speedup(PictureBox bomba, PictureBox fruit, int score, PictureBox[] snake, PictureBox speedup, Panel panel1)
        {

            Random o = new Random();
            rXXX = o.Next(0, width);
            int tempIII = rXXX % sizesnake;
            rXXX -= tempIII;
            rYYY = o.Next(0, width);
            int tempJJJ = rYYY % sizesnake;
            rYYY -= tempJJJ;
            if (fruit.Location.X == rXXX && fruit.Location.Y == rYYY || bomba.Location.X == rXXX && bomba.Location.Y == rYYY)
            {
                Speedup(bomba, fruit, score, snake, speedup, panel1);
            }
            for (int k = 0; k <= score; k++)
            {
                if (snake[k].Location.X == rXXX && snake[k].Location.Y == rYYY)
                {
                    Speedup(bomba, fruit, score, snake, speedup, panel1);
                }
            }
            speedup.Location = new Point(rXXX, rYYY);
            panel1.Controls.Add(speedup);
        }
        public void TouchSpeedup(int score, PictureBox[] snake, PictureBox speedup, Panel panel1, Timer timer1, PictureBox bomba, PictureBox fruit)
        {
            if (score <= 45)
            {
                if (score == p + 1)
                {
                    timer1.Interval = 250;
                }
                if (snake[0].Location.X == rXXX && snake[0].Location.Y == rYYY )
                {
                    timer1.Interval = 150;
                    p = score;
                    speedup.Visible = false;
                    rXXX = 0;
                    rYYY = 0;
                }
                if (score % 2 == 0 && score != p && score != pp )
                {
                    pp = score;
                    Speedup(bomba, fruit, score, snake, speedup, panel1);
                    speedup.Visible = true;
                }
            }
            else 
            {
                timer1.Interval = 250;
                speedup.Visible = false;
                rXXX = 0;
                rYYY = 0;
            }


        }
    }
}
