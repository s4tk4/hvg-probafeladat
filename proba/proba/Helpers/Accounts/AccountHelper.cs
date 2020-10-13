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
        private static bool ExistAccountNumber(string accountNumber, JsonFEResult jsonResult)
        {
            var items = AccountRepository.GetAccounts().Where(x => x.AccountNumber == accountNumber).ToList();
            if (items.Count == 0)
            {
                jsonResult.Success = false;
                jsonResult.ErrorMessage.Add($"This accountnumber '{accountNumber}' is not exists!");
            }
            return items.Count == 1;
        }


        internal static void DoPayment(InPaymentRequest data, JsonFEResult jsonResult)
        {
            var item = AccountRepository.GetAccounts().Where(x => x.AccountNumber == data.AccountNumber).ToList().FirstOrDefault();
            if (item == null)
            {
                jsonResult.Success = false;
                jsonResult.ErrorMessage.Add($"Transaction is not possible not valid accountnumber");
                return;

            }
            item.Balance += data.PriceNumber;
            AccountRepository.UpdateAccount(item);
        }

        internal static bool IsValidDataForPayment(InPaymentRequest data, JsonFEResult jsonResult)
        {
            if(!ExistAccountNumber(data.AccountNumber, jsonResult))
            {
                jsonResult.Success = false;
                jsonResult.ErrorMessage.Add($"Wrong account number {data.AccountNumber}");
                return false;
            }

            if (data.PriceNumber <= 0)
            {
                jsonResult.Success = false;
                jsonResult.ErrorMessage.Add("Price must to be biger then 0 (zero)");
                return false;
            }
            return true;
        }

        internal static bool IsValidDataForTransfer(PayTransferRequest data, JsonFEResult jsonResult)
        {
            if (!ExistAccountNumber(data.AccountId, jsonResult))
            {
                jsonResult.Success = false;
                jsonResult.ErrorMessage.Add($"Wrong account number {data.AccountNumber}");
                return false;
            }

            return IsValidDataForPayment(new InPaymentRequest { AccountNumber = data.AccountNumber, PriceNumber= data.PriceNumber }, jsonResult);
        }

        internal static void DoTransfer(PayTransferRequest data, JsonFEResult jsonResult)
        {
            var senderitem = AccountRepository.GetAccounts().Where(x => x.AccountNumber == data.AccountNumber).ToList().FirstOrDefault();
            var receiveritem = AccountRepository.GetAccounts().Where(x => x.AccountNumber == data.AccountId).ToList().FirstOrDefault();
            if (senderitem == null || receiveritem== null)
            {
                jsonResult.Success = false;
                jsonResult.ErrorMessage.Add($"Transaction is not possible not valid accountnumber for {(senderitem==null?"sender":"receiver")}");
                return;
            }

            if((senderitem.Balance - data.PriceNumber) < 0 && !senderitem.ExistCreditLine)
            {
                //nem mehet minuszba
                jsonResult.Success = false;
                jsonResult.ErrorMessage.Add("Transaction is not finished. Don't have Credit line");
                return;
            }

            if((senderitem.Balance - data.PriceNumber) < -50000)
            {
                //limit tul lepes
                jsonResult.Success = false;
                jsonResult.ErrorMessage.Add("Transaction is no finished. Don't have enough Credit line");
                return;
            }

            senderitem.Balance -= data.PriceNumber;
            receiveritem.Balance += data.PriceNumber;

            AccountRepository.UpdateAccount(senderitem);
            AccountRepository.UpdateAccount(receiveritem);

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