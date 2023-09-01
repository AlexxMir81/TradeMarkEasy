using TradeMarkEasy.Services;

namespace TrademarksEasy.Test
{
    public class TrademarkSeviceTests
    {
        private readonly TrademarkSevice _trademarkSevice;

        public TrademarkSeviceTests()
        {
            _trademarkSevice = new TrademarkSevice();
        }

        [Fact]
        public void New_trademark_yandex_is_registered()
        {
            //Arrange
            var trademark = "yandex";
            //Action
            var result = _trademarkSevice.TryAdd(trademark);
            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Registration_of_existed_trademark_is_rejected()
        {
            //Arrange
            var trademark = "yandex";
            _trademarkSevice.TryAdd(trademark);
            //Action
            var result = _trademarkSevice.TryAdd(trademark);
            //Assert
            Assert.False(result);
        }

        [Fact]
        public void Case_ignored()
        {
            //Arrange
            var trademark = "yandex";
            _trademarkSevice.TryAdd(trademark);
            trademark = "yaNdeX";
            //Action
            var result = _trademarkSevice.TryAdd(trademark);
            //Assert
            Assert.False(result);
        }


        [Fact]
        public void Spaces_ignoded()
        {
            //Arrange
            var trademark = "Trade Mark";
            _trademarkSevice.TryAdd(trademark);
            trademark = "Trade  Mark";
            //Action
            var result = _trademarkSevice.TryAdd(trademark);
            //Assert
            Assert.False(result);
        }
    }
}