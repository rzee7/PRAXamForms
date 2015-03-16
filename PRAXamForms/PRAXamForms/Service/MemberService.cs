using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PRAXamForms.Service
{
    public static class MemberService
    {
#if DEBUG
        public const String HosetName = "http://192.168.1.11:4040/api/";
        public const String MemberList = "Member";
        public const String MemberDetails = "Member/{0}";
#else
        private const String HOST_NAME = "https://rest-xamarinambassador.azurewebsites.net/api";
        private const String ALL_AMBASSADORS = "/values/";
        private const String DETA_AMBASSADOR = "/values/{0}";
#endif
        private static async Task<T> PostData<T>(string endpoint, HttpMethod method,
            IEnumerable<KeyValuePair<string, string>> content = null) where T : class
        {
            T returnResult = null;

            HttpClient client = null;
            try
            {
                client = new HttpClient();
                client.BaseAddress = new Uri(HosetName);
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                client.Timeout = new TimeSpan(0, 0, 15);

                HttpResponseMessage result = null;

                FormUrlEncodedContent data = null;
                if (content != null)
                    data = new FormUrlEncodedContent(content);

                if (method == HttpMethod.Get)
                    result = await client.GetAsync(endpoint);

                if (method == HttpMethod.Put)
                    result = await client.PutAsync(endpoint, data);

                if (method == HttpMethod.Delete)
                    result = await client.DeleteAsync(endpoint);

                if (method == HttpMethod.Post)
                    result = await client.PostAsync(endpoint, data);

                if (result != null)
                {
                    if (result.IsSuccessStatusCode
                        && result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var json = result.Content.ReadAsStringAsync().Result;
                        returnResult = JsonConvert.DeserializeObject<T>(json);
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error fetching data: " + ex.Message);
            }
            finally
            {
                if (client != null)
                    client.Dispose();
            }

            return returnResult;
        }

        public static void GetDataAsync(string endpoint, Action<Response> callback)
        {
            PostData<Response>(endpoint, HttpMethod.Get,
                null).ContinueWith((completed) =>
                {
                    if (!completed.IsFaulted)
                        callback(completed.Result);
                   
                }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
