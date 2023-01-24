using FluentFTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace FtpClientCs
{
    public class FtpService
    {
        public string UserName;
        public string Password;
        public FtpService(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
        public Stream DownloadStream(string requestUriString)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(requestUriString);
            request.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.CacheIfAvailable);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential(UserName, Password);
            request.KeepAlive = false;
            request.UseBinary = true;
            request.UsePassive = true;

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            //StreamReader reader = new StreamReader(responseStream);
            //string content = reader.ReadToEnd();
            //response.Close();
            //reader.Close();
            //return content;
            return responseStream;
        }
    }
}
