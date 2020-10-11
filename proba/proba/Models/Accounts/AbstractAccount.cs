using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI.HtmlControls;

namespace proba.Models.Accounts
{
    public class AbstractAccount
    {
        //#region private variables
        //private string _accountNumber;
        //private Currency.Currency _currency;
        //private float _balance;
        //private string _ownerName;
        //private bool _canWithdrawCash;
        //private bool _canBeDeposite;
        //private bool _existCreditLine;
        //#endregion
        #region public properties
        /// <summary>
        /// szamlaszam
        /// </summary>
        public string AccountNumber { get; set; }// { get { return this._accountNumber; } }
        /// <summary>
        /// PENZNEM
        /// </summary>
        public Currency.Currency Currency { get; set; }//{ get { return this.Currency; } }
        /// <summary>
        /// eegyenleg
        /// </summary>
        public float Balance { get; set; }//{ get { return this._balance; } }
        /// <summary>
        /// tulajdonos
        /// </summary>
        public string OwnerName { get; set; }//{ get { return this._ownerName; } }
        /// <summary>
        /// keezpenz felvetel
        /// </summary>
        public bool CanWithdrawCash { get; set; }//{ get { return this._canWithdrawCash; } }
        /// <summary>
        /// keszpenz befizetes
        /// </summary>
        public bool CanBeDeposited { get; set; }//{ get { return this._canBeDeposite; } }
        /// <summary>
        /// hitelkeret
        /// </summary>
        public bool ExistCreditLine { get; set; }//{ get { return this._existCreditLine; } }
        #endregion

    }

    public class AbstractAccountList
    {
        public List<AbstractAccount> Items { get; set; }
    }
}