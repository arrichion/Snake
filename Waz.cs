using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    class Waz
    {
        public int liczbaSegmentow;
        public int dlugoscBokuSegmentu;
        public int[] x = new int[900];
        public int[] y = new int[900];
        public string ruch;

        public Waz(int szerokoscOknaDoGry)
        {
            dlugoscBokuSegmentu = szerokoscOknaDoGry / 20;
            liczbaSegmentow = 3;
            ruch = "prawo";
            int xGlowa = 9 * dlugoscBokuSegmentu;
            int yGlowa = 9 * dlugoscBokuSegmentu;
            for (int i = 0; i < liczbaSegmentow; ++i)
            {
                x[i] = xGlowa - (i * dlugoscBokuSegmentu);
                y[i] = yGlowa;
            }
        }

        public void move()
        {
            for (int i = liczbaSegmentow - 1; i > 0; --i)
            {
                x[i] = x[i - 1];
                y[i] = y[i - 1];
            }
                if (ruch == "lewo")
                    x[0] -= dlugoscBokuSegmentu;
                if (ruch == "prawo")
                    x[0] += dlugoscBokuSegmentu;
                if (ruch == "gora")
                    y[0] -= dlugoscBokuSegmentu;
                if (ruch == "dol")
                    y[0] += dlugoscBokuSegmentu;

                //przekraczanie granicy ekranu
                if (x[0] < 0)
                    x[0] = dlugoscBokuSegmentu * 19;
                if (x[0] > dlugoscBokuSegmentu * 19)
                    x[0] = 0;
                if (y[0] < 0)
                    y[0] = dlugoscBokuSegmentu * 19;
                if (y[0] > dlugoscBokuSegmentu * 19)
                    y[0] = 0;
        }

        public void rysuj(Graphics g, Brush b)
        {
            g.FillRectangle(new SolidBrush(Color.LightGreen), x[0], y[0], dlugoscBokuSegmentu, dlugoscBokuSegmentu);
            for (int i = 1; i < liczbaSegmentow; ++i)
            {
                g.FillRectangle(b, x[i], y[i], dlugoscBokuSegmentu, dlugoscBokuSegmentu);
            }
        }

        public void dodajSegment()
        {
            x[liczbaSegmentow] = x[liczbaSegmentow - 1];
            y[liczbaSegmentow] = y[liczbaSegmentow - 1];
            liczbaSegmentow = liczbaSegmentow + 1;
        }

        public bool czyWazZyje()
        {
            for (int i = 1; i < liczbaSegmentow; ++i)
            {
                if (x[i] == x[0] && y[i] == y[0])
                    return false;
            }
            return true;
        }

        public bool czyPoleJestWolne(int a, int b)
        {
            for (int i = 0; i < liczbaSegmentow; ++i)
            {
                if (x[i] == a && y[i] == b)
                    return false;
            }
            return true;
        }

    }
}
