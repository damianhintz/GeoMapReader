using System;
using System.Collections.Generic;
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
            var guid = "5B16242D-CAC5-454B-B11B-7592376D1681";
            var element = map.Szukaj(guid);
            //*4741 65535  40 0.00000000
            Assert.AreEqual(expected: 4741, actual: element.Nagłówek.Kod);
            //:ID[5B16242D-CAC5-454B-B11B-7592376D1681]
            Assert.AreEqual(expected: guid, actual: element.Id);
            //:KR[#LIST;GG-III.6640.2164.2014=42591.38639,Nrudzinska]
            var operaty = element.Operaty;
            var operat = operaty.Single();
            Assert.AreEqual(expected: "GG-III.6640.2164.2014", actual: operat.Numer);
            Assert.AreEqual(expected: "42591.38639", actual: operat.Data);
            Assert.AreEqual(expected: "Nrudzinska", actual: operat.Operator);
            //:A2[gwA200]
            //:A4[1]
            //:MP[10]
            //:DT[42591.38639]
        }

        [TestMethod]
        void test_czy_map_reader_wczyta_operaty_obiektu()
        {
            var map = new Mapa();
            var reader = new MapReader(map);
            var fileName = Path.Combine(@"..\..\..\GeoMapSamples", "Nysa.MAP");
            reader.Load(fileName);
            //A1, A2, A3, A4,A5, A6, TX, DT, KR, MP
            var guid = "EBD94CBD-70F4-4504-9C76-EE6B44B165E3";
            var element = map.Szukaj(guid);
            //*4741 65535  40 0.00000000
            Assert.AreEqual(expected: 1361, actual: element.Nagłówek.Kod);
            Assert.AreEqual(expected: 7, actual: element.Atrybuty.Count());
            Assert.AreEqual(expected: 0, actual: element.Opisy.Count());
            Assert.AreEqual(expected: 1, actual: element.Punkty.Count());
            //:ID[5B16242D-CAC5-454B-B11B-7592376D1681]
            Assert.AreEqual(expected: guid, actual: element.Id);
            var operaty = element.Operaty;
            var operat = operaty.Single();
            Assert.AreEqual(expected: "473-414/70/1988", actual: operat.Numer);
            Assert.AreEqual(expected: null, actual: operat.Data);
            Assert.AreEqual(expected: null, actual: operat.Operator);
            //:A5[473-414/70/1988]
            //:TX[1988-09-15]
            //:MP[1]
            //:DT[42473.57348]
            //P 1  5591312.865  6460507.470
        }

        [TestMethod]
        void test_czy_map_reader_policzy_unikatowe_operaty()
        {
            var map = new Mapa();
            var reader = new MapReader(map);
            var fileName = Path.Combine(@"..\..\..\GeoMapSamples", "Nysa.MAP");
            reader.Load(fileName);
            var unikatoweOperaty = new HashSet<string>();
            foreach (var element in map)
            {
                var operaty = element.Operaty;
                foreach (var operat in operaty)
                {
                    var numer = operat.Numer;
                    unikatoweOperaty.Add(numer);
                }
            }
            Assert.AreEqual(expected: 1, actual: unikatoweOperaty.Count);
        }
    }
}
