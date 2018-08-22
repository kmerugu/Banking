using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApplication.BankingService;

namespace BankingApplication
{
	public class UserDetails
	{
		MKBankClient serviceRefrence = new MKBankClient();
		AccountDetails acDetails = new AccountDetails();

		public void Login()
		{
			try
			{

				Console.WriteLine("1. Login \n2. Register user");
				string inputvalue = Console.ReadLine();
				if (inputvalue == "1")
				{
					Console.WriteLine("Enter UserName : ");
					string username = Console.ReadLine();
					Console.WriteLine("Enter password:");
					string password = Console.ReadLine();
					int accountNumber = serviceRefrence.Login(username, password);
					Console.Clear();
					if (accountNumber != 0)
					{
						Console.WriteLine("***Welcome to the MK bank***" + username.ToUpper());

						//populate user details here by using the account number
						DataSet userDatasetDetails = serviceRefrence.GetUserDetails(accountNumber);

						AccountDetailsDTO.AccountNumber = Convert.ToInt32(userDatasetDetails.Tables[0].Rows[0][0]);
						AccountDetailsDTO.Name = userDatasetDetails.Tables[0].Rows[0][1].ToString();
						AccountDetailsDTO.Email = userDatasetDetails.Tables[0].Rows[0][3].ToString();
						AccountDetailsDTO.Mobile = userDatasetDetails.Tables[0].Rows[0][4].ToString();
						AccountDetailsDTO.Balance = userDatasetDetails.Tables[0].Rows[0][5].ToString();

						acDetails.GetOptions();
					}
					else
					{
						Console.WriteLine("");
						Console.WriteLine("Login failed. Please enter valid credentials");
						Login();
					}
				}
				else if (inputvalue == "2")
				{
					RegisterUser();
				}
				else
				{
					Console.WriteLine("Enter either 1 or 2 ");
					Login();
				}
			}
			catch (Exception ex)
			{

				throw;
			}
		}

		private void RegisterUser()
		{
			Console.WriteLine("***User registration*** ");
			Console.WriteLine("Enter Username: ");
			string userName = Console.ReadLine();
			Console.WriteLine("Enter Password: ");
			string pwd = Console.ReadLine();
			Console.WriteLine("Enter Email Address: ");
			string email = Console.ReadLine();
			Console.WriteLine("Enter Mobile Number: ");
			string mobile = Console.ReadLine();

			if (!String.IsNullOrEmpty(userName) && !String.IsNullOrEmpty(pwd) && !String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(mobile))
			{
				CreateNewAccount(userName, pwd, email, mobile);
			}
			else
			{
				RegisterUser();
			}

		}

		public void CreateNewAccount(string Name, string Password, string email, string mobile)
		{

			try
			{
				bool accountCreated = serviceRefrence.CreateNewAccount(Name, Password, email, mobile);
				if (accountCreated)
				{
					AccountDetailsDTO.Name = Name;
					AccountDetailsDTO.Email = email;
					AccountDetailsDTO.Mobile = mobile;
				}
				Console.WriteLine("User Bank Acount Created Successfully");
				Console.WriteLine("Press Enter to continue");
				Login();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Please give valid details");
				RegisterUser();
			}


		}

	}
}
