﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.CodeAnalysis;
using System;

namespace TinyFpTest.Complex
{
    [ExcludeFromCodeCoverage]
    public static class Program
    {
        public static void Main()
            => CreateHostBuilder()
                .Build()
                .Run();

        public static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder(Array.Empty<string>())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}