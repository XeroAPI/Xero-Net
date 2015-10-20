using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xero.Api.Infrastructure.RateLimiter
{
    public interface IRateLimiter
    {
        void WaitUntilLimit();

        bool CheckLimit();
    }
}
