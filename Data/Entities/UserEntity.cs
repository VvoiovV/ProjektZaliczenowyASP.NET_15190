using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("student")]
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(50)]
        [Required]
        public string Email { get; set; }

       

        [Column("birth_date")]
        public DateTime Birth { get; set; }

        public ICollection<OrderEntity> Enrollments { get; set; }
    }
}
