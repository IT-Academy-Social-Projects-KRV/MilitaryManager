using BusinessLogic.Services.Documents;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace DocumentGenerator
{
    [ExcludeFromCodeCoverage]
    public static class DocumentGeneratorServicesExtensions
    {
        public static IServiceCollection RegisterDocumentGenerationServices(this IServiceCollection services)
        {
            services.AddTransient<IDocumentGenerationService, DocumentGenerationService>();
            return services;
        }
    }

}
