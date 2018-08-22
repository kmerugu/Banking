<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccountDetails.aspx.cs" Inherits="WebAppASP.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >
	<div style="background-color:antiquewhite">
		<table style="width:100%;">
			<tr>
				<td style="width: 812px">
					&nbsp;</td>
				<td style="font-size: medium; float:right">
					Account No:
					<asp:Label ID="lblAccountNum" runat="server" ></asp:Label>
				</td>
			</tr>
			<tr>
				<td style="width: 812px">
					&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ***Welcome to the MK bank***<br />
					Please use the Following options to access your Account Details<br />
					<br />
					<br />
					<asp:RadioButtonList ID="RadioButtonList1" runat="server" Font-Bold="False" Font-Size="Medium">
						<asp:ListItem Value="1">WithDraw</asp:ListItem>
						<asp:ListItem Value="2">Deposit</asp:ListItem>
						<asp:ListItem Value="3">Balance Enquiry</asp:ListItem>
						<asp:ListItem Value="4">Transaction History</asp:ListItem>
					</asp:RadioButtonList>
					<br />
					<asp:Button ID="btnAccountDetails" runat="server" OnClick="btnAccountDetails_Click" Text="Submit" Font-Size="Medium" />
				</td>
				<td>
					&nbsp;</td>
			</tr>
		</table>
	
	<br />
	<asp:MultiView ID="MVAccountDetails" runat="server">
		<asp:View ID="ViewWithDrawl" runat="server">
			Please enter the amount to withdraw: $
			<asp:TextBox ID="txtWithDraw" runat="server" EnableViewState="False" ></asp:TextBox>
			<asp:RequiredFieldValidator ID="rfvWithdraw" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtWithDraw" ForeColor="Red" ValidationGroup="Withdraw">Enter Amount in USD</asp:RequiredFieldValidator>
			<br />
			<asp:Button ID="btnWithdraw" runat="server" Text="Submit" OnClick="btnWithdraw_Click" ValidationGroup="Withdraw"/>
			<br />
			<br />
			<asp:Label ID="lblWithdraw" runat="server"  Visible="False" EnableViewState="False"></asp:Label>
		</asp:View>
		<asp:View ID="ViewDeposit" runat="server">
			Please enter the amount to deposit: $
			<asp:TextBox ID="txtDeposit" runat="server" EnableViewState="False" ></asp:TextBox>
			<asp:RequiredFieldValidator ID="rfvDeposit" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ControlToValidate="txtDeposit" ValidationGroup="deposit">Enter Amount in USD</asp:RequiredFieldValidator>
			<br />
			<asp:Button ID="btnDeposit" runat="server" Text="Submit" OnClick="btnDeposit_Click" ValidationGroup="deposit"/>
			<br />
			<br />
			<asp:Label ID="lblDeposit" runat="server"  Visible="False" EnableViewState="False" ></asp:Label>
		</asp:View>
		<asp:View ID="ViewBalEnquiry" runat="server">			
			<asp:Label ID="lblEnquiry" runat="server" Text="Balance Amount in the Account is :" Visible="False" EnableViewState="False"></asp:Label>
		</asp:View>
		<asp:View ID="ViewHistory" runat="server">			
			<asp:Label ID="lblHistory" runat="server"  Visible="False" EnableViewState="False"></asp:Label>			
		</asp:View>
	</asp:MultiView>
	<br />
	<br />
		</div>
</asp:Content>
