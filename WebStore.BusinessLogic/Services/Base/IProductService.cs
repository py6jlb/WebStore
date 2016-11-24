using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.BusinessLogic.DTO.Product;

namespace WebStore.BusinessLogic.Services.Base
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetProducts();
    }
}