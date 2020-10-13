using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proba.Models.Accounts
{
    public class PayTransferRequest
    {
        //owner account
        public string AccountNumber { get; set; }
        public float PriceNumber { get; set; }
        //account who receive the price
        public string AccountId { get; set; }
    }
}