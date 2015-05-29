using HtmlAgilityPack;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Xml;

namespace BattleNotifier.Utils
{
    public static class WebRequestHelper
    {
        public static HtmlDocument GetHtmlFromUrl(string url)
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
            myRequest.Method = "GET";
            WebResponse myResponse = myRequest.GetResponse();
            StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
            string result = sr.ReadToEnd();
            sr.Close();
            myResponse.Close();

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(result);
            return doc;
        }

        public static XmlDocument GetXmlFromUrl(string url)
        {
            string xmlStr;
            var xmlDoc = new XmlDocument();
            try
            {
                using (var wc = new WebClient())
                {
                    xmlStr = wc.DownloadString(url);
                }
                xmlDoc.LoadXml(xmlStr);
            }
            catch (Exception) 
            {
                throw;
            }

            return xmlDoc;
        }

        public static Image GetImageFromUrl(string url)
        {
            using (var webClient = new WebClient())
            {
                return ByteArrayToImage(webClient.DownloadData(url));
            }
        }

        private static Image ByteArrayToImage(byte[] fileBytes)
        {
            using (var stream = new MemoryStream(fileBytes))
            {
                return Image.FromStream(stream);
            }
        }
    }
}
