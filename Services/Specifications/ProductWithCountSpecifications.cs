using Domain.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    public class ProductWithCountSpecifications : BaseSpecififcations<Product, int>
    {
        public ProductWithCountSpecifications(ProductSpecificationParameters productSpecificationParameters) : base
            (
            P => (string.IsNullOrEmpty(productSpecificationParameters.Search) || P.Name.ToLower().Contains(productSpecificationParameters.Search.ToLower()))
                        && (!productSpecificationParameters.BrandId.HasValue || P.BrandId == productSpecificationParameters.BrandId)
                        && (!productSpecificationParameters.TypeId.HasValue || P.TypeId == productSpecificationParameters.TypeId)
            )
        {
            
        }
    }
}
