using System.Linq;
using Xero.Api.Infrastructure.ThirdParty.Dust.Core.SignatureBaseStringParts.Parameters;

namespace Xero.Api.Infrastructure.ThirdParty.Dust.Http {
	public class AuthorizationHeader {
		private readonly OAuthParameters _oAuthParameters;
		private readonly string _realm;

		public AuthorizationHeader(OAuthParameters oAuthParameters, string realm) {
			_oAuthParameters = oAuthParameters;
			_realm = realm;
		}

		public string Value {
			get { return Prefix + Parameters; }
		}

		protected string Parameters {
			get {
				return Join(
					Realm,
					ConsumerKey,
					Token,
					SignatureMethod,
					Signature,
					Timestamp,
					Nonce,
					Version,
                    Verifier,
                    Callback
				);
			}
		}

		private string Join(params string[] bits) {
			return string.Join(", ", bits.Where(it => false == it.Equals(string.Empty)).ToArray());
		}

		private string Version {
			get { return ToString(_oAuthParameters.Version); }
		}

		private string Nonce {
			get { return ToString(_oAuthParameters.Nonce); }
		}

		private string Timestamp {
			get { return ToString(_oAuthParameters.Timestamp); }
		}

		private string Signature {
			get { return ToString(_oAuthParameters.Signature); }
		}

        private string Callback
        {
            get { return ToString(_oAuthParameters.Callback); }
        }

		private string SignatureMethod {
			get { return ToString(_oAuthParameters.SignatureMethod); }
		}

		private string Token {
			get { return HasToken ? ToString(_oAuthParameters.Token) : string.Empty; }
		}

        private string Verifier
        {
            get { return HasVerifier ? ToString(_oAuthParameters.Verifier) : string.Empty; }
        }

	    private string ConsumerKey {
			get { return ToString(_oAuthParameters.ConsumerKey); }
		}

		private string Realm {
			get {
				return HasRealm ? string.Format("realm=\"{0}\"", _realm) : string.Empty; 
			}
		}

        public bool HasVerifier
        {
            get
            {
                return !string.IsNullOrWhiteSpace(_oAuthParameters.Verifier.Value);
            }
        }

	    public bool HasToken {
	        get {
	            return !string.IsNullOrWhiteSpace(_oAuthParameters.Token.Value);
	        }
	    }
	    
		private bool HasRealm {
			get { return !string.IsNullOrWhiteSpace(_realm); }
		}

		private string ToString(Parameter parameter) {
            if (string.IsNullOrWhiteSpace(parameter.Value)) return string.Empty;
			return string.Format(
				"{0}=\"{1}\"", 
				parameter.Name, 
				Escape(parameter.Value)
			);
		}

		private string Escape(string value) {
			return new ParameterEncoding().Escape(value);
		}

		private string Prefix {
			get { return "OAuth "; }
		}
	}
}