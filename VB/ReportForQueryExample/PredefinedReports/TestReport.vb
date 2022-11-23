Imports DevExpress.XtraReports.UI
Imports System.Collections
Imports System.Drawing

Partial Public Class TestReport
    Inherits XtraReport

    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Public Sub New(ByVal tableName As String)
        Me.InitializeComponent()
        '
        ' TODO: Add constructor logic here
        '

        Bands.Add(New PageHeaderBand())
        Dim dataSource As DevExpress.DataAccess.Sql.SqlDataSource = New DevExpress.DataAccess.Sql.SqlDataSource("nwind")
        Dim queryString = String.Format("SELECT * FROM {0}", tableName)
        Dim parameterQuery As DevExpress.DataAccess.Sql.SelectQuery = DevExpress.DataAccess.Sql.SelectQueryFluentBuilder.AddTable(tableName).SelectAllColumns().Build(tableName)
        dataSource.Queries.Add(parameterQuery)
        dataSource.RebuildResultSchema()
        dataSource.Fill()
        Dim rowCount = CType(dataSource.Result(tableName), IList).Count
        Dim label As XRLabel = New XRLabel()
        label.Width = 500
        label.Font = New Font("Verdana", 10.0F, FontStyle.Bold)
        Bands(BandKind.PageHeader).Controls.Add(label)

        If rowCount > 0 Then
            Dim padding = 10
            Dim tableWidth = Convert.ToInt32(PageWidth - Margins.Left - Margins.Right - padding * 2)
            Dim dynamicTable As XRTable = XRTable.CreateTable(New Rectangle(padding, 2, tableWidth, 40), 1, 0)
            dynamicTable.Width = tableWidth
            dynamicTable.Rows.FirstRow.Width = tableWidth
            dynamicTable.Borders = DevExpress.XtraPrinting.BorderSide.All
            dynamicTable.BorderWidth = 1
            dynamicTable.BeginInit()

            For Each dc In dataSource.Result(tableName).Columns
                Dim cell As XRTableCell = New XRTableCell()
                Dim binding As ExpressionBinding = New ExpressionBinding("BeforePrint", "Text", dc.Name)
                cell.ExpressionBindings.Add(binding)
                cell.CanGrow = False
                cell.Width = 100
                cell.Text = dc.Name
                dynamicTable.Rows.FirstRow.Cells.Add(cell)
            Next

            dynamicTable.Font = New Font("Verdana", 8.0F)
            dynamicTable.EndInit()
            Me.Detail.Controls.Add(dynamicTable)
            label.Text = String.Format("Data table: {0}", tableName)
            Me.DataSource = dataSource
            DataMember = tableName
        Else
            label.Text = String.Format("There's no data to display or the table doesn't exist.")
        End If
    End Sub
End Class
