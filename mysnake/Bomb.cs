using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace mysnake
{
    class Bomb
    {
        public int rXX, rYY;
        int p;

        public void Bomba(int width, int sizesnake, PictureBox fruit, int score, PictureBox[] snake, PictureBox bomb, Panel panel1)
        {

            Random a = new Random();
            rXX = a.Next(0, width );
            int tempII = rXX % sizesnake;
            rXX -= tempII;
            rYY = a.Next(0, width);
            int tempJJ = rYY % sizesnake;
            rYY -= tempJJ;
            if (fruit.Location.X == rXX && fruit.Location.Y == rYY)
            {
                Bomba( width,  sizesnake,  fruit, score, snake, bomb, panel1);
            }
            for (int k = 0; k <= score; k++)
            {
                if (snake[k].Location.X == rXX && snake[k].Location.Y == rYY)
                {
                    Bomba(width, sizesnake, fruit, score, snake, bomb, panel1);
                }
            }
            bomb.Location = new Point(rXX, rYY);
            panel1.Controls.Add(bomb);
        }
        public void TouchBomb(int width, int sizesnake, PictureBox fruit, int score, PictureBox[] snake, PictureBox bomb, Panel panel1, Timer timer1)
        {
            if (snake[0].Location.X == rXX && snake[0].Location.Y == rYY)
            {
                timer1.Stop();
                Form2 form2 = new Form2();
                form2.Show();

            }
            if (score % 5 == 0 &&  p !=score && score > 0 && score < 70)
            {
                p = score;
                Bomba(width, sizesnake, fruit, score, snake, bomb, panel1);
            }
            if (score == 70)
            {
                bomb.Visible = false;
                rXX = 0;
                rYY = 0;
            }
        }
    }

}
