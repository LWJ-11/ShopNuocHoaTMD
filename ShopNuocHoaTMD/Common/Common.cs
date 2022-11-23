﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Net.Mail;
using System.Net;

namespace ShopNuocHoaTMD.Common
{
    public class Common
    {
        private static string password = ConfigurationManager.AppSettings["PasswordEmail"];
        private static string email = ConfigurationManager.AppSettings["Email"];
        public static bool SendMail(string name, string subject, string content, string toMail)
        {
            bool rs = false;
            try
            {
                MailMessage message = new MailMessage();
                var smtp = new System.Net.Mail.SmtpClient();
                {
                    smtp.Host = "smtp.gmail.com"; //host name
                    smtp.Port = 587; //port number
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential()
                    {
                        UserName = email,
                        Password = password
                    };
                }
                MailAddress fromAddress = new MailAddress(email, name);
                message.From = fromAddress;
                message.To.Add(toMail);
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = content;
                smtp.Send(message);
                rs = true;
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                rs = false;
            }
            return rs;
        }
    }
}