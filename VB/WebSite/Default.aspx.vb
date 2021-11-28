Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Partial Public Class _Default
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If Request.QueryString("TableName") Is Nothing Then
			Response.Redirect("Default.aspx?TableName=Customers") ' if no parameter was supplied, display the Customers table content
		Else
			Dim tableName As String = Request.QueryString("TableName")
			Dim report As New XtraReport1(tableName)

			ASPxWebDocumentViewer1.OpenReport(report)
		End If
	End Sub
End Class
