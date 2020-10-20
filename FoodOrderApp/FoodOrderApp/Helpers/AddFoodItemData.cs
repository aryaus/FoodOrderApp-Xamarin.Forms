using System;
using System.Collections.Generic;
using System.Text;
using FoodOrderApp.Models;

namespace FoodOrderApp.Helpers
{
    public class AddFoodItemData
    {
        public List<FoodItem> FoodItems { get; set; }

        public AddFoodItemData()
        {
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
                    CategoryID = 1,
                    ImageUrl = "MainBurger.png",
                    Name = "Burger and Pizza Hub 1",
                    Description = "Burger´- Pizza - Breakfast",
                    Rating = "4.8",
                    RatingDetail = "(121 Ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 45
                },
            };

        }
    }
}
