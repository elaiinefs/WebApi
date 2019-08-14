using Microsoft.Extensions.Logging;
using Stripe;
using System;
using System.Net.Mail;
using WApp.Api.Infraestructure.Core.Interfaces;

namespace WApp.Api.Infraestructure.Core.Services
{
    public class MessageService : IMessageService
    {

        public MailMessage GenerateMessage(string actionDescription, Receipt payment = null, string phoneNumber = "", string to = "")
        {
            MailMessage mm = new MailMessage();
            mm.From = new MailAddress("zaraiipay@gmail.com");
            mm.IsBodyHtml = true;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.Never;
            mm.Subject = "Zaraii Pay- " + actionDescription;
            
            SmtpClient client = SetClient();
            
                if (payment.PhoneNumber != ""&& payment.PhoneNumber!= null)
                {
                    mm.Subject = "";
                    mm.Body = GetTextBody(payment);
                    SendText(mm, client, payment.PhoneNumber);
                }
                if (payment.Email != "" && payment.Email != null)
                {
                    mm.Body = GetHtmlBody(payment);
                    //SendEmail(mm, client, new MailAddress(to));
                }
            
            return mm;
        }
        private SmtpClient SetClient()
        {
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("zaraiipay@gmail.com", "4048507Ela");
            return client;
        }
        private string SendText(MailMessage message, SmtpClient client, string phoneNumber)
        {
            string[] carrers = {
                "@vtexto.com",
                "@txt.att.net",
                "@tmomail.net",
                "@messaging.sprintpcs.com",
                "@vtext.com",
                "@myboostmobile.com"
            };
            for (int i = 0; i < carrers.Length; i++)
            {
                message.To.Clear();
                message.To.Add(new MailAddress(phoneNumber + carrers[i]));
                client.Send(message);
            }

            return "sent";
        }
        private string SendEmail(MailMessage message, SmtpClient client, MailAddress to)
        {
            message.To.Add(to);
            client.Send(message);
            return "sent";
        }
        private string GetHtmlBody(Receipt payment = null, string user = "", string business = "", string owner = "", string orderdesc = "", string deliverdate = "", string baddr = "", string bcity = "", string bstate = "", string bzcode = "", string deliverhr = "", string title = "", string useremail = "")
        {
            var body = "";
            if (payment != null)
            {
                body = "<body style='font-family: sans-serif;font-size: 14px; line-height: 1.4; margin: 0; padding: 0; -ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%; background-color: #f6f6f6; width: 100%;'><div><table style='border-collapse: separate;width: 100%;' class='body' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td></td></tr><tr><td>&nbsp;</td><td class='container' style='display: block;Margin: 0 auto !important;max-width: 580px; padding: 10px; width:auto !important; width: 580px;'><div class='content' style='box-sizing: border-box; display: block; Margin: 0 auto;max-width: 580px; padding: 10px;'><span class='preheader' style='color: transparent; display: none; height: 0; max-height: 0; max-width: 0; opacity: 0; overflow: hidden; mso-hide: all; visibility: hidden; width: 0;'>"
                + payment.Customer + " ha creado una orden para " + payment.Description + " . Puede encontrar mas detalles en "
                + "FoodOrderPR.com" + ".</span><table class='main' style='background: #fff;border-radius: 3px;width: 100%;'><tbody><tr><td class='wrapper' style='box-sizing: border-box;padding: 20px;'> <table border='0' cellspacing='0' cellpadding='0' style='border-collapse: separate;width: 100%;'><tbody><tr><td class='content-block' style='font-family:''Lora',serif'><h3 style='color:#4ABDAC'>/" +
                "Food Order PR</h3></td></tr><tr><td><hr/><p style='font-family: sans-serif;font-size: 14px;font-weight: normal;margin: 0; Margin-bottom: 15px;'/>" +
                "Hola " + owner + ",</p><p style='font-family: sans-serif;font-size: 14px; font-weight: normal; margin: 0;Margin-bottom: 15px;'>" + payment.Customer + " ha creado una orden para "
                + business + ", favor actualizar el estado de la orden. </p><h3> Detalles de la orden: </h3> <p><b> Creador: </b>" + payment.Email + " </p> <p><b> Orden: </b>"
                + title +
                " </p><p><b> Detalles: </b> " + orderdesc + " </p> <p><b> Fecha de recogido: </b> " + deliverdate + "</p> <p><b> Hora de recogido: </b>" + deliverhr + "</p></br> <tbody><tr><td align='left'><table border='0' cellspacing='0' cellpadding='0' style='box-sizing: border-box; width: 100%; background-color:white;'><tbody><tr><td> </td><tr><td><strong><a style='margin-bottom:5px; background-color:#4ABDAC; font-style:oblique; padding: 7px 15px 7px 15px; color:white; width: 100%; height: 70px; border-radius: 2px 2px 2px 2px;'" +
                "href='http://www.foodorderpr.com'> Presiona Aquí!</a></strong><p style='margin-bottom:5px;'></p></td><tr><td> </td></tr></tbody></table></td></tr></tbody></table><p>/" +
                "Si olvida la contraseña de su cuenta, puede recuperarla facilmente visitando a FoodOrderPR.com y presionando el enlace de olvidó contraseña.</p><p>/" +
                "Thanks for your business! Good Luck!.</p><hr /><p style='margin-top:10px; padding-top:10px; color: #999999; font-size: 12px; text-align: center;'> "
                + business + ", " + baddr + ", " + bcity + ", " + bstate + " " + bzcode + "</p><p style='color: #999999; font-size: 12px; text-align: center;'></p></td></tr></tbody></table></td></tr></tbody></table></div></body>";

            }
            return body;
        }

        private string GetTextBody(Receipt payment = null)
        {
            var body = "";
            if (payment != null)
            {
                body = "Thank you for shopping with us!" +
                    " Your order was successfully completed. \n ID: " + payment.Id + "\n Total: $" + (Convert.ToInt32(payment.Amount) / 100).ToString();
            }
            return body;
        }

    }
}
