using BlazorApp1.Models;
using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace BlazorApp1.Data;
//remova o file scoped {} e coloque ; no final do namespace namespace BlazorApp1.Data;



//public class AppDbContext : DbContext //herde do DcContext do EntityFramework
public class AppDbContext : DbContext
{
    //nesta classe de AppDbContext ou "qualquernomeContext.cs", vc vai configurar o seu contexto de coneção com banco de dados
    //para esta classe instalei no nuget o Microsoft.EntityFrameworkCore.Sqlite
    // crie um construtor ctor AppDbContext
    //O tipo do parametro será sempre DbContextOptions
    //Dentro do maior menor<>, coloque o mesmo nome da classe AppDbContext ou "qualquernomeContext.cs <AppDbContext> 
    // apos o <> coloque options e depois passe para a classe base :base e passe como parametro o options 
    //  este será um padrão que não muda e é o basico de um contexto
    // no contexto vc precisa dizer quais são as tabelas que vc vai criar no banco de dados, qual o nome que vc vai dar no banco, vc pode fazer as validações dos atributos da classe etc
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    // crie um DbSet da classe  Todo, de um nome Todos e um também para a classe Category com nome Categories
    // é comum e é padrão o model ficar no plural no banco de dados, então a classe Todo, ficará no banco como Todos
    // este comando DbSet vai criar esta tabela no banco de dados

    //public DbSet<Todo> Todos => Set<Todo>();
    //public DbSet<Category> Categories => Set<Category>();
    public DbSet<Todo> Todos { get; set; } = default!;

    public DbSet<Category> Categories { get; set; } = default!;

    // Override: é onde vamos criar as validações e será um pre-requisito para criar as tabelas
    // crie um Override do OnModelCreating e de um tab para criar a estrutura dele
    // no modelBuilder vamos trabalhar no modo Fluente API
    // se vc colocar o modelBuilder.Entity<e passar no nome da sua classe>(). 'a cada ponto '.'
    // vc coloca Property e cria uma regra para cada coluna da sua tabela '
    // crie uma função labda para cada property e acesse cada uma das suas propriedades e determine se é requerida, se é nulavel etc
    //modelBuilder.Entity<Todo>().Property(e => e.Title).IsRequired();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>().Property(e => e.Priority).HasConversion(typeof(string));
        modelBuilder.Entity<Category>().HasData
        (
            new Category { Id = 1, Description = "Trabalho" },
            new Category { Id = 2, Description = "Pessoal" },
            new Category { Id = 3, Description = "Outra" }
        );
    }
    //    modelBuilder.Entity<Todo>().Property(e => e.Description).IsRequired();
    //
    //    modelBuilder.Entity<Category>().Property(e => e.Description).IsRequired();
    //
    //    //Vc pode criar um crud com uma tela front End para incluir excrir alter e deletar dados na tabela ou se for almo
    //    //mais simples vc pode ja inicialiar seu banco com dados da forma que vamos exemplicicar aqui logo abaixo
    //
    //    //HasData recebe um array do mesmo tipo de dados, ou seja vai criar uma coleção de dados do tipo categoria
    //    // esses objetos vão ser incluidos no banco de dados quando a tabela for criada
    //    //modelBuilder.Entity<Category>().HasData
    //    //(
    //    //    new Category { Id = 1, Description = "Trabalho" },
    //    //    new Category { Id = 2, Description = "Pessoal" },
    //    //    new Category { Id = 3, Description = "Outra" }
    //    //);
    //
    //
    //    //ainda falando em contexto, vc precisa confirurar os arquivos appsettings.json e appsettings.Development.json
    //    //appsettings.json é o que vai para produção
    //    //appsettings.Development.json é o que vai ficar no servidor de desenvolviemtno
    //    //dentro desse arquivo é onde vai ficar a sua string de coneção "ConnectionStrings" adicione esta linha nestes arquivos

}








//public class AppDbContext : DbContext //herde do DcContext do EntityFramework
//{
//    //Crie um construtor ctor tab tab e herde de base() e passe dentro do AppDbContext (DbContextOptions options)
//    //e para o Base(options)
//    public AppDbContext(DbContextOptions options) : base(options) 
//    {
//            
//    }
//
//    //crie um DbSet da classe  Category, de um nome, e atribua como inicialização = Null!;  pois NÃO queremos receber NULLO
//    public DbSet<Category> Categories { get; set; } = null!;
//
//}

