namespace Xero.Api.Infrastructure.ThirdParty.Dust
{
    public class TokenKey
    {
        private readonly string _value;

        public TokenKey(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }

        public bool Exists
        {
            get { return Value != null; }
        }
    }
}