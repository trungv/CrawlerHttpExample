using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace CrawlerHttp
{
    public static class EmailHelper
    {
        public static void SendMailToMultiAddress(List<string> emailList, SmtpClient smtpClient)
        {
            //var fromAddress = new MailAddress("dungluyenyt@gmail.com", "Giải Trí Cuối Tuần Channel");
            //const string fromPassword = "Nguyentrung19";

            var fromAddress = new MailAddress("dungluyenyt@gmail.com", "Giải Trí Cuối Tuần Channel");
            const string fromPassword = "jpEC7kvDPZg0t2A9";

            smtpClient.Credentials = new NetworkCredential(fromAddress.Address, fromPassword);

            const string subject = "[Chương trình hài hước] Nhiều tiền để làm gì TEST??";
            const string body = @"https://www.youtube.com/watch?v=EP0YReIaG_E";

            using (var message = new MailMessage()
            {
                Subject = subject,
                Body = body,
                From = fromAddress
            }) 
            {
                //foreach (var email in emailList)
                //{
                //    message.To.Add(email);
                //}

                message.To.Add("vindvinn@gmail.com");

                smtpClient.Send(message);
            };
        }

        public static void SendMailToAddress(string address)
        {
            var fromAddress = new MailAddress("dungluyenyt@gmail.com", "Hai Huoc");
            var toAddress = new MailAddress(address);
            const string fromPassword = "Nguyentrung19";
            const string subject = "[Chuong trinh hai huoc] Giai stress cuoi tuan";
            const string body = @"https://www.youtube.com/watch?v=iCSqjBZVkgk";

            using (var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            })
            {
                var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                };

                smtp.Send(message);
            };
        }

        //public static void SendMailToMultiAddress(List<string> emailList)
        //{
        //    var fromAddress = new MailAddress("dungluyenyt@gmail.com", "Hai Huoc");
        //    const string fromPassword = "Nguyentrung19";
        //    const string subject = "[Chuong trinh hai huoc] Giai stress cuoi tuan";
        //    const string body = @"https://www.youtube.com/watch?v=iCSqjBZVkgk";

        //    using (var smtp = new SmtpClient
        //    {
        //        Host = "smtp.gmail.com",
        //        Port = 587,
        //        EnableSsl = true,
        //        DeliveryMethod = SmtpDeliveryMethod.Network,
        //        UseDefaultCredentials = false,
        //        Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
        //    })
        //    {
        //        var message = new MailMessage()
        //        {
        //            Subject = subject,
        //            Body = body,
        //            From = fromAddress
        //        };

        //        foreach (var email in emailList)
        //        {
        //            message.To.Add(email);
        //        }

        //        smtp.Send(message);
        //    };
        //}
    }
}
