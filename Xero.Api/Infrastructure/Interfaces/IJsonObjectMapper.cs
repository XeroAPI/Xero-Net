namespace Xero.Api.Infrastructure.Interfaces
{
    public interface IJsonObjectMapper
    {
        T From<T>(string result);
        string To<T>(T request);        
    }
}