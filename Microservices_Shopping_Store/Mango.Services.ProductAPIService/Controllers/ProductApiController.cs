using AutoMapper;
using Mango.Services.ProductAPIService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Mano.Services.ProductAPIService.Controllers
{
    [Route("api/coupon")]
    [ApiController]
    [Authorize]
    public class ProductApiController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private ResponseDTo _responseDTO;
        private readonly IMapper _mapper;
        public ProductApiController(AppDbContext appDbContext,IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
            _responseDTO = new ResponseDTO();
        }

        [HttpGet]

        public ResponseDTO Get()
        {
            try
            {
                IEnumerable<Coupon> coupons = _appDbContext.coupans.ToList();
                _responseDTO.Result =_mapper.Map<IEnumerable<CouponDTO>>(coupons);

                return _responseDTO;

            }
            catch (Exception ex)
            {
                _responseDTO.Success = false;
                _responseDTO.Message = ex.Message;
                return _responseDTO;
            }

        }

        [HttpGet]
        [Route("{id:int}")]

        public ResponseDTO Get(int id)
        {
            try
            {
                Coupon coupons = _appDbContext.coupans.Where(x=>x.CoupanId == id).FirstOrDefault() ?? null;
                _responseDTO.Result = _mapper.Map<CouponDTO>(coupons);
                

                return _responseDTO;

            }
            catch (Exception ex)
            {

                _responseDTO.Success = false;
                _responseDTO.Message = ex.Message;
                return _responseDTO;
            }

        }

        [HttpGet]
        [Route("getByCode/{code}")]

        public ResponseDTO GetByCode(string code)
        {
            try
            {
                Coupon coupons = _appDbContext.coupans.Where(x => x.CoupanCode.ToLower() == code.ToLower()).FirstOrDefault() ?? null;
                _responseDTO.Result = _mapper.Map<CouponDTO>(coupons);


                return _responseDTO;

            }
            catch (Exception ex)
            {

                _responseDTO.Success = false;
                _responseDTO.Message = ex.Message;
                return _responseDTO;
            }

        }


        [HttpPost]
        [Authorize(Roles ="ADMIN")]

        public ResponseDTO Post([FromBody] CouponDTO couponDTO)
        {
            try
            {
                Coupon coupan=_mapper.Map<Coupon>(couponDTO);
                _appDbContext.Add(coupan);
                _appDbContext.SaveChanges();
               
                return _responseDTO;

            }
            catch (Exception ex)
            {

                _responseDTO.Success = false;
                _responseDTO.Message = ex.Message;
                return _responseDTO;
            }

        }


        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public ResponseDTO Update([FromBody] CouponDTO couponDTO)
        {
            try
            {
                Coupon coupan = _mapper.Map<Coupon>(couponDTO);
                _appDbContext.Update(coupan);
                _appDbContext.SaveChanges();




                return _responseDTO;

            }
            catch (Exception ex)
            {

                _responseDTO.Success = false;
                _responseDTO.Message = ex.Message;
                return _responseDTO;
            }

        }


        [HttpDelete]
        [Route("{id:int}")]

        public ResponseDTO Delete(int id)
        {
            try
            {
               Coupon coupon= _appDbContext.coupans.First(x => x.CoupanId == id);
                _appDbContext.Remove(coupon);
                _appDbContext.SaveChanges();




                return _responseDTO;

            }
            catch (Exception ex)
            {

                _responseDTO.Success = false;
                _responseDTO.Message = ex.Message;
                return _responseDTO;
            }

        }
    }
}
