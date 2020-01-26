using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net;
using ChurchAccountingApiClient.Models.Reponse;
using Newtonsoft.Json;
using ChurchLibrary.Model.Base.Request;

namespace ChurchAccountingApiClient
{
    public static partial class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }
        
        public static void InitializeClient(string uri)
        {
            if (ApiClient == null)
            {
                ApiClient = new HttpClient();
                ApiClient.DefaultRequestHeaders.Accept.Clear();
                ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                ApiClient.BaseAddress = new Uri(uri);
            }
        }

        public static T CallGetWebApi<T>(string url)
        {
            using (HttpResponseMessage response = ApiHelper.ApiClient.GetAsync(url).Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    T model = response.Content.ReadAsAsync<T>().Result;

                    return model;
                }
                else
                {
                    var resultMessage = JsonConvert.DeserializeObject<Message>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                    throw new Exception(resultMessage.message);
                }
            }
        }

        /// <summary>
        /// Search API call
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="searchLimiter"></param>
        /// <returns></returns>
        public static T CallPostSearchWebApi<T>(string url, SearchLimiters searchLimiter)
        {
            using (HttpResponseMessage response = ApiClient.PostAsJsonAsync(url, searchLimiter).Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the updated T from the response body.
                    return response.Content.ReadAsAsync<T>().Result;
                }
                else
                {
                    var resultMessage = JsonConvert.DeserializeObject<Message>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                    throw new Exception(resultMessage.message);
                }
            }
        }

        /// <summary>
        /// Search API call
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="searchLimiter"></param>
        /// <returns></returns>
        public static T CallPutSearchWebApi<T>(string url, SearchLimiters searchLimiter)
        {
            using (HttpResponseMessage response = ApiClient.PutAsJsonAsync(url, searchLimiter).Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the updated T from the response body.
                    return response.Content.ReadAsAsync<T>().Result;
                }
                else
                {
                    var resultMessage = JsonConvert.DeserializeObject<Message>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                    throw new Exception(resultMessage.message);
                }
            }
        }

        public static void CallPostWebApi_current<T>(string url, T value)
        {
            using (HttpResponseMessage response = ApiClient.PostAsJsonAsync(url, value).Result)
            {
                if (response.IsSuccessStatusCode) {
                    
                }
                else
                {
                    var resultMessage = JsonConvert.DeserializeObject<Message>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                    throw new Exception(resultMessage.message);
                }
            }
        }

        public static void CallPostWebApi<T>(string url, T value)
        {
            var response = ApiClient.PostAsJsonAsync(url, value);

            response.Wait();
            var result = response.Result;
            
            if (result.IsSuccessStatusCode)
            {

            }
            else
            {
                var resultMessage = JsonConvert.DeserializeObject<Message>(result.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                throw new Exception(resultMessage.message);
            }
        }

        public static T CallPutWebApi<T>(string url, T value)
        {
            using (HttpResponseMessage response = ApiClient.PutAsJsonAsync(url, value).Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the updated T from the response body.
                    return response.Content.ReadAsAsync<T>().Result;
                }
                else
                {
                    var resultMessage = JsonConvert.DeserializeObject<Message>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                    throw new Exception(resultMessage.message);
                }
            }
        }
    }
}
