using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication
{
	class DTO
	{
	}
	public static class AccountDetailsDTO
	{
		public static string Name { get; set; }
		public static string Password { get; set; }
		public static string Email { get; set; }
		public static string Mobile { get; set; }

		public static string Balance { get; set; }

		public static int AccountNumber { get; set; }
	}

}
