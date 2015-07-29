using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebApplication1;

namespace ServerFile.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //[HttpParamAction]
        public ActionResult Download()
        {
            var path = GenerateFile("45");
            ViewBag.Path = path;
            return View("Download");
        }

        public string GenerateFile(string inputParam)
        {
            int k = int.Parse(inputParam);
            using (BCRandomStream rndstream = new BCRandomStream(1000))
            {
                string path = @"C:\Users\user\Documents\Zapis1111.txt";
                using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                {
                    using (StreamWriter writeStream = new StreamWriter(fileStream))
                    {
                        for (var i = 0; i < k; i++)
                            writeStream.WriteLine(rndstream.Read());
                    }
                    return path;


                }
            }
        }
    }
}
