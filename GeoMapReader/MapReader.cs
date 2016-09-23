using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GeoMapDomena;
using GeoMapReader.Parser;

namespace GeoMapReader
{
    public class MapReader
    {
        Mapa _map;

        public MapReader(Mapa map) { _map = map; }

        public void Load(string fileName)
        {
            var allLines = File.ReadAllLines(fileName, Encoding.GetEncoding(1250));
            var linesWithoutComments = allLines.Where(line => !line.StartsWith(";"));
            var headerLines = linesWithoutComments.Where(line => line.StartsWith("*"));
            foreach(var header in headerLines) ParseHeaderAndAddElementToMap(header);
        }

        void ParseHeaderAndAddElementToMap(string header)
        {
            var element = header.ParseElement();
            _map.AddElement(element);
        }
    }
}
