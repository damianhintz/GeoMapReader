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

        [TestMethod]
        public void test_czy_mapa_zawiera_dodany_element()
        {
            var map = new Mapa();
            var header = new Nagłówek(1111);
            var element = new ElementMapy(header);
            map.AddElement(element);
            Assert.AreEqual(1, map.Count());
        }
    }
}
