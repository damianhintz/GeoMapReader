﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMapDomena
{
    /// <summary>
    /// Punkt oparcia obiektu (geometria obiektu).
    /// </summary>
    public class PunktOparciaGeoMap
    {
        public double X;
        public double Y;
        public string Numer;

        public PunktOparciaGeoMap(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
