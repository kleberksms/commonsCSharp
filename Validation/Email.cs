using System;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace Validation
{
    public class Email
    {
        

        public bool resolveDns = false;
        public bool whiteListOnly = false;


        private string _email;
        private string _host;

        private MailAddress _mailAddress;
        private IPHostEntry _ipHostEntry;
        

        public Email(string email)
        {
            _email = email;
        }

        public bool IsValid()
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

            if (resolveDns)
            {
                if (!ResolveDns()) return false;
            }

            if (whiteListOnly)
            {
                if (!IsWhiteList()) return false;
            }

            return  regex.IsMatch(_email);
        }

        private bool ResolveDns()
        {
            _mailAddress = new MailAddress(_email);
            _host = _mailAddress.Host;

            try
            {
                _ipHostEntry = Dns.GetHostEntry(_host);
            }
            catch (SocketException)
            {
                return false;
            }
            return true;
        }

        /*
         * @todo resolve dns and mx, verify on public rbl 
         */
        private bool IsWhiteList()
        {
            //Not Implemented Yet
            return false;
        }
    }
}
