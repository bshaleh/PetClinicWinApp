using Newtonsoft.Json;
using PetClinicWinApp.Properties;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicWinApp.Helpers
{
    public static class ApiHelper
    {
        static ApiHelper()
        {
#if DEBUG
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
#endif
        }
        private static readonly string BaseUrl = $"http://{Settings.Default.ApiServerIp}:{Settings.Default.ApiPort}/api/";
        //private static readonly string BaseUrl = Settings.Default.ApiBaseUrl;
        //private static readonly string BaseUrl = "http://192.168.1.3:8080/api/"; // UPDATE TO YOUR API URL
        private static string _userRole;

        public static void SetUserRole(string role)
        {
            _userRole = role;
        }

        public static async Task<T> GetAsync<T>(string endpoint)
        {
            using (HttpClient client = new HttpClient())
            {
                if (!string.IsNullOrEmpty(_userRole))
                {
                    client.DefaultRequestHeaders.Add("UserRole", _userRole);
                }

                var response = await client.GetAsync(BaseUrl + endpoint);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(json);
            }
        }

        public static async Task<T> PostAsync<T>(string endpoint, object data)
        {
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(30);
                if (!string.IsNullOrEmpty(_userRole))
                {
                    client.DefaultRequestHeaders.Add("UserRole", _userRole);
                }

                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                try
                {
                    var response = await client.PostAsync(BaseUrl + endpoint, content);
                    response.EnsureSuccessStatusCode();
                    var resultJson = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(resultJson);
                }
                catch (TaskCanceledException ex)
                {

                    throw new Exception("Request timeout or canceled. Check API and database.", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception($"API Error: {ex.Message}", ex);
                }

            }
        }

        public static async Task<T> DeleteAsync<T>(string endpoint)
        {
            using (HttpClient client = new HttpClient())
            {
                // Set base address and timeout
                client.BaseAddress = new Uri(BaseUrl);
                client.Timeout = TimeSpan.FromSeconds(30); // Adjust timeout as needed

                // Add authorization header if user role is set (important for role-based endpoints)
                if (!string.IsNullOrEmpty(_userRole))
                {
                    client.DefaultRequestHeaders.Add("UserRole", _userRole);
                }

                try
                {
                    // Send DELETE request
                    HttpResponseMessage response = await client.DeleteAsync(endpoint);

                    // Ensure the request was successful (e.g., 200 OK, 204 No Content)
                    response.EnsureSuccessStatusCode();

                    // Read and deserialize the response content (if any)
                    string json = await response.Content.ReadAsStringAsync();

                    if (string.IsNullOrWhiteSpace(json))
                    {
                        // If no content, return default value (e.g., null for classes, default for structs)
                        // This handles cases like HTTP 204 No Content
                        return default(T);
                    }

                    // Deserialize the JSON response into the specified type T
                    return JsonConvert.DeserializeObject<T>(json);
                }
                //catch (HttpRequestException httpEx)
                //{
                //    // Handle HTTP errors (e.g., 404 Not Found, 500 Internal Server Error)
                //    // You might want to log this or wrap it in a custom exception
                //    //throw new Exception($"API Error ({response.StatusCode}): {httpEx.Message}", httpEx);
                //}
                catch (TaskCanceledException tcEx) when (tcEx.InnerException is TimeoutException)
                {
                    // Handle timeout specifically
                    throw new Exception("The request timed out while trying to delete the resource.", tcEx);
                }
                catch (Exception ex)
                {
                    // Handle other potential errors (e.g., network issues, serialization problems)
                    throw new Exception($"An error occurred while deleting the resource: {ex.Message}", ex);
                }
            }
        }


        public static async Task<T> PutAsync<T>(string endpoint, object data)
        {
            using (HttpClient client = new HttpClient())
            {
                // Set base address and timeout
                client.BaseAddress = new Uri(BaseUrl);
                client.Timeout = TimeSpan.FromSeconds(30); // Adjust timeout as needed

                // Add authorization header if user role is set (important for role-based endpoints)
                if (!string.IsNullOrEmpty(_userRole))
                {
                    client.DefaultRequestHeaders.Add("UserRole", _userRole);
                }

                try
                {
                    // Serialize the data object to JSON
                    string json = JsonConvert.SerializeObject(data);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    // Send PUT request
                    HttpResponseMessage response = await client.PutAsync(endpoint, content);

                    // Ensure the request was successful (e.g., 200 OK)
                    response.EnsureSuccessStatusCode();

                    // Read and deserialize the response
                    string resultJson = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(resultJson);
                }
                //catch (HttpRequestException httpEx)
                //{
                //    // Handle HTTP errors (e.g., 404 Not Found, 500 Internal Server Error)
                //    throw new Exception($"API Error ({response.StatusCode}): {httpEx.Message}", httpEx);
                //}
                catch (TaskCanceledException tcEx) when (tcEx.InnerException is TimeoutException)
                {
                    // Handle timeout specifically
                    throw new Exception("The request timed out while trying to update the resource.", tcEx);
                }
                catch (Exception ex)
                {
                    // Handle other potential errors (e.g., network issues, serialization problems)
                    throw new Exception($"An error occurred while updating the resource: {ex.Message}", ex);
                }
            }
        }

    }
}
