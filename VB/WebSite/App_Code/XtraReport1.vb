Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports DevExpress.XtraReports.UI
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Data.OleDb

''' <summary>
''' Summary description for XtraReport1
''' </summary>
Public Class XtraReport1
	Inherits DevExpress.XtraReports.UI.XtraReport
	Private Detail As DevExpress.XtraReports.UI.DetailBand
	Private PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
	''' <summary>
	''' Required designer variable.
	''' </summary>
	Private components As System.ComponentModel.IContainer = Nothing


	Public Sub New(ByVal tableName As String)
		InitializeComponent()
		'
		' TODO: Add constructor logic here
		'

		Dim ds As New DataSet()
		Dim dt As New DataTable(tableName)
		ds.Tables.Add(dt)

		Dim queryString As String = String.Format("SELECT * FROM {0}", tableName)

		Dim connectionString As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("nwindConnectionString").ConnectionString

		Dim rowsCount As Integer = -1

		Using connection As New OleDbConnection(connectionString)
			Try
				Dim adapter As New OleDbDataAdapter()
				adapter.SelectCommand = New OleDbCommand(queryString, connection)
				rowsCount = adapter.Fill(ds, tableName)
			Catch e1 As OleDbException
			End Try

		End Using


		Dim label As New XRLabel()
		label.Width = 500
		label.Font = New System.Drawing.Font("Verdana", 10F, FontStyle.Bold)
		PageHeader.Controls.Add(label)

		If rowsCount > 0 Then
			Dim padding As Integer = 10
			Dim tableWidth As Integer = Me.PageWidth - Me.Margins.Left - Me.Margins.Right - padding * 2

			Dim dynamicTable As XRTable = XRTable.CreateTable(New Rectangle(padding, 2, tableWidth, 40), 1, 0) ' table column count

			dynamicTable.Width = tableWidth
			dynamicTable.Rows.FirstRow.Width = tableWidth
			dynamicTable.Borders = DevExpress.XtraPrinting.BorderSide.All
			dynamicTable.BorderWidth = 1
			Dim i As Integer = 0
dynamicTable.BeginInit()
			For Each dc As DataColumn In ds.Tables(tableName).Columns

				Dim cell As New XRTableCell()

				Dim binding As New XRBinding("Text", ds, ds.Tables(tableName).Columns(i).ColumnName)
				cell.DataBindings.Add(binding)
				cell.CanGrow = False
				cell.Width = 100
				cell.Text = dc.ColumnName
				dynamicTable.Rows.FirstRow.Cells.Add(cell)
				i += 1
			Next dc
			dynamicTable.Font = New System.Drawing.Font("Verdana", 8F)
dynamicTable.EndInit()
			Detail.Controls.Add(dynamicTable)

			label.Text = String.Format("Data table: {0}", tableName)

			Me.DataSource = ds
			Me.DataMember = tableName
		Else
			label.Text = String.Format("There's no data to display or the table doesn't exists")
		End If
	End Sub

	''' <summary> 
	''' Clean up any resources being used.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
		If disposing AndAlso (components IsNot Nothing) Then
			components.Dispose()
		End If
		MyBase.Dispose(disposing)
	End Sub

	#Region "Designer generated code"

	''' <summary>
	''' Required method for Designer support - do not modify
	''' the contents of this method with the code editor.
	''' </summary>
	Private Sub InitializeComponent()
		Dim resourceFileName As String = "XtraReport1.resx"
		Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
		Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
		CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
		' 
		' Detail
		' 
		Me.Detail.Height = 0
		Me.Detail.Name = "Detail"
		' 
		' PageHeader
		' 
		Me.PageHeader.Height = 0
		Me.PageHeader.Name = "PageHeader"
		' 
		' XtraReport1
		' 
		Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() { Me.Detail, Me.PageHeader})
		Me.PageHeight = 800
		Me.PageWidth = 1200
		Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
		CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

	End Sub

	#End Region
End Class
