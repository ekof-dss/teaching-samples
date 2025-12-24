using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using project.Models;
using project.ViewModels;

namespace project.Services
{
    public interface IActorService
    {
        Task<List<Actor>> GetActors();

        Task<List<ActorCountryDto>> GetActorsWithCountry();

        Task<int> Add(string firstName, string lastName, long countryId);

        Task<int> Delete(long actorId);

        Task<int> Update(Actor actor);

        Task<List<ActorCountryDto>> Search(string fn, string ln, string c);
    }
}
