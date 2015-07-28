using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.Web.Http;
using Windows.Web.Http.Headers;

namespace SurveyPlatform.Helpers
{
    public partial class JsonFeed
    {
        public JsonFeed(Type T, string url, string[] headers = null)
        {
            _FeedDataType = T;
            _URL = url;
            _Headers = headers;
        }

        private Type _FeedDataType;
        private string _URL;
        private string[] _Headers;

        private async Task<JsonFeedResponse> GetFeedAsync(JsonFeedResponse response)
        {
            try
            {
                HttpClient hc = new HttpClient();
                hc.DefaultRequestHeaders.Accept.Add(new HttpMediaTypeWithQualityHeaderValue("application/json"));
                if (_Headers != null)
                    foreach (var header in _Headers)
                        hc.DefaultRequestHeaders.Accept.Add(new HttpMediaTypeWithQualityHeaderValue(header));

                var resultString = await hc.GetStringAsync(new Uri(this._URL));

                if (!string.IsNullOrEmpty(resultString))
                {
                    var resultJSon = JsonConvert.DeserializeObject(resultString, _FeedDataType);
                    if (resultJSon != null)
                    {
                        response.Data = resultJSon;
                        response.Status = JsonFeedResponseStatus.Success;
                    }
                    else
                    {
                        response.ErrorMessage = "Sorry, we are having trouble getting data. Please try again!";
                        response.Status = JsonFeedResponseStatus.DataError;
                    }
                }
                else
                {
                    response.ErrorMessage = "Sorry, we are having trouble getting data. Please try again!";
                    response.Status = JsonFeedResponseStatus.DataError;
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.Status = JsonFeedResponseStatus.ConnectionError;
            }

            return response;
        }

        public static async Task<JsonFeedResponse> GetObjectFromJson(string url, Type type, string[] HttpHeaders = null)
        {
            return await new JsonFeed(type, url, HttpHeaders).GetFeedAsync(new JsonFeedResponse());
        }
    }

    public class JsonFeedResponse
    {
        public JsonFeedResponseStatus Status { get; set; }
        public string ErrorMessage { get; set; }
        public object Data { get; set; }
    }

    public enum JsonFeedResponseStatus
    {
        DataError,
        ConnectionError,
        Success
    }
}
