namespace MiniECommerce.Web.Utilities.Extensions
{
    public static class AppsettingsConfig
    {
        public static IConfigurationRoot AddAppsettingsConfig()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)

            //eğer buradaki json file ı bulursa yukarıdakini okumaz, yoksa yukarıdakine bakar
            .AddJsonFile($"appsettings.{env}.json", optional: true)
            .AddEnvironmentVariables();

            return configuration.Build();
        }
    }
}
