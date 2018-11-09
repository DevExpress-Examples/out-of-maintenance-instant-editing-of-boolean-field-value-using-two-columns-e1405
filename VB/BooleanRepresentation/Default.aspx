<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="BooleanRepresentation._Default" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>Untitled Page</title>
</head>
<body>
	<form id="form1" runat="server">
	<div style="width:75%">
		<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
			SelectCommand="SELECT [ProductID], [ProductName], [UnitPrice], [Discontinued] FROM [Products]" DeleteCommand="DELETE FROM [Products] WHERE [ProductID] = @ProductID" InsertCommand="INSERT INTO [Products] ([ProductName], [UnitPrice], [Discontinued]) VALUES (@ProductName, @UnitPrice, @Discontinued)" UpdateCommand="UPDATE [Products] SET [ProductName] = @ProductName, [UnitPrice] = @UnitPrice, [Discontinued] = @Discontinued WHERE [ProductID] = @ProductID">
			<DeleteParameters>
				<asp:Parameter Name="ProductID" Type="Int32" />
			</DeleteParameters>
			<UpdateParameters>
				<asp:Parameter Name="ProductName" Type="String" />
				<asp:Parameter Name="UnitPrice" Type="Decimal" />
				<asp:Parameter Name="Discontinued" Type="Boolean" />
				<asp:Parameter Name="ProductID" Type="Int32" />
			</UpdateParameters>
			<InsertParameters>
				<asp:Parameter Name="ProductName" Type="String" />
				<asp:Parameter Name="UnitPrice" Type="Decimal" />
				<asp:Parameter Name="Discontinued" Type="Boolean" />
			</InsertParameters>
		</asp:SqlDataSource>
		<dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False"
			DataSourceID="SqlDataSource1" KeyFieldName="ProductID" OnHtmlRowCreated="ASPxGridView1_HtmlRowCreated" Width="100%">
			<Columns>
				<dxwgv:GridViewDataTextColumn FieldName="ProductID" ReadOnly="True" VisibleIndex="0">
					<EditFormSettings Visible="False" />
				</dxwgv:GridViewDataTextColumn>
				<dxwgv:GridViewDataTextColumn FieldName="ProductName" VisibleIndex="1">
				</dxwgv:GridViewDataTextColumn>
				<dxwgv:GridViewDataTextColumn FieldName="UnitPrice" VisibleIndex="2">
				</dxwgv:GridViewDataTextColumn>
				<dxwgv:GridViewDataTextColumn FieldName="Discontinued" VisibleIndex="3">
					<DataItemTemplate>
						<dxe:aspxradiobutton id="btnDiscontinued" runat="server" checked='<%#Eval("Discontinued")%>'
							clientinstancename="btnDiscontinued"></dxe:aspxradiobutton>
					</DataItemTemplate>
				</dxwgv:GridViewDataTextColumn>
				<dxwgv:GridViewDataTextColumn Caption="In production" FieldName="InProduction"
					VisibleIndex="4">
					<DataItemTemplate>
						<dxe:aspxradiobutton id="btnInProduction" runat="server" checked='<%#Not CBool(Eval("Discontinued"))%>'
							clientinstancename="btnInProduction" ></dxe:aspxradiobutton>
					</DataItemTemplate>
				</dxwgv:GridViewDataTextColumn>
			</Columns>
			<SettingsPager Mode="ShowAllRecords" Visible="False">
				<Summary Visible="False" />
			</SettingsPager>
			<Settings ShowVerticalScrollBar="True" />
		</dxwgv:ASPxGridView>
		<br />
		<dxe:ASPxButton ID="ASPxButton1" runat="server" OnClick="ASPxButton1_Click" Text="Update">
		</dxe:ASPxButton>

	</div>
	</form>
</body>
</html>
