using FtpClient;
using System.Net;
using System.Net.Cache;

try
{
    string requestUriString = "ftp://ftp.dlptest.com/Tempe_2170-S8P20120083-DIReading-2022-09-27T08-10-00-0700-1min.json";
    string userName = "dlpuser";
    string password = "rNrKYTX9g7z3RgJRmxWuGHbeu";

    FtpService ftpService = new FtpService();
    string response = ftpService.DownloadFile(requestUriString, userName, password);

    Console.WriteLine(response);
    //Console.WriteLine("Download Complete", response.StatusDescription);
}
catch (WebException e)
{
    Console.WriteLine(e.Message.ToString());
    String status = ((FtpWebResponse)e.Response).StatusDescription;
    Console.WriteLine(status);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message.ToString());
}
