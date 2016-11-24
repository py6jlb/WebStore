using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Domain.Entities
{
    [Table("Categories")]
    public class Category
    {
        public int Id { get; set; }

        public int? HeadCategoryId { get; set; }

        public string Name { get; set; }

        [ForeignKey("HeadCategoryId")]
        public virtual Category HeadCategory { get; set; }

        public virtual ICollection<Category> ChildCategories { get; set; }
    }
}
