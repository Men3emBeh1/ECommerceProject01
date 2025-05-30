using Domain.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IProductService
    {
        Task<PaginatedResponse<ProductResultDto>> GetAllProductsAsync(ProductSpecificationParameters productSpecificationParameters);
        Task<ProductResultDto>? GetProductByIdAsync(int id);
        Task<IEnumerable<BrandResultDto>> GetAllBrandsAsync();
        Task<IEnumerable<TypeResultDto>> GetAllTypesAsync();

    }
}
