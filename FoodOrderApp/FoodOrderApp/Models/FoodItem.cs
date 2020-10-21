using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrderApp.Models
{
    public class FoodItem
    {
        public int ProductId { get; set; }
        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public string Rating { get; set; }
        public string RatingDetail { get; set; }

        public string HomeSelected { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
    }
}
