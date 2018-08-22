using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication
{
	class Program
	{
		static void Main(string[] args)
		{
			UserDetails udetails = new UserDetails();

			try
			{
				Console.WriteLine("***************Welcome to the Banking Console**************");
				Console.WriteLine("\nPlease Select the below option to use the Banking");
				udetails.Login();
				Console.ReadLine();
			}
			catch (Exception ex)
			{
				
				throw;
			}
		}
	}
}
