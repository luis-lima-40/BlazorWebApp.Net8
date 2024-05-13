using BlazorApp1.Components;
using BlazorApp1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// apos sua string de conex�o estiver criada conforme acima, va para o program.cs para configirar
// aqui vamos adicionar um servi�o de contexto que ir�r inicializar na nossa aplica��o builder.Services.AddDbContext
// vc vai informar qual � o tipo de contexto que no caso � o AppDbContext, na sequencia passe as configura��es que criamos no contexto
// aqui ser� a nossa classe base e dentro do colchetes vc vai criar uma fun�o labda que pode chamar o de options
//vc vai passar para a fun��o labda o UseSqLite, e ele pede uma configura��o que � a string de conex�o, que nos criamos dentro do arquivo Appsettings.json com o nome de Default
// se vc tiver varias strings de conex�o 2 ou mais banco de dados, crie suas variaveis de string de cone��o e passe o par�metro para o UseSqLite

var connectionStr = builder.Configuration.GetConnectionString("Default");  //builder.Configuration.GetConnectionString pega a string de cone��o que vc criou dentro do seu appsettings.json
builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlite(connectionStr));

builder.Services.AddQuickGridEntityFrameworkAdapter();;
//builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlite(builder.Configuration.GetConnectionString("Default")));
//builder.Services.AddDbContext<AppDbContext>(x => x.UseInMemoryDatabase(databaseName: "app"));

// Agora vamos criar os migrations, cada modifica��o no banco o migrations ir� refletir a altera��o ou cria��o no banco de dados, ele cria uma linha do tempo como vers�es do seu banco de dados, em cada vers�o uma altera��o que vc criou


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
