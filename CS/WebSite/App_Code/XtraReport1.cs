using DevExpress.DataAccess.Sql;
using DevExpress.DataAccess.Sql.DataApi;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

/// <summary>
/// Summary description for XtraReport3
/// </summary>
public class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
{
    private TopMarginBand TopMargin;
    private BottomMarginBand BottomMargin;
    private DetailBand Detail;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public XtraReport1()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
    }
        public XtraReport1(string tableName)
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //

        this.Bands.Add(new PageHeaderBand());

        SqlDataSource dataSource = new SqlDataSource("nwindConnectionString");
        string queryString = string.Format("SELECT * FROM {0}", tableName);
        SelectQuery parameterQuery = SelectQueryFluentBuilder
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
            foreach (IColumn dc in dataSource.Result[tableName].Columns)
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

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }


    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.Height = 0;
            this.Detail.Name = "Detail";
            // 
            // XtraReport3
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail});
            this.PageHeight = 800;
            this.PageWidth = 1200;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
        this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Version = "21.2";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

}
