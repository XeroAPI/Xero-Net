using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xero.Api.Core.Model;

namespace Xero.Api.Core
{
    public partial class XeroCoreApi
    {
        public async Task<Organisation> GetOrganisationAsync()
        {
            return (await OrganisationEndpoint.FindAsync()).FirstOrDefault();
        }
    }
}
