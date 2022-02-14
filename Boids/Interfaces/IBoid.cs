using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Boids
{
    public interface IBoid
    {
        public Vector2 posit { get; set; }
        public Vector2 velocidade { get; set; }
        public Vector2 acc { get; set; }
        public Vector2 direcao { get; set; }
        public Vector2 boost { get; set; }
        public int tX { get; set; }
        public int tY { get; set; }

        public void atualizar();
        public void nascer(int Width, int Height, List<IBoid> boids);
        public Vector2 Alinhar(List<IBoid> boids, int alinhar);
        public Vector2 Convergir(List<IBoid> boids, int conver);
        public Vector2 Separacao(List<IBoid> boids, int separar);
        public Vector2 Boundaries(int width, int height);
        public void Bando(List<IBoid> boid, int width, int height, int alinhar, int separar, int conver);
        public void movAleatorio();
        public void limites(int Width, int Height);
    }
}
