using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoMapDomena;

namespace GeoMapReader.Parser
{
    static class HeaderParser
    {
        public static ElementMapy ParseElement(this string header) {
            if (string.IsNullOrEmpty(header)) throw new ArgumentNullException();
            if (!header.StartsWith("*")) throw new ArgumentException("Header should start with a *");
            //*4366 8388608  26 0.00000000
            var headerWithoutStar = header.Substring(1);
            var headerSplit = headerWithoutStar.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (headerSplit.Count() < 4) throw new ArgumentException("Header should have a minimum of 4 arguments");
            var codeString = headerSplit.First();
            var kind = codeString.ParseKind();
            var element = new ElementMapy(kind);
            throw new NotImplementedException();
        }
    }
}
