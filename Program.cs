using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace EmailCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("验证开始，请勿关闭此窗口...");
            try
            {
                var serverInfos = ConfigHelper.ReadConfig();
                var emailStream = ConfigHelper.ReadEmail();
                var emailData = ExcelHelper.ExcelToDataTable(emailStream);
                emailData.Columns.Add("result", typeof(String));
                foreach(DataRow item in emailData.Rows)
                {
                    var serverInfo = serverInfos.Where(o => item["Account"].ToString().Trim().EndsWith(o.key)).FirstOrDefault();
                    if(serverInfo==null)
                    {
                        item["result"] = "登录失败，邮件服务器未配置";
                        continue;
                    }
                    var emailClient = EmailFactory.Create(serverInfo.type, serverInfo.server, serverInfo.port);
                    item["result"] = emailClient.Login(item["Account"].ToString().Trim(), item["Password"].ToString().Trim()) ? "成功" : "失败";
                }

                ExcelHelper.DataTableToExcel(emailData, String.Empty, "Email/result.xlsx");
            }
            catch (Exception ex)
            {
                Console.WriteLine("验证出错：" + ex.Message);
            }
            Console.WriteLine("验证结束，请打开Emails/Result.xls文件查看验证结果");
            Console.ReadKey();
        }
    }
}
