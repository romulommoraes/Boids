using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boids
{
    class Boid
    {
        public Vector2 posit;
        public Vector2 velocidade;
        public Vector2 acc;
        public Vector2 direcao;
        public Vector2 boost;
        public Boid(int tX, int tY, int pX, int pY, int vX, int vY)
        {
            
            this.tX = tX;
            this.tY = tY;
            posit = new Vector2(pX, pY);
            velocidade = new Vector2(vX, vY);
            acc = new Vector2(0, 0);


        }
        public int tX { get; set; }
        public int tY { get; set; }


        public void atualizar()
        {
            Random movAl = new Random();
            int sort = movAl.Next(0, 25);

            if (sort == 0)
            {
                this.movAleatorio();
            }

            posit = Vector2.Add(posit, velocidade*2);
            
            velocidade = Vector2.Add(velocidade, acc);
            while (velocidade.Length() >= 2)
            {
                velocidade = Vector2.Multiply(velocidade, 0.9f);
            }
            acc = Vector2.Multiply(acc, 0);
        }
        public void nascer(int Width, int Height, List<Boid> boids)
        {            
            Random rndX = new Random();
            Random rndY = new Random();
            Random rndvX = new Random();
            Random rndvY = new Random();
            List<Vector2> Lcds = new();
            List<Vector2> LcdY = new();
            float cdX;
            float cdY;
            Vector2 cord;
            Vector2 cord2;

            foreach (Boid boid in boids)
            {
                cord = new Vector2(boid.posit.X, boid.posit.Y);
            }

                cdX = rndX.Next(35, Width - 100);
                cdY = rndY.Next(100, Height - 100);
                cord2 = new Vector2(cdX, cdY);
            while (Lcds.Contains(cord2))
            {
                cdX = rndX.Next(35, Width - 100);
                cdY = rndY.Next(100, Height - 100);
                cord2 = new Vector2(cdX, cdY);
            }

            posit.X = cdX;
            posit.Y = cdY;
            
            velocidade.X = rndvX.Next(-3, 4);
            velocidade.Y = rndvY.Next(-3, 4);
        }

        public Vector2 Alinhar(List<Boid> boids, int alinhar)
        {
            int raio = alinhar;
            direcao = new Vector2(0, 0);
            var numeroPercebido = 0;

            foreach (var boid in boids)
            {
                var d = Vector2.Distance(posit, boid.posit);
                if (boid != this && d <= raio)
                {
                    direcao = Vector2.Add(boid.velocidade, direcao);
                    numeroPercebido++;
                }
            }
            if (numeroPercebido > 0)
                {
                    direcao = Vector2.Divide(direcao, numeroPercebido);
                    if (direcao.Length() < 2)
                    {
                        direcao.X = direcao.X * 2;
                        direcao.Y = direcao.Y * 2;
                    }
                    if (direcao.Length() < 2)
                    {
                        direcao.X = direcao.X * 2;
                        direcao.Y = direcao.Y * 2;
                    }
                    if (direcao.Length() > 2)
                    {
                        direcao.X = direcao.X * 0.8f;
                        direcao.Y = direcao.Y * 0.8f;
                    }
                    if (direcao.Length() > 2)
                    {
                        direcao.X = direcao.X * 0.8f;
                        direcao.Y = direcao.Y * 0.8f;
                    }
                    direcao = Vector2.Subtract(direcao, velocidade);

                    while (direcao.Length() >= 0.20f)
                    {
                        direcao = Vector2.Multiply(direcao, 0.9f);
                    }
                }

            
            return direcao;
        }

        public Vector2 Convergir(List<Boid> boids, int conver)
        {
            var raio = conver;
            direcao = new Vector2(0, 0);
            var numeroPercebido = 0;

            foreach (var boid in boids)
            {
                var d = Vector2.Distance(posit, boid.posit);
                if (boid != this && d <= raio)
                {
                    direcao = Vector2.Add(direcao, boid.posit);
                    numeroPercebido++;
                }
            }
            if (numeroPercebido > 0)
                {
                    direcao = Vector2.Divide(direcao, numeroPercebido);
                    direcao = Vector2.Subtract(direcao, posit);
                    if (direcao.Length() < 2)
                    {
                        direcao.X = direcao.X * 2;
                        direcao.Y = direcao.Y * 2;
                    }
                    if (direcao.Length() < 2)
                    {
                        direcao.X = direcao.X * 2;
                        direcao.Y = direcao.Y * 2;
                    }
                    if (direcao.Length() > 2)
                    {
                        direcao.X = direcao.X * 0.8f;
                        direcao.Y = direcao.Y * 0.8f;
                    }
                    if (direcao.Length() > 2)
                    {
                        direcao.X = direcao.X * 0.8f;
                        direcao.Y = direcao.Y * 0.8f;
                    }
                    direcao = Vector2.Subtract(direcao, velocidade);
                    //direcao.limit(this.maxForce);
                    while (direcao.Length() >= 0.20f)
                    {
                        direcao = Vector2.Multiply(direcao, 0.9f);
                    }
                }            
            return direcao;
        }

        public Vector2 Separacao(List<Boid> boids, int separar)
        {
            var raio = separar;
            direcao = new Vector2(0, 0);
            var numeroPercebido = 0;
            foreach (var boid in boids)
            {
                var d = Vector2.Distance(this.posit, boid.posit);
                if (this != boid && d <= raio)
                {

                    var diff = Vector2.Subtract(this.posit, boid.posit);
                    diff = Vector2.Divide(diff, d);
                    direcao = Vector2.Add(direcao, diff);
                    numeroPercebido++;
                }
            }
            if (numeroPercebido > 0)
                {
                    direcao = Vector2.Divide(direcao, numeroPercebido);
                    if (direcao.Length() < 2)
                    {
                        direcao.X = direcao.X * 2;
                        direcao.Y = direcao.Y * 2;
                    }
                    if (direcao.Length() < 2)
                    {
                        direcao.X = direcao.X * 2;
                        direcao.Y = direcao.Y * 2;
                    }
                    if (direcao.Length() > 2)
                    {
                        direcao.X = direcao.X * 0.8f;
                        direcao.Y = direcao.Y * 0.8f;
                    }
                    if (direcao.Length() > 2)
                    {
                        direcao.X = direcao.X * 0.8f;
                        direcao.Y = direcao.Y * 0.8f;
                    }

                    direcao = Vector2.Subtract(direcao, velocidade);
                    while (direcao.Length() >= 0.20f)
                    {
                        direcao = Vector2.Multiply(direcao, 0.9f);
                    }
                }

            
            return direcao;

        }


        public Vector2 Boundaries(int width, int height)
        {
            var d = 50;
            Vector2 desire = new Vector2(0, 0);
            Vector2 steer = new Vector2(0, 0);

                if (this.posit.X < d)
                {
                    desire = new Vector2(2, velocidade.Y);
                }
                else if (this.posit.X > width - 20 - d)
                {
                    desire = new Vector2(-3, velocidade.Y);
                }
                if (this.posit.Y < d-40)
                {
                    desire = new Vector2(velocidade.X, 3);
                }
                else if (this.posit.Y > height -10 - d)
                {
                    desire = new Vector2(velocidade.X, -3);
                }


                if (desire.X != 0 && desire.Y != 0)
                {
                    desire = Vector2.Normalize(desire);
                    desire = Vector2.Multiply(desire, 2);
                    steer = Vector2.Subtract(desire, velocidade);
                    while (steer.Length() > 0.50f)
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



        public void Bando(List<Boid> boid, int width, int height, int alinhar, int separar, int conver)
        {
            var alinhamento = this.Alinhar(boid, alinhar);
            acc = Vector2.Add(acc, alinhamento);
            var convergir = this.Convergir(boid, conver);
            acc = Vector2.Add(acc, convergir);
            var separacao = this.Separacao(boid, separar);
            acc = Vector2.Add(acc, separacao);
            var steer = this.Boundaries(width, height);
            acc = Vector2.Add(acc, steer);
        }

        public void movAleatorio()
        {
            Random rndX = new Random();
            Random rndY = new Random();
            boost = new Vector2(rndX.Next(-8, 9)/4, rndY.Next(-8, 9)/4);
            velocidade = Vector2.Add(velocidade, boost);
        }
      
        public void limites(int Width, int Height)
        {
            if (posit.X <= 20 || posit.X >= Width - 50)
            {
                velocidade.X = velocidade.X * -2;
            }
            if (posit.Y <= 45 || posit.Y >= Height - 50)
            {
                velocidade.Y = velocidade.Y * -2;
            }
        }
    }
}
