using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР3.UsersClasses
{
    internal class InfoMailRu : InfoEmail
    {
        public InfoMailRu(StringPair emailAdressTo, string subject, string body) : base(emailAdressTo, subject, body)
        {
            SmtpClientAdress = "smtp.mail.ru";
            EmailAdressFrom = new StringPair("vika-vip2018@mail.ru", "Стрельникова Викторияф");
            EmailPassword = "H8XhqxUZy8c7cVeraCWj";
            Port = -1;
        }
    }
}
