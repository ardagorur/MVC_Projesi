using ItServiceApp.Core.Payment;

namespace ItServiceApp.Bussines.Services.Payment
{
    public interface IPaymentService
    {
        public InstallmentModel CheckInstalment(string binNumber, decimal Price);
        public PaymentResponseModel Pay(PaymentModel model);

    }
}
