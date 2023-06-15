using Microsoft.EntityFrameworkCore;

namespace AnimalsOnPages.Repositories
{
    public static class DataBaseInitializer
    {
        public static async Task InitializeDatabaseAsync(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var animalsDbContext = serviceScope.ServiceProvider.GetService<AnimalsDdContext>();
            await animalsDbContext.Database.MigrateAsync();
        }
    }
}
