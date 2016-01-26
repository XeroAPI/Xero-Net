using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xero.Api.Common
{
    public interface IPageableEndpoint<T> //where T : IXeroReadEndpoint<>
    {
        T Page(int page);
    }
}
