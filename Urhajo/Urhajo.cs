using System;
using System.Collections.Generic;
using System.Text;

namespace Urhajo
{
    public class UrhajoAdat
    {
        public string Nev { get; set; }
        public int Legenyseg { get; set; }
        public int MaxHatotav { get; set; }
        public int UzemenyagSzint { get; set; }
        public string Gyarto { get; set; }
        public string KuldetesStatusz { get; set; }
        public int InditasEve { get; set; }

        public UrhajoAdat(string nev, int legenyseg, int maxHatotav,
            int uzemenyagSzint, string gyarto, string kuldetesStatusz,
            int inditasEve)
        {
            Nev = nev;
            Legenyseg = legenyseg;
            MaxHatotav = maxHatotav;
            UzemenyagSzint = uzemenyagSzint;
            Gyarto = gyarto;
            KuldetesStatusz = kuldetesStatusz;
            InditasEve = inditasEve;
        }
    }
}
