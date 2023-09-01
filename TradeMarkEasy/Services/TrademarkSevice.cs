namespace TradeMarkEasy.Services
{
    public class TrademarkSevice
    {
        private List<string> _trademarks = new();
        public TrademarkSevice()
        {
            _trademarks = new List<string>();
        }
        public bool TryAdd(string trademark)
        {
            if (trademark is null)
            {
                throw new ArgumentNullException(nameof(trademark));
            }
            var normalizedTrademark = NormalizedTrademark(trademark);
            if (_trademarks.Contains(normalizedTrademark)) return false;
            _trademarks.Add(normalizedTrademark);
            return true;
        }

        private string NormalizedTrademark(string trademark)
        {
            var result = trademark
                .ToLower()
                .Replace(" ", "");
            return result;
        }
    }
}
