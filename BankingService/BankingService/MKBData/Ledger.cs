using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BankingService.MKBData
{
	public class Ledger
	{
		string ConnectionString = ConfigurationManager.ConnectionStrings["BankDBConnection"].ToString();

		public Boolean RecordDeposit(int accountNumber, double DepositAmount)
		{
			try
			{
				int moneyInAccount = GetAccountBalance(accountNumber);
				double amounttoInsertIntoAccount = moneyInAccount + DepositAmount;
				SqlConnection conString = new SqlConnection(ConnectionString);
				string query = "UPDATE dbo.AccountBalance SET BalanceAmount ='" + amounttoInsertIntoAccount + "' WHERE AccountNumber ='" + accountNumber + "' ";
				conString.Open();
				SqlCommand cmd = new SqlCommand(query, conString);
				int records = cmd.ExecuteNonQuery();
				conString.Close();
				if (records > 0)
				{
					RecordUserTransaction(accountNumber, "Debit", DateTime.Now, DepositAmount, "NA");
					return true;
				}
				else
					return false;
			}
			catch (Exception ex)
			{

				throw;
			}

		}

		public Boolean RecordWithDrawl(int accountNumber, double WithdrawlAmount)
		{

			try
			{
				int moneyInAccount = GetAccountBalance(accountNumber);
				double amounttoInsertIntoAccount = moneyInAccount - WithdrawlAmount;

				if (amounttoInsertIntoAccount > 0)
				{
					SqlConnection conString = new SqlConnection(ConnectionString);
					string query = "UPDATE dbo.AccountBalance SET BalanceAmount ='" + amounttoInsertIntoAccount + "' WHERE AccountNumber ='" + accountNumber + "' ";
					conString.Open();
					SqlCommand cmd = new SqlCommand(query, conString);
					int records = cmd.ExecuteNonQuery();
					conString.Close();
					if (records > 0)
					{
						RecordUserTransaction(accountNumber, "Credit", DateTime.Now, WithdrawlAmount, "NA");
						return true;
					}
					
				}
				else
				{
					return false;
				}
				return false;
			}
			catch (Exception ex)
			{

				throw;
			}
		}

		public int GetAccountBalance(int accountNumber)
		{

			try
			{
				SqlConnection conString = new SqlConnection(ConnectionString);
				string query = "Select BalanceAmount from dbo.AccountBalance where AccountNumber ='" + accountNumber + "'";

				SqlDataAdapter da = new SqlDataAdapter(query, conString);
				DataSet ds = new DataSet();
				da.Fill(ds, "balance");
				int bal = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
				return bal;

			}
			catch (Exception ex)
			{

				throw;
			}
		}

		public DataSet GetUserTransactionHistory(int accountNumber)
		{

			try
			{
				SqlConnection conString = new SqlConnection(ConnectionString);
				string query = "SELECT t.TransactionType,t.TransactionDate,t.Amount,t.TransactionRemarks from dbo.TransactionHistory t INNER JOIN dbo.AccountBalance ab on t.[AccountNumber] = ab.AccountNumber WHERE ab.AccountNumber = '" + accountNumber + "'";
				//conString.Open();
				SqlDataAdapter da = new SqlDataAdapter(query, conString);
				DataSet ds = new DataSet();
				da.Fill(ds, "transhis");
				return ds;
			}
			catch (Exception ex)
			{

				throw;
			}
		}

		public void RecordUserTransaction(int accountNumber, string transactionType, DateTime transactionDate, double amount, string transactionRemarks)
		{
			try
			{
				SqlConnection conString = new SqlConnection(ConnectionString);
				string query = "Insert into [dbo].[TransactionHistory]([AccountNumber],[TransactionType],[TransactionDate],[Amount],[TransactionRemarks])VALUES('" + accountNumber + "', '" + transactionType + "', '" + transactionDate + "','" + amount + "', '" + transactionRemarks + "'); ";
				conString.Open();
				SqlCommand cmd = new SqlCommand(query, conString);
				cmd.ExecuteNonQuery();
				conString.Close();
			}
			catch (Exception ex)
			{

				throw;
			}
		}

		public Boolean NewuserAccountDetailsInsert(string Name, string Password, string email, string mobile)
		{
			try
			{
				int acNumber = getAccountNumber(Name, email, mobile);
				SqlConnection conString = new SqlConnection(ConnectionString);
				string query = "Insert into [dbo].[AccountBalance]([AccountNumber],[BalanceAmount])VALUES('" + acNumber + "', '" + 0 + "'); ";
				conString.Open();
				SqlCommand cmd = new SqlCommand(query, conString);
				int records = cmd.ExecuteNonQuery();
				conString.Close();
				if (records > 0)
					return true;
				else
					return false;

			}
			catch (Exception ex)
			{

				throw;
			}
		}

		public DataSet getUserAccountDetails(int accountNumber)
		{
			try
			{
				SqlConnection conString = new SqlConnection(ConnectionString);
				string query = "SELECT u.AccountNumber, u.Name, u.Password,u.Email,u.Mobile, ab.BalanceAmount from dbo.[User] u INNER JOIN dbo.AccountBalance ab on u.[AccountNumber] = ab.AccountNumber WHERE ab.AccountNumber = '" + accountNumber + "'";
				//conString.Open();
				SqlDataAdapter cmd = new SqlDataAdapter(query, conString);
				DataSet ds = new DataSet();
				cmd.Fill(ds, "useracInfo");
				return ds;
			}
			catch (Exception ex)
			{

				throw;
			}
		}

		public int getAccountNumber(string Name, string email, string mobile)
		{

			try
			{
				SqlConnection conString = new SqlConnection(ConnectionString);
				string query = "SELECT AccountNumber from dbo.[User] where Email = '" + email + "' and Mobile = '" + mobile + "'and Name = '" + Name + "'";
				SqlDataAdapter cmd = new SqlDataAdapter(query, conString);
				DataSet ds = new DataSet();
				cmd.Fill(ds, "useracNo");
				return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
			}
			catch (Exception ex)
			{

				throw;
			}
		}
	}
}