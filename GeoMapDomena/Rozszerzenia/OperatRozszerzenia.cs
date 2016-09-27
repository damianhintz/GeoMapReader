using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMapDomena.Rozszerzenia
{
    /// <summary>
    /// Parser operatu z wartości atrybutu KR.
    /// </summary>
    public static class OperatRozszerzenia
    {
        public static Operat ParseOperat(this string wartość)
        {
            //:KR[#LIST;GG-III.6640.2164.2014=42591.38639,Nrudzinska]
            if (string.IsNullOrEmpty(wartość)) return null;
            var pola = wartość.Split('=');
            if (pola.Length != 2) throw new ArgumentException("Nieprawidłowy format zapisu operatu: " + wartość);
            var numer = pola.First();
            var operat = new Operat(numer);
            var dataLubOperator = pola.Last();
            var dataLubOperatorSplit = dataLubOperator.Split(',');
            if (dataLubOperatorSplit.Length != 2) throw new ArgumentException("Nieprawidłowy format zapisu daty i operatora operatu: " + dataLubOperator);
            var dataOperatu = dataLubOperatorSplit.First();
            var operatorOperatu = dataLubOperatorSplit.Last();
            operat.Data = dataOperatu;
            operat.Operator = operatorOperatu;
            return operat;
        }
    }
}
