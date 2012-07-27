using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Net;
using System.IO;

namespace Jhilburn.BunchBallAdmin.Helpers
{
    public class BunchBall
    {
        private static String apiKey = "9a312e656a434db0a9981fe68a71bea8";
        private static String secretKey = "e9bdae186d854669a79aaa3f06dc3831";

        public string GetAdminSessionKey()
        {
            string sessionKey = null;
            XmlDocument response;
            string url = string.Format("http://jhilburn.nitro.bunchball.net/nitro/api?method=admin.loginAdmin&apiKey={0}&userId={1}&password={2}", apiKey, "neal.patel@jhilburn.com", "QUiSGkvmqYL4");
            response = getHttpResponseAsXml(url);
            XmlNode node = response.SelectSingleNode("//sessionKey");
            if (node != null)
            {
                sessionKey = node.InnerText;
            }
            return sessionKey;
        }

        public XmlDocument getHttpResponseAsXml(String requestString)
        {
            WebRequest req = System.Net.WebRequest.Create(requestString);
            WebResponse resp = req.GetResponse();
            StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            XmlDocument response = new XmlDocument();
            response.LoadXml(sr.ReadToEnd());
            return response;

        }

        public void LogAction(string tagName, string userId, string value, string sessionKey)
        {
            XmlDocument response = null;
            string logActionURL = string.Format("http://jhilburn.nitro.bunchball.net/nitro/api?method=user.logAction&userId={0}&sessionKey={1}&value={2}&tags={3}", userId, sessionKey, value, tagName);
            response = getHttpResponseAsXml(logActionURL);
            
        }

        public void CompleteChallenge(string challengeName, string userId, string sessionKey)
        {
            XmlDocument response = null;
            string logActionURL = string.Format("http://jhilburn.nitro.bunchball.net/nitro/api?method=user.awardChallenge&userId={0}&sessionKey={1}&challenge={2}", userId, sessionKey, challengeName);
            response = getHttpResponseAsXml(logActionURL);

        }

        private static string GenerateSessionKey(string userId, string firstName, string lastName)
        {
            string sessionKey = null;
            string requestURL = string.Format("https://jhilburn.nitro.bunchball.net/nitro/api?method=user.login&userId={0}&firstName={1}&lastName={2}&apiKey={3}", userId, firstName, lastName, apiKey);
            WebRequest req = System.Net.WebRequest.Create(requestURL);
            WebResponse resp = req.GetResponse();
            StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            XmlDocument response = new XmlDocument();
            response.LoadXml(sr.ReadToEnd());

            XmlNode node = response.SelectSingleNode("//sessionKey");
            if (node != null)
            {
                sessionKey = node.InnerText;
            }

            return sessionKey;
        }
    }
}