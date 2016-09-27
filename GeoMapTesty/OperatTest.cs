using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeoMapDomena;
using GeoMapDomena.Rozszerzenia;

namespace GeoMapTesty
{
    [TestClass]
    public class OperatTest
    {
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void test_czy_operat_nie_ma_numeru()
        {
            var operat = new Operat(numer: "");
            Assert.Fail();
        }

        [TestMethod]
        public void test_czy_operat_ma_numer()
        {
            var operat = new Operat(numer: "123/2016");
            Assert.AreEqual(expected: "123/2016", actual: operat.Numer);
            Assert.IsNull(operat.Data);
            Assert.IsNull(operat.Operator);
        }

        [TestMethod]
        public void test_czy_wartość_zawiera_operat()
        {
            //:KR[#LIST;GG-III.6640.2164.2014=42591.38639,Nrudzinska]
            var operat = "GG-III.6640.2164.2014=42591.38639,Nrudzinska".ParseOperat();
            Assert.AreEqual(expected: "GG-III.6640.2164.2014", actual: operat.Numer);
            Assert.AreEqual(expected: "42591.38639", actual: operat.Data);
            Assert.AreEqual(expected: "Nrudzinska", actual: operat.Operator);
        }
    }
}
