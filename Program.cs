using WebApplication1.Infrastucture;

/* Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseHttpsRedirection();
app.UseAuthorization();
*/
namespace WebApplication1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            //Подключения конфигурацию файл appsetting.json 
            IConfigurationBuilder configBuild = new ConfigurationBuilder()
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            //Оборачивания секцию Project в объектную форму для удобства
            IConfiguration configuration = configBuild.Build();
            AppConfig config = configuration.GetSection("Project").Get<AppConfig>()!;

            //Подключания функционал контроллеров
            builder.Services.AddControllersWithViews();

            //Собрка конфигурации
            WebApplication app = builder.Build();

            //Подключения статичных файлов (css, js)
            app.UseStaticFiles();

            //Подключения маршрутизации
            app.UseRouting();

            //Регистрация маршрута
            app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
