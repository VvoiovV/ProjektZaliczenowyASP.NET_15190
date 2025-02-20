using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }  // ✅ ID kursu (produktu)
        public string UserId { get; set; } = string.Empty;  // ✅ ID użytkownika
        public DateTime OrderDate { get; set; }  // ✅ Data zamówienia
        public bool IsPaid { get; set; }  // ✅ Czy zamówienie jest opłacone?

        public ProductEntity? Product { get; set; }
    }
}
