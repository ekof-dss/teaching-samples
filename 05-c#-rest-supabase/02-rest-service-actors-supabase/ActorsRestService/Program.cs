using Microsoft.Extensions.DependencyInjection;

using Supabase;

using ActorsRestService;

var builder = WebApplication.CreateBuilder(args);

var supabaseConfiguration = builder.Configuration
    .GetSection("Supabase")
    .Get<SupabaseConfiguration>(); 

// Add services to the container.
builder.Services.AddScoped<Supabase.Client>(
    provider => new Supabase.Client(supabaseConfiguration.Url, supabaseConfiguration.Key));

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
