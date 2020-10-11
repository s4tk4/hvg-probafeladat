using proba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proba.Extensions
{
    public static class JsonFEResultExtension
    {
        public static string ToString(this JsonFEResult data)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        public static string GetDataString(this JsonFEResult data)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
    }
}