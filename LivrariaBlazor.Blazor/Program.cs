using LivrariaBlazor.CrossCutting.DependenciesApp;
using LivrariaBlazor.Infrastructure.Context;
using LivrariaBlazor.Presentation.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//Registrar Servi�os
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();
CreateDatabase(app);

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

static void CreateDatabase(WebApplication app)
{
    var serviceScope = app.Services.CreateScope();
    var dataContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
    dataContext?.Database.EnsureCreated();
}