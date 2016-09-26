using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMapDomena
{
    /// <summary>
    /// Atrybut opisowy obiektu na mapie.
    /// </summary>
    public class AtrybutOpisowy
    {
        public string Nazwa;
        public string Wartość;

        public AtrybutOpisowy(string nazwa, string wartość)
        {
            Nazwa = nazwa;
            Wartość = wartość;
        }
    }
}
