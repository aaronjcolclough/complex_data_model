namespace Microsoft.AspNetCore.Builder;

using ComplexDataModel.Identity;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseAdMiddleware(this IApplicationBuilder builder) =>
        builder.UseMiddleware<AdUserMiddleware>();
}