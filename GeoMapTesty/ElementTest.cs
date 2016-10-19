using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeoMapDomena;

namespace GeoMapTesty
{
    [TestClass]
    public class MapElementTest
    {
        [TestMethod]
        public void test_czy_element_zawiera_nagłówek()
        {
            var header = new Nagłówek(1234);
            var element = new ElementMapy(header);
            Assert.IsNotNull(element.Nagłówek);
            Assert.AreEqual(0, element.Atrybuty.Count());
            Assert.AreEqual(0, element.Opisy.Count());
            Assert.AreEqual(0, element.Punkty.Count());
            Assert.AreEqual(string.Empty, element.Id);
        }

        [TestMethod]
        public void test_czy_element_zawiera_dodany_id()
        {
            var header = new Nagłówek(1234);
            var element = new ElementMapy(header);
            var guid = Guid.NewGuid().ToString();
            element.DodajAtrybut("ID", guid);
            Assert.AreEqual(1, element.Atrybuty.Count());
            Assert.AreEqual(guid, element.Id);
        }

        [TestMethod]
        public void test_czy_element_zawiera_dodany_punkt()
        {
            var header = new Nagłówek(code: 1234);
            var element = new ElementMapy(header);
            element.DodajPunkt(x: 1.2, y: 3.4);
            Assert.AreEqual(expected: 1, actual: element.Punkty.Count());
            var punkt = element.Punkty.Single();
            Assert.AreEqual(expected: 1.2, actual: punkt.X);
            Assert.AreEqual(expected: 3.4, actual: punkt.Y);
        }

        [TestMethod]
        public void test_czy_klasa_2_jest_lokalizowana_przez_dwa_punkty()
        {
            var header = new Nagłówek(code: 2345);
            var element = new ElementMapy(header);
            var punkt = new PunktOparciaGeoMap(x: 1.2, y: 3.4);
            element.DodajPunkt(punkt);
            element.DodajPunkt(punkt);
        }

        [TestMethod]
        public void test_czy_klasa_3_jest_lokalizowana_przez_trzy_punkty()
        {
            var header = new Nagłówek(code: 3456);
            var element = new ElementMapy(header);
            var punkt = new PunktOparciaGeoMap(x: 1.2, y: 3.4);
            element.DodajPunkt(punkt);
            element.DodajPunkt(punkt);
            element.DodajPunkt(punkt);
        }

    }
}
