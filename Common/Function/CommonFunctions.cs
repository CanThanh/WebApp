using Common.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Common.Function
{
    public class CommonFunctions
    {
        public static string ReadFile(string path)
        {
            try
            {
                return File.ReadAllText(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return String.Empty;
            }
        }

        public static bool SendGmail(MailModel mailModel)
        {
            var result = true;
            try
            {
                MailMessage mMail = new MailMessage
                {
                    From = new MailAddress(mailModel.SenderAccount, mailModel.SenderName),
                    Subject = mailModel.Subject,
                    Body = mailModel.Body,
                    IsBodyHtml = true
                };
                foreach (var item in mailModel.LstReceiver)
                {
                    mMail.To.Add(item);
                }              
                var smtpClient = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(mailModel.SenderAccount, mailModel.SenderPassword)
                };
                if(mailModel.LstAttachment != null && mailModel.LstAttachment.Count > 0)
                {
                    foreach (var item in mailModel.LstAttachment)
                    {
                        if (!string.IsNullOrEmpty(item))
                        {
                            mMail.Attachments.Add(new Attachment(item));
                        }
                    }
                }
                smtpClient.Send(mMail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = false;
            }
            return result;      
        }
        public static string CreateRandomPassword(int length = 8)
        {
            // Create a string of characters, numbers, special characters that allowed in the password  
            //string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();

            // Select one random character at a time from the string  
            // and create an array of chars  
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }
    }
}
