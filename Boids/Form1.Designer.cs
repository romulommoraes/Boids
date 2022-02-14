
namespace Boids
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sair = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_alinhar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_separar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_convergir = new System.Windows.Forms.TextBox();
            this.flockOnOff = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_predadores = new System.Windows.Forms.TextBox();
            this.lbl_tempo = new System.Windows.Forms.Label();
            this.boids_count = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(438, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 24);
            this.button1.TabIndex = 0;
            this.button1.Text = "Iniciar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(69, 23);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nº de Boids";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // sair
            // 
            this.sair.Location = new System.Drawing.Point(628, 21);
            this.sair.Name = "sair";
            this.sair.Size = new System.Drawing.Size(89, 24);
            this.sair.TabIndex = 3;
            this.sair.Text = "Sair";
            this.sair.UseVisualStyleBackColor = true;
            this.sair.Click += new System.EventHandler(this.sair_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(533, 22);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(89, 24);
            this.button3.TabIndex = 4;
            this.button3.Text = "Resetar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Alinhar";
            // 
            // txt_alinhar
            // 
            this.txt_alinhar.Location = new System.Drawing.Point(138, 23);
            this.txt_alinhar.Name = "txt_alinhar";
            this.txt_alinhar.Size = new System.Drawing.Size(69, 23);
            this.txt_alinhar.TabIndex = 5;
            this.txt_alinhar.Text = "30";
            this.txt_alinhar.TextChanged += new System.EventHandler(this.txt_alinhar_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Separar";
            // 
            // txt_separar
            // 
            this.txt_separar.Location = new System.Drawing.Point(213, 23);
            this.txt_separar.Name = "txt_separar";
            this.txt_separar.Size = new System.Drawing.Size(69, 23);
            this.txt_separar.TabIndex = 7;
            this.txt_separar.Text = "30";
            this.txt_separar.TextChanged += new System.EventHandler(this.txt_separar_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(288, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Convergir";
            // 
            // txt_convergir
            // 
            this.txt_convergir.Location = new System.Drawing.Point(288, 23);
            this.txt_convergir.Name = "txt_convergir";
            this.txt_convergir.Size = new System.Drawing.Size(69, 23);
            this.txt_convergir.TabIndex = 9;
            this.txt_convergir.Text = "30";
            this.txt_convergir.TextChanged += new System.EventHandler(this.txt_convergir_TextChanged);
            // 
            // flockOnOff
            // 
            this.flockOnOff.AutoSize = true;
            this.flockOnOff.Location = new System.Drawing.Point(78, 27);
            this.flockOnOff.Name = "flockOnOff";
            this.flockOnOff.Size = new System.Drawing.Size(54, 19);
            this.flockOnOff.TabIndex = 11;
            this.flockOnOff.Text = "Flock";
            this.flockOnOff.UseVisualStyleBackColor = true;
            this.flockOnOff.CheckedChanged += new System.EventHandler(this.flockOnOff_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(363, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Predadores";
            // 
            // txt_predadores
            // 
            this.txt_predadores.Location = new System.Drawing.Point(363, 23);
            this.txt_predadores.Name = "txt_predadores";
            this.txt_predadores.Size = new System.Drawing.Size(69, 23);
            this.txt_predadores.TabIndex = 12;
            this.txt_predadores.Text = "1";
            // 
            // lbl_tempo
            // 
            this.lbl_tempo.AutoSize = true;
            this.lbl_tempo.Location = new System.Drawing.Point(628, 2);
            this.lbl_tempo.Name = "lbl_tempo";
            this.lbl_tempo.Size = new System.Drawing.Size(43, 15);
            this.lbl_tempo.TabIndex = 14;
            this.lbl_tempo.Text = "Tempo";
            // 
            // boids_count
            // 
            this.boids_count.AutoSize = true;
            this.boids_count.Location = new System.Drawing.Point(533, 2);
            this.boids_count.Name = "boids_count";
            this.boids_count.Size = new System.Drawing.Size(69, 15);
            this.boids_count.TabIndex = 15;
            this.boids_count.Text = "Nº de Boids";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 711);
            this.Controls.Add(this.boids_count);
            this.Controls.Add(this.lbl_tempo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_predadores);
            this.Controls.Add(this.flockOnOff);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_convergir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_separar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_alinhar);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.sair);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button sair;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_alinhar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_separar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_convergir;
        private System.Windows.Forms.CheckBox flockOnOff;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_predadores;
        private System.Windows.Forms.Label lbl_tempo;
        private System.Windows.Forms.Label boids_count;
    }
}

