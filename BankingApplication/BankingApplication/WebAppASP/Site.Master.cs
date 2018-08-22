using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppASP
{
	public partial class SiteMaster : MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void btnLogOut_Click(object sender, EventArgs e)
		{
			Session.Abandon();
			Session.Clear();
			Response.Redirect("~/Default.aspx");		
		}
	}
}