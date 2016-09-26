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
    /// <summary>
    /// Czytnik plików GEO-MAP.
    /// </summary>
    public class MapReader
    {
        Mapa _map;

        bool IsHeader { get { return CurrentRecord.StartsWith("*"); } }
        bool IsAttribute { get { return CurrentRecord.StartsWith(":"); } }
        bool IsComment { get { return CurrentRecord.StartsWith(";"); } }
        bool IsLabel { get { return CurrentRecord.StartsWith("L"); } }
        bool IsPoint {  get { return CurrentRecord.StartsWith("P"); } }
        string CurrentRecord { get { return _allLines[_index]; } }
        bool IsNotEnd { get { return _index < _allLines.Length; } }
        string[] _allLines;
        int _index;
        
        public MapReader(Mapa map) { _map = map; }

        public void Load(string fileName)
        {
            _allLines = File.ReadAllLines(fileName, Encoding.GetEncoding(1250));
            _index = 0;
            while(IsNotEnd)
            {
                if (IsComment) NextRecord();
                else ParseMapElement();
            }
        }

        void ParseMapElement()
        {
            if (!IsHeader) throw new InvalidOperationException("");
            var element = CurrentRecord.ParseElement();
            NextRecord();
            while (IsNotEnd && !IsHeader)
            {
                ParseRecord(element);
                NextRecord();
            }
            _map.AddElement(element);
        }

        void ParseRecord(ElementMapy element)
        {
            if (IsComment) return;
            if (IsAttribute)
            {
                var atrybut = CurrentRecord.ParseAtrybut();
            }
            else if (IsLabel) return;
            else if (IsPoint) return;
            else throw new InvalidOperationException(CurrentRecord);
        }

        void NextRecord() { _index++; }
    }
}
