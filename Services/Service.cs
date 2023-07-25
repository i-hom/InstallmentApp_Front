using InstallmentApp_Front.Model;
using System.Net.Http.Json;
using System.Text.Json;

namespace InstallmentApp_Front.Services;

public class Installment_Service
{
    public async Task<T> Request<T>(string requestmsg)
    {
        HttpClient client = new();
        HttpRequestMessage request = new(HttpMethod.Get, "http://192.168.0.77:7777/EndPoint");
        //HttpRequestMessage request = new(HttpMethod.Get, "http://10.10.10.5:7777/EndPoint");
        //HttpRequestMessage request = new(HttpMethod.Get, "http://192.168.233.88:7777/EndPoint");
        //HttpRequestMessage request = new(HttpMethod.Get, "https://c482-34-155-154-31.ngrok-free.app");

        request.Content = new StringContent(requestmsg, null, "application/json");
        HttpResponseMessage response = await client.SendAsync(request);

        response.EnsureSuccessStatusCode();

        client.Dispose();

        return await response.Content.ReadFromJsonAsync<T>();
    }
}


