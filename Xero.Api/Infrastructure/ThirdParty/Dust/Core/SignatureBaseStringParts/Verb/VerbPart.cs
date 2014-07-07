namespace Xero.Api.Infrastructure.ThirdParty.Dust.Core.SignatureBaseStringParts.Verb {
	internal class VerbPart {
		private readonly Request _request;

		public VerbPart(Request request) {
			_request = request;
		}

		public string Value {
			get { return _request.Verb.ToUpper(); }
		}
	}
}