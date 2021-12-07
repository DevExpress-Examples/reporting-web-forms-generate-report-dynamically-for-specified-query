Public Class HomeController
	Inherits Controller

	Public Function Index() As ActionResult
		Return View()
	End Function

	Public Function Viewer() As ActionResult
		If Request.QueryString("TableName") Is Nothing Then
			Response.Redirect("Viewer?TableName=Customers")
		Else
			Dim tableName As String = Request.QueryString("TableName")
			Dim report As New TestReport(tableName)
			Return View(report)
		End If
		Return View(New DevExpress.XtraReports.UI.XtraReport())
	End Function
End Class
