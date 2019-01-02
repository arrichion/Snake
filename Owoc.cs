using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    class Owoc
    {
        public int x, y, dlugoscBokuSegmentu;

        public void generujOwoc()
        {
            Random r = new Random();
            x = r.Next(0, 20) * dlugoscBokuSegmentu;
            y = r.Next(0, 20) * dlugoscBokuSegmentu;
        }

        public Owoc(int dlugoscBokuSegmentu)
        {
            this.dlugoscBokuSegmentu = dlugoscBokuSegmentu;
            generujOwoc();
        }

        public bool czyGenerowacOwoc(int xGlowa, int yGlowa)
        {
            if (x == xGlowa && y == yGlowa)
            {
                //generujOwoc();
                return true;
            }
            return false;                
        }

        public void rysujOwoc(Graphics g, Brush b)
        {
            g.FillRectangle(b, x, y, dlugoscBokuSegmentu, dlugoscBokuSegmentu);
        }     
    }
}
