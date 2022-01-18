using ItServiceApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ItServiceApp.Test
{
    public class PaymentTests
    {
        private readonly IPaymentService _paymentService;
        public PaymentTests(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [Fact]
        public void CheckInstalment()
        {
            var binNumbers = new string[] 
                { "5890040000000016", "9792020000000001", "374427000000003", "4543590000000006" };
            foreach (var bin in binNumbers)
            {
                var result = _paymentService.CheckInstalment(bin, 1000);
            }
            Assert.Equal(true, true);
        }
    }
}
