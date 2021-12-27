using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ItServiceApp.Extensions
{
    public static class AppExtensions
    {
        public static string GetUserId(this HttpContext context)
        {
            return context.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
        }
        public static string ToFullErrorString(this ModelStateDictionary modelState)
        {
            var message = new List<string>();
            foreach (var entry in modelState.Values)
            {
                foreach (var error in entry.Errors)
                {
                    message.Add(error.ErrorMessage);
                }
                
            }
            return String.Join(" ", message);
        }
    }
}
