namespace FluentMigratorDapper.Infrastructure.Persistence
{
    public class ConnectionStringSettings
    {
        public const string Section = "ConnectionStrings";

        public string Database { get; set; }
        public string Master { get; set; }
    }
}
