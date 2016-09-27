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
        public void test_czy_map_reader_wczyta_wszystkie_obiekty()
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

        [TestMethod]
        public void test_czy_map_reader_wczyta_atrybutu_obiektu()
        {
            var map = new Mapa();
            var reader = new MapReader(map);
            var fileName = Path.Combine(@"..\..\..\GeoMapSamples", "Nysa.MAP");
            reader.Load(fileName);
            //A1, A2, A3, A4,A5, A6, TX, DT, KR, MP
            //var element = map.Single(e => e.Id)
            //*4741 65535  40 0.00000000
            //:ID[5B16242D-CAC5-454B-B11B-7592376D1681]
            //:A2[gwA200]
            //:A4[1]
            //:TX[przesy’owy#2015-06-01;]
            //: MP[10]
            //:DT[42591.38639]
            //:KR[#LIST;GG-III.6640.2164.2014=42591.38639,Nrudzinska]
        }
    }
}
