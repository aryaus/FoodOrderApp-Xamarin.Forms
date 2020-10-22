using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using FoodOrderApp.Models;
using FoodOrderApp.Services;

namespace FoodOrderApp.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        private Category _SelectedCategory;

        public Category SelectedCategory
        {
            get { return _SelectedCategory; }
            set { _SelectedCategory = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<FoodItem> FoodItemsbyCategory { get; set; }
        private int _TotalFoodItems;

        public int TotalFoodItems
        {
            get { return _TotalFoodItems; }
            set { _TotalFoodItems = value;
                OnPropertyChanged();
            }
        }

        public CategoryViewModel(Category category)
        {
            SelectedCategory = category;
            FoodItemsbyCategory = new ObservableCollection<FoodItem>();
            GetFoodItemsAsync(category.CategoryID);
        }

        private async void GetFoodItemsAsync(int categoryID)
        {
            var data = await new FoodItemService().GetFoodItemsByCategoryAsync(categoryID);
            FoodItemsbyCategory.Clear();
            foreach (var item in data)
            {
                FoodItemsbyCategory.Add(item);
            }
            TotalFoodItems = FoodItemsbyCategory.Count;
        }
    }
}
