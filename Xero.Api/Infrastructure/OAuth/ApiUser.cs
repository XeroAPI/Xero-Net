using Xero.Api.Infrastructure.Interfaces;

namespace Xero.Api.Infrastructure.OAuth
{
    public class ApiUser : IUser
    {
        public string Name { get; set; }
        public string OrganisationId { get; set; }
    }
}