using System;

using Supabase;

namespace DssSupabase01
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var supabaseUrl = "https://azamryegrfdsrdumdboa.supabase.co";
            var supabaseKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImF6YW1yeWVncmZkc3JkdW1kYm9hIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MjU4MzAyMjEsImV4cCI6MjA0MTQwNjIyMX0.iJevVQqicaCcytzwuRiRplBUbitCLmR1uDzH-nEvpNo";

            var service = new SupabaseService(supabaseUrl, supabaseKey);

            // Fetch data
            string result = await service.GetDataAsync("Actor");
            Console.WriteLine("Data from table:");
            Console.WriteLine(result);

            // Insert data
            string jsonData = "{\"first_name\": \"Franco\", \"last_name\": \"Nero\"}";
            string insertResult = await service.InsertDataAsync("Actor", jsonData);
            Console.WriteLine("Insert response:");
            Console.WriteLine(insertResult);        
        }
    }
}
