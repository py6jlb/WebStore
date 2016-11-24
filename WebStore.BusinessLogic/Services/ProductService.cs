using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WebStore.BusinessLogic.DTO.Product;
using WebStore.BusinessLogic.Services.Base;
using WebStore.DataAccess.Repositories.Base;

namespace WebStore.BusinessLogic.Services
{
    public class ProductService
        : IProductService
    {
        IProductRepository _productRepository = null;
        IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            return _productRepository.GetProducts().Select(_mapper.Map<ProductDTO>).ToArray();
        }
    }
}
