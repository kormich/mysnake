using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mysnake
{
    public class Snake
    {
        public int _forX;
        public int _forY;
        int sizesnake = 40;

        


        public void Run(object sender, KeyEventArgs a)
        {
            switch (a.KeyCode.ToString())
            {
                case "Right":

                    _forX = 1;
                    _forY = 0;

                    break;

                case "Left":

                    _forX = -1;
                    _forY = 0;

                    break;
                case "Up":

                    _forY = -1;
                    _forX = 0;

                    break;
                case "Down":

                    _forY = 1;
                    _forX = 0;

                    break;
            }

        }
        public void moveSnake(PictureBox[] snake,int score)
        {
            for (int i = score; i >= 1; i--)
            {
                snake[i].Location = new Point(snake[i - 1].Location.X, snake[i - 1].Location.Y);

            }

            snake[0].Location = new Point(snake[0].Location.X + _forX * sizesnake, snake[0].Location.Y + _forY * sizesnake);

            if (snake[0].Location.X < 0)
            {
                snake[0].Location = new Point(560, snake[0].Location.Y + _forY * sizesnake);

            }
            if (snake[0].Location.X > 560)
            {
                snake[0].Location = new Point(0, snake[0].Location.Y + _forY * sizesnake);
            }

            if (snake[0].Location.Y < 0)
            {
                snake[0].Location = new Point(snake[0].Location.X + _forX * sizesnake, 560);
            }

            if (snake[0].Location.Y > 560)
            {
                snake[0].Location = new Point(snake[0].Location.X + _forX * sizesnake, 0);
            }


        }

     
    }
}
