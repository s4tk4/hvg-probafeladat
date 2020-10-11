using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace proba.Helpers.XMLHelpers
{
    public class XMLHelper
    {
        public static XDocument DeSerialise(string devizaXML)
        {
            XDocument result = XDocument.Parse(devizaXML);
            return result;
        }
    }
}