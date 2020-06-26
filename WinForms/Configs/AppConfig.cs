using System.Configuration;

namespace WinForms.Configs
{
    public static class AppConfig
    {
        public static string ConnectionString => ConfigurationManager.AppSettings["ConnectionString"];
    }
}