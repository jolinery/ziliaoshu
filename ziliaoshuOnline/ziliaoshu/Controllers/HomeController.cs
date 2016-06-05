using O2S.Components.PDFRender4NET;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ziliaoshu.BLL;
using ziliaoshu.Common;
using ziliaoshu.Common.ConvertPDF2Image;
using ZiLiaoShu.Entity;

namespace ZiLiaoShu.Controllers
{
    public class HomeController : Controller
    {
        //显示页面
        public ActionResult Index()
        {
           // ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            var model = new BookDetailBo().GetBookSearchAll();
            return View(model);
        }
                //显示页面
        public ActionResult copyright()
        {
           // ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }
         
        //列表 
        public ActionResult BookList()
        {
           // ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            var dblist = new BookDetailBo().GetBookSearchAll();
            return View(dblist);
        }
        //添加
        public ActionResult AddBook(BookDetail bookDetail)
        {

            //bool isValid = new BookDetailBo().AddBookBo(bookDetail);
            return View();
        }
       
        //添加
        //public ActionResult AddTIBook(BookDetail bookDetail)
        //{

        //    bool isValid = new BookDetailBo().AddBookBo(bookDetail);
        //    return View(isValid);
        //}
        public JsonResult ProcessRequest(HttpPostedFileBase context)
        {
            //var model = new StringBuilder();
            //context.response.contenttype = "text/plain";
            var files = Request.Files;
            var oFile = HttpContext.Request.Files["file_data"];
            var stream = oFile.InputStream;
            
            BookDetail bookDetail;
            try
            {
                HttpPostedFileBase file;
                for (int i = 0; i < files.Count; ++i)
                {
                    bookDetail = new BookDetail();
                    file = files[i];
                    if (file == null || file.ContentLength == 0 || string.IsNullOrEmpty(file.FileName)) continue;
                    //string filename = Path.GetFileNameWithoutExtension(file.FileName) + DateTime.Now.ToString("yyyymmddhhmmss") + Extension.RndNumStr(6) + Path.GetExtension(file.FileName);
                    
                    /********************文件夹**************************/

                    string yearmonth = DateTime.Now.ToString("yymm");

                    string fileName = PathHelper.RadomPath(Path.GetExtension(file.FileName));
                    string fileP = PathHelper.StoreShuPath(fileName);
                    string filePath = HttpContext.Server.MapPath(fileP);
                    while (Directory.Exists(filePath))
                    {
                        filePath = HttpContext.Server.MapPath(PathHelper.StoreShuPath(fileName));
                    }
                    file.SaveAs(filePath);
                    
                    if (!Directory.Exists(HttpContext.Server.MapPath("/img/") ))
                    {
                        Directory.CreateDirectory(HttpContext.Server.MapPath("/img/") );
                    }
                    string imgNamePath = HttpContext.Server.MapPath("/img/{0}".FormatWith(fileName));
                    //转换并存入图片
                    O2SComponents.ConvertPDF2Image( filePath, imgNamePath, ImageFormat.Jpeg);
                    bookDetail.BookName = Path.GetFileNameWithoutExtension(file.FileName);
                    bookDetail.FileSize = oFile.ContentLength;
                    bookDetail.Adress = filePath;
                    bookDetail.IsActive = 1;
                    bookDetail.icon = imgNamePath + ImageFormat.Jpeg;
                    new BookDetailBo().AddBookBo(bookDetail);
                }

            }
            catch (Exception ex)
            {
                //context.response.statuscode = 500;
                //context.response.write(ex.message);
                //context.response.end();
            }
            finally
            {

                // context.response.end();
            }
            return Json(true);
        }
        public bool SavePDF(Stream str) 
        {
            if (str.CanRead && str.Length > 0)
            {
                var byteList = new List<byte[]>();

                //str.Read(byteList,);
            }
            return true;
        }
        public ActionResult ViewBook()
        {
            ViewBag.Message = "资料书 阅读";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
