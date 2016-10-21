using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xero.Api.Core.Model;

namespace Xero.Api.Core
{
    partial interface IXeroCoreApi
    {
        Task<Organisation> GetOrganisationAsync();
    }
}
