using Microsoft.AspNetCore.Mvc;
using WebCommerce.Discount.Dtos;
using WebCommerce.Discount.Services;

namespace WebCommerce.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> CouponList()
        {
            var values = await _discountService.GetAllDiscountCouponsAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCouponById(int id)
        {
            var value = await _discountService.GetDiscountCouponByIdAsync(id);
            return Ok(value);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCoupon(int id)
        {
            await _discountService.DeleteDiscountCouponAsync(id);
            return Ok("Discount coupon is deleted!");
        }

        [HttpPost]
        public async Task<IActionResult> AddCoupon(CreateDiscountCouponDto coupon)
        {
            await _discountService.CreateDiscountCouponAsync(coupon);
            return Ok("Discount coupon is added");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCoupon(UpdateDiscountCouponDto coupon)
        {
            await _discountService.UpdateDiscountCouponAsync(coupon);
            return Ok("Discount coupon is updated");
        }
    }
}
