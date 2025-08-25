using GatePass.Presentation.Components;
using GatePass.Business;
using GatePass.Data;

var builder = WebApplication.CreateBuilder(args);

#region Configure Services for DI

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// project layers
builder.Services.AddBusiness();
builder.Services.AddData(builder.Configuration);

#endregion

var app = builder.Build();

#region App Pipeline

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

// project layers
app.UseBusiness();
app.UseData();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(GatePass.Presentation.Client._Imports).Assembly);

#endregion

app.Run();
