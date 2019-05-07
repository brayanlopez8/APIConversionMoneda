using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace BrayanTechnicalTest.API.AppInsights
{
    public class CustomLog : ITelemetryInitializer
    {
        public void Initialize(ITelemetry telemetry)
        {
            var requestTelemetry = telemetry as RequestTelemetry;

            int code;
            if (requestTelemetry != null)
            {
                bool parsed = Int32.TryParse(requestTelemetry.ResponseCode, out code);
                if (!parsed) return;
                if (code >= 400 && code < 500)
                {
                    if (requestTelemetry != null && (HttpContext.Current.Request.HttpMethod == HttpMethod.Post.ToString() || HttpContext.Current.Request.HttpMethod == HttpMethod.Put.ToString()))
                    {
                        using (var reader = new StreamReader(HttpContext.Current.Request.InputStream))
                        {
                            string requestBody = reader.ReadToEnd();
                            requestTelemetry.Properties.Add("body", requestBody);
                        }
                    }
                }
            }

        }
        public static void CustomLogExeption(Exception ex, Stream inputStream )
        {
            using (var reader = new StreamReader(inputStream))
            {
                string requestBody = reader.ReadToEnd();
                TelemetryClient telemetry = new TelemetryClient();
                telemetry.TrackException(ex, new System.Collections.Generic.Dictionary<string, string>() {
                            { "body",requestBody }
                        });
            };
        }
    }

}