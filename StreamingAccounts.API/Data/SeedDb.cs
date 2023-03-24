
using StreamingAccounts.API.Data;
using StreamingAccounts.Shared.Entities;

namespace StreamingAccounts.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCategoriesAsync();
        }

        private async Task CheckCategoriesAsync()
        {
            if (!_context.Categories.Any())
            {
                _context.Categories.Add(new Categories { Name = "Colombia" });
                _context.Categories.Add(new Categories { Name = "USA" });
                _context.Categories.Add(new Categories { Name = "Canadá" });

            }

            await _context.SaveChangesAsync();
        }
    }
}
