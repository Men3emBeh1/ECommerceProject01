using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class ProductNotFoundException(int id) : NotFoundException($"The product with id : {id} was not found!")
    {
    }
}
