using System.Collections.Generic;
using Xero.Api.Common;
using Xero.Api.Core.Model;

namespace Xero.Api.Core.Response
{
    public class OptionsResponse : XeroResponse<Option>
    {
        public IList<Option> Options { get; set; }

        public override IList<Option> Values
        {
            get { return Options; }
        }
    }
}