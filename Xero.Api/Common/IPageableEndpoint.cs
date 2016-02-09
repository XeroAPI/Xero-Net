namespace Xero.Api.Common
{
    public interface IPageableEndpoint<T>
    {
        T Page(int page);
    }
}
