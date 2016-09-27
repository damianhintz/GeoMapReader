using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeoMapDomena;

namespace GeoMapTesty
{
    [TestClass]
    public class ElementOperatTest
    {
        [TestMethod]
        public void test_czy_element_nie_zawiera_operatu()
        {
            var header = new Nagłówek(code: 1234);
            var element = new ElementMapy(header);
            Assert.AreEqual(expected: 0, actual: element.Operaty.Count());
        }

        [TestMethod]
        public void test_czy_element_nie_zawiera_operatów()
        {
            var atrybut = new AtrybutOpisowy(
                nazwa: "KR",
                wartość: "#LIST;");
            var header = new Nagłówek(code: 1234);
            var element = new ElementMapy(header);
            element.DodajAtrybut(atrybut);
            var operaty = element.Operaty;
            Assert.AreEqual(expected: 0, actual: operaty.Count());
        }

        [TestMethod]
        public void test_czy_element_zawiera_jeden_operat_bez_operatora()
        {
            var atrybut = new AtrybutOpisowy(
                nazwa: "KR",
                wartość: "123/2016");
            var header = new Nagłówek(code: 1234);
            var element = new ElementMapy(header);
            element.DodajAtrybut(atrybut);
            var operaty = element.Operaty;
            Assert.AreEqual(expected: 1, actual: operaty.Count());
            var operat = operaty.Single();
            Assert.AreEqual(expected: "123/2016", actual: operat.Numer);
        }

        [TestMethod]
        public void test_czy_element_zawiera_jeden_operat()
        {
            var atrybut = new AtrybutOpisowy(
                nazwa: "KR",
                wartość: "#LIST;123=1.2,Damian");
            var header = new Nagłówek(code: 1234);
            var element = new ElementMapy(header);
            element.DodajAtrybut(atrybut);
            var operaty = element.Operaty;
            Assert.AreEqual(expected: 1, actual: operaty.Count());
            var operat = operaty.Single();
            Assert.AreEqual(expected: "123", actual: operat.Numer);
            Assert.AreEqual(expected: "1.2", actual: operat.Data);
            Assert.AreEqual(expected: "Damian", actual: operat.Operator);
        }
    }
}
