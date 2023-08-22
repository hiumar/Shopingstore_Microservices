using AutoMapper;
using Mano.Services.Coupan.Data;
using Mano.Services.Coupan.Model;
using Mano.Services.Coupan.Model.DTO;
using Microsoft.AspNetCore.Mvc;


namespace Mano.Services.Coupan.Controllers
{
    [Route("api/coupon")]
    [ApiController]

    public class CouponController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private ResponseDTO _responseDTO;
        private readonly IMapper _mapper;
        public CouponController(AppDbContext appDbContext,IMapper mapper)
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
