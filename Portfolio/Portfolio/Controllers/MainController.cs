using Portfolio.Models;
using Portfolio.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Portfolio.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendMessage(EmailResponseModel model)
        {
            SendEmail sendEmail = new SendEmail();

            string senderEmailAddress = "umut_dogan_koc@hotmail.com";
            string senderPassword = "Umutsumeyye1234";
            string receiverSMTP = "smtp-mail.outlook.com";
            int receiverPort = 587;
            string toEmailAddress = "info@umutdogankoc.com";
            string subject = "New Message Received from umutdogankoc.com";
            string emailBody = model.Name+" "+model.Email+" " +model.Message;
            string cc = "umutkoc.88@gmail.com";

            try
            {
                sendEmail.Send(senderEmailAddress, senderPassword, receiverSMTP, receiverPort, toEmailAddress, subject, emailBody, cc);
                model.State = true;
                model.SuccessMessage = "Your message has been sent.";
                
            }
            catch (Exception ex)
            {

                model.State = false;
                model.ErrorMessage = ex.Message;
            }


            return Json(model);
        }
    }
}