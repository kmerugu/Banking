using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BankingService.MKBData
{
	public class UserDetails
	{
		string ConnectionString = ConfigurationManager.ConnectionStrings["BankDBConnection"].ToString();
		Ledger userAccountinforamtion = new Ledger();
		public int Login(string username, string password)
		{
			try
			{
				string query = "Select AccountNumber from dbo.[User] where Name ='" + username + "' AND Password = '" + password + "'";
				SqlConnection conString = new SqlConnection(ConnectionString);
				SqlDataAdapter da = new SqlDataAdapter(query, conString);
				DataSet ds = new DataSet();
				da.Fill(ds, "AcNo");
				if (ds.Tables[0].Rows.Count > 0)
					return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
				else
					return 0;

			}
			catch (Exception ex)
			{

				throw;
			}
		}

		public Boolean CreateNewAccount(string Name, string Password, string email, string mobile)
		{
			try
			{
				try
				{
					SqlConnection conString = new SqlConnection(ConnectionString);
					string query = "Insert into [dbo].[User]([Name],[Password],[Email],[Mobile])VALUES('" + Name + "', '" + Password + "', '" + email + "', '" + mobile + "'); ";
					conString.Open();
					SqlCommand cmd = new SqlCommand(query, conString);
					int records = cmd.ExecuteNonQuery();
					conString.Close();
					if (records > 0)
					{
						userAccountinforamtion.NewuserAccountDetailsInsert(Name, Password, email, mobile);
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
			catch (Exception ex)
			{

				throw;
			}
		}
	}
}