using ApplicationCore.Interfaces;
using Microsoft.Extensions.Configuration;
using Qwill.Interfaces;
using Qwill.ViewModels;
using System;
using System.Threading.Tasks;

namespace Qwill.Services
{
    public class AddressVmService : IAddressVmService
    {
        private readonly IPafTokenService _pafTokenService;
        private readonly IConfiguration _config;
        private readonly IAppLogger<AddressVmService> _appLogger;

        public AddressVmService(IConfiguration config, IPafTokenService pafTokenService, IAppLogger<AddressVmService> appLogger)
        {
            _pafTokenService = pafTokenService;
            _config = config;
            _appLogger = appLogger;
        }

        public async Task<AddressVm> Get()
        {
            return new AddressVm
            {
                Token = await _pafTokenService.GetAddressApiToken("UnspecifiedReferer"),
                IsLive = Convert.ToBoolean(_config.GetSection("IsLive").Value)
            };
        }
    }
}
