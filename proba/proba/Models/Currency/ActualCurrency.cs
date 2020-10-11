using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proba.Models.Currency
{
    public class ActualCurrency
    {
        public string bank { get; set; }
        public DateTime datum { get; set; }
        public string Name { get; set; }
        public float Byu { get; set; }
        public float Sell { get; set; }
    }
}