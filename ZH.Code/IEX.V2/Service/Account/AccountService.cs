﻿using QSBuilder;
using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;
using ZH.Code.IEX.V2.Helper;
using ZH.Code.IEX.V2.Model.Account.Request;
using ZH.Code.IEX.V2.Model.Account.Response;

namespace ZH.Code.IEX.V2.Service.Account
{
    internal class AccountService : IAccountService
    {
        private readonly string _sk;
        private readonly Executor _executor;

        public AccountService(HttpClient client, string sk, string pk, bool sign)
        {
            _sk = sk;
            _executor = new Executor(client, sk, pk, sign);
        }

        public async Task<MetadataResponse> MetadataAsync()
        {
            const string urlPattern = "account/metadata";

            var qsb = new QueryStringBuilder();
            qsb.Add("token", _sk);

            var pathNVC = new NameValueCollection();

            return await _executor.ExecuteAsync<MetadataResponse>(urlPattern, pathNVC, qsb);
        }

        public async Task<UsageResponse> UsageAsync(UsageType type)
        {
            const string urlPattern = "account/usage/[type]";

            var qsb = new QueryStringBuilder();
            qsb.Add("token", _sk);

            var pathNVC = new NameValueCollection { { "type", type.ToString().ToLower() } };

            return await _executor.ExecuteAsync<UsageResponse>(urlPattern, pathNVC, qsb);
        }

        public Task PayAsYouGoAsync(bool allow)
        {
            throw new NotImplementedException("Not implemented due to API failed");
        }
    }
}