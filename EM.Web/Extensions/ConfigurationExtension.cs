namespace EM.Web.Extensions
{
    public static class ConfigurationExtension
    {
        public static string GetSuccessiveString(this IConfiguration configuration, string sname)
        {
            return configuration.GetValue<string>($"Successive:{sname}");
        }
    }
}
