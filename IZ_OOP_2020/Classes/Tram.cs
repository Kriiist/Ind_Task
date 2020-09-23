using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IZ_OOP_2020.Classes
{
    public class Tram
    {
        public bool IsGood = true;
        public bool OnLine = false;
        public int LineNum = 0;
        public int LastPart = 0;
        //public LineSys LS;


        public Tram()
        {

        }

        /*public void Move()
        {


            PictureBox tr = new PictureBox();
            tr.Visible = true;
            LS.line[LineNum].linePart[LastPart].Pic.Visible = true;
            for (; LastPart < LS.line[LineNum].CountOfStations - 2; LastPart++)
            {
                Thread.Sleep(1000);
                LS.line[LineNum].linePart[LastPart].Pic.Visible = false;
                if (LastPart == LS.line[LineNum].CountOfStations - 3)
                {
                    LastPart = 0;
                }
                LS.line[LineNum].linePart[LastPart + 1].Pic.Visible = true;
            }
        }*/

        public typeCrash checkCrash()
        {
            Random rnd = new Random();
            int rand = rnd.Next(1, 500);
            if (rand <= 1)
            {
                int []ran = new int[3];
                ran[0] = rnd.Next(1, 90);
                ran[1] = rnd.Next(1, 90);
                ran[2] = rnd.Next(1, 90);
                typeCrash TC = new typeCrash();
                for (int i = 0; i < 3; i++)
                {
                    if (ran[i] <= 30)
                        TC.electric = true;
                    if (ran[i] > 30 && ran[i] <= 60)
                        TC.mechanic = true;
                    if (ran[i] > 60 && ran[i] <= 90)
                        TC.rail = true;
                }
                SystemSounds.Exclamation.Play();
                return TC;

            }
            else
            {
                return null;
            }
           


        }

    }
}
