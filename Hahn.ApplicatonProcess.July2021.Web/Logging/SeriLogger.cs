using Microsoft.Extensions.Hosting;
using Serilog;
using System;

namespace Hahn.ApplicatonProcess.July2021.Web.Logging
{
    public static class SeriLogger
    {
        public static Action<HostBuilderContext, LoggerConfiguration> Configure =>
           (context, configuration) =>
           {
               configuration
                    .ReadFrom.Configuration(context.Configuration);
           };
    }
}
