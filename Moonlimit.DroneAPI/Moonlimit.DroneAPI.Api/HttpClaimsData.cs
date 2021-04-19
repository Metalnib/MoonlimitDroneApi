using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AutoMapper.Internal;
using Microsoft.AspNetCore.Http;
using Moonlimit.DroneAPI.Domain.Service;
using Serilog;

namespace Moonlimit.DroneAPI.Api
{
    public class HttpClaimsData : IClaimsData
    {
        public HttpClaimsData(IHttpContextAccessor httpContextAccessor)
        {
            if (int.TryParse(httpContextAccessor.HttpContext?.User?.FindFirstValue("user_id"), out var id))
                UserId = id;
            else
                Log.Error("HttpContext - User is null!!!");

            if (int.TryParse(httpContextAccessor.HttpContext?.User?.FindFirstValue("account_id"), out var acc))
                AccountId = acc;
            
            Roles = httpContextAccessor.HttpContext?.User?.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList();
        }
        public int UserId { get; }
        public int AccountId { get; }
        public IList<string> Roles { get; }
    }
}