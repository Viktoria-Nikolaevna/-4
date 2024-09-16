using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using ЛР3.UsersClasses;
using System.Security.Cryptography.X509Certificates;

namespace ЛР3.UsersClasses
{
    public class SendingEmail
    {
        private InfoEmail InfoEmail { get; set; }
        public SendingEmail(InfoEmail infoEmail)
        {
            InfoEmail = infoEmail ?? throw new ArgumentNullException(nameof(infoEmail));
        }

        public void Send() 
        {
            try
            {
                SmtpClient mySmtpClient = new SmtpClient(InfoEmail.SmtpClientAdress);//вносим адрес SMTP сервера
                mySmtpClient.UseDefaultCredentials = false;//задаем учетные данные пользователя
                mySmtpClient.EnableSsl = true;//включаем использование протокола SSL

                if (InfoEmail.Port != -1)
                    mySmtpClient.Port = InfoEmail.Port;

                //задаем учетные данные пользователя
                NetworkCredential basicAuthenticationInfo = new NetworkCredential(
                InfoEmail.EmailAdressFrom.EmailAdress,
                InfoEmail.EmailPassword);

                mySmtpClient.Credentials = basicAuthenticationInfo;

                //Добавляем адрес откуда отправлено сообщение
                MailAddress from = new MailAddress(
                InfoEmail.EmailAdressFrom.EmailAdress,
                InfoEmail.EmailAdressFrom.Name);

                //Добавляем адрес куда будет отправлено сообщение
                MailAddress to = new MailAddress(
                InfoEmail.EmailAdressTo.EmailAdress,
                InfoEmail.EmailAdressTo.Name);

                MailMessage myMail = new MailMessage(from, to);

                //Добавляем наш адрес в список адресов для ответа
                MailAddress replyTo = new MailAddress(InfoEmail.EmailAdressFrom.EmailAdress);
                myMail.ReplyToList.Add(replyTo);

                Encoding encoding = Encoding.UTF8;//выбираем кодировку символов в письме (в нашем случаен UTF8)

                //задаем значение заголовка и его кодировку
                myMail.Subject = InfoEmail.Subject;
                myMail.SubjectEncoding = encoding;

                //задаем значение сообщения и его кодировку
                myMail.Body = InfoEmail.Body;
                myMail.BodyEncoding = encoding;

                mySmtpClient.Send(myMail);//отправляем письмо
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
