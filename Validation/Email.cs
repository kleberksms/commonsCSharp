using System;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace Validation
{
    public class Email
    {
        private string _email;
        public bool validDomain = false;

        public Email(string email)
        {
            _email = email;
        }

        public bool IsValid()
        {
            var ret = false;

            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

            if (validDomain)
            {
                MailAddress address = new MailAddress(_email);
                string host = address.Host;
                IPHostEntry resolve;
                try
                {
                    resolve = Dns.GetHostEntry(host);
                }
                catch (SocketException ex)
                {
                    return false;
                }
            }

            return  regex.IsMatch(_email);
        }
    }
}
