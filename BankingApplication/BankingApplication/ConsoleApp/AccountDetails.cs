using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApplication.BankingService;

namespace BankingApplication
{
	public class AccountDetails
	{
		public AccountDetails()
		{

		}
		MKBankClient serviceRefrence = new MKBankClient();

			
		public int getAccountNumber()
		{

			try
			{
				return AccountDetailsDTO.AccountNumber = serviceRefrence.GetAccountNumber(AccountDetailsDTO.Name, AccountDetailsDTO.Email, AccountDetailsDTO.Mobile);


			}
			catch (Exception ex)
			{

				throw;
			}
		}
	
		public void GetOptions()
		{
			Console.WriteLine("\n Please use the Following options to access your Account Details");
			Console.WriteLine("1.WithDrawl \n2.Deposit \n3.Balance Enquiry \n4.Transaction History \n5.LogOut");
			string ip = Console.ReadLine();
			if(!String.IsNullOrEmpty(ip))
			{
				NavigatetoUserOptions(ip);
			}
			else
			{
				GetOptions();
			}
		}
		public void NavigatetoUserOptions(string input)
		{
			int ACnumber = getAccountNumber();
			//WithDrawl
			if (input == "1")
			{
				Console.WriteLine("Please Enter the Amount to Withdraw");
				string num = Console.ReadLine();
				if (!String.IsNullOrEmpty(num))
				{
					try
					{
						bool withdrawlSucc = serviceRefrence.RecordWithDrawl(ACnumber, Convert.ToDouble(num));
						if (withdrawlSucc)
							Console.WriteLine("withdrawl transaction is Successful");
						else
							Console.WriteLine("withdrawl transaction has failed !");
					}
					catch(Exception ex)
					{
						Console.WriteLine("Invalid Amount");
						NavigatetoUserOptions(input);
					}
				}
				else
				{
					NavigatetoUserOptions(input);
				}
			}
			//Deposit
			else if (input == "2")
			{
				Console.WriteLine("Please Enter the Amount to Deposit");
				string num = Console.ReadLine();
				if (!String.IsNullOrEmpty(num))
				{
					try
					{
						bool DepositSucc = serviceRefrence.RecordDeposit(ACnumber, Convert.ToDouble(num));

						if (DepositSucc)
							Console.WriteLine("Deposit transaction is Successful");
						else
							Console.WriteLine("Deposit transaction has failed !");
					}
					catch
					{
						Console.WriteLine("Invalid Amount");
						NavigatetoUserOptions(input);
					}
				}
				else
				{
					NavigatetoUserOptions(input);
				}
			}
			//Balance
			else if (input == "3")
			{
				DataSet userDatasetDetails = serviceRefrence.GetUserDetails(ACnumber);
				string Balance = userDatasetDetails.Tables[0].Rows[0][5].ToString(); 
				Console.WriteLine("Balance Amount in the Account is : " + Balance);
			}
			//Transaction History
			else if (input == "4")
			{
				Console.WriteLine("*****Transaction History*******");
				DataSet ds = serviceRefrence.TransactionHistory(AccountDetailsDTO.AccountNumber);

				if (ds.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
					{
						Console.WriteLine("TransactionType:  " + ds.Tables[0].Rows[i][0].ToString() + "    TransactionDate:  " + ds.Tables[0].Rows[i][1].ToString() + "    Amount:  " + ds.Tables[0].Rows[i][2].ToString() + "    TransactionRemarks: " + ds.Tables[0].Rows[i][3].ToString());
					}
				}
				else
				{
					Console.WriteLine(" No transactions made for this account ");
				}
				Console.WriteLine("*****Transaction History END *******");
			}
			else if (input == "5")
			{				
				Environment.Exit(0);

			}
			else
			{
				Console.WriteLine(" Enter a valid input from the following options ");
				GetOptions();
			}
			GetOptions();
		}
	}
}
