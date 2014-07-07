using System;

namespace Xero.Api.Infrastructure.ThirdParty.Dust.Lang
{
    public static class ObjectExtensions
    {
        public static T Tap<T>(this T self, Action<T> block)
        {
            block(self);

            return self;
        }
    }
}
