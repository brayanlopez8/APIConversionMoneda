using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BrayanTechnicalTest.BLL.Utitlity
{
    public class RestUtitity
    {
        public static T CallService<T>(string url, string operation, object requestBodyObject, string method, string username,
            string password) where T : class
        {
            // Initialize an HttpWebRequest for the current URL.
            var webReq = (HttpWebRequest)WebRequest.Create(url);
            webReq.Method = method;
            webReq.Accept = "application/json";

            //Add basic authentication header if username is supplied
            if (!string.IsNullOrEmpty(username))
            {
                webReq.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(username + ":" + password));
            }

            //Add key to header if operation is supplied
            if (!string.IsNullOrEmpty(operation))
            {
                webReq.Headers["Operation"] = operation;
            }

            //Serialize request object as JSON and write to request body
            if (requestBodyObject != null)
            {
                var requestBody = JsonConvert.SerializeObject(requestBodyObject);
                webReq.ContentLength = requestBody.Length;
                var streamWriter = new StreamWriter(webReq.GetRequestStream(), Encoding.ASCII);
                streamWriter.Write(requestBody);
                streamWriter.Close();
            }

            var response =  (HttpWebResponse)webReq.GetResponse();


            if (response == null)
            {
                return null;
            }

            var streamReader = new StreamReader(response.GetResponseStream());

            var responseContent = streamReader.ReadToEnd().Trim();

            var jsonObject = JsonConvert.DeserializeObject<T>(responseContent);

            return jsonObject;
        }


        public static string CallService(string urlAddress)
        {
            string Result = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }

                Result = readStream.ReadToEnd();

                response.Close();
                readStream.Close();
            }
            return Result;
        }
    }
}
