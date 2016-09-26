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

        public void AddElement(ElementMapy element)
        {
            if (element == null) throw new ArgumentNullException("Element mapy jest null");
            _elementy.Add(element);
        }

        public IEnumerator<ElementMapy> GetEnumerator() { return _elementy.GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { throw new NotImplementedException(); }
    }
}
