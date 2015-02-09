using Xero.Api.Infrastructure.ThirdParty.Dust.Core.SignatureBaseStringParts.Parameters.Nonce;
using Xero.Api.Infrastructure.ThirdParty.Dust.Core.SignatureBaseStringParts.Parameters.Timestamp;
using Xero.Api.Infrastructure.ThirdParty.Dust.Lang;

namespace Xero.Api.Infrastructure.ThirdParty.Dust.Core.SignatureBaseStringParts.Parameters
{
	public class OAuthParameters
    {
        private readonly ConsumerKey _key;
        private readonly TokenKey _tokenKey;
        private readonly string _signatureMethod;
	    private string _signature;
    	private readonly string _version;
        private readonly string _nonce, _timestamp, _verifier, _session;
        private string _callback;

	    public static OAuthParameters Empty = new OAuthParameters(
	        new ConsumerKey(string.Empty), 
	        new TokenKey(string.Empty), 
	        string.Empty, 
	        new DefaultTimestampSequence(), 
	        new DefaultNonceSequence(), 
	        string.Empty, 
	        null,
            null
        );

	    public OAuthParameters(
			ConsumerKey key, 
			TokenKey tokenKey, 
			string signatureMethod, 
			TimestampSequence timestamps, 
			NonceSequence nonces, 
			string signature, 
			string version,
            string verifier = null,
            string session = null,
            string callback = null
		)
        {
    	    _key = key;
            _tokenKey = tokenKey;
            _signatureMethod = signatureMethod;
    	    _signature = signature;
	        _session = session;
	        _callback = callback;
	        _verifier = verifier;
	        _version = version ?? "1.0";

    	    _nonce = nonces.Next();
    	    _timestamp = timestamps.Next();
        }

	    internal Parameters List() {
    		return new Parameters(
    				ConsumerKey,
    				Version,
    				SignatureMethod,
    				Timestamp,
    				Nonce
				).Tap(it =>
                {
					if (_tokenKey.Exists)
                    {
    					it.Add(Token);
					}

                    if (!string.IsNullOrWhiteSpace(_verifier))
                    {
                        it.Add(Verifier);
                    }

                    if (!string.IsNullOrWhiteSpace(_session))
                    {
                        it.Add(Session);
                    }

                    if (!string.IsNullOrWhiteSpace(_callback))
                    {
                        it.Add(Callback);
                    }
                });
    	}

    	internal Parameter Token {
    		get { return new Parameter(Name.Token, _tokenKey.Value); }
    	}

    	internal Parameter ConsumerKey {
    		get { return new Parameter(Name.ConsumerKey, _key.Value); }
    	}

    	internal Parameter SignatureMethod {
    		get { return new Parameter(Name.SignatureMethod, _signatureMethod); }
    	}

		public void SetSignature(string what) {
			_signature = what;
		}

		internal Parameter Signature {
    		get { return new Parameter(Name.Signature, _signature); }
    	}

    	internal Parameter Timestamp {
    		get { return new Parameter(Name.Timestamp, _timestamp); }
    	}

    	internal Parameter Nonce {
    		get { return new Parameter(Name.Nonce, _nonce); }
    	}

    	internal Parameter Version {
    		get { return new Parameter(Name.Version, _version); }
    	}

        internal Parameter Verifier
        {
            get { return new Parameter(Name.Verifier, _verifier); }
        }

        internal Parameter Session
        {
            get { return new Parameter(Name.Session, _session); }
        }

        internal Parameter Callback
        {
            get { return new Parameter(Name.CallBack, _callback); }
        }
    }
}