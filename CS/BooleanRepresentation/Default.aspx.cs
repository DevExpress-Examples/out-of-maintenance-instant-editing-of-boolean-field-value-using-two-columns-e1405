using System;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxEditors;

namespace BooleanRepresentation {
    public partial class _Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void ASPxGridView1_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e) {
            if (e.RowType == GridViewRowType.Data) {
                ASPxGridView grid = sender as ASPxGridView;
                ASPxRadioButton discontinued = grid.FindRowCellTemplateControl(e.VisibleIndex, grid.Columns["Discontinued"] as GridViewDataColumn, "btnDiscontinued") as ASPxRadioButton;
                ASPxRadioButton inproduction = grid.FindRowCellTemplateControl(e.VisibleIndex, grid.Columns["InProduction"] as GridViewDataColumn, "btnInProduction") as ASPxRadioButton;
                discontinued.ClientInstanceName = "btnDiscontinued" + e.VisibleIndex;
                inproduction.ClientInstanceName = "btnInProduction" + e.VisibleIndex;
                inproduction.ClientSideEvents.CheckedChanged = String.Format("function (s,e) {{if(btnInProduction{0}.GetChecked()) {{btnDiscontinued{0}.SetChecked(false);}}}}", e.VisibleIndex);
                discontinued.ClientSideEvents.CheckedChanged = String.Format("function (s,e) {{if(btnDiscontinued{0}.GetChecked()) {{btnInProduction{0}.SetChecked(false);}}}}", e.VisibleIndex);
            }
        }

        protected void ASPxButton1_Click(object sender, EventArgs e) {
            for (int i = ASPxGridView1.VisibleStartIndex; i < ASPxGridView1.VisibleStartIndex + ASPxGridView1.VisibleRowCount; i++)
            {
                ASPxRadioButton discontinued = ASPxGridView1.FindRowCellTemplateControl(i, ASPxGridView1.Columns["Discontinued"] as GridViewDataColumn, "btnDiscontinued") as ASPxRadioButton;
                object[] vals = (object[]) ASPxGridView1.GetRowValues(i, new string[] { "ProductName", "UnitPrice", "ProductID" });

                SqlDataSource1.UpdateParameters["ProductName"].DefaultValue  = vals[0].ToString();
                SqlDataSource1.UpdateParameters["UnitPrice"].DefaultValue    = vals[1].ToString();
                SqlDataSource1.UpdateParameters["ProductID"].DefaultValue    = vals[2].ToString();
                SqlDataSource1.UpdateParameters["Discontinued"].DefaultValue = discontinued.Checked.ToString(); 
                //SqlDataSource1.Update();  //uncomment this line to submit changes to the database
            }
        }
    }
}
