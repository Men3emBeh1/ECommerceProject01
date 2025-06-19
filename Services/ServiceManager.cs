using AutoMapper;
using Domain.Contracts;
using Persistence;
using Persistence.Repositories;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StackExchange.Redis.Role;

namespace Services
{
    public class ServiceManager(IUnitOfWork _unitOfWork, IMapper _mapper, IBasketRepository basketRepository, ICacheRepository cacheRepository) : IserviceManager
    {
        public IProductService ProductService { get; } = new ProductService(_unitOfWork, _mapper);

        public IBasketService BasketService { get; } = new BasketService(basketRepository, _mapper);
        public ICacheService CacheService { get; } = new CacheService(cacheRepository);
    }
}
