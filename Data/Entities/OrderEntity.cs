using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }  
        public string UserId { get; set; } = string.Empty;  
        public DateTime OrderDate { get; set; } 
        public bool IsPaid { get; set; }  

        public ProductEntity? Product { get; set; }
    }
}
