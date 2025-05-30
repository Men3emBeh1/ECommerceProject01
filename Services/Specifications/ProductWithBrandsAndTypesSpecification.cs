using Domain.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    public class ProductWithBrandsAndTypesSpecification : BaseSpecififcations<Product, int>
    {
        public ProductWithBrandsAndTypesSpecification(int id) : base(p => p.Id == id)
        {
            ApplyInclude();
        }

        public ProductWithBrandsAndTypesSpecification(ProductSpecificationParameters productSpecificationParameters) : base
            (
                P => (string.IsNullOrEmpty(productSpecificationParameters.Search) || P.Name.ToLower().Contains(productSpecificationParameters.Search.ToLower())) 
                        &&(!productSpecificationParameters.BrandId.HasValue || P.BrandId == productSpecificationParameters.BrandId) 
                        && (!productSpecificationParameters.TypeId.HasValue || P.TypeId == productSpecificationParameters.TypeId)
            )
        {
            ApplyInclude();
            ApplySorting(productSpecificationParameters.Sort);
            ApplyPagination(productSpecificationParameters.PageIndex, productSpecificationParameters.PageSize);
        }

        private void ApplyInclude()
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
        }

        private void ApplySorting(string sort)
        {
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort.ToLower())
                {
                    case "nameasc":
                        AddOrderBy(p => p.Name);
                        break;
                    case "namedes":
                        AddOrderByDescending(p => p.Name);
                        break;
                    case "priceasc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "pricedes":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }
            else
            {
                AddOrderBy(p => p.Name);
            }
        }
    }
}
