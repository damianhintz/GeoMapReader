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
        public static ElementMapy ParseElement(this string headerRecord) {
            if (string.IsNullOrEmpty(headerRecord)) throw new ArgumentNullException();
            if (!headerRecord.StartsWith("*")) throw new ArgumentException("Header record should start with a *");
            //*4366 8388608  26 0.00000000
            var headerWithoutStar = headerRecord.Substring(1);
            var headerSplit = headerWithoutStar.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (headerSplit.Count() < 4) throw new ArgumentException("Header record should have a minimum of 4 arguments");
            var codeString = headerSplit.First();
            var header = codeString.ParseHeader();
            var element = new ElementMapy(header);
            return element;
        }
    }
}
