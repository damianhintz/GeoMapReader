using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMapDomena
{
    /// <summary>
    /// Klasa obiektu na mapie.
    /// </summary>
    public class Nagłówek
    {
        public int Klasa { get { return _code / 1000; } }
        public int GrupaTematyczna { get { return int.Parse(_code.ToString()[1].ToString()); } }
        public int PodgrupaTematyczna { get { return _code / 1000; } }
        public int Obiekt { get { return _code / 1000; } }
        public int Kod { get { return _code; } }
        int _code;
        int _kolor;
        int _warstwa;
        double _os;

        public Nagłówek(int code)
        {
            if (code < 1000) throw new ArgumentOutOfRangeException("Code is too small");
            if (code > 7999) throw new ArgumentOutOfRangeException("Code is too big");
            _code = code;
        }
    }
}
