using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xero.Api.Infrastructure.RateLimiter
{
    interface IRateLimiter
    {
        void WaitUntilLimit();

        bool CheckLimit();
    }
}
