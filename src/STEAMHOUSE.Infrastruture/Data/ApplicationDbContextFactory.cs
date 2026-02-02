using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace STEAMHOUSE.Infrastruture.Data;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        // Tạo cái này để đọc connectionstring mỗi khi add Migration thì đứng  folder migration rồi cứ 
        // dotnet ef migrarions add thôi
        string path = Path.Combine(Directory.GetCurrentDirectory(), "..", "STEAMHOUSE.Dashboard");

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(path)
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        builder.UseNpgsql(connectionString, x => x.MigrationsAssembly("STEAMHOUSE.Infrastruture")) // Chỉ định rõ nơi lưu Migration
            .UseSnakeCaseNamingConvention();

        return new ApplicationDbContext(builder.Options);
    }
}