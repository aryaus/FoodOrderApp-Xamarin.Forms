using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using FoodOrderApp.Models;
using Firebase.Database.Query;
using System.Collections.ObjectModel;

namespace FoodOrderApp.Services
{
     
    public class FoodItemService
    {
        FirebaseClient client;
        public FoodItemService()
        {
            client = new FirebaseClient("https://foodorderapp-60d9b.firebaseio.com/");
        }

        public async Task<List<FoodItem>> GetFoodItemAsync()
        {
            var products = (await client.Child("FoodItems").
                OnceAsync<FoodItem>()).Select(f => new FoodItem
                {
                    CategoryID = f.Object.CategoryID,
                    Description = f.Object.Description,
                    HomeSelected = f.Object.HomeSelected,
                    ImageUrl = f.Object.ImageUrl,
                    Price = f.Object.Price,
                    Rating = f.Object.Rating,
                    RatingDetail = f.Object.RatingDetail,
                    ProductId = f.Object.ProductId,
                    Name = f.Object.Name

                }).ToList();
            return products;
        }

        // this method return the food items based on category
        public async Task<ObservableCollection<FoodItem>> GetFoodItemsByCategoryAsync(int categoryID)
        {
            var foodItemsByCategory = new ObservableCollection<FoodItem>();
            var items = (await GetFoodItemAsync()).Where(p => p.CategoryID == categoryID).ToList();

            foreach (var item in items)
            {
                foodItemsByCategory.Add(item);
            }
            return foodItemsByCategory;

        }


    }
}
