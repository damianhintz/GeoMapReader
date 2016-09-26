using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoMapDomena;

namespace GeoMapReader.Parser
{
    static class NagłówekParser
    {
        public static Nagłówek ParseHeader(this string code)
        {
            int codeValue = int.Parse(code);
            var header = new Nagłówek(codeValue);
            return header;
        }
    }
}
