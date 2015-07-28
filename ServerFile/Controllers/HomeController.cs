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
            var path = GenerateFile("23");
           // var ty = inputText.value;
            ViewBag.Message = path;            
            return View();
        }
        public ActionResult Download(object sender, EventArgs e)
        {
           // var ty = inputText.value;
            var path = GenerateFile("23");
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename="+ path);
            Response.TransmitFile(Server.MapPath(path));
            Response.End();

            return null;
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
