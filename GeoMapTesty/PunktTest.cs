using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeoMapDomena;

namespace GeoMapTesty
{
    [TestClass]
    public class PunktTest
    {
        [TestMethod]
        public void test_czy_punkt_ma_współrzędne()
        {
            var punkt = new PunktOparciaGeoMap(12.3, 45.6);
            Assert.AreEqual(12.3, punkt.X);
            Assert.AreEqual(45.6, punkt.Y);
            Assert.IsNull(punkt.Numer);
        }
        
    }
}
