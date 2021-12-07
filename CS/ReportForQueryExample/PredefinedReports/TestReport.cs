using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

public partial class TestReport : DevExpress.XtraReports.UI.XtraReport
{
    public TestReport()
    {
        InitializeComponent();
    }

    public TestReport(string tableName)
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //

        this.Bands.Add(new PageHeaderBand());

        DevExpress.DataAccess.Sql.SqlDataSource dataSource = new DevExpress.DataAccess.Sql.SqlDataSource("nwind");
        string queryString = string.Format("SELECT * FROM {0}", tableName);
        DevExpress.DataAccess.Sql.SelectQuery parameterQuery = DevExpress.DataAccess.Sql.SelectQueryFluentBuilder
            .AddTable(tableName)
            .SelectAllColumns()
            .Build(tableName);
        dataSource.Queries.Add(parameterQuery);
        dataSource.RebuildResultSchema();
        dataSource.Fill();
        int rowCount = ((IList)dataSource.Result[tableName]).Count;

        XRLabel label = new XRLabel();
        label.Width = 500;
        label.Font = new System.Drawing.Font("Verdana", 10F, FontStyle.Bold);
        this.Bands[BandKind.PageHeader].Controls.Add(label);

        if (rowCount > 0)
        {
            int padding = 10;
            int tableWidth = this.PageWidth - this.Margins.Left - this.Margins.Right - padding * 2;

            XRTable dynamicTable = XRTable.CreateTable(
                                new Rectangle(padding,    // rect X
                                                2,          // rect Y
                                                tableWidth, // width
                                                40),        // height
                                                1,          // table row count
                                                0);         // table column count

            dynamicTable.Width = tableWidth;
            dynamicTable.Rows.FirstRow.Width = tableWidth;
            dynamicTable.Borders = DevExpress.XtraPrinting.BorderSide.All;
            dynamicTable.BorderWidth = 1;

            dynamicTable.BeginInit();
            foreach (DevExpress.DataAccess.Sql.DataApi.IColumn dc in dataSource.Result[tableName].Columns)
            {

                XRTableCell cell = new XRTableCell();

                ExpressionBinding binding = new ExpressionBinding("BeforePrint", "Text", dc.Name);
                cell.ExpressionBindings.Add(binding);
                cell.CanGrow = false;
                cell.Width = 100;
                cell.Text = dc.Name;
                dynamicTable.Rows.FirstRow.Cells.Add(cell);
            }
            dynamicTable.Font = new System.Drawing.Font("Verdana", 8F);
            dynamicTable.EndInit();
            Detail.Controls.Add(dynamicTable);

            label.Text = string.Format("Data table: {0}", tableName);

            this.DataSource = dataSource;
            this.DataMember = tableName;
        }
        else
        {
            label.Text = string.Format("There's no data to display or the table doesn't exist.");
        }
    }

}
