using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace _ShopiXamarin.Network
{
    public class Operations : IOperations
    {
        private const string Accept = "application/json";
        private const string UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.89 Safari/537.36)";

        public async Task<T> GetResponse<T>(string url, CancellationToken ctn)
        {
            Uri uri = null;
            using (var client = CreateClient(url))
            {
                var model = default(T);
                string json = null;
                try
                {
                    if (!Uri.TryCreate(url.Trim(), UriKind.Absolute, out uri))
                    {
                        //throw new AlveoException(_localizationManager.GetResourceString("method_error"));
                    }
                    var response = await client.GetAsync(uri, ctn);

                    json = await response.Content.ReadAsStringAsync();
                    ctn.ThrowIfCancellationRequested();
                    model = JsonConvert.DeserializeObject<T>(json, GetSerializeSettings(out var deseralizeMsg));
                    ctn.ThrowIfCancellationRequested();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return model;
            }
        }

        public async Task<T> PostJson<T>(string url, T myclass, CancellationToken ctn)
        {
            var data = JsonConvert.SerializeObject(myclass, new JsonSerializerSettings { Error = (s, e) => { e.ErrorContext.Handled = true; } });
            Uri uri = null;
            using (var client = CreateClient(url))
            {
                var model = default(T);
                string json = null;
                try
                {
                    if (!Uri.TryCreate(url.Trim(), UriKind.Absolute, out uri))
                    {
                        //throw new AlveoException(_localizationManager.GetResourceString("method_error"));
                    }
                    var response = await client.PostAsync(uri, new StringContent(data, Encoding.UTF8, Accept), ctn);
                    json = await response.Content.ReadAsStringAsync();
                    ctn.ThrowIfCancellationRequested();

                    model = JsonConvert.DeserializeObject<T>(json, GetSerializeSettings(out var deseralizeMsg));

                    ctn.ThrowIfCancellationRequested();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return model;
            }
        }
        public async Task<TU> PostJson<T, TU>(string url, T myclass, CancellationToken ctn, int timeoutSeconds = 0)
        {
            //var data = JsonConvert.SerializeObject(myclass, new JsonSerializerSettings { Error = (s, e) => { e.ErrorContext.Handled = true; } });
            var data = JsonConvert.SerializeObject(myclass);
            Uri uri = null;
            using (var client = CreateClient(url, timeoutSeconds))
            {
                var model = default(TU);
                string json = null;
                try
                {
                    if (!Uri.TryCreate(url.Trim(), UriKind.Absolute, out uri))
                    {
                        //throw new AlveoException(_localizationManager.GetResourceString("method_error"));
                    }
                    var response = await client.PostAsync(uri, new StringContent(data, Encoding.UTF8, Accept), ctn);
                    ctn.ThrowIfCancellationRequested();
                    json = await response.Content.ReadAsStringAsync();

                    model = JsonConvert.DeserializeObject<TU>(json, GetSerializeSettings(out var deseralizeMsg));

                    ctn.ThrowIfCancellationRequested();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return model;
            }
        }

        public async Task<T> PutJson<T>(string url, T myclass, CancellationToken ctn)
        {
            var data = JsonConvert.SerializeObject(myclass, new JsonSerializerSettings { Error = (s, e) => { e.ErrorContext.Handled = true; } });
            Uri uri = null;
            using (var client = CreateClient(url))
            {
                var model = default(T);
                string json = null;
                try
                {
                    if (!Uri.TryCreate(url.Trim(), UriKind.Absolute, out uri))
                    {
                        //throw new AlveoException(_localizationManager.GetResourceString("method_error"));
                    }
                    var response = await client.PutAsync(uri, new StringContent(data, Encoding.UTF8, Accept), ctn);
                    ctn.ThrowIfCancellationRequested();
                    json = await response.Content.ReadAsStringAsync();

                    model = JsonConvert.DeserializeObject<T>(json, GetSerializeSettings(out var deseralizeMsg));

                    ctn.ThrowIfCancellationRequested();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return model;
            }
        }

        public async Task<TU> PutJson<T, TU>(string url, T myclass, CancellationToken ctn)
        {
            var data = JsonConvert.SerializeObject(myclass, new JsonSerializerSettings { Error = (s, e) => { e.ErrorContext.Handled = true; } });
            Uri uri = null;
            using (var client = CreateClient(url))
            {
                var model = default(TU);
                string json = null;
                try
                {
                    if (!Uri.TryCreate(url.Trim(), UriKind.Absolute, out uri))
                    {
                        //throw new AlveoException(_localizationManager.GetResourceString("method_error"));
                    }
                    var response = await client.PutAsync(uri, new StringContent(data, Encoding.UTF8, Accept), ctn);
                    ctn.ThrowIfCancellationRequested();
                    json = await response.Content.ReadAsStringAsync();

                    model = JsonConvert.DeserializeObject<TU>(json, GetSerializeSettings(out var deseralizeMsg));

                    ctn.ThrowIfCancellationRequested();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                ctn.ThrowIfCancellationRequested();
                return model;
            }
        }

        public async Task<T> DeleteJson<T>(string url, CancellationToken ctn)
        {
            Uri uri = null;
            using (var client = CreateClient(url))
            {
                var model = default(T);
                string json = null;
                try
                {
                    if (!Uri.TryCreate(url.Trim(), UriKind.Absolute, out uri))
                    {
                        //throw new AlveoException(_localizationManager.GetResourceString("method_error"));
                    }
                    var response = await client.DeleteAsync(uri, ctn);
                    json = await response.Content.ReadAsStringAsync();
                    ctn.ThrowIfCancellationRequested();

                    model = JsonConvert.DeserializeObject<T>(json, GetSerializeSettings(out var deseralizeMsg));

                    ctn.ThrowIfCancellationRequested();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return model;
            }
        }

        private HttpClient CreateClient(string url, int timeoutSeconds = 0)
        {
            var httpClient = new HttpClient(new HttpClientHandler
            {
                AllowAutoRedirect = true,
                UseCookies = true
            });

            if (timeoutSeconds > 0)
            {
                httpClient.Timeout = TimeSpan.FromSeconds(timeoutSeconds);
            }
            httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd(UserAgent);
            httpClient.DefaultRequestHeaders.Accept.TryParseAdd(Accept);
            httpClient.DefaultRequestHeaders.AcceptLanguage.TryParseAdd("en-US");

            return httpClient;
        }

        private static JsonSerializerSettings GetSerializeSettings(out List<string> deseralizeMsg)
        {
            var messages = new List<string>();

            var settings = new JsonSerializerSettings
            {
                Error = (s, e) =>
                {
                    messages.Add(string.Format("Object:{0}  Message:{1}", e.ErrorContext.Member,
                        e.ErrorContext.Error.Message));

                    e.ErrorContext.Handled = true;
                },
                DateFormatString = "dd/MM/yyy hh:mm:ss"
            };

            deseralizeMsg = messages;

            return settings;
        }
    }
}
