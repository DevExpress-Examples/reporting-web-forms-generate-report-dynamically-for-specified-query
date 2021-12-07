using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReportForQueryExample.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult Viewer() {
            if (Request.QueryString["TableName"] == null)
                Response.Redirect("Viewer?TableName=Customers"); 
            else
            {
                string tableName = Request.QueryString["TableName"];
                TestReport report = new TestReport(tableName);
                return View(report);
            }
            return View(new DevExpress.XtraReports.UI.XtraReport());
        }
    }
}
