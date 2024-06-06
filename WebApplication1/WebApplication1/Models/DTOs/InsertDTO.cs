using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTOs;

public class InsertDTO
{
    [MaxLength(100)]
    public string ProductName { get; set; }

    public double ProductWeight { get; set; }
    public double ProductWidth { get; set; }
    public double ProductHeight { get; set; }
    public double ProductDepth { get; set; }

    public List<int> ProductCategories { get; set; }

}