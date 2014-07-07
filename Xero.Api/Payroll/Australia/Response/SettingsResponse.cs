using System.Collections.Generic;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Payroll.Australia.Model;

namespace Xero.Api.Payroll.Australia.Response
{
    public class SettingsResponse : IXeroResponse<Settings>
    {
        public Settings Settings { get; private set; }
        
        public IList<Settings> Values { get { return new[] { Settings }; } }
    }
}
