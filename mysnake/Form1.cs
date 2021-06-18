using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mysnake
{
    public partial class Form1 : Form
    {
        public Label labelScore;
        public int width = 600;
        public int height = 600;
        public int sizesnake = 40;
        public int forX, forY;
        public int rX, rY;
        public int rXX, rYY;
        public PictureBox fruit;
        public PictureBox bomb;
        public PictureBox speedup;
        public PictureBox[] snake = new PictureBox[400];
        Snake snakee = new Snake();
        Fruit fruit1 = new Fruit();
        Bomb bomba = new Bomb();
        Speed speed = new Speed();
        public int h = 0, m = 0, s=0;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public Form1()
        {
            InitializeComponent();
            this.Width = width + 60;
            this.Height = height + 120;
            Map map = new Map(this.width, this.height, sizesnake, panel1);

            timer2.Interval = 1000;
 

            label1.Text = "00 :";
            label2.Text = "00";
            label3.Text = "00 :";
            timer2.Start();

            labelScore = new Label();
            labelScore.Text = "Score: 0";
            labelScore.Location = new Point(170, 10);
            this.Controls.Add(labelScore);

            snake[0] = new PictureBox();
            snake[0].Location = new Point(400, 400);
            snake[0].Size = new Size(sizesnake, sizesnake);
            snake[0].BackColor = Color.Green;
            panel1.Controls.Add(snake[0]);


            timer1.Tick += new EventHandler(update);
            timer1.Interval = 250;
            timer1.Start();
            this.KeyDown += new KeyEventHandler(snakee.Run);

            fruit = new PictureBox();
            fruit.BackColor = Color.Red;
            fruit.Size = new Size(sizesnake, sizesnake);
            fruit1.Createfruit(snake, fruit, panel1, bomba.rXX, bomba.rYY);

            bomb = new PictureBox();
            bomb.BackColor = Color.Black;
            bomb.Size = new Size(sizesnake, sizesnake);
            bomba.Bomba( width,  sizesnake, fruit,  fruit1.score, snake, bomb,  panel1);

            speedup = new PictureBox();
            speedup.BackColor = Color.Yellow;
            speedup.Size = new Size(sizesnake, sizesnake);
            speed.Speedup(bomb, fruit, fruit1.score, snake, speedup, panel1);

        }
        public void timer2_Tick(object sender, EventArgs e)
        {

            if (s < 59)
            {
                s++;
                if (s < 10)
                    label2.Text = "0" + s.ToString();
                else
                    label2.Text = s.ToString();
            }
            else
            {
                if (m < 59)
                {
                    m++;
                    if (m < 10)
                        label1.Text = "0" + m.ToString() + ":";
                    else
                        label1.Text = m.ToString() + ":";
                    s = 0;
                    label2.Text = "00";

                }
                else
                {
                    m = 0;
                    label1.Text = "00 :";
                }
            }
            if (m==59 && s==59)
            {
                h++;
                if (h < 10)
                    label3.Text = "0" + h.ToString() + ":";
                else
                    label3.Text = h.ToString() + ":";

            }
        }

        public void update(Object myObject, EventArgs eventsArgs)
        {

            fruit1.eatItself(snake, panel1, labelScore);
            fruit1.eatFruit(snake, fruit, panel1, snakee._forX, snakee._forY, bomba.rXX, bomba.rYY, timer1, labelScore);
            snakee.moveSnake(snake, fruit1.score);
            bomba.TouchBomb(width, sizesnake, fruit, fruit1.score, snake, bomb, panel1, timer1);
            speed.TouchSpeedup(fruit1.score, snake, speedup, panel1, timer1, bomb, fruit);
        }

    }
}
