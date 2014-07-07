namespace Xero.Api.Infrastructure.Interfaces
{
    public interface IAuthenticationToken
    {
        IToken Token { get; set; }
        string Signature { get; set; }
    }
}