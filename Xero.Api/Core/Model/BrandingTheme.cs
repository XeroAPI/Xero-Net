using System;
using System.Runtime.Serialization;

namespace Xero.Api.Core.Model
{
    [DataContract(Namespace = "")]
    public class BrandingTheme
    {
        [DataMember(Name = "BrandingThemeID")]
        public Guid BrandingThemeId { get; set; }

        [DataMember(Name = "CreatedDateUTC")]
        public DateTime CreatedDateUtc { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int SortOrder { get; set; }
    }
}