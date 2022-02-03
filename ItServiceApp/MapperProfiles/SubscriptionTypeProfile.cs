using AutoMapper;
using ItServiceApp.Models.Entites;
using ItServiceApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItServiceApp.MapperProfiles
{
    public class SubscriptionTypeProfile:Profile
    {
        public SubscriptionTypeProfile()
        {
            CreateMap<SubscriptionTypeViewModel, SubscriptionType>().ReverseMap();
        }
    }
}
