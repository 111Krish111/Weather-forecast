
using BlazorApp.Components;
using BlazorApp.Controllers;
using MudBlazor.Services;
using BlazorApp.Singletons;
using BlazorApp.Services;
using Supabase;

var builder = WebApplication.CreateBuilder(args);

var supabaseUrl = "https://swgemivmgvibghrnarov.supabase.co";
var supabaseKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InN3Z2VtaXZtZ3ZpYmdocm5hcm92Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3Mzk4NzU0NjksImV4cCI6MjA1NTQ1MTQ2OX0.UKecbhqzrUqaZ8f_-PC_HD75-5WGLpuGVMzmv4gdnxc";

var options = new SupabaseOptions { AutoConnectRealtime = true };
var supabaseClient = new Supabase.Client(supabaseUrl, supabaseKey, options);

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.AddSingleton(supabaseClient);
builder.Services.AddScoped<AuthService>();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddMudServices();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<DatabaseController>();
builder.Services.AddScoped<SupabaseController>();
builder.Services.AddScoped<UserStateManager>();
builder.Services.AddSingleton<WeatherDataService>();
builder.Services.AddHttpClient();
builder.Services.AddMudBlazorSnackbar();
builder.Services.AddSingleton<PersonalInfoService>();
builder.Services.AddSingleton<FavoriteCityService>();
builder.Services.AddScoped<WeatherAPIService>(); // ? Correct



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();