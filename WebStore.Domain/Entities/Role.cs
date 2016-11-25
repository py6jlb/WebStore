using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Domain.Entities
{
    [Table("Roles")]
    public class Role
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(250)]
        [Index("IX_Role_Name", IsUnique = true, Order = 1)]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
