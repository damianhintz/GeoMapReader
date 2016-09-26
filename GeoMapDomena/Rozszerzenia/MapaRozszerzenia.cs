using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMapDomena.Rozszerzenia
{
    public static class MapaRozszerzenia
    {
        public static IEnumerable<ElementMapy> ElementyKlasy(this Mapa map, int klasa)
        {
            var elementy1 =
                from obj
                in map
                where obj.Nagłówek.Klasa == klasa
                select obj;
            return elementy1;
        }

    }
}
