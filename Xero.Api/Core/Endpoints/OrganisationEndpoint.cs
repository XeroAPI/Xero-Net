using System;
using System.Linq;
using Xero.Api.Common;
using Xero.Api.Core.Model;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public interface IOrganisationEndpoint : IXeroReadEndpoint<OrganisationEndpoint, Organisation, OrganisationResponse>
    {
        OrganisationCisSetting GetCisSettings(Guid id);
    }

    public class OrganisationEndpoint : XeroReadEndpoint<OrganisationEndpoint, Organisation, OrganisationResponse>, IOrganisationEndpoint
    {
        internal OrganisationEndpoint(XeroHttpClient client)
            : base(client, "/api.xro/2.0/Organisation")
        {
        }

        public OrganisationCisSetting GetCisSettings(Guid id)
        {
            var organisationCisSettings = Client.Get<OrganisationCisSetting, OrganisationCisSettingsResponse>(string.Format("/api.xro/2.0/organisations/{0}/cissettings", id));

            return organisationCisSettings.FirstOrDefault();
        }
    }
}