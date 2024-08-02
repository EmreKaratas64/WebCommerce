using Dapper;
using Microsoft.EntityFrameworkCore;
using WebCommerce.Discount.Context;
using WebCommerce.Discount.Dtos;

namespace WebCommerce.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _dapperContext;

        public DiscountService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateCouponAsync(CreateDiscountCouponDto createDiscountCouponDto)
        {
            var query = "insert into Coupons (Code,Rate,IsActive,ValidDate) values(@code,@rate,@isactive,@validdata)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createDiscountCouponDto.Code);
            parameters.Add("@rate", createDiscountCouponDto.Rate);
            parameters.Add("@isactive", createDiscountCouponDto.IsActive);
            parameters.Add("@validdata", createDiscountCouponDto.ValidDate);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteCouponAsync(int id)
        {
            var query = "Delete From Coupons where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllCouponsAsync()
        {
            var query = "Select * from Coupons";
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultDiscountCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task<ResultDiscountCouponDto> GetCouponByIdAsync(int id)
        {
            var query = "Select * from Coupons where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<ResultDiscountCouponDto>(query);
                return value;
            }
        }

        public async Task UpdateCouponAsync(UpdateDiscountCouponDto updateDiscountCouponDto)
        {
            string query = "Update Coupons Set Code=@code,Rate=@rate,IsActive=@isActive,ValidDate=@validDate where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@code", updateDiscountCouponDto.Code);
            parameters.Add("@rate", updateDiscountCouponDto.Rate);
            parameters.Add("@isActive", updateDiscountCouponDto.IsActive);
            parameters.Add("@validDate", updateDiscountCouponDto.ValidDate);
            parameters.Add("@couponId", updateDiscountCouponDto.CouponId);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
