using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMapDomena
{
    public class TypElementu
    {
        public int Code { get { return _code; } }
        public int Kind { get { return _code / 1000; } }
        int _code;

        public TypElementu(int code)
        {
            if (code < 1000) throw new ArgumentOutOfRangeException("Code is too small");
            if (code > 7999) throw new ArgumentOutOfRangeException("Code is too big");
            _code = code;
        }
    }
}
