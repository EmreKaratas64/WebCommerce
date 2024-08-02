using WebCommerce.Discount.Dtos;

namespace WebCommerce.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponsAsync();

        Task<GetByIdDiscountCouponDto> GetDiscountCouponByIdAsync(int id);

        Task CreateDiscountCouponAsync(CreateDiscountCouponDto createDiscountCouponDto);

        Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateDiscountCouponDto);

        Task DeleteDiscountCouponAsync(int id);
    }
}
