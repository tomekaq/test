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
            Attachment();
            return View();
        }

        protected void CsGenerClick(object sender,EventArgs e) { 
        
        string input = Request["inputText"];
        GenerateFile(input);
        }
        public void Attachment()
        {

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("toja@wp.pl");
            mail.To.Add("t.antonik@sente.pl");

            FileStream fileContent;
            fileContent = GenerateFile("45");

            mail.Attachments.Add(new Attachment(fileContent, "Zapis111.txt", "text/plain"));
            try
            {
                SmtpClient clinet = new SmtpClient("localhost");
                clinet.Send(mail);
            }
            catch(Exception e)
            {
                int i = 0; 
            }
        }
        public FileStream GenerateFile(string inputParam)
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
                    return fileStream;
                }
            }
        }
    }
}
