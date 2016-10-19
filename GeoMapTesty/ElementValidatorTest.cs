using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeoMapDomena;
using GeoMapDomena.Rozszerzenia;

namespace GeoMapTesty
{
    [TestClass]
    public class ElementValidatorTest
    {
        [TestMethod]
        public void test_czy_klasa_1_jest_lokalizowana_tylko_przez_jeden_punkt()
        {
            var header = new Nagłówek(code: 1234);
            var element = new ElementMapy(header);
            var punkt = new PunktOparciaGeoMap(x: 1.2, y: 3.4);
            element.DodajPunkt(punkt);
            element.DodajPunkt(punkt);
            Assert.IsTrue(element.IsInvalid());
        }

        [TestMethod]
        public void test_czy_klasa_2_jest_lokalizowana_tylko_przez_dwa_punkty()
        {
            var header = new Nagłówek(code: 2345);
            var element = new ElementMapy(header);
            var punkt = new PunktOparciaGeoMap(x: 1.2, y: 3.4);
            element.DodajPunkt(punkt);
            element.DodajPunkt(punkt);
            element.DodajPunkt(punkt);
            Assert.IsTrue(element.IsInvalid());
        }

        [TestMethod]
        public void test_czy_klasa_3_jest_lokalizowana_tylko_przez_trzy_punkty()
        {
            var header = new Nagłówek(code: 3456);
            var element = new ElementMapy(header);
            var punkt = new PunktOparciaGeoMap(x: 1.2, y: 3.4);
            element.DodajPunkt(punkt);
            element.DodajPunkt(punkt);
            element.DodajPunkt(punkt);
            element.DodajPunkt(punkt);
            Assert.IsTrue(element.IsInvalid());
        }
    }
}
