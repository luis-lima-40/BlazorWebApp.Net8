namespace BlazorApp1.Models;
//remova o file scoped {} e coloque ; no final do namespace namespace BlazorApp1.Data;
public class Category
{
    public int Id { get; set; }
    public string? Description { get; set; } = string.Empty;
}

