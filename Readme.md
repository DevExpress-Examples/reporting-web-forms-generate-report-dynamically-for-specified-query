<!-- default file list -->
*Files to look at*:

* [XtraReport1.cs](./CS/WebSite/App_Code/XtraReport1.cs) (VB: [XtraReport1.vb](./VB/WebSite/App_Code/XtraReport1.vb))
* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
<!-- default file list end -->
# How to dynamically generate a report with a parametrized SQL query as a data source


<p><strong>Description</strong>:<br>  I need to implement a generic kind of web report viewer to display the result of my SQL query, which accepts some parameters.</p>
<p><strong>Solution</strong>:<br>  This can be done by creating an <a href="https://documentation.devexpress.com/#XtraReports/clsDevExpressXtraReportsUIXRTabletopic">XRTable</a> control dynamically.</p>
To pass a table name (which is a query parameter), you can use a query string variable. As a result, you can pass the "TableName" parameter as follows:
  
`href="http://hostname/PassSQLQuery/ReportViewer.aspx?TableName=Customers`

<p>Then, the XtraReport code-behind methods will populate data using the SQL query, which returns all the table rows from the table.<br> In the final step, an XRTable control is created, and gets bound to the column names of the data table.</p>


<h3>Description</h3>

In this solution, the <a href="https://documentation.devexpress.com/#XtraReports/CustomDocument17738">HTML5 Document Viewer</a>&nbsp;is used to display the report preview.

<br/>


