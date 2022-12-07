Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Web

Namespace BooleanRepresentation
	Partial Public Class _Default
		Inherits System.Web.UI.Page
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

		Protected Sub ASPxGridView1_HtmlRowCreated(ByVal sender As Object, ByVal e As ASPxGridViewTableRowEventArgs)
			If e.RowType = GridViewRowType.Data Then
				Dim grid As ASPxGridView = TryCast(sender, ASPxGridView)
				Dim discontinued As ASPxRadioButton = TryCast(grid.FindRowCellTemplateControl(e.VisibleIndex, TryCast(grid.Columns("Discontinued"), GridViewDataColumn), "btnDiscontinued"), ASPxRadioButton)
				Dim inproduction As ASPxRadioButton = TryCast(grid.FindRowCellTemplateControl(e.VisibleIndex, TryCast(grid.Columns("InProduction"), GridViewDataColumn), "btnInProduction"), ASPxRadioButton)
				discontinued.ClientInstanceName = "btnDiscontinued" & e.VisibleIndex
				inproduction.ClientInstanceName = "btnInProduction" & e.VisibleIndex
				inproduction.ClientSideEvents.CheckedChanged = String.Format("function (s,e) {{if(btnInProduction{0}.GetChecked()) {{btnDiscontinued{0}.SetChecked(false);}}}}", e.VisibleIndex)
				discontinued.ClientSideEvents.CheckedChanged = String.Format("function (s,e) {{if(btnDiscontinued{0}.GetChecked()) {{btnInProduction{0}.SetChecked(false);}}}}", e.VisibleIndex)
			End If
		End Sub

		Protected Sub ASPxButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
			For i As Integer = ASPxGridView1.VisibleStartIndex To ASPxGridView1.VisibleStartIndex + ASPxGridView1.VisibleRowCount - 1
				Dim discontinued As ASPxRadioButton = TryCast(ASPxGridView1.FindRowCellTemplateControl(i, TryCast(ASPxGridView1.Columns("Discontinued"), GridViewDataColumn), "btnDiscontinued"), ASPxRadioButton)
				Dim vals() As Object = CType(ASPxGridView1.GetRowValues(i, New String() { "ProductName", "UnitPrice", "ProductID" }), Object())

				SqlDataSource1.UpdateParameters("ProductName").DefaultValue = vals(0).ToString()
				SqlDataSource1.UpdateParameters("UnitPrice").DefaultValue = vals(1).ToString()
				SqlDataSource1.UpdateParameters("ProductID").DefaultValue = vals(2).ToString()
				SqlDataSource1.UpdateParameters("Discontinued").DefaultValue = discontinued.Checked.ToString()
				'SqlDataSource1.Update();  //uncomment this line to submit changes to the database
			Next i
		End Sub
	End Class
End Namespace
