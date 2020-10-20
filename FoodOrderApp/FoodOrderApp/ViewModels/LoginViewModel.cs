using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FoodOrderApp.Services;
using FoodOrderApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FoodOrderApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
       
        private string _Username;
        public string Username
        {
            get { return this._Username; }
            set { this._Username = value;
                OnPropertyChanged();
            }
        }
        

        private string _Password;
        public string Password
        {
            get { return this._Password; }
            set
            {
                this._Password = value;
                OnPropertyChanged();
            }
        }


        private bool _IsBusy;
        public bool IsBusy
        {
            get { return this._IsBusy; }
            set
            {
                this._IsBusy = value;
                OnPropertyChanged();
            }
        }

        private bool _Result;
        public bool Result
        {
            get { return this._Result; }
            set
            {
                this._Result = value;
                OnPropertyChanged();
            }
        }

        // define to command object to support the login and register buttons

        public Command LoginCommand { get; set; }
        public Command RegisterCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await LoginCommandAsync());
            RegisterCommand = new Command(async () => await RegisterCommandAsync());

        }

        private async Task RegisterCommandAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var userService = new UserService();
                Result = await userService.RegisterUser(Username, Password);
                if (Result)
                {
                    await Application.Current.MainPage.DisplayAlert("Success", "User Registered", "OK");
                } else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "This User already exist", "OK");
                }
            }
            catch (Exception ex)
            {

                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            } 
        }

        private async Task LoginCommandAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var userService = new UserService();
                Result = await userService.LoginUser(Username, Password);
                if (Result)
                {
                    // here store the value within this preferences
                    Preferences.Set("Username", Username);
                   
                    await Application.Current.MainPage.Navigation.PushModalAsync(new ProductsView());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Invalid Username or Password", "OK");
                }
            }
            catch (Exception ex)
            {

                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
