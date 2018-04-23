<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.XtraReports.v7.3.Web, Version=7.3.8.0, Culture=neutral, PublicKeyToken=9b171c9fd64da1d1"
    Namespace="DevExpress.XtraReports.Web" TagPrefix="dxwc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;<dxwc:ReportToolbar ID="ReportToolbar1" runat="server" ReportViewer="<%# ReportViewer1 %>"
            ShowDefaultButtons="False">
            <Styles>
                <LabelStyle>
                    <Margins MarginLeft="3px" MarginRight="3px" />
                </LabelStyle>
            </Styles>
            <Items>
                <dxwc:ReportToolbarButton ItemKind="Search" ToolTip="Display the search window" />
                <dxwc:ReportToolbarSeparator />
                <dxwc:ReportToolbarButton ItemKind="PrintReport" ToolTip="Print the report" />
                <dxwc:ReportToolbarButton ItemKind="PrintPage" ToolTip="Print the current page" />
                <dxwc:ReportToolbarSeparator />
                <dxwc:ReportToolbarButton Enabled="False" ItemKind="FirstPage" ToolTip="First Page" />
                <dxwc:ReportToolbarButton Enabled="False" ItemKind="PreviousPage" ToolTip="Previous Page" />
                <dxwc:ReportToolbarLabel Text="Page" />
                <dxwc:ReportToolbarComboBox ItemKind="PageNumber" Width="65px">
                </dxwc:ReportToolbarComboBox>
                <dxwc:ReportToolbarLabel Text="of" />
                <dxwc:ReportToolbarTextBox IsReadOnly="True" ItemKind="PageCount" />
                <dxwc:ReportToolbarButton ItemKind="NextPage" ToolTip="Next Page" />
                <dxwc:ReportToolbarButton ItemKind="LastPage" ToolTip="Last Page" />
                <dxwc:ReportToolbarSeparator />
                <dxwc:ReportToolbarButton ItemKind="SaveToDisk" ToolTip="Export a report and save it to the disk" />
                <dxwc:ReportToolbarButton ItemKind="SaveToWindow" ToolTip="Export a report and show it in a new window" />
                <dxwc:ReportToolbarComboBox ItemKind="SaveFormat" Width="70px">
                    <Elements>
                        <dxwc:ListElement Text="Pdf" Value="pdf" />
                        <dxwc:ListElement Text="Xls" Value="xls" />
                        <dxwc:ListElement Text="Rtf" Value="rtf" />
                        <dxwc:ListElement Text="Mht" Value="mht" />
                        <dxwc:ListElement Text="Text" Value="txt" />
                        <dxwc:ListElement Text="Csv" Value="csv" />
                        <dxwc:ListElement Text="Image" Value="png" />
                    </Elements>
                </dxwc:ReportToolbarComboBox>
            </Items>
        </dxwc:ReportToolbar>
        <br />
        <dxwc:reportviewer id="ReportViewer1" runat="server" reportname="XtraReport1"></dxwc:reportviewer>
    
    </div>
    </form>
</body>
</html>
