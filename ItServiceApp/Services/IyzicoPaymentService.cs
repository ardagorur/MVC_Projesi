using AutoMapper;
using ItServiceApp.Models.Payment;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItServiceApp.Services
{
    public class IyzicoPaymentService : IPaymentService
    {
        private readonly IConfiguration _configuration;
        private readonly IyzicoPaymentOptions _options;
        private readonly IMapper _mapper;
        public IyzicoPaymentService(IConfiguration configuration,IyzicoPaymentOptions options, IMapper mapper)
        {
            _configuration = configuration;
            _options = options;
            _mapper = mapper;
            var section = _configuration.GetSection(IyzicoPaymentOptions.Key);
            options = new IyzicoPaymentOptions()
            {
                ApiKey = section["ApiKey"],
                SecretKey = section["SecretKey"],
                BaseUrl = section["BaseUrl"],
                ThreedsCallbackUrl = section["ThreedsCallbackUrl "]
            };
        }
        public InstallmentModel CheckInstalment(string binNumber, decimal Price)
        {
            throw new NotImplementedException();
        }

        public PaymentResponseModel Pay(PaymentModel model)
        {
            throw new NotImplementedException();
        }
    }
}
