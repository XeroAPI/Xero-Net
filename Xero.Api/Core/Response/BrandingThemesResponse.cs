using System.Collections.Generic;
using Xero.Api.Common;
using Xero.Api.Core.Model;

namespace Xero.Api.Core.Response
{
    public class BrandingThemesResponse : XeroResponse<BrandingTheme>
    {
        public List<BrandingTheme> BrandingThemes { get; set; }

        public override IList<BrandingTheme> Values
        {
            get { return BrandingThemes; }
        }
    }
}
