using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppASP.BankingService;

namespace WebAppASP
{
	public partial class _Default : Page
	{
		MKBankClient serviceRefrence = new MKBankClient();
		
		protected void Page_Load(object sender, EventArgs e)
		{
			
		}


		protected void btnLogIn_Click(object sender, EventArgs e)
		{
			int AccountNumber = serviceRefrence.Login(txtUsername.Text, txtPwd.Text);
			Session["AccountNumber"] = AccountNumber;
			if (AccountNumber != 0)
			{
				Response.Redirect("AccountDetails.aspx");
			}
			else
			{
				lbCredentialsError.Visible = true;
			}
		}

		protected void btnCreateUser_Click(object sender, EventArgs e)
		{
			bool accountCreated = serviceRefrence.CreateNewAccount(txtSignUpUsername.Text, txtSignUpPwd.Text, txtSignUpEmail.Text, txtSignUpPhone.Text);
			if (accountCreated)
			{
				lblCreateAccount.Visible = true;
			}
		}
	}
}