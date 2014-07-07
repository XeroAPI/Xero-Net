using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Xero.Api.Infrastructure.Http;
using Xero.Api.Infrastructure.Interfaces;

namespace Xero.Api.Common
{
    public abstract class XeroReadEndpoint<T, TResult, TResponse>
        where T : XeroReadEndpoint<T, TResult, TResponse>
        where TResponse : IXeroResponse<TResult>, new()
    {
        private DateTime? _modifiedSince;
        private string _query;
        private string _orderBy;
        private NameValueCollection _parameters;

        protected string ApiEndpointUrl { get; private set; }
        public XeroHttpClient Client { get; private set; }

        protected bool UseFourDp { get; private set; }

        protected XeroReadEndpoint(XeroHttpClient client, string apiEndpointUrl)
        {
            Client = client;
            ApiEndpointUrl = apiEndpointUrl;
        }

        public T ModifiedSince(DateTime modified)
        {
            _modifiedSince = modified;
            return (T)this;
        }

        public T Where(string query)
        {
            _query = query;
            return (T)this;
        }

        public T Or(string query)
        {
            _query = string.Concat(_query, " OR ", query);
            return (T)this;
        }

        public T And(string query)
        {
            _query = string.Concat(_query, " AND ", query);
            return (T)this;
        }

        public T OrderBy(string query)
        {
            _orderBy = query;
            return (T)this;
        }

        public T OrderByDescending(string query)
        {
            _orderBy = query + " DESC";
            return (T)this;
        }

        public T UseFourDecimalPlaces(bool use4Dp)
        {
            UseFourDp = use4Dp;

            if (_parameters != null && !use4Dp)
            {
                _parameters.Remove("unitdp");
            }

            return (T)this;
        }

        public IEnumerable<TResult> Find()
        {
            return Get(ApiEndpointUrl, null);
        }

        public TResult Find(Guid child)
        {
            return Find(child.ToString("D"));
        }

        public TResult Find(string child)
        {
            return Get(ApiEndpointUrl, "/" + child).FirstOrDefault();
        }
        
        public virtual void ClearQueryString()
        {
            UseFourDp = false;
            _orderBy = null;
            _query = null;
            _modifiedSince = null;
            _parameters = null;
        }

        public string QueryString
        {
            get
            {
                AddFourDecimalPlaces();
                return new QueryGenerator(_query, _orderBy, _parameters).QueryString;
            }
        }

        internal protected T Parameter(string name, int value)
        {
            return Parameter(name, value.ToString("D"));
        }

        internal protected T Parameter(string name, bool value)
        {
            return Parameter(name, value.ToString().ToLower());
        }

        internal protected T Parameter(string name, string value)
        {
            if (_parameters == null)
            {
                _parameters = new NameValueCollection();
            }

            _parameters[name] = value;

            return (T)this;
        }

        internal protected T Parameters(NameValueCollection parameters)
        {
            if (_parameters == null)
            {
                _parameters = parameters;
            }
            else
            {
                _parameters.Add(parameters);
            }

            return (T)this;
        }

        private void AddFourDecimalPlaces()
        {
            if (UseFourDp)
            {
                Parameter("unitdp", 4);
            }
        }

        private IEnumerable<TResult> Get(string endpoint, string child)
        {
            try
            {
                if (_parameters == null)
                {
                    _parameters = new NameValueCollection();
                }

                AddFourDecimalPlaces();

                Client.Where = _query;
                Client.Order = _orderBy;
                Client.ModifiedSince = _modifiedSince;
                Client.Parameters = _parameters;

                return Client.Get<TResult, TResponse>(endpoint + (child ?? string.Empty));
            }
            finally
            {
                ClearQueryString();                
            }
        }
    }
}
