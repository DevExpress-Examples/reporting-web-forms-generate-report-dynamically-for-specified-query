<%@ Page Language="vb" AutoEventWireup="true"  CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.XtraReports.v21.2.Web.WebForms, Version=21.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.XtraReports.Web" TagPrefix="dxwc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>Report Created for the Specified Table</title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<dxwc:ASPxWebDocumentViewer ID="ASPxWebDocumentViewer1" runat="server">
		</dxwc:ASPxWebDocumentViewer>
	</div>
	</form>
</body>
</html>