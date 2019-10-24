﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Adder
{
    public class KeyChecker
    {
        private readonly RequestDelegate _next;

        public KeyChecker(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Query.ContainsKey("y"))
            {
                int x;
                if (int.TryParse(context.Request.Query["y"], out x))
                {
                    await _next.Invoke(context);
                }
                else
                {
                    await context.Response.WriteAsync("у should be a number");
                }
            }
            else
            {
                await context.Response.WriteAsync("You must input a number");
            }
        }
    }
}