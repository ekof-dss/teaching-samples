using System;
using System.Net.Http;


namespace DssSupabase01
{

public class SupabaseService
    {
        private readonly HttpClient _client;

        public SupabaseService(string supabaseUrl, string supabaseKey)
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(supabaseUrl)
            };
            _client.DefaultRequestHeaders.Add("apikey", supabaseKey);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {supabaseKey}");
        }

        public async Task<string> GetDataAsync(string tableName)
        {
            var response = await _client.GetAsync($"/rest/v1/{tableName}?select=*");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> InsertDataAsync(string tableName, string jsonData)
        {
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"/rest/v1/{tableName}", content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}