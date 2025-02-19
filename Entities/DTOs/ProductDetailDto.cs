using Core.Entities;

namespace Entities.DTOs;

// bu DTO Sınıfları, DB tablosu olmayan, ilişkili tablolalardaki verileri döndürecek nesnelerdir  
// Core Katmanındaki Entities IDto interface inden implemente olur
public class ProductDetailDto : IDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string CategoryName { get; set; }
    public short UnitsInStock { get; set; }
}