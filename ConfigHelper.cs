using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailCheck
{
    public class ConfigHelper
    {
        private const String serverConfigPath = @"Email/EmailServer.json";
        private const String emailPath = @"Email/emails.xlsx";
        public static List<ServerInfo> ReadConfig()
        {
            if(File.Exists(serverConfigPath))
            {
                String configStr = File.ReadAllText(serverConfigPath);
                List<ServerInfo> serverInfos = JsonConvert.DeserializeObject<List<ServerInfo>>(configStr);
                return serverInfos;
            }
            else
            {
                throw new FileNotFoundException("服务器配置文件未找到");
            }
        }

        public static Stream ReadEmail()
        {
            if (File.Exists(emailPath))
            {
                return File.OpenRead(emailPath);
            }
            else
            {
                throw new FileNotFoundException("邮箱列表excel文件未找到");
            }
        }
    }

    public class ServerInfo
    {
        public String key { get; set; }
        public String type { get; set; }
        public String server { get; set; }
        public int port { get; set; }
    }
}
