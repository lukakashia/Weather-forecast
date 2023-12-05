using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        await SendHttpRequest();
    }

    public static async Task SendHttpRequest()
    {
        string apiKey = "8758588fecddaf8df7cc6de88eb96620";
        string city = "Rustavi";
        try
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}";

                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseContent = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"Weather information for {city}: {responseContent}");
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine("Failed to get weather information. Error: " + ex.Message);
        }
    }
}