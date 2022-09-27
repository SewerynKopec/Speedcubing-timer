using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace SpeedCubeTimer
{
    public partial class Form1 : Form
    {
        Brush [] czerwona_ścianka;
        Brush [] niebieska_ścianka;
        Brush [] zielona_ścianka;
        Brush [] pomarańczowa_ścianka;
        Brush [] biała_ścianka;
        Brush [] żółta_ścianka;
        Czas nowy;
        List<Czas> historia;
        
        public class Czas
        {
            public double time;
            public string algorithm;
        }
        public Form1()
        {
            czerwona_ścianka = new Brush [9];
            niebieska_ścianka = new Brush [9];
            zielona_ścianka = new Brush [9];
            pomarańczowa_ścianka = new Brush [9];
            biała_ścianka = new Brush [9];
            żółta_ścianka = new Brush[9];
            reset_kostki();
            
            timer1 = new Timer();
            historia = new List<Czas>();
            InitializeComponent();
            Scramble();
        }
        private void reset_kostki()
        {
            for (int i = 0; i < 9; i++)
            {
                czerwona_ścianka[i] = Brushes.Red;
                niebieska_ścianka[i] = Brushes.Blue;
                zielona_ścianka[i] = Brushes.Lime;
                pomarańczowa_ścianka[i] = Brushes.Orange;
                biała_ścianka[i] = Brushes.White;
                żółta_ścianka[i] = Brushes.Yellow;
            }
        }
        public enum Ruch
        {
            F,
            U,
            R,
            B,
            D,
            L,
            Fi,
            Ui,
            Ri,
            Bi,
            Di,
            Li,
            F2,
            U2,
            R2,
            B2,
            D2,
            L2
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Pattern(sender, e);
        }
        private void Pattern(object sender, PaintEventArgs e)
        {
            
            int bok = 25;
            int Bspace = 6;
            int Sspace = 2;
            int x = Bspace;
            int y = Bspace;

            Rectangle rec = new Rectangle(x, y, bok, bok);

        //orange

            rec.X = x;  rec.Y = y + 3 * bok + 2 * Sspace + Bspace;
            e.Graphics.FillRectangle(pomarańczowa_ścianka[0], rec);
            rec.X = x;  rec.Y = y + 4 * bok + 3 * Sspace + Bspace;
            e.Graphics.FillRectangle(pomarańczowa_ścianka[1], rec);
            rec.X = x;  rec.Y = y + 5 * bok + 4 * Sspace + Bspace;
            e.Graphics.FillRectangle(pomarańczowa_ścianka[2], rec);

            rec.X = x + 1 * bok + 1 * Sspace; rec.Y = y + 3 * bok + 2 * Sspace + Bspace;
            e.Graphics.FillRectangle(pomarańczowa_ścianka[3], rec);
            rec.X = x + 1 * bok + 1 * Sspace; rec.Y = y + 4 * bok + 3 * Sspace + Bspace;
            e.Graphics.FillRectangle(pomarańczowa_ścianka[4], rec);
            rec.X = x + 1 * bok + 1 * Sspace; rec.Y = y + 5 * bok + 4 * Sspace + Bspace;
            e.Graphics.FillRectangle(pomarańczowa_ścianka[5], rec);

            rec.X = x + 2 * bok + 2 * Sspace; rec.Y = y + 3 * bok + 2 * Sspace + Bspace;
            e.Graphics.FillRectangle(pomarańczowa_ścianka[6], rec);
            rec.X = x + 2 * bok + 2 * Sspace; rec.Y = y + 4 * bok + 3 * Sspace + Bspace;
            e.Graphics.FillRectangle(pomarańczowa_ścianka[7], rec);
            rec.X = x + 2 * bok + 2 * Sspace; rec.Y = y + 5 * bok + 4 * Sspace + Bspace;
            e.Graphics.FillRectangle(pomarańczowa_ścianka[8], rec);

            ///green
            ///
            rec.X = x + 3 * bok + 3 * Sspace + 1 * Bspace; rec.Y = y + 3 * bok + 2 * Sspace + Bspace;
            e.Graphics.FillRectangle(zielona_ścianka[0], rec);
            rec.X = x + 3 * bok + 3 * Sspace + 1 * Bspace; rec.Y = y + 4 * bok + 3 * Sspace + Bspace;
            e.Graphics.FillRectangle(zielona_ścianka[1], rec);
            rec.X = x + 3 * bok + 3 * Sspace + 1 * Bspace; rec.Y = y + 5 * bok + 4 * Sspace + Bspace;
            e.Graphics.FillRectangle(zielona_ścianka[2], rec);

            rec.X = x + 4 * bok + 4 * Sspace + 1 * Bspace; rec.Y = y + 3 * bok + 2 * Sspace + Bspace;
            e.Graphics.FillRectangle(zielona_ścianka[3], rec);
            rec.X = x + 4 * bok + 4 * Sspace + 1 * Bspace; rec.Y = y + 4 * bok + 3 * Sspace + Bspace;
            e.Graphics.FillRectangle(zielona_ścianka[4], rec);
            rec.X = x + 4 * bok + 4 * Sspace + 1 * Bspace; rec.Y = y + 5 * bok + 4 * Sspace + Bspace;
            e.Graphics.FillRectangle(zielona_ścianka[5], rec);

            rec.X = x + 5 * bok + 5 * Sspace + 1 * Bspace; rec.Y = y + 3 * bok + 2 * Sspace + Bspace;
            e.Graphics.FillRectangle(zielona_ścianka[6], rec);
            rec.X = x + 5 * bok + 5 * Sspace + 1 * Bspace; rec.Y = y + 4 * bok + 3 * Sspace + Bspace;
            e.Graphics.FillRectangle(zielona_ścianka[7], rec);
            rec.X = x + 5 * bok + 5 * Sspace + 1 * Bspace; rec.Y = y + 5 * bok + 4 * Sspace + Bspace;
            e.Graphics.FillRectangle(zielona_ścianka[8], rec);

            ///red
            ///
            rec.X = x + 6 * bok + 6 * Sspace + 2 * Bspace; rec.Y = y + 3 * bok + 2 * Sspace + Bspace;
            e.Graphics.FillRectangle(czerwona_ścianka[0], rec);
            rec.X = x + 6 * bok + 6 * Sspace + 2 * Bspace; rec.Y = y + 4 * bok + 3 * Sspace + Bspace;
            e.Graphics.FillRectangle(czerwona_ścianka[1], rec);
            rec.X = x + 6 * bok + 6 * Sspace + 2 * Bspace; rec.Y = y + 5 * bok + 4 * Sspace + Bspace;
            e.Graphics.FillRectangle(czerwona_ścianka[2], rec);

            rec.X = x + 7 * bok + 7 * Sspace + 2 * Bspace; rec.Y = y + 3 * bok + 2 * Sspace + Bspace;
            e.Graphics.FillRectangle(czerwona_ścianka[3], rec);
            rec.X = x + 7 * bok + 7 * Sspace + 2 * Bspace; rec.Y = y + 4 * bok + 3 * Sspace + Bspace;
            e.Graphics.FillRectangle(czerwona_ścianka[4], rec);
            rec.X = x + 7 * bok + 7 * Sspace + 2 * Bspace; rec.Y = y + 5 * bok + 4 * Sspace + Bspace;
            e.Graphics.FillRectangle(czerwona_ścianka[5], rec);

            rec.X = x + 8 * bok + 8 * Sspace + 2 * Bspace; rec.Y = y + 3 * bok + 2 * Sspace + Bspace;
            e.Graphics.FillRectangle(czerwona_ścianka[6], rec);
            rec.X = x + 8 * bok + 8 * Sspace + 2 * Bspace; rec.Y = y + 4 * bok + 3 * Sspace + Bspace;
            e.Graphics.FillRectangle(czerwona_ścianka[7], rec);
            rec.X = x + 8 * bok + 8 * Sspace + 2 * Bspace; rec.Y = y + 5 * bok + 4 * Sspace + Bspace;
            e.Graphics.FillRectangle(czerwona_ścianka[8], rec);

            ///Blue
            
            rec.X = x + 9 * bok + 9 * Sspace + 3 * Bspace; rec.Y = y + 3 * bok + 2 * Sspace + Bspace;
            e.Graphics.FillRectangle(niebieska_ścianka[0], rec);
            rec.X = x + 9 * bok + 9 * Sspace + 3 * Bspace; rec.Y = y + 4 * bok + 3 * Sspace + Bspace;
            e.Graphics.FillRectangle(niebieska_ścianka[1], rec);
            rec.X = x + 9 * bok + 9 * Sspace + 3 * Bspace; rec.Y = y + 5 * bok + 4 * Sspace + Bspace;
            e.Graphics.FillRectangle(niebieska_ścianka[2], rec);

            rec.X = x + 10 * bok + 10 * Sspace + 3 * Bspace; rec.Y = y + 3 * bok + 2 * Sspace + Bspace;
            e.Graphics.FillRectangle(niebieska_ścianka[3], rec);
            rec.X = x + 10 * bok + 10 * Sspace + 3 * Bspace; rec.Y = y + 4 * bok + 3 * Sspace + Bspace;
            e.Graphics.FillRectangle(niebieska_ścianka[4], rec);
            rec.X = x + 10 * bok + 10 * Sspace + 3 * Bspace; rec.Y = y + 5 * bok + 4 * Sspace + Bspace;
            e.Graphics.FillRectangle(niebieska_ścianka[5], rec);

            rec.X = x + 11 * bok + 11 * Sspace + 3 * Bspace; rec.Y = y + 3 * bok + 2 * Sspace + Bspace;
            e.Graphics.FillRectangle(niebieska_ścianka[6], rec);
            rec.X = x + 11 * bok + 11 * Sspace + 3 * Bspace; rec.Y = y + 4 * bok + 3 * Sspace + Bspace;
            e.Graphics.FillRectangle(niebieska_ścianka[7], rec);
            rec.X = x + 11 * bok + 11 * Sspace + 3 * Bspace; rec.Y = y + 5 * bok + 4 * Sspace + Bspace;
            e.Graphics.FillRectangle(niebieska_ścianka[8], rec);

            ///White

            rec.X = x + 3 * bok + 3 * Sspace + 1 * Bspace; rec.Y = y + 0 * bok + 0 * Sspace ;
            e.Graphics.FillRectangle(biała_ścianka[0], rec);
            rec.X = x + 3 * bok + 3 * Sspace + 1 * Bspace; rec.Y = y + 1 * bok + 1 * Sspace ;
            e.Graphics.FillRectangle(biała_ścianka[1], rec);
            rec.X = x + 3 * bok + 3 * Sspace + 1 * Bspace; rec.Y = y + 2 * bok + 2 * Sspace ;
            e.Graphics.FillRectangle(biała_ścianka[2], rec);

            rec.X = x + 4 * bok + 4 * Sspace + 1 * Bspace; rec.Y = y + 0 * bok + 0 * Sspace ;
            e.Graphics.FillRectangle(biała_ścianka[3], rec);
            rec.X = x + 4 * bok + 4 * Sspace + 1 * Bspace; rec.Y = y + 1 * bok + 1 * Sspace ;
            e.Graphics.FillRectangle(biała_ścianka[4], rec);
            rec.X = x + 4 * bok + 4 * Sspace + 1 * Bspace; rec.Y = y + 2 * bok + 2 * Sspace ;
            e.Graphics.FillRectangle(biała_ścianka[5], rec);

            rec.X = x + 5 * bok + 5 * Sspace + 1 * Bspace; rec.Y = y + 0 * bok + 0 * Sspace ;
            e.Graphics.FillRectangle(biała_ścianka[6], rec);
            rec.X = x + 5 * bok + 5 * Sspace + 1 * Bspace; rec.Y = y + 1 * bok + 1 * Sspace ;
            e.Graphics.FillRectangle(biała_ścianka[7], rec);
            rec.X = x + 5 * bok + 5 * Sspace + 1 * Bspace; rec.Y = y + 2 * bok + 2 * Sspace ;
            e.Graphics.FillRectangle(biała_ścianka[8], rec);

            ///Yellow
            ///
            rec.X = x + 3 * bok + 3 * Sspace + 1 * Bspace; rec.Y = y + 6 * bok + 4 * Sspace + 2 * Bspace;
            e.Graphics.FillRectangle(żółta_ścianka[0], rec);
            rec.X = x + 3 * bok + 3 * Sspace + 1 * Bspace; rec.Y = y + 7 * bok + 5 * Sspace + 2 * Bspace;
            e.Graphics.FillRectangle(żółta_ścianka[1], rec);
            rec.X = x + 3 * bok + 3 * Sspace + 1 * Bspace; rec.Y = y + 8 * bok + 6 * Sspace + 2 * Bspace;
            e.Graphics.FillRectangle(żółta_ścianka[2], rec);

            rec.X = x + 4 * bok + 4 * Sspace + 1 * Bspace; rec.Y = y + 6 * bok + 4 * Sspace + 2 * Bspace;
            e.Graphics.FillRectangle(żółta_ścianka[3], rec);
            rec.X = x + 4 * bok + 4 * Sspace + 1 * Bspace; rec.Y = y + 7 * bok + 5 * Sspace + 2 * Bspace;
            e.Graphics.FillRectangle(żółta_ścianka[4], rec);
            rec.X = x + 4 * bok + 4 * Sspace + 1 * Bspace; rec.Y = y + 8 * bok + 6 * Sspace + 2 * Bspace;
            e.Graphics.FillRectangle(żółta_ścianka[5], rec);

            rec.X = x + 5 * bok + 5 * Sspace + 1 * Bspace; rec.Y = y + 6 * bok + 4 * Sspace + 2 * Bspace;
            e.Graphics.FillRectangle(żółta_ścianka[6], rec);
            rec.X = x + 5 * bok + 5 * Sspace + 1 * Bspace; rec.Y = y + 7 * bok + 5 * Sspace + 2 * Bspace;
            e.Graphics.FillRectangle(żółta_ścianka[7], rec);
            rec.X = x + 5 * bok + 5 * Sspace + 1 * Bspace; rec.Y = y + 8 * bok + 6 * Sspace + 2 * Bspace;
            e.Graphics.FillRectangle(żółta_ścianka[8], rec);
        }
        private void Obrót(Ruch ruch)
        {
            if(ruch == Ruch.F)
            {
                Ruch_F();
            }
            if (ruch == Ruch.F2)
            {
                Ruch_F();
                Ruch_F();
            }
            if (ruch == Ruch.Fi)
            {
                Ruch_F();
                Ruch_F();
                Ruch_F();
            }
            if (ruch == Ruch.B)
            {
                Ruch_B();
            }
            if (ruch == Ruch.B2)
            {
                Ruch_B();
                Ruch_B();
            }
            if (ruch == Ruch.Bi)
            {
                Ruch_B();
                Ruch_B();
                Ruch_B();
            }
            if (ruch == Ruch.R)
            {
                Ruch_R();
            }
            if (ruch == Ruch.R2)
            {
                Ruch_R();
                Ruch_R();
            }
            if (ruch == Ruch.Ri)
            {
                Ruch_R();
                Ruch_R();
                Ruch_R();
            }
            if (ruch == Ruch.L)
            {
                Ruch_L();
            }
            if (ruch == Ruch.L2)
            {
                Ruch_L();
                Ruch_L();
            }
            if (ruch == Ruch.Li)
            {
                Ruch_L();
                Ruch_L();
                Ruch_L();
            }
            if (ruch == Ruch.U)
            {
                Ruch_U();
            }
            if (ruch == Ruch.U2)
            {
                Ruch_U();
                Ruch_U();
            }
            if (ruch == Ruch.Ui)
            {
                Ruch_U();
                Ruch_U();
                Ruch_U();
            }
            if (ruch == Ruch.D)
            {
                Ruch_D();
            }
            if (ruch == Ruch.D2)
            {
                Ruch_D();
                Ruch_D();
            }
            if (ruch == Ruch.Di)
            {
                Ruch_D();
                Ruch_D();
                Ruch_D();
            }
        }
        private void Ruch_F()
        {
            Ruch_ścianki(ref zielona_ścianka);
            Swap(ref biała_ścianka[2], ref czerwona_ścianka[0]);
            Swap(ref biała_ścianka[2], ref żółta_ścianka[6]);
            Swap(ref biała_ścianka[2], ref pomarańczowa_ścianka[8]);
            Swap(ref biała_ścianka[5], ref czerwona_ścianka[1]);
            Swap(ref biała_ścianka[5], ref żółta_ścianka[3]);
            Swap(ref biała_ścianka[5], ref pomarańczowa_ścianka[7]);
            Swap(ref biała_ścianka[8], ref czerwona_ścianka[2]);
            Swap(ref biała_ścianka[8], ref żółta_ścianka[0]);
            Swap(ref biała_ścianka[8], ref pomarańczowa_ścianka[6]);
        }
        private void Ruch_B()
        {
            Ruch_ścianki(ref niebieska_ścianka);
            Swap(ref biała_ścianka[6], ref pomarańczowa_ścianka[0]);
            Swap(ref biała_ścianka[6], ref żółta_ścianka[2]);
            Swap(ref biała_ścianka[6], ref czerwona_ścianka[8]);
            Swap(ref biała_ścianka[3], ref pomarańczowa_ścianka[1]);
            Swap(ref biała_ścianka[3], ref żółta_ścianka[5]);
            Swap(ref biała_ścianka[3], ref czerwona_ścianka[7]);
            Swap(ref biała_ścianka[0], ref pomarańczowa_ścianka[2]);
            Swap(ref biała_ścianka[0], ref żółta_ścianka[8]);
            Swap(ref biała_ścianka[0], ref czerwona_ścianka[6]);
        }
        private void Ruch_R()
        {
            Ruch_ścianki(ref czerwona_ścianka);
            Swap(ref biała_ścianka[8], ref niebieska_ścianka[0]);
            Swap(ref biała_ścianka[8], ref żółta_ścianka[8]);
            Swap(ref biała_ścianka[8], ref zielona_ścianka[8]);
            Swap(ref biała_ścianka[7], ref niebieska_ścianka[1]);
            Swap(ref biała_ścianka[7], ref żółta_ścianka[7]);
            Swap(ref biała_ścianka[7], ref zielona_ścianka[7]);
            Swap(ref biała_ścianka[6], ref niebieska_ścianka[2]);
            Swap(ref biała_ścianka[6], ref żółta_ścianka[6]);
            Swap(ref biała_ścianka[6], ref zielona_ścianka[6]);
        }
        private void Ruch_L()
        {
            Ruch_ścianki(ref pomarańczowa_ścianka);
            Swap(ref biała_ścianka[0], ref zielona_ścianka[0]);
            Swap(ref biała_ścianka[0], ref żółta_ścianka[0]);
            Swap(ref biała_ścianka[0], ref niebieska_ścianka[8]);
            Swap(ref biała_ścianka[1], ref zielona_ścianka[1]);
            Swap(ref biała_ścianka[1], ref żółta_ścianka[1]);
            Swap(ref biała_ścianka[1], ref niebieska_ścianka[7]);
            Swap(ref biała_ścianka[2], ref zielona_ścianka[2]);
            Swap(ref biała_ścianka[2], ref żółta_ścianka[2]);
            Swap(ref biała_ścianka[2], ref niebieska_ścianka[6]);
        }
        private void Ruch_U()
        {
            Ruch_ścianki(ref biała_ścianka);
            Swap(ref zielona_ścianka[0], ref pomarańczowa_ścianka[0]);
            Swap(ref zielona_ścianka[0], ref niebieska_ścianka[0]);
            Swap(ref zielona_ścianka[0], ref czerwona_ścianka[0]);
            Swap(ref zielona_ścianka[3], ref pomarańczowa_ścianka[3]);
            Swap(ref zielona_ścianka[3], ref niebieska_ścianka[3]);
            Swap(ref zielona_ścianka[3], ref czerwona_ścianka[3]);
            Swap(ref zielona_ścianka[6], ref pomarańczowa_ścianka[6]);
            Swap(ref zielona_ścianka[6], ref niebieska_ścianka[6]);
            Swap(ref zielona_ścianka[6], ref czerwona_ścianka[6]);
        }
        private void Ruch_D()
        {
            Ruch_ścianki(ref żółta_ścianka);
            Swap(ref zielona_ścianka[2], ref czerwona_ścianka[2]);
            Swap(ref zielona_ścianka[2], ref niebieska_ścianka[2]);
            Swap(ref zielona_ścianka[2], ref pomarańczowa_ścianka[2]);
            Swap(ref zielona_ścianka[5], ref czerwona_ścianka[5]);
            Swap(ref zielona_ścianka[5], ref niebieska_ścianka[5]);
            Swap(ref zielona_ścianka[5], ref pomarańczowa_ścianka[5]);
            Swap(ref zielona_ścianka[8], ref czerwona_ścianka[8]);
            Swap(ref zielona_ścianka[8], ref niebieska_ścianka[8]);
            Swap(ref zielona_ścianka[8], ref pomarańczowa_ścianka[8]);
        }
        private void Swap(ref Brush a, ref Brush b)
        {
            Brush buffor = a;
            a = b;
            b = buffor;            
        }
        private void Ruch_ścianki(ref Brush[] tab)
        {
            Swap(ref tab[0], ref tab[6]);
            Swap(ref tab[0], ref tab[8]);
            Swap(ref tab[0], ref tab[2]);
            Swap(ref tab[1], ref tab[3]);
            Swap(ref tab[1], ref tab[7]);
            Swap(ref tab[1], ref tab[5]);
        }        
        public string Scramble()
        {
            reset_kostki();
            Random r = new Random();
            String text = "";
            Ruch [] scramble = new Ruch[20];
            for (int i =0; i<20; i++)
            {
                scramble[i] = (Ruch) r.Next(18);
                if (warunki_scrambla(i, ref scramble)) i--;
                else
                {
                    Obrót(scramble[i]);
                    if ((int)scramble[i] >=6 && (int)scramble[i] < 12)
                    {
                        dodawanie_apostrofu(ref text, scramble[i]);
                    }
                    else text += scramble[i].ToString() + "  ";
                }
            }
            label1.Text = text;
            panel1.Refresh();
            return text;
        }
        private void dodawanie_apostrofu(ref string text, Ruch ruch)
        {
            if(ruch == Ruch.Fi)
            {
                text += "F'  ";
            }
            if (ruch == Ruch.Bi)
            {
                text += "B'  ";
            }
            if (ruch == Ruch.Ri)
            {
                text += "R'  ";
            }
            if (ruch == Ruch.Li)
            {
                text += "L'  ";
            }
            if (ruch == Ruch.Ui)
            {
                text += "U'  ";
            }
            if (ruch == Ruch.Di)
            {
                text += "D'  ";
            }
        }
        private bool warunki_scrambla(int i, ref Ruch[] scramble)
        {
            if (i > 0 && (int)scramble[i] % 6 == (int)scramble[i - 1] % 6) return true;
            if (i > 1 &&
                (int)scramble[i] % 6 == ((int)scramble[i - 1] + 3) % 6 &&
                (int)scramble[i] % 6 == ((int)scramble[i - 2]) % 6) return true;
            else return false;
        }
        bool ready_flag = false;
        bool running_flag = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            Stoper.Text = "0.00";
            Stoper.ForeColor = Color.Lime;
            timer1.Stop();
            panel1.Visible = false;
            label1.Visible = false;
            dataGridView1.Visible = false;
            ready_flag = true;
        }
        TimeSpan stopwatch;
        private void timer2_Tick(object sender, EventArgs e)
        {
            stopwatch = DateTime.Now - start;
            Stoper.Text = string.Format("{0}.{1}", stopwatch.Seconds, (stopwatch.Milliseconds / 10).ToString("D2"));
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space && ready_flag == false)
            {
                Stoper.ForeColor = Color.Red;
                timer1.Interval = 500;
                timer1.Start();
            }
            if(running_flag == true)
            {
                timer2.Stop();
                running_flag = false;
                ready_flag = false;

                panel1.Visible = true;
                label1.Visible = true;
                dataGridView1.Visible = true;

                nowy = new Czas();
                nowy.time = (double)stopwatch.Seconds + Math.Floor((double)stopwatch.Milliseconds/10)/100 ;
                nowy.algorithm = label1.Text;
                historia.Add(nowy);
                ///double[] tab =  { historia.Count, nowy.time};
                dataGridView1.Rows.Add(historia.Count, nowy.time);
                Scramble();
            }
        }
        DateTime start;
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                if (running_flag == false)
                {
                    if (ready_flag == true)
                    {
                        Stoper.ForeColor = Color.Black;
                        running_flag = true;
                        timer2.Interval = 10;
                        start = DateTime.Now;
                        timer2.Start();
                    }
                    else
                    {
                        Stoper.ForeColor = Color.Black;
                        timer1.Stop();
                    }
                }             
                
            }
        }       
    }
}
