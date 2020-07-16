
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Killer
{
    class LifeBar
    {
        private readonly int lifeBarPosistionX = 520, lifeBarPositionY = 10, lifeBarHeight = 20;
        public int Health;

        public void Draw(Graphics g)
        {
           
            g.FillRectangle(Brushes.Green, lifeBarPosistionX, lifeBarPositionY, Health, lifeBarHeight);
            g.DrawRectangle(new Pen(Color.Red, 3), new Rectangle(lifeBarPosistionX, lifeBarPositionY, 100, lifeBarHeight));
        }


    }
}
