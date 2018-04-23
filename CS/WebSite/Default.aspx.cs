using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["TableName"] == null)
            Response.Redirect("Default.aspx?TableName=Customers"); // if no parameter was supplied, display the Customers table content
        else {
            string tableName = Request.QueryString["TableName"];
            XtraReport1 report = new XtraReport1(tableName);
            ReportViewer1.Report = report;
        }
    }
}
