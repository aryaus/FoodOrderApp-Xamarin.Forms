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

        public ObservableCollection<FoodItem> FoodItemsByCategory { get; set; }
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
            FoodItemsByCategory = new ObservableCollection<FoodItem>();
            GetFoodItems(category.CategoryID);
        }

        private async void GetFoodItems(int categoryID)
        {
            var data = await new FoodItemService().GetFoodItemsByCategoryAsync(categoryID);
            FoodItemsByCategory.Clear();
            foreach (var item in data)
            {
                FoodItemsByCategory.Add(item);
            }
            TotalFoodItems = FoodItemsByCategory.Count;
        }
    }
}
