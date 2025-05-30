using AutoMapper;
using Domain.Contracts;
using Domain.Models;
using Persistence;
using Services.Abstractions;
using Services.Specifications;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService(IUnitOfWork _unitOfWork, IMapper _mapper) : IProductService
    {
        public async Task<PaginatedResponse<ProductResultDto>> GetAllProductsAsync(ProductSpecificationParameters productSpecificationParameters)
        {
            var specification = new ProductWithBrandsAndTypesSpecification(productSpecificationParameters);
            var products = await _unitOfWork.GetRepository<Product, int>().GetAllAsync(specification);
            var specCount = new ProductWithCountSpecifications(productSpecificationParameters);

            var count = await _unitOfWork.GetRepository<Product, int>().CountAsync(specCount);

            var result = _mapper.Map<IEnumerable<ProductResultDto>>(products);
            return new PaginatedResponse<ProductResultDto>(productSpecificationParameters.PageIndex, productSpecificationParameters.PageSize, count, result);
        }
        public async Task<ProductResultDto?> GetProductByIdAsync(int id)
        {
            var specification = new ProductWithBrandsAndTypesSpecification(id);

            var product = await _unitOfWork.GetRepository<Product, int>().GetAsync(specification);
            if (product is null) return null;
            var result = _mapper.Map<ProductResultDto>(product);
            return result;
        }

        public async Task<IEnumerable<BrandResultDto>> GetAllBrandsAsync()
        {
            var brands = await _unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();
            var result = _mapper.Map<IEnumerable<BrandResultDto>>(brands);
            return result;
        }
        
        public async Task<IEnumerable<TypeResultDto>> GetAllTypesAsync()
        {
            var types = await _unitOfWork.GetRepository<ProductType, int>().GetAllAsync();
            var result = _mapper.Map<IEnumerable<TypeResultDto>>(types);
            return result;
        }
    }
}
