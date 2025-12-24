using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using project.Models;

namespace project.Services
{
    public interface ICountryService
    {
        Task<List<Country>> GetCountries();

        Task<int> Add(string countryName, string countryCode);

        Task<int> Delete(long countryId);

        Task<int> Update(Country country);
    }
}
