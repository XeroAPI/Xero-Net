using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Xero.Api.Core.Model
{
    [CollectionDataContract(Namespace = "", Name = "Tracking")]
    public class ItemTracking : List<ItemTrackingCategory>
    {        
    }
}