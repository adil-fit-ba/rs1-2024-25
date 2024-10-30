using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FIT_Api_Example.Helper.Auth
{
    public class AutorizacijaSwaggerHeader : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "my-auth-token",
                In = ParameterLocation.Header,
                Description = "upisati token preuzet iz autentikacijacontrollera"
            });
        }
    }
}
