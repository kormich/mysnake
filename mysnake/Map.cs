using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mysnake
{

     class Map
    {
        private int _width;
        private int _height;
        private int _sizesnake;

        public Map(int width, int height, int sizesnake, Panel controlPanel)
        {
            _width = width;
            _height = height;
            _sizesnake = sizesnake;
            controlPanel.Width = _width+60 ;
            controlPanel.Height = _height+120 ;
            CreateMap(controlPanel);
        }

        public void CreateMap(Panel panel)
        {
            for (int i = 0; i <= _width / _sizesnake; i++)
            {
                PictureBox lines = new PictureBox();
                lines.BackColor = Color.Black;
                lines.Location = new Point(0, _sizesnake * i);
                lines.Size = new Size(_width , 1);
                panel.Controls.Add(lines);
            }
            for (int i = 0; i <= _height / _sizesnake; i++)
            {
                PictureBox lines = new PictureBox();
                lines.BackColor = Color.Black;
                lines.Location = new Point(_sizesnake * i, 0);
                lines.Size = new Size(1, _width );
                panel.Controls.Add(lines);
            }
        }
    }      
}
        
