using FluentFTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpClientCs
{
    public class FluentFtpDemo
    {
        public static void Demo()
        {
            try
            {
                string host = "ftp://ftp.dlptest.com";
                string userName = "dlpuser";
                string password = "rNrKYTX9g7z3RgJRmxWuGHbeu";

                using (var ftp = new FtpClient(host, userName, password))
                {
                    ftp.Connect();
                    FtpListItem[] ftpListItems = ftp.GetListing("/");
                    foreach (var item in ftpListItems)
                    {
                        using (Stream stream = new MemoryStream())
                        {
                            if (ftp.DownloadStream(stream, item.FullName))
                            {
                                stream.Position = 0;
                                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                                string content = reader.ReadToEnd();
                                Console.WriteLine(content);
                                // Do something like put file in target
                                if (true)   // if completed sucefully
                                {
                                    FtpStatus ftpStatus = ftp.UploadStream(stream, "/backup/" + item.Name, FtpRemoteExists.Overwrite, true);
                                    if (ftpStatus == FtpStatus.Success)
                                        ftp.DeleteFile(item.FullName);
                                    else
                                        Console.WriteLine("Error uploading copy");
                                    reader.Close();
                                }
                            }
                            else
                                Console.WriteLine(item.FullName + " downloading error");
                        }
                    }
                }
                Console.WriteLine("Operation Completed");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
    }
}
