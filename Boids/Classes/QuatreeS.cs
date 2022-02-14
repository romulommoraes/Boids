using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Boids
{
    class QuatreeS
    {
        public QuatreeS(int codigo, List<Boid> boids, List<Predador> predadores)
        {
            Codigo = codigo;
            CordX = getCordX();
            CordY = getCordY();

            LimitesX = getlimitesX();
            LimitesY = getlimitesY();
            Boids = getBoids(boids);
            Predadores = getPredadores(predadores);
            Limitrofe = getLimitrofe();

        }

        public int Codigo { get; set; }
        public List<Boid> Boids { get; set; }

        public List<Predador> Predadores { get; set; }
        public double[] LimitesX { get; set; }
        public double[] LimitesY { get; set; }
        public double CordX { get; set; }
        public double CordY { get; set; }
        public bool Limitrofe { get; set; }



        public double getCordX()
        {
            if (Codigo <10)
            {
                return Codigo+1;
            }
            else if (Codigo >= 10 && Codigo < 20)
            {
                return (Codigo - 10) +1;
            }
            else if (Codigo >= 20 && Codigo < 30)
            {
                return (Codigo - 20) + 1;
            }
            else if (Codigo >= 30 && Codigo < 40)
            {
                return (Codigo - 30) + 1;
            }
            else if (Codigo >= 40 && Codigo < 50)
            {
                return (Codigo - 40) + 1;
            }
            else if (Codigo >= 50 && Codigo < 60)
            {
                return (Codigo - 50) + 1;
            }
            else if (Codigo >= 60 && Codigo < 70)
            {
                return (Codigo - 60) + 1;
            }
            else if (Codigo >= 70 && Codigo < 80)
            {
                return (Codigo - 70) + 1;
            }
            else if (Codigo >= 80 && Codigo < 90)
            {
                return (Codigo - 80) + 1;
            }
            else if (Codigo >= 90 && Codigo < 100)
            {
                return (Codigo - 90) + 1;
            }
            else
            {
                return 99;
            }
        }
        public double getCordY()
        { 
          double CordY = Codigo / 10;
          return Math.Round(CordY+1, 0);
        }

        public double[] getlimitesX()
        {
            double[] arrX = new double[2] { (CordX - 1) * 75, (CordX * 75)-1 };
            return arrX ;
        }

        public double[] getlimitesY()
        {
            double[] arrY = new double[2] { (CordY - 1) * 75, (CordY * 75) - 1 };
            return arrY;
        }

        public List<Boid> getBoids(List<Boid> boids)
        {
            List<Boid> contidos = new List<Boid>();
            foreach (Boid boid in boids)
            {
                if (boid.posit.X >= LimitesX[0] && boid.posit.X <= LimitesX[1] && boid.posit.Y >= LimitesY[0] && boid.posit.Y <= LimitesY[1])
                {
                    contidos.Add(boid);
                }
            }
            return contidos;
        }

        public List<Predador> getPredadores(List<Predador> predadors)
        {
            List<Predador> contidos = new List<Predador>();
            foreach (Predador predador in predadors)
            {
                if (predador.posit.X >= LimitesX[0] && predador.posit.X <= LimitesX[1] && predador.posit.Y >= LimitesY[0] && predador.posit.Y <= LimitesY[1])
                {
                    contidos.Add(predador);
                }
            }
            return contidos;
        }

        public void atualizarBoids(List<Boid> boids)
        {
            List<Boid> contidos = new List<Boid>();
            foreach (Boid boid in boids)
            {
                if (boid.posit.X >= LimitesX[0] && boid.posit.X <= LimitesX[1] && boid.posit.Y >= LimitesY[0] && boid.posit.Y <= LimitesY[1])
                {
                    contidos.Add(boid);
                }
            }
            Boids = contidos;
        }

        public void atualizarPreds(List<Predador> predadores)
        {
            List<Predador> contidos = new();
            foreach (Predador predador in predadores)
            {
                if (predador.posit.X >= LimitesX[0] && predador.posit.X <= LimitesX[1] && predador.posit.Y >= LimitesY[0] && predador.posit.Y <= LimitesY[1])
                {
                    contidos.Add(predador);
                }
            }
            Predadores = contidos;
        }

        public bool getLimitrofe() //da pra otimizar ou retirar

        {
            bool limit = false;

            if (CordY == 1 )
            {
                limit = true;
            }
            if (CordY == 10)
            {
                limit = true;
            }
            if (CordX == 1)
            {
                limit = true;
            }
            if (CordX == 10)
            {
                limit = true;
            }

            return limit;
        }
    }


}

