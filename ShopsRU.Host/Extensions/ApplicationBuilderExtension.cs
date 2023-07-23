﻿using ShopsRU.Host.Middlewares;

namespace ShopsRU.Host.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseGlobalExceptionHandler(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
