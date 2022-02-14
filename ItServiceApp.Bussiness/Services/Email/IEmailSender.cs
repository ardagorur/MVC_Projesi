﻿using ItServiceApp.Core.ComplexTypes;
using System.Threading.Tasks;

namespace ItServiceApp.Bussines.Services.Email
{
    public interface IEmailSender
    {
        Task SendAsync(EmailMessage message);
    }
}
