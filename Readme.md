<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128600472/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E889)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [XtraReport1.cs](./CS/WebSite/App_Code/XtraReport1.cs) (VB: [XtraReport1.vb](./VB/WebSite/App_Code/XtraReport1.vb))
* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
<!-- default file list end -->
# How to dynamically generate a report with a parametrized SQL query as a data source


<p><strong>Description</strong>:<br>  I need to implement a generic kind of web report viewer to display the result of my SQL query, which accepts some parameters.</p>
<p><strong>Solution</strong>:<br>  This can be done by creating an <a href="https://documentation.devexpress.com/#XtraReports/clsDevExpressXtraReportsUIXRTabletopic">XRTable</a> control dynamically.</p>
<p>To pass a table name (which is a query parameter), you can use a query string variable. As a result, you can pass the "TableName" parameter as follows: <br> <code>http://hostname/PassSQLQuery/ReportViewer.aspx?TableName=Customers</code></p>
<p>Then, the XtraReport code-behind methods will populate data using the SQL query, which returns all the table rows from the table.<br> In the final step, an XRTable control is created, and gets bound to the column names of the data table.</p>


<h3>Description</h3>

In this solution, depreciated ReportViewer and ReportToolbar are used. Starting with version v13.2, all the required components were combined altogether into the <a href="https://documentation.devexpress.com/#xtrareports/clsDevExpressXtraReportsWebASPxDocumentViewertopic">ASPxDocumentViewer</a> control. See&nbsp;<a href="https://documentation.devexpress.com/#XtraReports/CustomDocument5193">ASP.NET Document Viewer</a>.

<br/>


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=reporting-web-forms-generate-report-dynamically-for-specified-query&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=reporting-web-forms-generate-report-dynamically-for-specified-query&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
