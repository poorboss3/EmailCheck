using System;
using System.Collections.Generic;
using System.Linq;
using Pop3;
using System.Text;
using System.Threading.Tasks;

namespace EmailCheck
{
    public class Pop3Helper: EamilHelper
    {
        private readonly String _server;
        private readonly int _port;
        public Pop3Helper(String server,int port)
        {
            if (String.IsNullOrEmpty(server))
                throw new ArgumentNullException("server", "邮件服务器地址不为空");
            if (port <= 0)
                throw new ArgumentNullException("port", "邮件服务器端口不可为空");
            this._server = server;
            this._port = port;
        }
        public bool Login(String account, String password)
        {
            using (Pop3Client popClient = new Pop3Client())
            {
                popClient.Connect(_server, account, password,this._port,true);
                return popClient.IsConnected;
            }
        }
    }
}
