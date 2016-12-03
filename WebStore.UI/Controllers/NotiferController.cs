using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.UI.Models.Notifier;

namespace WebStore.UI.Controllers
{
    public class NotiferController : Controller
    {
        private const string cookieName = "cart";

        public ActionResult CartNotifier()
        {
            var cookie = Request.Cookies.Get(cookieName);
            bool model = false;

            var popupValue = cookie.Values.Get("popUp");

            if (popupValue == null)
            {
                model = true;
                cookie = new HttpCookie(cookieName);
                Notifier popUpModel = new Notifier() { onOrOff = true };
                cookie.Values.Add("notif", Newtonsoft.Json.JsonConvert.SerializeObject(popUpModel));
                return PartialView("_CartNotifier", model);
            }

            return PartialView("_CartNotifier", model);
        }
    }
}