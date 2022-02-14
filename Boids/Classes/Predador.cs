using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Boids
{
    class Predador
    {
        public Vector2 posit;
        public Vector2 velocidade;
        public Vector2 acc;
        public Vector2 boost;
        public Vector2 direcao;
        public Predador(int tX, int tY, int pX, int pY, int vX, int vY, int fome)
        {
            this.tX = tX;
            this.tY = tY;
            this.fome = fome;
            posit = new Vector2(pX, pY);
            velocidade = new Vector2(vX, vY);
            acc = new Vector2(0, 0);
        }

        public int tX { get; set; }
        public int tY { get; set; }
        public int fome { get; set; }

        public void atualizar()
        {
            Random movAl = new Random();
            int sort = movAl.Next(0, 15);

            if (sort == 0)
            {
                this.movAleatorio();
            }

            posit = Vector2.Add(posit, velocidade * 2);

            velocidade = Vector2.Add(velocidade, acc);
            while (velocidade.Length() >= 2)
            {
                velocidade = Vector2.Multiply(velocidade, 0.9f);
            }
            acc = Vector2.Multiply(acc, 0);
        }

        public void nascer(int Width, int Height)
        {

            Random rndX = new Random();
            Random rndY = new Random();
            Random rndvX = new Random();
            Random rndvY = new Random();
            posit.X = rndX.Next(35, Width - 100);
            posit.Y = rndY.Next(100, Height - 100);
            velocidade.X = rndvX.Next(-3, 4);
            velocidade.Y = rndvY.Next(-3, 4);
        }

        public void movAleatorio()
        {
            Random rndX = new Random();
            Random rndY = new Random();

            boost = new Vector2(rndX.Next(-8, 9) / 4, rndY.Next(-8, 9) / 4);

            velocidade = Vector2.Add(velocidade, boost);

        }

        public Boid predarSimples(List<Boid> boids)
        {
            double distancia;
            foreach (var boid in boids)
            {
                distancia = Vector2.Distance(this.posit, boid.posit);
                if (distancia <= 8)
                {
                    this.posit = boid.posit;
                    return boid;
                    //boids.Remove(boid);
                }
            }
            return null;

        }

        public void limites(int Width, int Height)
        {
            //this.atualizar();

            if (posit.X <= 20 || posit.X >= Width - 50)
            {
                velocidade.X = velocidade.X * -2;
            }
            if (posit.Y <= 45 || posit.Y >= Height - 50)
            {
                velocidade.Y = velocidade.Y * -2;
            }
        }

        //--------------------------------- PREDAÇÃO AVANÇADA ------------------------------------//

        public Vector2 Convergir(List<Boid> boids, int conver)
        {
            //var raio = conver;
            int raio = 75;
            direcao = new Vector2(0, 0);
            var numeroPercebido = 0;

            foreach (var boid in boids)
            {
                var d = Vector2.Distance(posit, boid.posit);
                if (d <= raio)
                {
                    direcao = Vector2.Add(direcao, boid.posit);
                    numeroPercebido++;

                }
            }
            if (numeroPercebido > 0)
            {
                direcao = Vector2.Divide(direcao, numeroPercebido);
                direcao = Vector2.Subtract(direcao, posit);
                if (direcao.Length() < 3)
                {
                    direcao.X = direcao.X * 2;
                    direcao.Y = direcao.Y * 2;
                }
                if (direcao.Length() < 3)
                {
                    direcao.X = direcao.X * 2;
                    direcao.Y = direcao.Y * 2;
                }
                if (direcao.Length() > 3)
                {
                    direcao.X = direcao.X * 0.8f;
                    direcao.Y = direcao.Y * 0.8f;
                }
                if (direcao.Length() > 3)
                {
                    direcao.X = direcao.X * 0.8f;
                    direcao.Y = direcao.Y * 0.8f;
                }
                direcao = Vector2.Subtract(direcao, velocidade);
                //direcao.limit(this.maxForce);
                while (direcao.Length() >= 0.30f)
                {
                    direcao = Vector2.Multiply(direcao, 0.9f);
                }

            }
            return direcao;
        }

        public Vector2 Boundaries(int width, int height)
        {
            var d = 30;
            Vector2 desire = new Vector2(0, 0);
            Vector2 steer = new Vector2(0, 0);

            if (this.posit.X < d)
            {
                desire = new Vector2(2, velocidade.Y);
            }
            else if (this.posit.X > width - 50 - d)
            {
                desire = new Vector2(-3, velocidade.Y);
            }
            if (this.posit.Y < d - 40)
            {
                desire = new Vector2(velocidade.X, 3);
            }
            else if (this.posit.Y > height - 50 - d)
            {
                desire = new Vector2(velocidade.X, -3);
            }

            if (desire.X != 0 && desire.Y != 0)
            {
                desire = Vector2.Normalize(desire);
                desire = Vector2.Multiply(desire, 2);
                steer = Vector2.Subtract(desire, velocidade);
                while (steer.Length() > 0.10f)
                {
                    steer = Vector2.Multiply(steer, 0.9f);
                }
                return steer;
            }
            else
            {
                return steer;
            }
        }

        public void PredacaoAvancada(List<Boid> boid, int width, int height, int alinhar, int separar, int conver)
        {
            var convergir = this.Convergir(boid, conver);
            acc = Vector2.Add(acc, convergir);
            var steer = this.Boundaries(width, height);
            acc = Vector2.Add(acc, steer);

        }
    }
}
