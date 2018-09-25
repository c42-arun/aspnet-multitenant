using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class SessionController : MultiTenantMvcController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}