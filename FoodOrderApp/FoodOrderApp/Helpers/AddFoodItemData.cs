using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using FoodOrderApp.Models;
using Xamarin.Forms;

namespace FoodOrderApp.Helpers
{
    public class AddFoodItemData
    {
        FirebaseClient client;
        public List<FoodItem> FoodItems { get; set; }

        public AddFoodItemData()
        {
            client = new FirebaseClient("https://foodorderapp-60d9b.firebaseio.com/");
            FoodItems = new List<FoodItem>()
            {
                new FoodItem
                {
                    ProductId = 1,
                    CategoryID = 1,
                    ImageUrl = "MainBurger.png",
                    Name = "Burger and Pizza Hub 1",
                    Description = "Burger´- Pizza - Breakfast",
                    Rating = "4.8",
                    RatingDetail = "(121 Ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 45
                },
                 new FoodItem
                {
                    ProductId = 2,
                    CategoryID = 2,
                    ImageUrl = "MainBurger.png",
                    Name = "Burger and Pizza Hub 1",
                    Description = "Burger´- Pizza - Breakfast",
                    Rating = "4.8",
                    RatingDetail = "(121 Ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 45
                },
                 new FoodItem
                {
                    ProductId = 3,
                    CategoryID = 1,
                    ImageUrl = "MainBurger.png",
                    Name = "Burger and Pizza Hub 2",
                    Description = "Burger´- Pizza - Breakfast",
                    Rating = "4.8",
                    RatingDetail = "(121 Ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 45
                },
                 new FoodItem
                {
                    ProductId = 4,
                    CategoryID = 1,
                    ImageUrl = "MainBurger.png",
                    Name = "Burger and Pizza Hub 2",
                    Description = "Burger´- Pizza - Breakfast",
                    Rating = "4.8",
                    RatingDetail = "(121 Ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 45
                },
                 new FoodItem
                {
                    ProductId = 5,
                    CategoryID = 2,
                    ImageUrl = "MainBurger.png",
                    Name = "Burger and Pizza Hub 1",
                    Description = "Burger´- Pizza - Breakfast",
                    Rating = "4.8",
                    RatingDetail = "(121 Ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 45
                },
                 new FoodItem
                {
                    ProductId = 6,
                    CategoryID = 1,
                    ImageUrl = "MainBurger.png",
                    Name = "Burger and Pizza Hub 1",
                    Description = "Burger´- Pizza - Breakfast",
                    Rating = "4.8",
                    RatingDetail = "(121 Ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 45
                },
                 new FoodItem
                {
                    ProductId = 7,
                    CategoryID = 3,
                    ImageUrl = "MainDessert.png",
                    Name = "Cakes",
                    Description = "Ice Cream - Breakfast",
                    Rating = "4.5",
                    RatingDetail = "(130 Ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 45
                },
                 new FoodItem
                {
                    ProductId = 8,
                    CategoryID = 3,
                    ImageUrl = "MainDessert.png",
                    Name = "Cakes",
                    Description = "Cook Cakes - Breakfast",
                    Rating = "4.8",
                    RatingDetail = "(120 Ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 45
                },
            };

        }
        public async Task AddFoodItemAsync()
        {
            try
            {
                foreach (var item in FoodItems)
                {
                    await client.Child("FoodItems").PostAsync(new FoodItem()
                    {
                        CategoryID = item.CategoryID,
                        ProductId = item.ProductId,
                        Description = item.Description,
                        Rating = item.Rating,
                        RatingDetail = item.RatingDetail,
                        HomeSelected = item.HomeSelected,
                        Price = item.Price,
                        ImageUrl = item.ImageUrl,
                        Name = item.Name,

                    });
               
                }
            }
            catch (Exception ex)
            {

                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
