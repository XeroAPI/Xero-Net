using System;
using Xero.Api.Infrastructure.ThirdParty.Dust.Core.SignatureBaseStringParts.Parameters;

namespace Xero.Api.Infrastructure.ThirdParty.Dust.Core.SignatureBaseStringParts.Earl {
	internal class EarlPart {
		private readonly Uri _uri;

		internal EarlPart(Uri uri) {
			_uri = uri;
		}

		internal string Value {
			get {
				return Escape(string.Format("{0}://{1}{2}", _uri.Scheme, Authority, Path()));
			}
		}

		private string Path() {
			return _uri.AbsolutePath.TrimEnd('/');
		}

		private string Escape(string what) {
			return new ParameterEncoding().Escape(what);
		}

		private string Authority {
			get {
				if (_uri.Port == 80 || _uri.Port == 443)
					return _uri.Host;

				return _uri.Authority;
			}
		}
	}
}