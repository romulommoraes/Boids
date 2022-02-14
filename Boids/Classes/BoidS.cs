using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boids
{
    class BoidS
    {
        public BoidS(int tX, int tY, int pX, int pY, int vX, int vY)
        {
            this.tX = tX;
            this.tY = tY;
            this.pX = pX;
            this.pY = pY;
            this.vX = vX;
            this.vY = vY;
        }
        public int tX { get; set; }
        public int tY { get; set; }
        public int pX { get; set; }
        public int pY { get; set; }
        public int vX { get; set; }
        public int vY { get; set; }

        public void atualizar()
        {
            this.pX = this.pX + this.vX;
            this.pY = this.pY + this.vY;
        }
        public void nascer(int Width, int Height)
        {

            Random rndX = new Random();
            Random rndY = new Random();
            Random rndvX = new Random();
            Random rndvY = new Random();
            this.pX = rndX.Next(10, Width - 150);
            this.pY = rndY.Next(10, Height - 50);
            this.vX = rndvX.Next(-2, 3);
            this.vY = rndvY.Next(-2, 3);
        }

        public void movAleatorio()
        {
            Random rndMov = new Random();
            int sort = rndMov.Next(0, 15);
            if (sort == 0)
            {
                movSub();
            }
            else if (sort == 10)
            {
                movAdd();
            }
            else
            {
                
            }

        }
        public void movSub()
        {
            Random rndX = new Random();
            Random rndY = new Random();
            this.vX = rndX.Next(-1, 2);
            this.vY = rndY.Next(-1, 2);
            switch (this.vX)
            {
                case 2:
                    this.vX = 1;
                    break;
                case 1:
                    this.vX = this.vX + rndX.Next(-1, 2);
                    break;
                case 0:
                    this.vX = this.vX + rndX.Next(-1, 2);
                    break;
                case -1:
                    this.vX = this.vX + rndX.Next(-1, 2);
                    break;
                case -2:
                    this.vX = -1;
                    break;
                default:
                    break;
            }
            switch (this.vY)
            {
                case 2:
                    this.vY = 1;
                    break;
                case 1:
                    this.vY = this.vY + rndY.Next(-1, 2);
                    break;
                case 0:
                    this.vY = this.vY + rndY.Next(-1, 2);
                    break;
                case -1:
                    this.vY = this.vY + rndY.Next(-1, 2);
                    break;
                case -2:
                    this.vY = -1;
                    break;
                default:
                    break;
            }
        }
        public void movAdd()
        {
            Random rndX = new Random();
            Random rndY = new Random();
            this.vX = rndX.Next(-1, 2);
            this.vY = rndY.Next(-1, 2);
        }

        public void limites(int Width, int Height)
        {
            this.atualizar();

            if (this.pX <= 5 || this.pX >= Width - 130)
            {
                this.vX = this.vX * -1;
            }
            if (this.pY <= 5 || this.pY >= Height - 60)
            {
                this.vY = this.vY * -1;
            }

            if (this.vX > 2 || this.vX < -2)
            {
                this.movAleatorio();
            }
            if (this.vY > 2 || this.vY < -2)
            {
                this.movAleatorio();
            }

            Random movAl = new Random();
            int sort = movAl.Next(0, 5);

            if (sort == 0)
            {
                this.movAleatorio();
            }

        }


    }
}
