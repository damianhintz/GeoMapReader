using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoMapDomena.Rozszerzenia;

namespace GeoMapDomena
{
    /// <summary>
    /// Obiekt na mapie.
    /// </summary>
    public class ElementMapy
    {
        public Nagłówek Nagłówek { get { return _header; } }
        Nagłówek _header;

        #region Atrybuty opisowe

        /// <summary>
        /// Identyfikator obiektu.
        /// </summary>
        public string Id
        {
            get
            {
                var atrybut = Atrybuty.SingleOrDefault(a => a.Nazwa.Equals("ID"));
                if (atrybut == null) return string.Empty;
                return atrybut.Wartość;
            }
        }

        /// <summary>
        /// Lista operatów przypisanych do obiektu.
        /// </summary>
        public IEnumerable<Operat> Operaty
        {
            get
            {
                var atrybut = Atrybuty.SingleOrDefault(a => a.Nazwa.Equals("KR"));
                var operaty = new List<Operat>();
                if (atrybut == null) return operaty; //brak operatów
                if (atrybut.JestListą)
                {
                    foreach (var wartość in atrybut)
                    {
                        var operat = wartość.ParseOperat();
                        operaty.Add(operat);
                    }
                }
                else
                {
                    var operat = new Operat(atrybut.Wartość);
                    operaty.Add(operat);
                }
                return operaty;
            }
        }

        /// <summary>
        /// Atrybuty opisowe np. A1, A2, A3, A4, A5, A6, TX, DT, KR, MP.
        /// </summary>
        public IEnumerable<AtrybutOpisowy> Atrybuty { get { return _atrybuty; } }
        List<AtrybutOpisowy> _atrybuty = new List<AtrybutOpisowy>();

        #endregion

        public IEnumerable<Etykieta> Opisy { get { return _opisy; } }
        List<Etykieta> _opisy = new List<Etykieta>();

        public IEnumerable<PunktOparcia> Punkty { get { return _punkty; } }
        List<PunktOparcia> _punkty = new List<PunktOparcia>();

        public ElementMapy(Nagłówek header)
        {
            if (header == null) throw new ArgumentNullException();
            _header = header;
        }

        public void DodajAtrybut(AtrybutOpisowy atrybut)
        {
            if (atrybut == null) throw new ArgumentNullException();
            _atrybuty.Add(atrybut);
        }

        public void DodajAtrybut(string nazwa, string wartość)
        {
            DodajAtrybut(new AtrybutOpisowy(nazwa, wartość));
        }

        public void DodajPunkt(PunktOparcia punkt)
        {
            if (punkt == null) throw new ArgumentNullException();
            _punkty.Add(punkt);
        }

        public void DodajPunkt(double x, double y)
        {
            var punkt = new PunktOparcia(x, y);
            DodajPunkt(punkt);
        }
    }
}
