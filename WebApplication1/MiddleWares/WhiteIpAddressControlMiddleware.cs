﻿using System.Net;

namespace WebApplication1.MiddleWares
{
    public class WhiteIpAddressControlMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private const string WhiteIpAddress = "::1";
        public WhiteIpAddressControlMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }
          
        public async Task InvokeAsync(HttpContext context)
        {
            var requestIpAddress=context.Connection.RemoteIpAddress;

            bool AnyWhiteIpAddress=IPAddress.Parse(WhiteIpAddress).Equals(requestIpAddress);

            if (AnyWhiteIpAddress==true)
            {
                await _requestDelegate(context);
            }
            else
            {
                context.Response.StatusCode=HttpStatusCode.Forbidden.GetHashCode();
                await context.Response.WriteAsync("Forbidden");
            }
        }
    }
}
