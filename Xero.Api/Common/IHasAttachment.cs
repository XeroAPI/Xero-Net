using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xero.Api.Common
{
    public interface IHasAttachment
    {
        bool? HasAttachments { get; set; }
    }
}
