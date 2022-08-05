namespace Antigaspi.Web.Extensions
{
    public static class ServiceExtensions
    {
        /*
        public static void ConfigureCors(this IServiceCollection appServices)
        {
            appServices.AddCors(corsConfig =>
            {
                corsConfig.AddPolicy("CorsPolicy",
                        builder => builder
                            .AllowAnyOrigin() //WithOrigins("http://www.something.com")
                            .AllowAnyMethod() //WithMethods("POST", "GET")
                            .AllowAnyHeader()); //WithHeaders("accept", "content-type")
            });
        }
        */

        public static void ConfigureIISIntegration(this IServiceCollection appServices)
        {
            appServices.Configure<IISOptions>(options =>
            {

            });
        }
    }
}
