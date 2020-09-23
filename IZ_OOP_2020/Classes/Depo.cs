using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IZ_OOP_2020.Classes
{
    class Depo
    {
        private int countOfTrams;
        private int countOfGoodTrams;
        private int countOfBrokenTrams;
        private int[] GoodTramsIDs;
        private int[] BrokenTramsIDs;
        private Tram[] Trams;
        public Depo()
        {
            countOfTrams = 60;
            countOfGoodTrams = 60;
            countOfBrokenTrams = 0;
            BrokenTramsIDs = new int[countOfTrams];
            GoodTramsIDs = new int[countOfTrams];
            Trams = new Tram[60];
            for (int i = 1; i <= countOfTrams; i++)
            {
                //Trams[i] = new Tram(i);
                //GoodTramsIDs[i]=
            }
            
        }
    }
}
