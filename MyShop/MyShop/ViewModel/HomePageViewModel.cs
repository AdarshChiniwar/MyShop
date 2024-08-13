using MyShop.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyShop.ViewModel
{
    public class HomePageViewModel : BaseViewModel
    {
        #region Properties
        public ICommand BrowseProductsCmd { get; set; }
        public ICommand BrowseProductsCategoryCmd { get; set; }
        #endregion

        #region Constructor
        public HomePageViewModel()
        {
            BrowseProductsCmd = new Command(BrowseProducts);
            BrowseProductsCategoryCmd = new Command(GetCategories);
        }
        #endregion

        #region Functions
        /// <summary>
        /// Functions to browse the products based on selected categories
        /// </summary>
        private async void BrowseProducts()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new Products());
        }

        /// <summary>
        /// Function to select the categories
        /// </summary>
        private async void GetCategories()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ProductCategories());
        }
        #endregion
    }
}
