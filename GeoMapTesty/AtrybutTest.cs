using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeoMapDomena;

namespace GeoMapTesty
{
    [TestClass]
    public class AtrybutTest
    {
        [TestMethod]
        public void test_czy_atrybut_ma_nazwę_i_wartość()
        {
            var atrybut = new AtrybutOpisowy(nazwa: "ID", wartość: "1");
            Assert.AreEqual(expected: "ID", actual: atrybut.Nazwa);
            Assert.AreEqual(expected: "1", actual: atrybut.Wartość);
        }

        [TestMethod]
        public void test_czy_atrybut_nie_jest_listą()
        {
            var atrybut = new AtrybutOpisowy(nazwa: "ID", wartość: "1");
            Assert.AreEqual(expected: "ID", actual: atrybut.Nazwa);
            Assert.AreEqual(expected: "1", actual: atrybut.Wartość);
            Assert.IsFalse(atrybut.JestListą);
            Assert.AreEqual(expected: 0, actual: atrybut.Count());
            Assert.AreEqual(expected: 0, actual: atrybut.Wartości.Count());
        }

        [TestMethod]
        public void test_czy_atrybut_jest_pustą_listą()
        {
            //:KR[#LIST;]
            var atrybut = new AtrybutOpisowy(nazwa: "KR", wartość: "#LIST;");
            Assert.AreEqual(expected: "KR", actual: atrybut.Nazwa);
            Assert.AreEqual(expected: "", actual: atrybut.Wartość);
            Assert.IsTrue(atrybut.JestListą);
            Assert.AreEqual(expected: 1, actual: atrybut.Count());
        }

        [TestMethod]
        public void test_czy_atrybut_jest_listą()
        {
            //:KR[#LIST;GG-III.6640.1974.2015=42496.48844,PSobczak]
            var atrybut = new AtrybutOpisowy(nazwa: "KR", wartość: "#LIST;GG-III.6640.1974.2015=42496.48844,PSobczak");
            Assert.AreEqual(expected: "KR", actual: atrybut.Nazwa);
            Assert.AreEqual(expected: "GG-III.6640.1974.2015=42496.48844,PSobczak", actual: atrybut.Wartość);
            Assert.IsTrue(atrybut.JestListą);
            Assert.AreEqual(expected: 1, actual: atrybut.Count());
            Assert.AreEqual(expected: 1, actual: atrybut.Wartości.Count());
            Assert.AreEqual(expected: "GG-III.6640.1974.2015=42496.48844,PSobczak", actual: atrybut.First());
        }

        [TestMethod]
        public void test_czy_atrybut_jest_listą_wielu_wartości()
        {
            var atrybut = new AtrybutOpisowy(
                nazwa: "KR",
                wartość: "#LIST;GG-III.6640.1974.2015=42496.43125,PSobczak;3006-26/2008=42496.42961,PSobczak");
            Assert.AreEqual(expected: "KR", actual: atrybut.Nazwa);
            //Assert.AreEqual(expected: "#LIST;GG-III.6640.1974.2015=42496.43125,PSobczak;3006-26/2008=42496.42961,PSobczak", actual: atrybut.Wartość);
            Assert.AreEqual(expected: 2, actual: atrybut.Count());
            Assert.IsTrue(atrybut.JestListą);
            var wartość1 = atrybut.First();
            Assert.AreEqual(expected: "GG-III.6640.1974.2015=42496.43125,PSobczak", actual: wartość1);
            var wartość2 = atrybut.Last();
            Assert.AreEqual(expected: "3006-26/2008=42496.42961,PSobczak", actual: wartość2);
        }

        [TestMethod, ExpectedException(typeof(InvalidOperationException))]
        public void test_czy_atrybut_będący_listą_wielu_wartości_ma_wartość()
        {
            var atrybut = new AtrybutOpisowy(
                nazwa: "KR",
                wartość: "#LIST;GG-III.6640.1974.2015=42496.43125,PSobczak;3006-26/2008=42496.42961,PSobczak");
            Assert.AreEqual(expected: "KR", actual: atrybut.Nazwa);
            Assert.IsTrue(atrybut.JestListą);
            var wartość = atrybut.Wartość;
            Assert.Fail();
        }
    }
}
