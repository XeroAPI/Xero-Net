namespace Xero.Api.Infrastructure.Interfaces
{
    public interface ITokenStore
    {
        IToken Find(string user);
        void Add(IToken token);
        void Delete(IToken token);
    }
}