<!-- default file list -->
*Files to look at*:

* [XtraReport1.cs](./CS/WebSite/App_Code/XtraReport1.cs) (VB: [XtraReport1.vb](./VB/WebSite/App_Code/XtraReport1.vb))
* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
<!-- default file list end -->
# How to dynamically generate a report with a parameterized SQL query as a data source

<strong>Description</strong>:

I need a web report viewer to display the result of my SQL query, which accepts some parameters.

<strong>Solution</strong>:

Create an <a href="https://documentation.devexpress.com/#XtraReports/clsDevExpressXtraReportsUIXRTabletopic">XRTable</a> control dynamically.

Use a query string variable to pass the table name as a query parameter, as follows:
  
`href="http://hostname/PassSQLQuery/ReportViewer.aspx?TableName=Customers`

The XtraReport code-behind method populates the data source with data retrieved from the SQL query. The XRTable control is created in code. Table cells are bound to the column names of the data table.


