using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР3.UsersClasses
{
    internal class InfoGmail : InfoEmail
    {
        public InfoGmail(StringPair emailAdressTo, string subject, string body) : base(emailAdressTo, subject, body)
        {
            SmtpClientAdress = "smtp.gmail.com";
            EmailAdressFrom = new StringPair("v9299990393@gmail.com","Стрельникова Виктория");
            EmailPassword = "ygkb xgjo wapr hagn";
            Port = 587;
        }
    }
}
