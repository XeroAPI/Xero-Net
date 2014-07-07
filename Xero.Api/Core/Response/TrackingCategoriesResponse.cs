using System.Collections.Generic;
using Xero.Api.Common;
using Xero.Api.Core.Model;

namespace Xero.Api.Core.Response
{
    public class TrackingCategoriesResponse : XeroResponse<TrackingCategory>
    {
        public IList<TrackingCategory> TrackingCategories { get; set; }

        public override IList<TrackingCategory> Values
        {
            get { return TrackingCategories; }
        }
    }
}