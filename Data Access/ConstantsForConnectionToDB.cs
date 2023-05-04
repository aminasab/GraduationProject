namespace graduationProject
{
    internal class ConstantsForConnectionToDB
    {
        public const string Login = "postgres";
        public const string Password = "postgres";
        public const string Host = "localhost";
        public const string Port = "5432";
        public const string DbName = "GarmentFactory";

        public static string ConnectionString { get; } = $"User ID={Login};Password={Password};Host={Host};Port={Port};Database={DbName};";
    }
}
