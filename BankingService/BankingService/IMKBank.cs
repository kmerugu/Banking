using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;

namespace BankingService
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMKBank" in both code and config file together.
	[ServiceContract]
	public interface IMKBank
	{

		[OperationContract]
		Boolean CreateNewAccount(string username, string pwd, string email, string mobile);

		[OperationContract]
		int Login(string username, string password);

		[OperationContract]
		Boolean RecordDeposit(int accountNumber, double amount);

		[OperationContract]
		Boolean RecordWithDrawl(int accountNumber, double withdrawlAmount);

		[OperationContract]
		double CheckBalance(int accountNumber);

		[OperationContract]
		int GetAccountNumber(string Name, string email, string mobile);

		[OperationContract]
		DataSet GetUserDetails(int accountNo);
		
		[OperationContract]
		DataSet TransactionHistory(int accountNumber);
	}


	// Use a data contract as illustrated in the sample below to add composite types to service operations.
	[DataContract]
	public class CompositeType
	{
		public string Name { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public string Mobile { get; set; }
	}
}
