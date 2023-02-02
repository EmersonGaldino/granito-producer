using Microsoft.AspNetCore.Builder;

namespace granito.bootstrapper.Configurations.Swagger;

public static class ApplicationBuildExtensionsSwagger
{
    public static void UseSwaggerConfig(this IApplicationBuilder app)
    {
        
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Galdino-V1");
            c.RoutePrefix = string.Empty;
        });
    }
}