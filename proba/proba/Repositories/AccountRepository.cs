using Microsoft.Ajax.Utilities;
using proba.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace proba.Repositories
{
    public class AccountRepository
    { 
        public static List<AbstractAccount> GetAccounts()
        {
            List<AbstractAccount> result = new List<AbstractAccount>();

            AbstractAccountList accountItems = GetAllAccounts();
            if (accountItems!= null && accountItems.Items!= null && accountItems.Items.Count > 0)
            {
                result.AddRange(accountItems.Items);
            }

            return result;
        }

        private static AbstractAccountList GetAllAccounts()
        {
            string dbdatafolder = ConfigurationManager.AppSettings["dbdatafolder"];
            DirectoryInfo directoryInfo = new DirectoryInfo(dbdatafolder);
            AbstractAccountList resultt = new AbstractAccountList();
            resultt.Items = new List<AbstractAccount>();
            foreach (var filename in directoryInfo.GetFiles())
            {
                AbstractAccount accountItem = dblayer.ME.GetItems<AbstractAccount>(filename.Name);
                resultt.Items.Add(accountItem);
            }
            return resultt;
        }

        internal static void CreateNewAccount(AbstractAccount data)
        {
            //AbstractAccountList accountItems = dblayer.ME.GetItems<AbstractAccountList>("accounts");
            //if(accountItems == null)
            //{
            //    accountItems = new AbstractAccountList();
            //    accountItems.Items = new List<AbstractAccount>();
            //}
            //accountItems.Items.Add(data);
            dblayer.ME.InsertNewItem(data, data.AccountNumber);
        }

        internal static void UpdateAccount(AbstractAccount data)
        {
            
            dblayer.ME.UpdateItem(data);
        }
    }
}