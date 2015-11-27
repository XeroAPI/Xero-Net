﻿using System;
using System.Collections.Specialized;
using System.Linq;
using HttpUtility = Xero.Api.Infrastructure.ThirdParty.HttpUtility.HttpUtility;

namespace Xero.Api.Common
{
    public class QueryGenerator
    {
        public string Where { get; private set; }
        public string Order { get; private set; }
        public NameValueCollection Parameters { get; private set; }
        
        public QueryGenerator(string where, string order, NameValueCollection parameters)
        {
            Where = where;
            Order = order;
            Parameters = parameters;            
        }

        public string QueryString
        {
            get
            {
                var collection = BuildCollection();
                return String.Join("&", collection.AllKeys.Select(a => a + "=" + collection[a]).ToArray());
            }
        }

        public string UrlEncodedQueryString
        {
            get
            {
                var collection = BuildCollection();
                return String.Join("&", collection.AllKeys.Select(a => a + "=" + HttpUtility.UrlEncode(collection[a])).ToArray());
            }
        }

        private NameValueCollection BuildCollection()
        {
            var collection = new NameValueCollection();

            if (!string.IsNullOrWhiteSpace(Where))
            {
                collection.Add("where", Where);
            }

            if (!string.IsNullOrWhiteSpace(Order))
            {
                collection.Add("order", Order);
            }            

            if (Parameters != null)
            {
                collection.Add(Parameters);
            }
            return collection;
        }
    }
}