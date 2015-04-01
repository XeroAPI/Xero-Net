using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Xero.Api.Common;
using Xero.Api.Core.Model;

namespace Xero.Api.Core.Request
{
    [CollectionDataContract(Namespace = "", Name = "TrackingCategories")]
    public class TrackingCategoriesRequest : XeroRequest<TrackingCategory>
    {
    }   
}
