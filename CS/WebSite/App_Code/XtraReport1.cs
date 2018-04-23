using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;

/// <summary>
/// Summary description for XtraReport1
/// </summary>
public class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;


	public XtraReport1(string tableName)
	{
		InitializeComponent();
		//
		// TODO: Add constructor logic here
		//
        
        DataSet ds = new DataSet();
        DataTable dt = new DataTable(tableName);
        ds.Tables.Add(dt);

        string queryString = string.Format("SELECT * FROM {0}", tableName);

        string connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["nwindConnectionString"].ConnectionString;

        int rowsCount = -1;

        using (OleDbConnection connection =  new OleDbConnection(connectionString)) {
            try {
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = new OleDbCommand(queryString, connection);
                rowsCount = adapter.Fill(ds, tableName);
            }
            catch (OleDbException) { }
            
        }


        XRLabel label = new XRLabel();
        label.Width = 500;
        label.Font = new System.Drawing.Font("Verdana", 10F, FontStyle.Bold);
        PageHeader.Controls.Add(label);

        if (rowsCount > 0) {
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
            int i = 0;
dynamicTable.BeginInit();
            foreach (DataColumn dc in ds.Tables[tableName].Columns)
            {

                XRTableCell cell = new XRTableCell();

                XRBinding binding = new XRBinding("Text", ds, ds.Tables[tableName].Columns[i].ColumnName);
                cell.DataBindings.Add(binding);
                cell.CanGrow = false;
                cell.Width = 100;
                cell.Text = dc.ColumnName;
                dynamicTable.Rows.FirstRow.Cells.Add(cell);
                i++;
            }
            dynamicTable.Font = new System.Drawing.Font("Verdana", 8F);
dynamicTable.EndInit();
            Detail.Controls.Add(dynamicTable);

            label.Text = string.Format("Data table: {0}", tableName);

            this.DataSource = ds;
            this.DataMember = tableName;
        }
        else {
            label.Text = string.Format("There's no data to display or the table doesn't exists");
        }
	}
	
	/// <summary> 
	/// Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing) {
		if (disposing && (components != null)) {
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	#region Designer generated code

	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent() {
        string resourceFileName = "XtraReport1.resx";
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Height = 0;
        this.Detail.Name = "Detail";
        // 
        // PageHeader
        // 
        this.PageHeader.Height = 0;
        this.PageHeader.Name = "PageHeader";
        // 
        // XtraReport1
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader});
        this.PageHeight = 800;
        this.PageWidth = 1200;
        this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion
}
