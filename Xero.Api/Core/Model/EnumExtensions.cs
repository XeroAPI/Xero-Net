using System;
using System.Runtime.Serialization;

namespace Xero.Api.Core.Model
{
    public static class EnumExtensions
    {
        public static string GetEnumMemberValue(this Enum value)
        {
            var type = value.GetType();
            var memInfo = type.GetMember(value.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(EnumMemberAttribute), false);
            return (attributes.Length > 0) ? ((EnumMemberAttribute)attributes[0]).Value : value.ToString("");
        }

    }
}
