using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Imap4;
using System.Text;
using System.Threading.Tasks;

namespace EmailCheck
{
    public class Imap4Helper: EamilHelper
    {
        private readonly String _server;
        private readonly int _port;
        public Imap4Helper(String server,int port)
        {
            if (String.IsNullOrEmpty(server))
                throw new ArgumentNullException("server", "邮件服务器地址不可为空");
            if(port<=0)
                throw new ArgumentNullException("port", "邮件服务器端口不可为空");
            _server = server;
            _port = port;
        }

        public bool Login(String account, String password)
        {
            try
            {
                Imap4Client client = new Imap4Client();
                client.Connect(_server, _port, true);
                client.SendAuthUserPass(account, password);
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
