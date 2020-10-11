using Microsoft.Ajax.Utilities;
using proba.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proba.Repositories
{
    public class AccountRepository
    { 
        public static List<AbstractAccount> GetAccounts()
        {
            List<AbstractAccount> result = new List<AbstractAccount>();

            AbstractAccountList accountItems = dblayer.ME.GetItems<AbstractAccountList>("accounts");
            if (accountItems!= null && accountItems.Items!= null && accountItems.Items.Count > 0)
            {
                result.AddRange(accountItems.Items);
            }

            return result;
        }

        internal static void CreateNewAccount(AbstractAccount data)
        {
            AbstractAccountList accountItems = dblayer.ME.GetItems<AbstractAccountList>("accounts");
            if(accountItems == null)
            {
                accountItems = new AbstractAccountList();
                accountItems.Items = new List<AbstractAccount>();
            }
            accountItems.Items.Add(data);
            dblayer.ME.InsertNewItem(accountItems, "accounts");
        }
    }
}