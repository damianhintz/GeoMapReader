using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMapDomena.Rozszerzenia
{
    public static class ElementRozszerzenia
    {
        public static bool IsInvalid(this ElementMapy element)
        {
            var klasa = element.Nagłówek.Klasa;
            var count = element.Punkty.Count();
            return (klasa == 1 && count != 1 ||
                klasa == 2 && count != 2 ||
                klasa == 3 && count != 3 ||
                klasa == 4 && count < 2 ||
                klasa == 5 && count < 3 ||
                klasa == 6 && count > 2 ||
                klasa == 7 && count > 2);
        }
    }
}
