using Microsoft.VisualBasic.CompilerServices;
using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;



namespace Boids
{
    
    public partial class Form1 : Form
    {
        
        List<Boid> boids = new List<Boid>();
        List<QuatreeS> quadrantes = new List<QuatreeS>();
        List<Predador> predadors = new();
        List<Boid> vizinhos = new List<Boid>();

        int separar;
        int convergir;
        int alinhar;
        bool flock;
        int predadores;
        int timerFome = 0;

    public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (var boid in boids)
            {
                e.Graphics.FillEllipse(Brushes.Red, boid.posit.X, boid.posit.Y, boid.tX, boid.tY);
            }
            foreach (var predador in predadors)
            {
                e.Graphics.FillEllipse(Brushes.Black, predador.posit.X, predador.posit.Y, predador.tX, predador.tY);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (boids.Count > 0)
            {
                timerFome++;
            }

            lbl_tempo.Text = timerFome.ToString();
            boids_count.Text = boids.Count.ToString();
            if (flock == true && timerFome > 2)
            {
                foreach (var boid in boids)
                {
                    //boid.Bando(boids, Width, Height, alinhar, separar, convergir);
                    boid.limites(Width, Height);
                    boid.atualizar();
                }

                for (int i = 0; i < quadrantes.Count; i++)
                {
                    quadrantes[i].atualizarBoids(boids);
                    quadrantes[i].atualizarPreds(predadors);
                    if (quadrantes[i].Boids.Count > 0)
                    {
                        vizinhos.AddRange(quadrantes[i].Boids);
                        foreach (var quadrante in quadrantes)
                        {
                            if (quadrante.Boids.Count > 0)
                            {
                                //linha
                                if (quadrante.CordX == quadrantes[i].CordX - 1 && quadrante.CordY == quadrantes[i].CordY)
                                {
                                    vizinhos.AddRange(quadrante.Boids);
                                }
                                if (quadrante.CordX == quadrantes[i].CordX + 1 && quadrante.CordY == quadrantes[i].CordY)
                                {
                                    vizinhos.AddRange(quadrante.Boids);
                                }
                                //coluna
                                if (quadrante.CordY == quadrantes[i].CordY - 1 && quadrante.CordX == quadrantes[i].CordX)
                                {
                                    vizinhos.AddRange(quadrante.Boids);
                                }
                                if (quadrante.CordY == quadrantes[i].CordY + 1 && quadrante.CordX == quadrantes[i].CordX)
                                {
                                    vizinhos.AddRange(quadrante.Boids);
                                }
                                //diagonais
                                if (quadrante.CordX == quadrantes[i].CordX - 1 && quadrante.CordY == quadrantes[i].CordY - 1)
                                {
                                    vizinhos.AddRange(quadrante.Boids);
                                }
                                if (quadrante.CordX == quadrantes[i].CordX + 1 && quadrante.CordY == quadrantes[i].CordY + 1)
                                {
                                    vizinhos.AddRange(quadrante.Boids);
                                }
                                if (quadrante.CordX == quadrantes[i].CordX - 1 && quadrante.CordY == quadrantes[i].CordY + 1)
                                {
                                    vizinhos.AddRange(quadrante.Boids);
                                }
                                if (quadrante.CordX == quadrantes[i].CordX + 1 && quadrante.CordY == quadrantes[i].CordY - 1)
                                {
                                    vizinhos.AddRange(quadrante.Boids);
                                }

                            }
                        }
                        foreach (var boid in quadrantes[i].Boids)
                        {
                            boid.Bando(vizinhos, Width, Height, alinhar, separar, convergir);
                        }
                    }
                    foreach (var predador in quadrantes[i].Predadores)
                    {
                        if (predador.fome > 0)
                        {
                            predador.PredacaoAvancada(vizinhos, Width, Height, alinhar, separar, convergir);
                            Boid morto = predador.predarSimples(vizinhos);
                            if (morto != null)
                            {
                                boids.Remove(morto);
                                predador.fome--;
                            }
                        }
                    }
                    vizinhos.Clear();
                }
            }
            else
            {
                foreach (var boid in boids)
                {
                    boid.limites(Width, Height);
                    boid.atualizar();
                }
                foreach (var predador in predadors)
                {
                    if (predador.fome > 0)
                    {
                        predador.PredacaoAvancada(boids, Width, Height, alinhar, separar, convergir);
                        Boid morto = predador.predarSimples(boids);
                        if (morto != null)
                        {
                            boids.Remove(morto);
                            predador.fome--;
                        }
                    }
                }
            }
            if (predadors.Count > 0)
            {
                foreach (var predador in predadors)
                {
                    if (timerFome % 100 == 0)
                    {
                        predador.fome++;
                    }
                    predador.limites(Width, Height);
                    predador.atualizar();
                }
            }
            Invalidate();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            flock = flockOnOff.Checked;
            timerFome = 0;
            timer1.Enabled = true;
            alinhar = int.Parse(txt_alinhar.Text);
            separar = int.Parse(txt_separar.Text);
            convergir = int.Parse(txt_convergir.Text);
            try
            {
                predadores = int.Parse(txt_predadores.Text);
            }
            catch (Exception)
            {
                predadores = 0;
            }
            
            for (int i = 0; i < int.Parse(textBox1.Text); i++)
            {
   
                Boid boid = new Boid(6,6, 0, 0, 0, 0);                
                boid.nascer(Width, Height, boids);
                boids.Add(boid);
            }

            for (int i = 0; i < (Height / 75) * 10; i++)
            {
                QuatreeS quadrante = new QuatreeS(i, boids, predadors);
                quadrantes.Add(quadrante);
            }

            if (predadores > 0)
            {
                for (int i = 0; i < int.Parse(txt_predadores.Text); i++)
                {
                    Predador predador = new(9, 9, 0, 0, 0, 0, 10);
                    predador.nascer(Width, Height);
                    predadors.Add(predador);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            boids.Clear();
            predadors.Clear();
            quadrantes.Clear();
            timerFome = 0;
        }

        private void sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void flockOnOff_CheckedChanged(object sender, EventArgs e)
        {
            flock = flockOnOff.Checked;
        }

        private void txt_alinhar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                alinhar = int.Parse(txt_alinhar.Text);
            }
            catch (Exception)
            {
                alinhar = 0;
            }
        }

        private void txt_separar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                separar = int.Parse(txt_separar.Text);
            }
            catch (Exception)
            {
                separar = 0;
            }
        }

        private void txt_convergir_TextChanged(object sender, EventArgs e)
        {
            try
            {
                convergir = int.Parse(txt_convergir.Text);
            }
            catch (Exception)
            {
                convergir = 0;
            }
        }
    }
}
