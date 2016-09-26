using System;
using System.Linq;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeoMapDomena;
using GeoMapDomena.Rozszerzenia;
using GeoMapReader;

namespace GeoMapTesty
{
    [TestClass]
    public class MapReaderTest
    {
        [TestMethod]
        public void test_czy_map_reader_counts()
        {
            var map = new Mapa();
            var reader = new MapReader(map);
            var fileName = Path.Combine(@"..\..\..\GeoMapSamples", "Nysa.MAP");
            reader.Load(fileName);
            Assert.AreEqual(124399, map.Liczba);
            Assert.AreEqual(124399, map.Count());
            Assert.AreEqual(124399, map.Elementy.Count());
            Assert.AreEqual(89036, map.ElementyKlasy(1).Count());
            Assert.AreEqual(3255, map.ElementyKlasy(2).Count());
            Assert.AreEqual(16, map.ElementyKlasy(3).Count());
            Assert.AreEqual(20239, map.ElementyKlasy(4).Count());
            Assert.AreEqual(11853, map.ElementyKlasy(5).Count());
            Assert.AreEqual(0, map.ElementyKlasy(6).Count());
            Assert.AreEqual(0, map.ElementyKlasy(7).Count());
        }
    }
}
