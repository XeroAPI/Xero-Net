using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using HttpUtility = Xero.Api.Infrastructure.ThirdParty.HttpUtility.HttpUtility;

namespace Xero.Api.Infrastructure.ThirdParty.Dust.Core.SignatureBaseStringParts.Parameters
{
    internal class RequestParameters : IEnumerable<Parameter>
    {
        private readonly NameValueCollection _values;
    	private readonly Parameters _parameters;

    	public RequestParameters(Request request)
        {
            _values = HttpUtility.HttpUtility.ParseQueryString(request.Url.Query);

        	_parameters = new Parameters(MapAll());
        }

    	private Parameter[] MapAll() {
    		return _values.AllKeys.SelectMany(Map).ToArray();
    	}

    	private IEnumerable<Parameter> Map(string key)
        {
    		return ValueFor(key).Split(',').Select(v => new Parameter(key, v));
        }

    	private string ValueFor(string key) {
    		return _values[key];
    	}

    	#region Implementation of IEnumerable

    	IEnumerator IEnumerable.GetEnumerator() {
    		return GetEnumerator();
    	}

    	public IEnumerator<Parameter> GetEnumerator() {
    		return _parameters.GetEnumerator();
    	}

    	#endregion

    	internal void Add(Parameters what) {
    		_parameters.Add(what);
    	}

		public override string ToString() {
			return _parameters.ToString();
		}
    }
}