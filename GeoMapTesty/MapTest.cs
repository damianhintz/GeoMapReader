using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeoMapDomena;

namespace GeoMapTesty
{
    [TestClass]
    public class MapTest
    {
        [TestMethod]
        public void test_czy_mapa_jest_pusta()
        {
            var map = new Mapa();
            Assert.AreEqual(0, map.Count());
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void test_czy_mapa_zawiera_pusty_element()
        {
            var map = new Mapa();
            map.AddElement(null);
            Assert.Fail();
        }

        [TestMethod]
        public void test_czy_mapa_doda_element_klasy_1()
        {
            var map = new Mapa();
            var header = new Nagłówek(1111);
            var element = new ElementMapy(header);
            var punkt = new PunktOparcia(x: 1.2, y: 3.4);
            element.DodajPunkt(punkt);
            map.AddElement(element);
            Assert.AreEqual(1, map.Count());
        }

        [TestMethod]
        public void test_czy_mapa_doda_element_klasy_4_liniowy()
        {
            var map = new Mapa();
            var header = new Nagłówek(4567);
            var element = new ElementMapy(header);
            var punkt = new PunktOparcia(x: 1.2, y: 3.4);
            element.DodajPunkt(punkt);
            element.DodajPunkt(punkt);
            map.AddElement(element);
            Assert.AreEqual(1, map.Count());
        }

        [TestMethod]
        public void test_czy_mapa_doda_element_klasy_5_powierzchniowy()
        {
            var map = new Mapa();
            var header = new Nagłówek(5678);
            var element = new ElementMapy(header);
            var punkt = new PunktOparcia(x: 1.2, y: 3.4);
            element.DodajPunkt(punkt);
            element.DodajPunkt(punkt);
            element.DodajPunkt(punkt);
            map.AddElement(element);
            Assert.AreEqual(1, map.Count());
        }

        [TestMethod]
        public void test_czy_mapa_zawiera_dodany_id()
        {
            var map = new Mapa();
            var header = new Nagłówek(1234);
            var element = new ElementMapy(header);
            var guid = Guid.NewGuid().ToString();
            var id = new AtrybutOpisowy("ID", guid);
            element.DodajAtrybut(id);
            map.AddElement(element);
            var punktId = map.Szukaj(guid);
            Assert.AreEqual(expected: guid, actual: punktId.Id);
        }

        [TestMethod]
        public void test_czy_mapa_zawiera_dodany_taki_sam_id()
        {
            var map = new Mapa();
            var header = new Nagłówek(1234);
            var element = new ElementMapy(header);
            var guid = Guid.NewGuid().ToString();
            var id = new AtrybutOpisowy("ID", guid);
            element.DodajAtrybut(id);
            map.AddElement(element);
            map.AddElement(element);
            Assert.AreEqual(expected: 2, actual: map.Count());
        }

        [TestMethod, ExpectedException(typeof(InvalidOperationException))]
        public void test_czy_mapa_wyszuka_taki_sam_id()
        {
            var map = new Mapa();
            var header = new Nagłówek(1234);
            var element = new ElementMapy(header);
            var guid = Guid.NewGuid().ToString();
            var id = new AtrybutOpisowy("ID", guid);
            element.DodajAtrybut(id);
            map.AddElement(element);
            map.AddElement(element);
            map.Szukaj(guid);
            Assert.Fail();
        }
    }
}
