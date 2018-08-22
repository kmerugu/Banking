<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebAppASP._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
		<table style="width: 100%; height: 155px;">
			<tr>
				<td class="modal-sm" style="width: 490px">
					<strong>SignIn</strong><br />
					<br />
					<table style="width:100%;">
						<tr>
							<td class="modal-sm" style="width: 90px">
					<asp:Label ID="Label1" runat="server" Text="UserName"></asp:Label>
							</td>
							<td>
					<asp:TextBox ID="txtUsername" runat="server" Width="121px"></asp:TextBox>*
								<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername" ForeColor="Red" ValidationGroup="SignIn">UserName required</asp:RequiredFieldValidator>
							</td>
						</tr>
						<tr>
							<td class="modal-sm" style="width: 90px">
					<asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
							</td>
							<td>
					<asp:TextBox ID="txtPwd" runat="server" Width="121px" TextMode="Password"></asp:TextBox>*
								<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPwd" ForeColor="Red" ValidationGroup="SignIn">Password required</asp:RequiredFieldValidator>
							</td>
						</tr>
					</table>
					<br />
					<asp:Button ID="btnLogIn" runat="server" Text="Log In" OnClick="btnLogIn_Click" ValidationGroup="SignIn"/>
					<strong>
					<br />
					<br />
					<asp:Label ID="lbCredentialsError" runat="server" ForeColor="Red" Text="Invalid UserName or Password" Visible="False"></asp:Label>
					</strong>
				</td>
				<td>
					<strong>SignUp<br />
					</strong><br />
					<table style="width:100%;">
						<tr>
							<td style="width: 88px">
								<asp:Label ID="Label3" runat="server" Text="UserName"></asp:Label>
							</td>
							<td>
								<asp:TextBox ID="txtSignUpUsername" runat="server" ></asp:TextBox>*
								<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSignUpUsername" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="CreateUser">UserName Required</asp:RequiredFieldValidator>
							</td>
						</tr>
						<tr>
							<td style="width: 88px">
								<asp:Label ID="Label4" runat="server" Text="Password"></asp:Label>
							</td>
							<td>
								<asp:TextBox ID="txtSignUpPwd" runat="server" TextMode="Password"></asp:TextBox>*
								<asp:RequiredFieldValidator ID="RequiredFieldValidator4"  runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ControlToValidate="txtSignUpPwd" ValidationGroup="CreateUser">Password Required</asp:RequiredFieldValidator>
							</td>
						</tr>
						<tr>
							<td style="width: 88px">
								<asp:Label ID="Label5" runat="server" Text="Email"></asp:Label>
							</td>
							<td>
								<asp:TextBox ID="txtSignUpEmail" runat="server"></asp:TextBox>*
								<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ControlToValidate="txtSignUpEmail" ValidationGroup="CreateUser">Email Required</asp:RequiredFieldValidator>
								<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ControlToValidate="txtSignUpEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Invalid Email</asp:RegularExpressionValidator>
							</td>
						</tr>
						<tr>
							<td style="width: 88px">

								<asp:Label ID="Label6" runat="server" Text="Phone"></asp:Label>

							</td>
							<td>
								<asp:TextBox ID="txtSignUpPhone" runat="server"></asp:TextBox>*
								<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ControlToValidate="txtSignUpPhone" ValidationGroup="CreateUser">Phone Number Required</asp:RequiredFieldValidator>
								<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ControlToValidate="txtSignUpPhone" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}">Invalid Phone Number</asp:RegularExpressionValidator>
							</td>
						</tr>
					</table>
					<br />
					<asp:Button ID="btnCreateUser" runat="server" Text="Create User" OnClick="btnCreateUser_Click" ValidationGroup="CreateUser"/>
					<br />
					<br />
					<strong>
					<asp:Label ID="lblCreateAccount" runat="server" Text="User Bank Account Created Successfully" Visible="False"></asp:Label>
					</strong>
				</td>
				<td>&nbsp;</td>
			</tr>
			
		</table>
    </div>

    </asp:Content>
