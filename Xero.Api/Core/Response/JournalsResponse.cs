using System.Collections.Generic;
using Xero.Api.Common;
using Xero.Api.Core.Model;

namespace Xero.Api.Core.Response
{
    public class JournalsResponse : XeroResponse<Journal> 
    {
        public IList<Journal> Journals { get; set; }

        public override IList<Journal> Values
        {
            get { return Journals; }
        }
    }
}