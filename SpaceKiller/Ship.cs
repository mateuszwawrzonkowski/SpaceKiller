using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Space_Killer
{
    class Ship
    {
        Image image;
        public float spaceshipX, spaceshipY;
        public float spaceshipV;

        public Ship (string file)
        {
            image = Image.FromFile(file);
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(new Bitmap(image), spaceshipX, spaceshipY, 31, 71);
        }

        public void Move(float dt)
        {
            float dx;
            dx = spaceshipV * dt;
            spaceshipX += dx;
        }  
    }
}
