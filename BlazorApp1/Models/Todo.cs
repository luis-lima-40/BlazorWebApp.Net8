using BlazorApp1.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Models;


public class Todo
{
    //Atrioto Key é campo de chave primaria que será criado no banco de dados
    [Key]
    [DisplayName("Id")]
    public int Id { get; set; }

    //[Required] //Atrioto Required é campo requerido que será criado no banco de dados, vamos definir essas validações em outro local, não aqui no model mas é possivel deixar aqui dependendo da sua arquitetura do programa
    [DisplayName("Creation Date")]
    public DateTime CreationDate { get; set; } = DateTime.Now;
    //public TodoPriority Priority { get; set; }

    //public int Priority { get; set; }
    [DisplayName("Priority")]
    public string Priority { get; set; } = "Casual"; 
    //public TodoPriority Priority { get; set; } = TodoPriority.Casual; //ver como converter enum em string para evoluir este codig

    [Required(ErrorMessage = "Informe o Titulo")]
    [StringLength(50, ErrorMessage = "O Titulo deve ter no máximo 50 caracteres")]
    [MinLength(3, ErrorMessage = "O Titulo deve conter pelo menos 3 caracteres")]
    [DisplayName("Title")]
    public string? Title { get; set; }
    
    [StringLength(250, ErrorMessage = "Os Detalhes deve ter no máximo 250 caracteres")]
    [MinLength(3, ErrorMessage = "Os Detalhes deve conter pelo menos 3 caracteres")]
    [DisplayName("Details")]
    public string? Details { get; set; } //Antes estava como Description

    [DisplayName("Done")]
    public bool Done { get; set; }

    [DisplayName("Done Date")]
    public DateTime? DoneDate { get; set; } = null;


    [DisplayName("Category")]
    public int CategoryId { get; set; }
    //[Required(ErrorMessage = "Categoria Inválida")] por enquando não está associando, verificar erro

    public Category? Category { get; set; }
}
