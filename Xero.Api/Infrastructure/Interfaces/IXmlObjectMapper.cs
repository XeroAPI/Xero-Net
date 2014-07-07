namespace Xero.Api.Infrastructure.Interfaces
{
    public interface IXmlObjectMapper
    {
        T From<T>(string result);
        string To<T>(T request);        
    }
}