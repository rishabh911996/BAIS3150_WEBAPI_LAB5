namespace BAIS3150_WEBAPI_LAB5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            var app = builder.Build();

            app.UseRouting();

            app.MapControllers();

            app.Run();
        }
    }
}
