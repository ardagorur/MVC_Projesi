using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItServiceApp.Models.Payment
{
    public class CardModel
    {
        public string CardHolderName { get; set; }
        public string CarNumber { get; set; }
        public string ExpierYear { get; set; }
        public string ExpireMonth { get; set; }
        public string Cvc { get; set; }
    }
}
