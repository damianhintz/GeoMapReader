using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMapDomena
{
    /// <summary>
    /// Obiekt na mapie.
    /// </summary>
    public class ElementMapy
    {
        public Nagłówek Nagłówek { get { return _header; } }
        Nagłówek _header;

        public IEnumerable<AtrybutOpisowy> Atrybuty { get { return _atrybuty; } }
        List<AtrybutOpisowy> _atrybuty = new List<AtrybutOpisowy>();

        public IEnumerable<Etykieta> Opisy { get { return _opisy; } }
        List<Etykieta> _opisy = new List<Etykieta>();

        public IEnumerable<PunktOparcia> Punkty { get { return _punkty; } }
        List<PunktOparcia> _punkty = new List<PunktOparcia>();
        
        public ElementMapy(Nagłówek header) {
            if (header == null) throw new ArgumentNullException();
            _header = header;
        }
    }
}
