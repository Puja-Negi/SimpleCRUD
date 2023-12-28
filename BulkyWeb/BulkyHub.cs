using Bulky.DataAccess.Data;
using Bulky.Model;
using Microsoft.AspNetCore.SignalR;

namespace BulkyWeb
{
    public class BulkyHub : Hub
    {
        private readonly CategoryService _categoryService;
        private readonly ApplicationDbContext _dbContext;

        public BulkyHub(CategoryService categoryService, ApplicationDbContext dbContext)
        {
            _categoryService = categoryService;
            _dbContext = dbContext;
        }

        public async Task UpdateCategory(int categoryId)
        {
            // Implement logic to retrieve updated category by categoryId
            var updatedCategory = await GetUpdatedCategory(categoryId);

            if (updatedCategory != null)
            {
                // Send the updated category to the clients
                _categoryService.SendUpdate(updatedCategory); // Utilize CategoryService to broadcast the update
            }
        }

        private Task<Category> GetUpdatedCategory(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
