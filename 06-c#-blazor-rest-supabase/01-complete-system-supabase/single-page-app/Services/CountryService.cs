using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Linq;

using project;
using project.Models;
using project.ViewModels;
using static System.Net.WebRequestMethods;

namespace project.Services
{
    public class CountryService : ICountryService
    {
        private readonly string _requestUri;
        private readonly HttpClient _httpClient;
        private readonly IMessagingService _messagingService;

        public CountryService(HttpClient httpClient, 
            IMessagingService messagingService)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(
                nameof(httpClient));
            _requestUri = "https://localhost:6001/api" + "/Countries";
            _messagingService = messagingService ?? throw new
                ArgumentNullException(nameof(messagingService));
        }
        public async Task<List<Country>> GetCountries()
        {
            // sending request for reading to the server
            List<Country> countries = await _httpClient.GetFromJsonAsync<List<Country>>(
                    _requestUri);
            await _messagingService.Add("CountryService::Sent request for read");
            return countries;
        }

        public async Task<int> Add(string countryName, string countryCode)
        {
            // sending request for adding to the server
            Country countryAdd = new Country()
            {
                countryName = countryName,
                countryCode = countryCode,
                createdAt = DateTime.Now
            };
            var response = await _httpClient.PostAsJsonAsync(_requestUri, countryAdd);
            await _messagingService.Add(response.IsSuccessStatusCode ?
                "CountryService::Sent request for add" :
                "CountryService::Error while adding");
             // return result
            return 0;      
        }

        public async Task<int> Delete(long countryId)
        {
            // sending request for deleting to the server
            var response = await _httpClient.DeleteAsync(_requestUri + "/"
                + countryId);
            await _messagingService.Add(response.IsSuccessStatusCode ?
                "CountryService::Sent request for delete" :
                "CountryService::Error while deleting");
            // return result
            return 0;
        }

        public async Task<int> Update(Country country)
        {
       // sending request for updating to the server
            Country countryUpd = new Country()
            {
                countryId = country.countryId,
                countryName = country.countryName,
                createdAt = country.createdAt
            };
            var response = await _httpClient.PutAsJsonAsync<Country>(
                _requestUri + "/" + country.countryId, countryUpd);
            await _messagingService.Add(response.IsSuccessStatusCode ?
                "CountryService::Sent request for update" :
                "CountryService::Error while updating");
            // return result          
            return 0;        }
    }
}