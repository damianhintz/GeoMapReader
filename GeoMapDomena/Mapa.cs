using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMapDomena
{
    /// <summary>
    /// Mapa zbudowana z obiektów.
    /// </summary>
    public class Mapa : IEnumerable<ElementMapy>
    {
        public string Użytkownik;
        public string Operator;
        public int Liczba { get { return _elementy.Count; } }

        public IEnumerable<ElementMapy> Elementy { get { return _elementy; } }
        List<ElementMapy> _elementy = new List<ElementMapy>();
        Dictionary<string, ElementMapy> _indeksId = new Dictionary<string, ElementMapy>();

        public void AddElement(ElementMapy element)
        {
            if (element == null) throw new ArgumentNullException("Element mapy jest null");
            _elementy.Add(element);
            AddToIndex(element);
        }

        bool AddToIndex(ElementMapy element)
        {
            var id = element.Id;
            if (_indeksId.ContainsKey(id))
            {
                //throw new InvalidOperationException("Mapa zawiera już obiekt o takim id: " + id);
                _indeksId[id] = null; //Elements with the same id are not accesible by index
                return false;
            }
            _indeksId.Add(id, element);
            return true;
        }

        public ElementMapy Szukaj(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException("Id obiektu jest puste");
            if (!_indeksId.ContainsKey(id)) return null;
            var element = _indeksId[id];
            if (element == null) throw new InvalidOperationException("Obiekt o takim id nie jest dostępny za pomocą indeksu: " + id);
            return element;
        }

        public IEnumerator<ElementMapy> GetEnumerator() { return _elementy.GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { throw new NotImplementedException(); }
    }
}
