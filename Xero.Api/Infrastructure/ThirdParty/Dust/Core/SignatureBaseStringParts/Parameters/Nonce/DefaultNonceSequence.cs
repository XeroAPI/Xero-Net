using System;

namespace Xero.Api.Infrastructure.ThirdParty.Dust.Core.SignatureBaseStringParts.Parameters.Nonce {
	public class DefaultNonceSequence : NonceSequence {
		public string Next() {
			return Guid.NewGuid().ToString();
		}
	}
}