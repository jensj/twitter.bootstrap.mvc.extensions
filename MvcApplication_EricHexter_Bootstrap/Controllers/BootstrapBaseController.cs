using System.Web.Mvc;
using MvcApplication_EricHexter_Bootstrap.BootstrapSupport;

namespace MvcApplication_EricHexter_Bootstrap.Controllers
{
    public class BootstrapBaseController: Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public void Attention(string message)
        {
            TempData.Add(Alerts.ATTENTION, message);
        }

        public void Success(string message)
        {
            TempData.Add(Alerts.SUCCESS, message);
        }

        public void Information(string message)
        {
            TempData.Add(Alerts.INFORMATION, message);
        }

        public void Error(string message)
        {
            TempData.Add(Alerts.ERROR, message);
        }
    }
}
