﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoMapDomena;

namespace GeoMapReader.Parser
{
    /// <summary>
    /// Parser rekordu punktu oparcia.
    /// </summary>
    static class PunktParser
    {
        public static PunktOparcia ParsePunkt(this string record)
        {
            //P 1  5594582.150  6456464.390   180.6200,4046
            if (string.IsNullOrEmpty(record)) throw new ArgumentNullException("Rekord punktu oparcia jest pusty");
            if (!record.StartsWith("P ")) throw new ArgumentException("Rekord punktu oparcia nie zaczyna się od P");
            var pola = record.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (pola.Length < 4) throw new ArgumentException("Rekord punktu oparcia ma za mało pól");
            var xString = pola[2];
            var yString = pola[3];
            var x = double.Parse(xString);
            var y = double.Parse(yString);
            var punkt = new PunktOparcia(x, y);
            return punkt;
        }
    }
}
