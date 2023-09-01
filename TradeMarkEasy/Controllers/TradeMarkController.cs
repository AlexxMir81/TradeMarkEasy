using Microsoft.AspNetCore.Mvc;
using TradeMarkEasy.Services;

namespace TradeMarkEasy.Controllers
{
    
    [Route("trademark")]
    public class TradeMarkController : ControllerBase
    {
        private readonly TrademarkSevice _trademarkSevice;
        public TradeMarkController(TrademarkSevice trademarkSevice)
        {
            _trademarkSevice = trademarkSevice?? throw new ArgumentNullException(nameof(trademarkSevice));
        }

        [HttpGet("register")]
        public ActionResult<string> Register(string trademark)
        {
            if (_trademarkSevice.TryAdd(trademark))
            {
                return Ok("ТМ Зарегистрирована");
            }else
            return BadRequest("Такая торговая марка зарегистрирована!");
        }
    }
}
