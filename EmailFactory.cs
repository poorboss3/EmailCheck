using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailCheck
{
    public class EmailFactory
    {
        public static EamilHelper Create(String type,String server, int port)
        {
            EamilHelper helper;
            switch (type.ToLower())
            {
                case "pop3":
                    helper=new  Pop3Helper(server, port);
                    break;
                case "imap4":
                    helper=new Imap4Helper(server, port);
                    break;
                default:
                    helper = new Pop3Helper(server, port);
                    break;
            }
            return helper;
        }
    }
}
