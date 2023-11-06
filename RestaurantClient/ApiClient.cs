using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Restaurant.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text;
using System.Xml.Linq;

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

    public async void PostDataToApiGeneric<T>(string apiUrl, T data)
    {
        try
        {
            // Serialize the object to a JSON string
            string jsonString = JsonSerializer.Serialize(data);

            // Create an instance of StringContent from the JSON string
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }




}
