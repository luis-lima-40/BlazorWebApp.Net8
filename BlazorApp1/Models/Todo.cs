using BlazorApp1.Enum;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Models;


public class Todo
{
    [Key] //Atrioto Key é campo de chave primaria que será criado no banco de dados
    public int Id { get; set; }
    //[Required] //Atrioto Required é campo requerido que será criado no banco de dados, vamos definir essas validações em outro local, não aqui no model mas é possivel deixar aqui dependendo da sua arquitetura do programa
    public DateTime CreationDate { get; set; }
    public TodoPriority Priority { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public bool Done { get; set; }
    public DateTime? DoneDate { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}
