using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;  // ✅ Nazwa produktu
        public decimal Price { get; set; }  // ✅ Cena kursu
        public string Description { get; set; } = string.Empty;  // ✅ Opis kursu
    }
}
