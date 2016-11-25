using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WebStore.BusinessLogic.DTO.Product;
using WebStore.BusinessLogic.Services.Base;
using WebStore.DataAccess.Repositories.Base;
using WebStore.BusinessLogic.DTO.Category;
using WebStore.Domain.Entities;

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

        public IEnumerable<ProductForIndexView> GetProducts()
        {
            return _productRepository.GetProducts().Select(_mapper.Map<ProductForIndexView>).ToArray();
        }

        public void DelProduct(int id)
        {
            var prod = _productRepository.GetProducts(x => x.Id == id).FirstOrDefault();
            _productRepository.DelProducts(prod);
        }

        public ProductDTO GetProduct(int id)
        {
            return _productRepository.GetProducts(x => x.Id == id).Select(_mapper.Map<ProductDTO>).FirstOrDefault();
        }

        public IEnumerable<CategoryForDropDownList> GetCategories()
        {
            return _productRepository.GetCategoryes().Select(_mapper.Map<CategoryForDropDownList>).ToArray();
        }

        public void UpdateProduct(ProductDTO editedProduct)
        {
            Product tmp = _mapper.Map<ProductDTO, Product>(editedProduct);
            tmp.CategoryId = _productRepository.GetCategoryes().FirstOrDefault(x => x.Name == editedProduct.CategoryName).Id;
            _productRepository.UpdateProduct(tmp);

        }

        public void AddProduct(ProductDTO product)
        {
            Product tmp = _mapper.Map<ProductDTO, Product>(product);
            tmp.CategoryId = _productRepository.GetCategoryes().FirstOrDefault(x => x.Name == product.CategoryName).Id;
            _productRepository.AddProduct(tmp);
        }
    }
}
