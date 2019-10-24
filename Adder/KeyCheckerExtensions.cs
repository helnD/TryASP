﻿using Microsoft.AspNetCore.Builder;

namespace Adder
{
    public static class KeyCheckerExtensions
    {
        public static IApplicationBuilder UseKeyChecker(this IApplicationBuilder builder) =>
            builder.UseMiddleware<KeyChecker>();
    }
}