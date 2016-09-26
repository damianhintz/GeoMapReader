using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoMapDomena;

namespace GeoMapReader.Parser
{
    static class AtrybutParser
    {
        public static AtrybutOpisowy ParseAtrybut(this string record)
        {
            //:ID[C353953E-1BCE-4D6A-B5D4-AB17D6C32D1D]
            if (string.IsNullOrEmpty(record)) throw new ArgumentNullException();
            if (!record.StartsWith(":")) throw new ArgumentException();
            if (!record.EndsWith("]")) throw new ArgumentException();
            var recordWithoutColon = record
                .Substring(1)
                .TrimEnd(']');
            var leftIndex = recordWithoutColon
                .IndexOf('[');
            if (leftIndex < 0) throw new ArgumentException();
            var name = recordWithoutColon
                .Substring(0, leftIndex);
            var valueIndex = leftIndex + 1;
            var value = recordWithoutColon.Substring(valueIndex);
            var atrybut = new AtrybutOpisowy(name, value);
            return atrybut;
        }
    }
}
