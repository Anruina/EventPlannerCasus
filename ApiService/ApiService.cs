using Newtonsoft.Json;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Library.ApiService
{

    public class ApiService
    {

        private HttpClient _httpClient;
        private JsonSerializerOptions _jsonSerializerOptions;

        public ApiService()
        {

            ///<summary> I am temporary disabling certificate validation check, because it is giving problems </summary>
            _httpClient = new HttpClient(new HttpClientHandler
            {

                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true

            });
            _httpClient.BaseAddress = new Uri("https://10.0.2.2:7119");//"https://10.0.2.2:7119");

            _jsonSerializerOptions = new JsonSerializerOptions
            {

                ReferenceHandler = ReferenceHandler.Preserve,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true

            };

        }

        public async Task<T?> GetSpecific<T>(string apiFunction, int? id = null)
        {

            try
            {

                if (id != null)
                    apiFunction += id.ToString();

                HttpResponseMessage Response = await _httpClient.GetAsync(apiFunction);

                if (Response.IsSuccessStatusCode)
                {

                    string Content = await Response.Content.ReadAsStringAsync();
                    T? Object = System.Text.Json.JsonSerializer.Deserialize<T>(Content, _jsonSerializerOptions);

                    return Object;

                }

            }
            catch (Exception ex) 
            {

                Debug.WriteLine(@"\tERROR {0}", ex);

            }

            return default(T);

        }

        public async Task<List<T>?> GetList<T>(string apiFunction)
        {

            try
            {

                HttpResponseMessage Response = await _httpClient.GetAsync(apiFunction);

                if (Response.IsSuccessStatusCode)
                {

                    string Content = await Response.Content.ReadAsStringAsync();
                    List<T>? ObjectList = System.Text.Json.JsonSerializer.Deserialize<List<T>>(Content, _jsonSerializerOptions);

                    return ObjectList;

                }

            }
            catch (Exception ex)
            {

                Debug.WriteLine(@"\tERROR {0}", ex);

            }

            return null;

        }

        public async Task<T?> CreateObject<T>(string apiFunction, T? Object)
        {

            try
            {

                StringContent content = new StringContent(JsonConvert.SerializeObject(Object), System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage Response = await _httpClient.PostAsync(apiFunction, content);

                if (Response.IsSuccessStatusCode)
                    return System.Text.Json.JsonSerializer.Deserialize<T>(await Response.Content.ReadAsStringAsync(), _jsonSerializerOptions);

            }
            catch(Exception ex)
            {

                Debug.WriteLine(@"\tERROR {0}", ex);

            }

            return default(T);

        }

        public async Task<T?> UpdateObject<T>(string apiFunction, int id, T Object)
        {

            try
            {

                apiFunction += id.ToString();

                var content = new StringContent(JsonConvert.SerializeObject(Object), System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage Response = await _httpClient.PutAsync(apiFunction, content);

                if (Response.IsSuccessStatusCode)
                    return System.Text.Json.JsonSerializer.Deserialize<T>(await Response.Content.ReadAsStringAsync(), _jsonSerializerOptions);

            }
            catch (Exception ex)
            {

                Debug.WriteLine(@"\tERROR {0}", ex);

            }

            return default(T);

        }

        public async Task<bool> DeleteObject(string apiFunction, int? id = null)
        {

            try
            {

                if (id != null)
                    apiFunction += id.ToString();

                HttpResponseMessage Response = await _httpClient.DeleteAsync(apiFunction);
                return Response.IsSuccessStatusCode;

            }
            catch (Exception ex)
            {

                Debug.WriteLine(@"\tERROR {0}", ex);

            }

            return false;

        }

    }

}
