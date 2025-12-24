using System;
using System.Net.Http;
using System.Threading.Tasks;

using Supabase;
using Supabase.Core;
using Supabase.Functions;

namespace DssSupabase02
{

    public class Program
    {
        static async Task Main(string[] args)
        {
            // init
            var supabaseUrl = "https://azamryegrfdsrdumdboa.supabase.co";
            var supabaseKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImF6YW1yeWVncmZkc3JkdW1kYm9hIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MjU4MzAyMjEsImV4cCI6MjA0MTQwNjIyMX0.iJevVQqicaCcytzwuRiRplBUbitCLmR1uDzH-nEvpNo";

            var options = new Supabase.SupabaseOptions
            {
                AutoConnectRealtime = true
            };

            var supabase = new Supabase.Client(supabaseUrl, supabaseKey, options);
            await supabase.InitializeAsync();

            // A result can be fetched like so.
            var result = await supabase.From<Actor>().Get();
            var actors = result.Models;

            Console.WriteLine(actors.Count);

            var model = new Actor
            {
                FirstName = "Robert",
                LastName = "De Niro",
                DateOfBirth = new DateTime(1946,7,13),
                CountryCode = "US",
                CreatedAt = DateTime.Now
            };

            await supabase.From<Actor>().Insert(model);
        }
    }
}

