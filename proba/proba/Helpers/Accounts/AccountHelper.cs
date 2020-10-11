using proba.Models;
using proba.Models.Accounts;
using proba.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;

namespace proba.Helpers.Accounts
{
    public class AccountHelper
    {
        #region private methods
        public static List<AbstractAccount> GetAccountsList()
        {
            var accounts = AccountRepository.GetAccounts();
            return accounts;
        }

        internal static bool IsValidDataForCreation(AbstractAccount data, JsonFEResult jsonResult)
        {
            bool result = true;
            if (!IsValidAccountNumber(data.AccountNumber, jsonResult) || !NotExistAccountNumber(data.AccountNumber, jsonResult))
            {
                result = false;
            }

            if (string.IsNullOrEmpty(data.OwnerName))
            {
                jsonResult.Success = false;
                jsonResult.ErrorMessage.Add("Missing Owner name");
                return false;
            }
            return result;
        }

        internal static void CreateNewAccount(AbstractAccount data)
        {
            if (!data.ExistCreditLine)
            {
                data.Balance = 5000;
            }
            AccountRepository.CreateNewAccount(data);
        }
        #endregion

        #region private
        private static bool NotExistAccountNumber(string accountNumber, JsonFEResult jsonResult)
        {
            var items = AccountRepository.GetAccounts().Where(x => x.AccountNumber == accountNumber).ToList();
            if (items.Count != 0)
            {
                jsonResult.Success = false;
                jsonResult.ErrorMessage.Add($"This accountnumber '{accountNumber}' is exists!");
            }
            return items.Count == 0;
        }

        private static bool IsValidAccountNumber(string accountNumber, JsonFEResult jsonResult)
        {
            if (string.IsNullOrEmpty(accountNumber))
            {
                jsonResult.Success = false;
                jsonResult.ErrorMessage.Add("Empty account number");
                return false;
            }

            Regex regex = new Regex("([\\d]{8})-([\\d]{8})-([\\d]{8})");
            Match match = regex.Match(accountNumber);
            if (!match.Success)
            {
                jsonResult.Success = false;
                jsonResult.ErrorMessage.Add("Invalid or wrong account number format");
            }
            return match.Success;
        }
        #endregion

    }
}