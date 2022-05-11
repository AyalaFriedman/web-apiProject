using DL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;


namespace WebApiProject
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RATINGMiddleware
    {
        private readonly RequestDelegate _next;

        public RATINGMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext, Production_aaContext production_aaContext)
        {
            Rating rating = new Rating();
            rating.Host = httpContext.Request.Host.Value;
            rating.Method = httpContext.Request.Method;
            rating.Path = httpContext.Request.Path;
            rating.Referer = httpContext.Request.Headers["Referer"];
            rating.UserAgent = httpContext.Request.Headers["User-Agent"];
            rating.RecordDate = DateTime.Now;
            production_aaContext.Ratings.Add(rating);
            production_aaContext.SaveChanges();
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RATINGMiddlewareExtensions
    {
        public static IApplicationBuilder UseRATINGMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RATINGMiddleware>();
        }
    }
}
