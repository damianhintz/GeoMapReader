using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoMapDomena;

namespace GeoMapReader.Parser
{
    static class KindParser
    {
        public static TypElementu ParseKind(this string code)
        {
            int codeValue = int.Parse(code);
            var kind = new TypElementu(codeValue);
            throw new NotImplementedException();
        }
    }
}
