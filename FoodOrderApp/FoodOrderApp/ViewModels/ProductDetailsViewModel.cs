using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FoodOrderApp.Models;
using FoodOrderApp.Views;
using Xamarin.Forms;

namespace FoodOrderApp.ViewModels
{
    public class ProductDetailsViewModel : BaseViewModel
    {
        private FoodItem _SelectedFoodItem;

        public FoodItem SelectedFoodItem
        {
            get { return _SelectedFoodItem; }
            set { this._SelectedFoodItem = value;
                OnPropertyChanged();
            }
        }

        private int _TotalQuantity;

        public int TotalQuantity
        {
            get { return _TotalQuantity; }
            set
            {
                this._TotalQuantity = value;
                if (this._TotalQuantity < 0)
                    this._TotalQuantity = 0;
                if (this._TotalQuantity > 10)
                    this._TotalQuantity -= 1; 
                OnPropertyChanged();
            }
        }

        public Command IncrementOrderCommand { get; set; }
        public Command DecrementOrderCommand { get; set; }
        public Command AddToCartCommand { get; set; }
        public Command ViewCartCommand { get; set; }
        public Command HomeCommand { get; set; }

        public ProductDetailsViewModel(FoodItem foodItem)
        {
            SelectedFoodItem = foodItem;
            _TotalQuantity = 0;

            IncrementOrderCommand = new Command(() => IncrementOrder());
            DecrementOrderCommand = new Command(() => DecrementOrder());
            AddToCartCommand = new Command(() => AddToCart());
            ViewCartCommand = new Command(async () => await ViewCartAsync());
            HomeCommand = new Command(async () => await GoToHomeAsync());
        }

        private async Task GoToHomeAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new ProductsView());
        }

        private async Task ViewCartAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new CartView());
        }

        private void AddToCart()
        {
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            try
            {
                CartItem ci = new CartItem()
                {
                    ProductId = SelectedFoodItem.ProductId,
                    ProductName = SelectedFoodItem.Name,
                    Price = SelectedFoodItem.Price,
                    Quantity = TotalQuantity
                };
                var item = cn.Table<CartItem>().ToList()
                    .FirstOrDefault(c => c.ProductId == SelectedFoodItem.ProductId);
                if (item == null)
                    cn.Insert(ci);
                else
                {
                    item.Quantity += TotalQuantity;
                    cn.Update(item);
                }
                cn.Close();
                Application.Current.MainPage.DisplayAlert("Cart", "Selected Item Added To Cart", "OK");
            }
            catch (Exception ex)
            {

                Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private void DecrementOrder()
        {
            TotalQuantity--;
        }

        private void IncrementOrder()
        {
            TotalQuantity++;
        }
    }
}
