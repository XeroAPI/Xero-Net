using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Xero.Api.Core.Model.Setup;
using Xero.Api.Infrastructure.Interfaces;

namespace Xero.Api.Core.Request
{
    [DataContract(Namespace = "", Name="Setup")]
    public class SetupRequest : IXeroRequest<Setup>
    {
        public IList<Setup> Items { get; private set; }
        
        public void Add(Setup value)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Setup> value)
        {
            throw new NotImplementedException();
        }

        public bool ContainsItems()
        {
            return Items.Any();
        }
    }
}
