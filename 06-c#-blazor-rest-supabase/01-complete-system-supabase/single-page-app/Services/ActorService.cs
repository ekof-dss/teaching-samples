using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Linq;

using project.Models;
using project.ViewModels;
using static System.Net.WebRequestMethods;
using static System.Net.Mime.MediaTypeNames;

namespace project.Services
{
    public class ActorService : IActorService
    {
        private readonly string _requestUri;
        private readonly HttpClient _httpClient;
        private readonly IMessagingService _messagingService;

        public ActorService(HttpClient httpClient,
            IMessagingService messagingService)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(
                nameof(httpClient));
            _requestUri = "https://localhost:6001/api" + "/Actors";
            _messagingService = messagingService ?? throw new
                ArgumentNullException(nameof(messagingService));
        }
        public async Task<List<Actor>> GetActors()
        {
            // sending request for reading to the server
            List<Actor> actors = await _httpClient.GetFromJsonAsync<List<Actor>>(
                _requestUri);
            await _messagingService.Add("ActorService::Sent request for read");
            return actors;
        }

        public async Task<List<ActorCountryDto>> GetActorsWithCountry()
        {
            // sending request for reading to the server
            List<ActorCountryDto> actors = await _httpClient.GetFromJsonAsync<List<ActorCountryDto>>(
                _requestUri + "/WithCountry");
            await _messagingService.Add("ActorService::Sent request for read actors with country");
            return actors;
        }
        public async Task<int> Add(string firstName, string lastName,
            long countryId)
        {
            // sending request for adding to the server
            ActorAddDto actorAdd = new ActorAddDto()
            {
                actorId = -1,
                firstName = firstName,
                lastName = lastName,
                countryId = countryId,
                createdAt = DateTime.Now
            };
            var response = await _httpClient.PostAsJsonAsync(_requestUri, actorAdd);
            await _messagingService.Add(response.IsSuccessStatusCode ?
                "ActorService::Sent request for add" :
                "ActorService::Error while adding");
             // return result
            return 0;
        }

        public async Task<int> Delete(long actorId)
        {
            // sending request for deleting to the server
            var response = await _httpClient.DeleteAsync(_requestUri + "/"
                + actorId);
            await _messagingService.Add(response.IsSuccessStatusCode ?
                "ActorService::Sent request for delete" :
                "ActorService::Error while deleting");
            // return result
            return 0;
        }

        public async Task<int> Update(Actor actor)
        {
            // sending request for updating to the server
            ActorUpdateDto actorUpd = new ActorUpdateDto()
            {
                actorId = actor.actorId,
                firstName = actor.firstName,
                lastName = actor.lastName,
                countryId = actor.countryId,
                dateOfBirth = actor.dateOfBirth,
                createdAt = actor.createdAt
            };
            var response = await _httpClient.PutAsJsonAsync<ActorUpdateDto>(
                _requestUri + "/" + actor.actorId, actorUpd);
            await _messagingService.Add(response.IsSuccessStatusCode ?
                "ActorService::Sent request for update" :
                "ActorService::Error while updating");
            // return result          
            return 0;
        }

        public async Task<List<ActorCountryDto>> Search(string fn, string ln, string c)
        {
            await _messagingService.Add("ActorService::Search for " + fn + " " + ln + " " + c);
            List<ActorCountryDto> actors = await _httpClient.GetFromJsonAsync<List<ActorCountryDto>>(
                        _requestUri + "/WithCountry");
            List<ActorCountryDto> result = actors.Where(actor =>
                            actor.first_name.ToLower().Contains(fn.ToLower())
                            || actor.last_name.ToLower().Contains(ln.ToLower())
                            || actor.country_name.ToLower().Contains(c.ToLower())
                            )
                        .ToList<ActorCountryDto>();
            return result;
        }

    }
}