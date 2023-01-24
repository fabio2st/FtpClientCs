using FtpClientCs;
using System.Net;
using System.Net.Cache;
using System.Text;

namespace FtpClientCs
{
    static class FtpWebRequestDemo
    {
        public static void Demo()
        {
            try
            {
                string requestUriString = "ftp://ftp.dlptest.com/23012023.csv";
                string userName = "dlpuser";
                string password = "rNrKYTX9g7z3RgJRmxWuGHbeu";

                FtpService ftpService = new FtpService(userName, password);
                using (Stream response = ftpService.DownloadStream(requestUriString))
                {
                    //response.Position = 0;
                    StreamReader reader = new StreamReader(response);
                    string content = reader.ReadToEnd();
                    Console.WriteLine(content);
                    reader.Close();
                }
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

        }

    }
}
