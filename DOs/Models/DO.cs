using System.ComponentModel.DataAnnotations;

public class DO
{
    public int Id {get; set;}
    [MaxLength(20)]
    public string Title {get; set;}
    [MaxLength(100)]
    public string Description {get; set;}
    public bool Done {get; set;}
    public DateTime DueDate {get; set;}
}