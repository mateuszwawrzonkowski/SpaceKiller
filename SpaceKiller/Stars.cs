using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Killer

{
    class Stars
    {
        public Stars (int backgroundSpeed)
        {
            this.backgroundSpeed = backgroundSpeed;
        }

        /* private int positionX, positionY, size;*/
        private int backgroundVertical = 0, backgroundVertical1 = 480;
        public int backgroundSpeed;
        public void Draw(Graphics g)
        {
            /* Random rnd = new Random();

                 for (int i = 0; i <= 2; i++)
                 {
                     positionX = rnd.Next(0, 640);
                     positionY = rnd.Next(0, 1000);
                     size = rnd.Next(1, 3);
                     g.DrawEllipse(Pens.White, positionX, positionY, size, size);
                     g.FillEllipse(Brushes.White, positionX, positionY, size, size);
                 }
            */

            g.DrawImage(new Bitmap(@".\Resources\stars_bg_0.png"), 0, backgroundVertical, 999, 508);
            g.DrawImage(new Bitmap(@".\Resources\stars_bg_1.png"), 0, backgroundVertical1, 999, 508);


        }
        public void BackgroundMoving()
        {
            if (backgroundVertical > 480)
            {
                backgroundVertical = -480;
            }
            if (backgroundVertical1 > 480)
            {
                backgroundVertical1 = -480;
            }
            backgroundVertical += backgroundSpeed;
            backgroundVertical1 += backgroundSpeed;
        }



    }
}
