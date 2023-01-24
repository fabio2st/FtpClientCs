using FtpClientCs;
using System.Net;
using System.Net.Cache;
using System.Reflection.PortableExecutable;
using System.Text;

try
{
    //FtpWebRequestDemo.Demo();
    FluentFtpDemo.Demo();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message.ToString());
}
