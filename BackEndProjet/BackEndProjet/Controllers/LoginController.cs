using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BackEndProjet.Controllers
{
    public class LoginController : Controller
    {

        public JsonResult SendOTP()
        {
            int otpValue = new Random().Next(100000, 999999);
            var status = "";
            try
            {
                string recipient = "21655481874";
                string APIKey = "36jvStO33+0-844dQ5rS9BGvF5WiWixGutyYbBxZ0R";

                string message = "Your OTP Number is " + otpValue + " ( Sent By : Technotips-Ashish )";
                String encodedMessage = HttpUtility.UrlEncode(message);

                using (var webClient = new WebClient())
                {
                    byte[] response = webClient.UploadValues("https://api.textlocal.in/send/", new NameValueCollection(){

                                         {"apikey" , APIKey},
                                         {"numbers" , recipient},
                                         {"message" , encodedMessage},
                                         {"sender" , "TXTLCL"}});

                    string result = System.Text.Encoding.UTF8.GetString(response);

                    var jsonObject = JObject.Parse(result);

                    status = jsonObject["status"].ToString();

                    Session["CurrentOTP"] = otpValue;
                }


                return Json(status, JsonRequestBehavior.AllowGet);


            }
            catch (Exception e)
            {

                throw (e);

            }

        }

        public ActionResult EnterOTP()
        {

            return View();
        }

        [HttpPost]
        public JsonResult VerifyOTP(string otp)
        {
            bool result = false;

            string sessionOTP = Session["CurrentOTP"].ToString();

            if (otp == sessionOTP)
            {
                result = true;

            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
// GET: Login

 