using proba.Helpers.XMLHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Xml.Linq;

namespace proba.Helpers.HttpHelpers
{
    public class HttpHelper
    {
        internal static XDocument GetXmlFromApi(string currencyUrl)
        {
            HttpClient httpClient = new HttpClient();
            string devizaXML = httpClient.GetStringAsync(currencyUrl).Result;

            XDocument result = XMLHelper.DeSerialise(devizaXML);

            return result;
        }
    }
}