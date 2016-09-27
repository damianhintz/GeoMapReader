using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMapDomena
{
    /// <summary>
    /// Atrybut opisowy obiektu na mapie.
    /// </summary>
    public class AtrybutOpisowy : IEnumerable<string>
    {
        public string Nazwa;

        public string Wartość
        {
            get
            {
                if (JestListą) throw new InvalidOperationException("Atrybut zawiera listę wartości");
                //else if (_wartości.Count == 1) return _wartości.First();
                else return _wartość; //to nie jest lista lub jest pustą listą
            }
        }
        string _wartość;

        public bool JestListą { get { return _wartości.Count > 0 || _wartość.Equals("#LIST;"); } }
        public IEnumerable<string> Wartości { get { return _wartości; } }
        List<string> _wartości = new List<string>();

        public AtrybutOpisowy(string nazwa, string wartość)
        {
            if (string.IsNullOrEmpty(nazwa)) throw new ArgumentNullException("Nazwa atrybutu jest pusta");
            Nazwa = nazwa;
            _wartość = wartość;
            if (wartość.StartsWith("#LIST;")) BuildList();
        }

        void BuildList()
        {
            //:KR[#LIST;GG-III.6640.1974.2015=42496.43125,PSobczak;3006-26/2008=42496.42961,PSobczak]
            if (!_wartość.StartsWith("#LIST;")) throw new InvalidOperationException("Wartość nie jest listą");
            var pola = _wartość.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            _wartości.AddRange(pola.Skip(1));
        }

        public IEnumerator<string> GetEnumerator() { return _wartości.GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { throw new NotImplementedException(); }
    }
}
