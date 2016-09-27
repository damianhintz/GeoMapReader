using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMapDomena
{
    /// <summary>
    /// Reprezentuje operat przypisany do obiektu.
    /// </summary>
    public class Operat
    {
        public string Numer;
        public string Data;
        public string Operator;

        public Operat(string numer)
        {
            if (string.IsNullOrEmpty(numer)) throw new ArgumentNullException("Numer operatu nie może być pusty");
            Numer = numer;
        }
    }
}
