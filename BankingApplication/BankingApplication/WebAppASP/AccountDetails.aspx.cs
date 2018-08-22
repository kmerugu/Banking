using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppASP.BankingService;
using System.Drawing;

namespace WebAppASP
{
	public partial class Contact : Page
	{
		MKBankClient serviceRefrence = new MKBankClient();
		int ACnumber;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["AccountNumber"] != null)
			{
				ACnumber =(int)Session["AccountNumber"];
				lblAccountNum.Text = ACnumber.ToString();
			}
		}
	
		protected void btnAccountDetails_Click(object sender, EventArgs e)
		{
			if (RadioButtonList1.SelectedValue != null)
			{
				switch(Convert.ToInt16(RadioButtonList1.SelectedValue))
				{
					case 1:
						MVAccountDetails.ActiveViewIndex = 0;						
						break;
					case 2:
						MVAccountDetails.ActiveViewIndex = 1;
						break;
					case 3:
						string balanceAmount=GetBalance();
						MVAccountDetails.ActiveViewIndex = 2;
						lblEnquiry.Text = lblEnquiry.Text + balanceAmount;
						lblEnquiry.Visible = true;
						break;
					case 4:
						GetHistory();
						MVAccountDetails.ActiveViewIndex = 3;
						lblHistory.Visible = true;
						break;

				}
				
	        }
		}
		protected void btnWithdraw_Click(object sender, EventArgs e)
		{
			try
			{
				bool withdrawlSucc = serviceRefrence.RecordWithDrawl(ACnumber, Convert.ToDouble(txtWithDraw.Text));
				if (withdrawlSucc)
				{
					lblWithdraw.Text = "Withdraw transaction Successful";
					lblWithdraw.Visible = true;
				}
				else
				{
					lblWithdraw.Text = "Withdraw transaction failed. Please try again with correct amount";
					lblWithdraw.Visible = true;
				}
			}
			catch(Exception ex)
			{
				lblWithdraw.ForeColor = Color.Red;
				lblWithdraw.Text = "Enter a valid amount";
				lblWithdraw.Visible = true;
			}
		}
		protected void btnDeposit_Click(object sender, EventArgs e)
		{
			try
			{
				bool depositSucc = serviceRefrence.RecordDeposit(ACnumber, Convert.ToDouble(txtDeposit.Text));
				if (depositSucc)
				{
					lblDeposit.Text = "Deposit transaction Successful";
					lblDeposit.Visible = true;
				}
				else
				{
					lblDeposit.Text = "Deposit transaction failed. Please try again";
					lblDeposit.Visible = true;
				}
			}
			catch(Exception ex)
			{
				lblDeposit.ForeColor = Color.Red;
				lblDeposit.Text = "Enter a valid amount";
				lblDeposit.Visible = true;
			}
		}

		protected string GetBalance()
		{
			DataSet userDatasetDetails = serviceRefrence.GetUserDetails(ACnumber);
			string balance= userDatasetDetails.Tables[0].Rows[0][5].ToString();
			return balance;
		}

		protected void GetHistory()
		{
			DataSet ds = serviceRefrence.TransactionHistory(ACnumber);
			StringBuilder sb = new StringBuilder();
			if (ds.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
				{
					sb.AppendLine("TransactionType:  " + ds.Tables[0].Rows[i][0].ToString() + "    TransactionDate:  " + ds.Tables[0].Rows[i][1].ToString() + "    Amount:  " + ds.Tables[0].Rows[i][2].ToString() + "    TransactionRemarks: " + ds.Tables[0].Rows[i][3].ToString());		
				}
			}
			else
			{
				sb.AppendLine("******No transactions made for this account******");
			}
			lblHistory.Text = sb.ToString().Replace(Environment.NewLine, "<br />");
		}
	}
}