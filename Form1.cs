using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        private bool czyGraJestAktywna;
        private Waz snake;
        private Owoc owoc;

        public Form1()
        {
            InitializeComponent();
            czyGraJestAktywna = false;
            timer1.Enabled = true;
            pauzaToolStripMenuItem.Enabled = false;
            resetToolStripMenuItem.Enabled = false;
        }

        private void poleGry_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {         
            if (czyGraJestAktywna)
            {
                startToolStripMenuItem.Enabled = false;
                resetToolStripMenuItem.Enabled = true;
                poleGry.CreateGraphics().Clear(Color.Black);
                snake.move();
                snake.rysuj(poleGry.CreateGraphics(), new SolidBrush(Color.Aqua));
                owoc.rysujOwoc(poleGry.CreateGraphics(), new SolidBrush(Color.Red));
                if (owoc.czyGenerowacOwoc(snake.x[0], snake.y[0]))
                {
                    while(!snake.czyPoleJestWolne(owoc.x, owoc.y))
                        owoc.generujOwoc();
                    snake.dodajSegment();
                }                    
                if (!snake.czyWazZyje())
                {
                    czyGraJestAktywna = false;
                    startToolStripMenuItem.Enabled = true;
                    pauzaToolStripMenuItem.Enabled = false;
                }
            }
            else
            {                
                FontFamily fontFamily1 = new FontFamily("Arial");
                Font f = new Font(fontFamily1, 15);
                Brush b = new SolidBrush(Color.White);

                if (pauzaToolStripMenuItem.Text == "Wznów")
                    poleGry.CreateGraphics().DrawString("PAUZA", f, b, 100, 138);
                else
                    poleGry.CreateGraphics().DrawString("Naciśnij 'Start'", f, b, 80, 138);
            }            
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            czyGraJestAktywna = true;
            snake = new Waz(poleGry.Width);
            owoc = new Owoc(snake.dlugoscBokuSegmentu);
            pauzaToolStripMenuItem.Enabled = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up && snake.ruch != "dol")
                snake.ruch = "gora";
            if (e.KeyCode == Keys.Down && snake.ruch != "gora")
                snake.ruch = "dol";
            if (e.KeyCode == Keys.Right && snake.ruch != "lewo")
                snake.ruch = "prawo";
            if (e.KeyCode == Keys.Left && snake.ruch != "prawo")
                snake.ruch = "lewo";
        }

        private void pauzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (czyGraJestAktywna)
            {
                czyGraJestAktywna = false;
                pauzaToolStripMenuItem.Text = "Wznów";
                poleGry.CreateGraphics().Clear(Color.Black);                
            }
            else
            {
                czyGraJestAktywna = true;
                pauzaToolStripMenuItem.Text = "Pauza";
                resetToolStripMenuItem.Enabled = true;
            }
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            czyGraJestAktywna = true;
            snake = new Waz(poleGry.Width);
            owoc = new Owoc(snake.dlugoscBokuSegmentu);
            pauzaToolStripMenuItem.Text = "Pauza";
        }

        private void szybciejToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (timer1.Interval > 10)
                timer1.Interval -= 10;
        }

        private void wolniejToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Interval += 10;
        }
    }
}
