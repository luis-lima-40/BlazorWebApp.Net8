using BlazorApp1.Components;
using BlazorApp1.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// apos sua string de conexão estiver criada conforme acima, va para o program.cs para configirar
// aqui vamos adicionar um serviço de contexto que irár inicializar na nossa aplicação builder.Services.AddDbContext
// vc vai informar qual é o tipo de contexto que no caso é o AppDbContext, na sequencia passe as configurações que criamos no contexto
// aqui será a nossa classe base e dentro do colchetes vc vai criar uma funão labda que pode chamar o de options
//vc vai passar para a função labda o UseSqLite, e ele pede uma configuração que é a string de conexão, que nos criamos dentro do arquivo Appsettings.json com o nome de Default
// se vc tiver varias strings de conexão 2 ou mais banco de dados, crie suas variaveis de string de coneção e passe o parâmetro para o UseSqLite

var connectionStr = builder.Configuration.GetConnectionString("Default");  //builder.Configuration.GetConnectionString pega a string de coneção que vc criou dentro do seu appsettings.json
builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlite(connectionStr));
//builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlite(builder.Configuration.GetConnectionString("Default")));
//builder.Services.AddDbContext<AppDbContext>(x => x.UseInMemoryDatabase(databaseName: "app"));

// Agora vamos criar os migrations, cada modificação no banco o migrations irá refletir a alteração ou criação no banco de dados, ele cria uma linha do tempo como versões do seu banco de dados, em cada versão uma alteração que vc criou


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
