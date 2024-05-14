using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BlazorApp1.Models;
//remova o file scoped {} e coloque ; no final do namespace namespace BlazorApp1.Data;
public class Category
{
    [Key]
    [DisplayName("Id")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe a Descrição")]
    [StringLength(50, ErrorMessage = "A Descrição deve ter no máximo 50 caracteres")]
    [MinLength(3, ErrorMessage = "A Descrição deve conter pelo menos 3 caracteres")]
    [DisplayName("Description")]
    public string Description { get; set; } = string.Empty;

    public List<Todo> Todo { get; set; } = new();

}



