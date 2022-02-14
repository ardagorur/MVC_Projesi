using AutoMapper;
using ItServiceApp.Core.Entites;
using ItServiceApp.Core.ViewModels;

namespace ItServiceApp.Bussines.MapperProfiles
{
    public class SubscriptionTypeProfile:Profile
    {
        public SubscriptionTypeProfile()
        {
            CreateMap<SubscriptionTypeViewModel, SubscriptionType>().ReverseMap();
        }
    }
}
