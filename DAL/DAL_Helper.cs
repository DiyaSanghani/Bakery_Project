namespace Bakery_Project.DAL
{
    public class DAL_Helper
    {
        // ama static etle use kairu che k jetla bhi controller che ema as it is rye
        public static string ConnStr = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("myConnectionString");
    }
}
