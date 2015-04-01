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
        public const string HostName ="http://192.168.1.2:4040/api/";
        public const string MemberList = "Member";
        public const string MemberDetails = "Member/{0}";
        public const string Login = "Login";
        public const string UserAvailabale = "Login/1";

        public static async Task<T> PostData<T, Tr>(string endpoint, HttpMethod method,
            Tr content)
        {
            T returnResult=default(T);

            HttpClient client = null;
            try
            {
                client = new HttpClient();
                client.BaseAddress = new Uri(HostName);
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                client.Timeout = new TimeSpan(0, 0, 15);

                HttpResponseMessage result = null;

                StringContent data = null;
                if (content != null)
                    data = new StringContent(JsonConvert.SerializeObject(content), UTF8Encoding.UTF8, "application/json");

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
            PostData<Response, object>(endpoint, HttpMethod.Get,
                null).ContinueWith((completed) =>
                {
                    if (!completed.IsFaulted)
                        callback(completed.Result);
                }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
