using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.IO;

namespace Gomoku
{
    class Connect
    {
        static string url = Config.url;

        public static string GetHttpResponse(string url, int Timeout)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            request.UserAgent = null;
            request.Timeout = Timeout;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }

        public static void move(int x, int y, int color)
        {
            try
            {
                string param = "/move?" + Convert.ToString(x) + "&" + Convert.ToString(y) + "&" + Convert.ToString(color);
                GetHttpResponse(url + param, 6000);
            }
            catch
            {

            }
        }

        public static void new_game()
        {
            try
            {
                string param = "/new";
                GetHttpResponse(url + param, 6000);
            }
            catch
            {

            }
        }
    }
}
