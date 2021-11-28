Imports DevExpress.DataAccess.Sql
Imports DevExpress.DataAccess.Sql.DataApi
Imports DevExpress.XtraReports.UI
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing

''' <summary>
''' Summary description for XtraReport3
''' </summary>
Public Class XtraReport1
	Inherits DevExpress.XtraReports.UI.XtraReport

	Private TopMargin As TopMarginBand
	Private BottomMargin As BottomMarginBand
	Private Detail As DetailBand

	''' <summary>
	''' Required designer variable.
	''' </summary>
	Private components As System.ComponentModel.IContainer = Nothing

	Public Sub New()
		InitializeComponent()
		'
		' TODO: Add constructor logic here
		'
	End Sub
		Public Sub New(ByVal tableName As String)
		InitializeComponent()
		'
		' TODO: Add constructor logic here
		'

		Me.Bands.Add(New PageHeaderBand())

'INSTANT VB NOTE: The variable dataSource was renamed since Visual Basic does not handle local variables named the same as class members well:
		Dim dataSource_Renamed As New SqlDataSource("nwindConnectionString")
		Dim queryString As String = String.Format("SELECT * FROM {0}", tableName)
		Dim parameterQuery As SelectQuery = SelectQueryFluentBuilder.AddTable(tableName).SelectAllColumns().Build(tableName)
		dataSource_Renamed.Queries.Add(parameterQuery)
		dataSource_Renamed.RebuildResultSchema()
		dataSource_Renamed.Fill()
'INSTANT VB NOTE: The variable rowCount was renamed since Visual Basic does not handle local variables named the same as class members well:
		Dim rowCount_Renamed As Integer = DirectCast(dataSource_Renamed.Result(tableName), IList).Count

		Dim label As New XRLabel()
		label.Width = 500
		label.Font = New System.Drawing.Font("Verdana", 10F, FontStyle.Bold)
		Me.Bands(BandKind.PageHeader).Controls.Add(label)

		If rowCount_Renamed > 0 Then
'INSTANT VB NOTE: The variable padding was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim padding_Renamed As Integer = 10
			Dim tableWidth As Integer = Me.PageWidth - Me.Margins.Left - Me.Margins.Right - padding_Renamed * 2

			Dim dynamicTable As XRTable = XRTable.CreateTable(New Rectangle(padding_Renamed, 2, tableWidth, 40), 1, 0) ' table column count -  table row count -  height -  width -  rect Y -  rect X

			dynamicTable.Width = tableWidth
			dynamicTable.Rows.FirstRow.Width = tableWidth
			dynamicTable.Borders = DevExpress.XtraPrinting.BorderSide.All
			dynamicTable.BorderWidth = 1

			dynamicTable.BeginInit()
			For Each dc As IColumn In dataSource_Renamed.Result(tableName).Columns

				Dim cell As New XRTableCell()

				Dim binding As New ExpressionBinding("BeforePrint", "Text", dc.Name)
				cell.ExpressionBindings.Add(binding)
				cell.CanGrow = False
				cell.Width = 100
				cell.Text = dc.Name
				dynamicTable.Rows.FirstRow.Cells.Add(cell)
			Next dc
			dynamicTable.Font = New System.Drawing.Font("Verdana", 8F)
			dynamicTable.EndInit()
			Detail.Controls.Add(dynamicTable)

			label.Text = String.Format("Data table: {0}", tableName)

			Me.DataSource = dataSource_Renamed
			Me.DataMember = tableName
		Else
			label.Text = String.Format("There's no data to display or the table doesn't exist.")
		End If
		End Sub

	''' <summary> 
	''' Clean up any resources being used.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
			Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
			Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
			Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
			DirectCast(Me, System.ComponentModel.ISupportInitialize).BeginInit()
			' 
			' TopMargin
			' 
			Me.TopMargin.Name = "TopMargin"
			' 
			' BottomMargin
			' 
			Me.BottomMargin.Name = "BottomMargin"
			' 
			' Detail
			' 
			Me.Detail.Height = 0
			Me.Detail.Name = "Detail"
			' 
			' XtraReport3
			' 
			Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() { Me.TopMargin, Me.BottomMargin, Me.Detail})
			Me.PageHeight = 800
			Me.PageWidth = 1200
			Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
		Me.Font = New System.Drawing.Font("Arial", 9.75F)
			Me.Version = "21.2"
			DirectCast(Me, System.ComponentModel.ISupportInitialize).EndInit()

	End Sub

	#End Region
End Class
