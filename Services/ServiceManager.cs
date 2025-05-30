using AutoMapper;
using Domain.Contracts;
using Persistence;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager(IUnitOfWork _unitOfWork, IMapper _mapper) : IserviceManager
    {
        public IProductService ProductService { get; } = new ProductService(_unitOfWork, _mapper);
    }
}
