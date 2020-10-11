using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proba.Models
{
    public class JsonFEResult
    {
        public JsonFEResult()
        {
            ResultMessage = new List<string>();
            ErrorMessage = new List<string>();
        }
        public bool Success { get; set; }
        public List<string> ResultMessage { get; set; }
        public List<string> ErrorMessage { get; set; }
        
    }
}