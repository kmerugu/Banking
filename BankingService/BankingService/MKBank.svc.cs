using BankingService.MKBData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BankingService
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MKBank" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select MKBank.svc or MKBank.svc.cs at the Solution Explorer and start debugging.
	public class MKBank : IMKBank
	{
		UserDetails userInformation = new UserDetails();
		Ledger AccountInformation = new Ledger();

		public double CheckBalance(int accountNumber)
		{
			return AccountInformation.GetAccountBalance(accountNumber);
		}

		public bool CreateNewAccount(string name, string pwd, string email, string mobile)
		{
			return userInformation.CreateNewAccount(name, pwd, email, mobile);
		}

		public int Login(string username, string password)
		{
			return userInformation.Login(username, password);
		}

		public bool RecordDeposit(int accountNumber, double amount)
		{
			return AccountInformation.RecordDeposit(accountNumber, amount);
		}

		public bool RecordWithDrawl(int accountNumber, double withdrawlAmount)
		{
			return AccountInformation.RecordWithDrawl(accountNumber, withdrawlAmount);
		}

		public int GetAccountNumber(string Name, string email, string mobile)
		{
			return AccountInformation.getAccountNumber(Name, email, mobile);
		}

		public DataSet GetUserDetails(int accountNumber)
		{
			return AccountInformation.getUserAccountDetails(accountNumber);
		}

		public DataSet TransactionHistory(int accountNumber)
		{

			return AccountInformation.GetUserTransactionHistory(accountNumber);
		}
	}
}
