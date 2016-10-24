using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Xero.Api.Common;
using Xero.Api.Core.Model;
using Xero.Api.Infrastructure.Http;

namespace Xero.Api.Core.Endpoints
{
    public partial class AllocationsEndpoint
    {
        public Task<Allocation> AddAsync(Allocation allocation, CancellationToken cancellation = default(CancellationToken))
        {
            var endpoint = string.Format("/api.xro/2.0/CreditNotes/{0}/Allocations", allocation.CreditNote.Id);

            return AddAsync(allocation, endpoint, cancellation);
        }

        public Task<CreditNoteAllocation> AddAsync(CreditNoteAllocation allocation, CancellationToken cancellation = default(CancellationToken))
        {
            var endpoint = string.Format("/api.xro/2.0/CreditNotes/{0}/Allocations", allocation.CreditNote.Id);

            return AddAsync(allocation, endpoint, cancellation);
        }

        public Task<PrepaymentAllocation> AddAsync(PrepaymentAllocation allocation, CancellationToken cancellation = default(CancellationToken))
        {
            var endpoint = string.Format("/api.xro/2.0/Prepayments/{0}/Allocations", allocation.Prepayment.Id);

            return AddAsync(allocation, endpoint, cancellation);
        }

        public Task<OverpaymentAllocation> AddAsync(OverpaymentAllocation allocation, CancellationToken cancellation = default(CancellationToken))
        {
            var endpoint = string.Format("/api.xro/2.0/Overpayments/{0}/Allocations", allocation.Overpayment.Id);

            return AddAsync(allocation, endpoint, cancellation);
        }

        public async Task<T> AddAsync<T>(T allocation, string endpoint, CancellationToken cancellation = default(CancellationToken))
            where T : AllocationBase
        {
            var allocations = HandleResponse<T>(await _client
                .Client
                .PutAsync(endpoint, _client.XmlMapper.To(new List<T> { allocation }), cancellation: cancellation))
                .Allocations;

            return allocations.FirstOrDefault();
        }
    }
}
