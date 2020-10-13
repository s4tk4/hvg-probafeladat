using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proba.Models.Accounts
{
    public class InPaymentRequest
    {
        public string AccountNumber { get; set; }
        public float PriceNumber { get; set; }
    }
}