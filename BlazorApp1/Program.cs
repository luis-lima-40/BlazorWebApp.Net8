using BlazorApp1.Components;
using BlazorApp1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// apos sua string de conexao estiver criada conforme acima, va para o program.cs para configirar
// aqui vamos adicionar um servico de contexto que ira inicializar na nossa aplicacao builder.Services.AddDbContext
// vc vai informar qual e o tipo de contexto que no caso e o AppDbContext, na sequencia passe as configuracoes que criamos no contexto
// aqui sera a nossa classe base e dentro do colchetes vc vai criar uma funcao lambda que pode chamar o de 'options'
// vc vai passar para a funcao lambda o UseSqLite, e ele pede uma configuracao que e a string de conexao, que nos criamos dentro do arquivo Appsettings.json com o nome de 'Default'
// se vc tiver varias strings de conexao 2 ou mais banco de dados, crie suas variaveis de string de conecao e passe o parametro para o UseSqLite
// builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlite(builder.Configuration.GetConnectionString("Default")));

var connectionStr = builder.Configuration.GetConnectionString("Default");  //builder.Configuration.GetConnectionString pega a string de conecao que vc criou dentro do seu appsettings.json
builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlite(connectionStr));

builder.Services.AddQuickGridEntityFrameworkAdapter();

//builder.Services.AddDbContext<AppDbContext>(x => x.UseInMemoryDatabase(databaseName: "app"));


// Agora na pasta Components, clique com botão direito do mouse, add, New Scaffolded Item, 
// selecione Razor Component / Razor Components using Entity Framework (Crud)


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
