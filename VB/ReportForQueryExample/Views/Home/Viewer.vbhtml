@ModelType DevExpress.XtraReports.UI.XtraReport

@Html.DevExpress().WebDocumentViewer(Sub(settings)
                                              settings.Name = "WebDocumentViewer1"
                                          End Sub).Bind(Model).GetHtml()
