using Shared;

namespace Services
{
    public interface IBasketService
    {
        Task<BasketDto?> GetBasketAsync(string id);
        Task<BasketDto?> UpdateBasketAsync(BasketDto basketDto);
        Task<bool> DeleteBasketAsync(string id);
    }
}