using System.Text.Json.Serialization;

namespace BlazorApp1.Enum;



[JsonConverter(typeof(JsonStringEnumConverter))]
//para que vc transforme um enum em uma string, uma linha antes do public enum  use [JsonConverter(typeof(JsonStringEnumConverter))], faça a importação do using System.Text.Json.Serialization;

public enum TodoPriority
{
    Urgent,
    Important,
    Casual,
}

