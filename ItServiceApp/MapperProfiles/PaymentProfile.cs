using AutoMapper;
using ItServiceApp.Models.Entites;
using ItServiceApp.Models.Payment;
using ItServiceApp.ViewModels;
using Iyzipay.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItServiceApp.MapperProfiles
{
    public class PaymentProfile:Profile
    {
        public PaymentProfile()
        {
            CreateMap<InstallmentPriceModel, InstallmentPrice>().ReverseMap();
            //CreateMap<InstallmentPrice,InstallmentPriceModel> reverse yerine
            CreateMap<InstallmentModel, InstallmentDetail>().ReverseMap();
            CreateMap<CardModel, PaymentCard>().ReverseMap();
            CreateMap<BasketModel, BasketItem>().ReverseMap();
            CreateMap<CustomerModel, Buyer>().ReverseMap();
            CreateMap<PaymentResponseModel, Payment>().ReverseMap();
            CreateMap<AddressModel, ItServiceApp.Models.Entites.Address>().ReverseMap();
            CreateMap<SubscriptionTypeViewModel, SubscriptionType>().ReverseMap();

        }
    }
}
