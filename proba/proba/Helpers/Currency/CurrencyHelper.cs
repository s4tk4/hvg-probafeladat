using proba.Helpers.HttpHelpers;
using proba.Models.Currency;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Xml.Linq;

namespace proba.Helpers.Currency
{
    public class CurrencyHelper
    {
        internal static List<ActualCurrency> GetActualCurrency()
        {

            string currencyUrl = ConfigurationManager.AppSettings["CurrencyApiUrl"];
            
            XDocument devizaDocument = HttpHelper.GetXmlFromApi(currencyUrl);

            List<ActualCurrency> result = new List<ActualCurrency>();

            var a = devizaDocument.Elements();

            //foreach (XElement elStr in devizaDocument.Element(new XName("valuta")))
            //{
            //    foreach (XElement elText in elStr.Elements("item"))
            //    {
            //        textStrings.Add((string)elText);
            //    }
            //}

            return null;
        }
    }
}