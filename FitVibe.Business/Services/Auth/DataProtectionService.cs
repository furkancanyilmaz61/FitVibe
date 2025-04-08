using FitVibe.Business.Services.Interfaces;
using Microsoft.AspNetCore.DataProtection;

namespace FitVibe.Business.Services
{
    public class DataProtectionService 
    {
        private readonly IDataProtector _protector;

        public DataProtectionService(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("FitVibe.SecretProtector");
        }

        public string Protect(string input)
        {
            return _protector.Protect(input);
        }

        public string Unprotect(string encrypted)
        {
            return _protector.Unprotect(encrypted);
        }
    }
}
