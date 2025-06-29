﻿using Domain.Contracts;
using Domain.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class BasketRepository(IConnectionMultiplexer connection) : IBasketRepository
    {
        private readonly IDatabase _database = connection.GetDatabase();
        public async Task<CustomerBasket> GetBasketAsync(string id)
        {
            var redisValue = await _database.StringGetAsync(id);
            if (redisValue.IsNullOrEmpty)
            {
                return null;
            }
            var basket = JsonSerializer.Deserialize<CustomerBasket>(redisValue);
            if (basket is null)
            {
                return null;
            }
            return basket;
        }
        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket, TimeSpan? timeSpan = null)
        {
            var redisValue = JsonSerializer.Serialize(basket);
            var flag = await _database.StringSetAsync(basket.Id, redisValue, timeSpan ?? TimeSpan.FromDays(30));
            if (!flag)
            {
                return null;
            }
            return await GetBasketAsync(basket.Id);
        }

        public async Task<bool> DeleteBasketAsync(string id)
        {
            return await _database.KeyDeleteAsync(id);
        }

        
    }
}
