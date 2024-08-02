using WebCommerce.Discount.Dtos;

namespace WebCommerce.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultDiscountCouponDto>> GetAllCouponsAsync();

        Task<ResultDiscountCouponDto> GetCouponByIdAsync(int id);

        Task CreateCouponAsync(CreateDiscountCouponDto createDiscountCouponDto);

        Task UpdateCouponAsync(UpdateDiscountCouponDto updateDiscountCouponDto);

        Task DeleteCouponAsync(int id);
    }
}
