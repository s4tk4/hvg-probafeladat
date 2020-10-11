using proba.Helpers.Accounts;
using proba.Helpers.Currency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proba.Controllers
{
    public class AccountController : Controller
    {

        public ActionResult CreateAccount()
        {
            ViewBag.Title = "Create Account";

            return View();
        }

        public ActionResult ListAccounts()
        {
            
            ViewBag.Title = "List Accounts";


            var model = AccountHelper.GetAccountsList();

            return View(model);
        }

        public ActionResult ShowDeviza()
        {

            ViewBag.Title = "Actual Deviza";

            var model = CurrencyHelper.GetActualCurrency();
            //var model = AccountHelper.GetAccountsList();

            return View(model);
        }
    }
}
