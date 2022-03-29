using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Lab3_example.Models;

public class Product
{
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    [Range(0, 20000)]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(7,2)")]
    public decimal? Price { get; set; } = 5.00M;

    public uint StockCount { get; set; } = 0;
}