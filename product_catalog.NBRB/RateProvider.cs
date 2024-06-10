using product_catalog.NBRB.Contracts;
using product_catalog.NBRB.Models;
using System.Net.Http.Json;

namespace product_catalog.NBRB;

public class RateProvider : IRateProvider
{
    private readonly HttpClient _httpClient;

    public RateProvider(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<decimal> ConvertValueToCurrency(decimal value, string currency)
    {
        var response = await _httpClient.GetAsync($"{currency}");

        if (!response.IsSuccessStatusCode)
        {
            var message = await GenerateErrorMessage(response);
            throw new NBRBRequestException(message);
        }

        var rate = await response.Content.ReadFromJsonAsync<Rate>();

        return value * rate.Cur_OfficialRate;
    }

    private async Task<string> GenerateErrorMessage(HttpResponseMessage response)
    {
        var message = await response.Content.ReadAsStringAsync();
        return $"Error message: {message}";
    }
}
