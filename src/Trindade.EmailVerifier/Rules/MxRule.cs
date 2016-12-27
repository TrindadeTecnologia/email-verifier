using System.Collections.Generic;
using System.Linq;
using ARSoft.Tools.Net.Dns;
using System;
using System.Threading.Tasks;

namespace Trindade.EmailVerifier.Rules
{
    public sealed class MxRule: IEmailRule
    {
        private IDictionary<string, bool> CacheProvider { get; } = new Dictionary<string, bool>();

        public bool IsValid(string email)
        {
            string domain = email.Split('@')[1];
            bool result = false;

            if (CacheProvider.ContainsKey(domain))
                return CacheProvider[domain];

            try
            {
                List<MxRecord> mxRecords = Constants.DnsResolver.Resolve<MxRecord>(domain, RecordType.Mx);

                result = mxRecords.Any();
                CacheProvider.Add(domain, result);
            }
            catch 
            {
                result = false;
            }

            return result;
        }

        public async Task<bool> IsValidAsync(string email)
        {
            string domain = email.Split('@')[1];
            bool result = false;

            if (CacheProvider.ContainsKey(domain))
                return CacheProvider[domain];

            try
            {
                List<MxRecord> mxRecords = await Constants.DnsResolver.ResolveAsync<MxRecord>(domain, RecordType.Mx);

                result = mxRecords.Any();
                CacheProvider.Add(domain, result);
            }
            catch
            {
                result = false;
            }

            return result;
        }
    }
}
