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

        private async Task<Category?> GetUpdatedCategory(int categoryId)
        {
            try
            {
                // Retrieve the category by its Id using ApplicationDbContext
                var category = await _dbContext.Categories.FindAsync(categoryId);

                // If the category exists, return it
                if (category != null)
                {
                    return category;
                }
                else
                {
                    // If the category with the given Id doesn't exist
                    // Handle the scenario according to your requirements
                    // For example, throw an exception or return null
                    // This part depends on how you want to handle this case
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions or errors during data retrieval
                // Log the exception or perform error handling as required
                Console.WriteLine($"Error fetching category: {ex.Message}");
                return null; // Return null or handle the error condition appropriately
            }
        }
    }
}
