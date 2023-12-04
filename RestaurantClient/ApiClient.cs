using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Restaurant.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text;
using System.Xml.Linq;
using System.Windows.Forms;

public class ApiClient
{
    private HttpClient httpClient;

    public ApiClient()
    {
        httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("https://localhost:1337/");
    }

    public async Task<string> GetDataFromApi(string apiUrl)
    {
        try
        {
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                return data;
            }
            else
            {
                Console.WriteLine($"API request failed with status code: {response.StatusCode}");
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return null;
        }
    }

    public async Task<T> GetDataFromApiGeneric<T>(string apiUrl)
    {
        try
        {
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(data);
            }
            else
            {
                Console.WriteLine($"API request failed with status code: {response.StatusCode}");
                return default(T);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return default(T);
        }
    }

    public async Task<T> GetDataFromApiGeneric<T>(string apiUrl, T data)
    {
        var handler = new WinHttpHandler();
        HttpClient httpClient = new HttpClient(handler);

        // Serialize the object to a JSON string
        string jsonString = JsonSerializer.Serialize(data);

        // Create an instance of StringContent from the JSON string
        var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(apiUrl),
            Content = content
        };

        try
        {
            var response = await httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(responseData);
            }
            else
            {
                Console.WriteLine($"API request failed with status code: {response.StatusCode}");
                return default(T);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return default(T);
        }
    }

    public async Task<HttpResponseMessage> PostDataToApiGeneric<T>(string apiUrl, T data)
    {
        HttpResponseMessage response = new HttpResponseMessage();
        response.StatusCode = System.Net.HttpStatusCode.BadRequest;
        try
        {
            // Serialize the object to a JSON string
            string jsonString = JsonSerializer.Serialize(data);

            // Create an instance of StringContent from the JSON string
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, apiUrl);
            request.Content = content;

            response = await httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show($"Not successful, HTTP-Statuscode: {response.StatusCode}", "API Call failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred: {ex.Message}", "API Call failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return response;
    }

    public async Task<HttpResponseMessage> PutDataToApiGeneric<T>(string apiUrl, T data)
    {
        HttpResponseMessage response = new HttpResponseMessage();
        response.StatusCode = System.Net.HttpStatusCode.BadRequest;
        try
        {
            // Serialize the object to a JSON string
            string jsonString = JsonSerializer.Serialize(data);

            // Create an instance of StringContent from the JSON string
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            response = await httpClient.PutAsync(apiUrl, content);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show($"Success, HTTP-Statuscode: {response.StatusCode}");
            }
            else
            {
                MessageBox.Show($"Not successful, HTTP-Statuscode: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        return response;
    }

    public async Task<HttpResponseMessage> PutDataToApiGeneric<T>(string apiUrl, T data1, T data2)
    {
        List<T> objList= new List<T>();
        objList.Add(data1);
        objList.Add(data2);

        HttpResponseMessage response = new HttpResponseMessage();
        response.StatusCode = System.Net.HttpStatusCode.BadRequest;
        try
        {
            // Serialize the object list to a JSON string, the list contains exactly two objects of type T
            string jsonString = JsonSerializer.Serialize(objList);

            // Create an instance of StringContent from the JSON string
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Put, apiUrl);
            request.Content = content;
            response = await httpClient.SendAsync(request);

            //response = await httpClient.PutAsync(apiUrl, content);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show($"Success, HTTP-Statuscode: {response.StatusCode}");
            }
            else
            {
                MessageBox.Show($"Not successful, HTTP-Statuscode: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        return response;
    }
}
