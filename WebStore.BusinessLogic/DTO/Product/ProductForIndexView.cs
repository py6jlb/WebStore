using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.BusinessLogic.DTO.Product
{
    public class ProductForIndexView
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
