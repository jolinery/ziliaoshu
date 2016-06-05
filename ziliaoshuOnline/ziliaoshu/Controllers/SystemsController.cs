using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ziliaoshu.BLL;
using ZiLiaoShu.Entity;

namespace ZiLiaoShu.Controllers
{
    public class SystemsController : Controller
    {
        //
        // GET: /Systems/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _Header()
        {

            return PartialView();
        }
        public ActionResult _Munu()
        {

            return PartialView();
        }
        public ActionResult _Footer_Wrapper()
        {
            var model = new FeedBack();
            return PartialView("_Footer_Wrapper", model);
        }
        public JsonResult SendMessege(string Content)
        {
            var model = new FeedBackBo().AddFeedBack(Content);
            return Json(model);
        }
        
    }
}
