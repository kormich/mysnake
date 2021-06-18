using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mysnake
{
    public class Fruit
    {
        public int _rX, _rY;
        int width = 600;
        int _sizesnake = 40;
        public int score;

        public void Createfruit(PictureBox[] snake, PictureBox fruit,Panel panel1, int rXX, int rYY)
        {
            Random r = new Random();
            _rX = r.Next(0, width );
            int tempI = _rX % _sizesnake;
            _rX -= tempI;
            _rY = r.Next(0, width);
            int tempJ = _rY % _sizesnake;
            _rY -= tempJ;

            for (int i = 0; i <= score; i++)
            {
                if (snake[i].Location.X == _rX && snake[i].Location.Y == _rY || _rX == rXX && _rY == rYY)
                {
                    Createfruit(snake, fruit, panel1, rXX, rYY);
                }
            }

            fruit.Location = new Point(_rX, _rY);
            panel1.Controls.Add(fruit);

        }

        public void eatFruit(PictureBox[] snake, PictureBox fruit, Panel panel1, int _forX,int _forY, int rXX, int rYY, Timer timer1, Label labelScore)
        {
            if (score == 195)
            {
                timer1.Stop();
                Form3 form3 = new Form3();
                form3.Show();
            }
            if (snake[0].Location.X == _rX && snake[0].Location.Y == _rY)
            {
                score += 1;
                labelScore.Text = "Score: " + score;
                snake[score] = new PictureBox();
                snake[score].Location = new Point(snake[score - 1].Location.X - 40 * _forX, snake[score - 1].Location.Y - 40 * _forY);
                snake[score].Size = new Size(_sizesnake, _sizesnake);
                snake[score].BackColor = Color.Green;
                panel1.Controls.Add(snake[score]);
                Createfruit(snake, fruit, panel1, rXX, rYY);
            }


        }

        public void eatItself(PictureBox[] snake, Panel panel1, Label labelScore)
        {
            if (score >= 2)
            {

                if (snake[0].Location == snake[2].Location)
                {
                    for (int j = 1; j <= score; j++)
                        panel1.Controls.Remove(snake[j]);
                    score = 0;
                    labelScore.Text = "Score: " + score;
                }
            }
            for (int i = 1; i <= score; i++)
            {
                if (snake[0].Location == snake[i].Location)
                {
                    for (int j = i; j <= score; j++)
                        panel1.Controls.Remove(snake[j]);
                    score = score - (score - i + 1);
                    labelScore.Text = "Score: " + score;
                }

            }


        }
    }
}
