using MyShop.Model;
using MyShop.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace MyShop.ViewModel
{
    public class ProductsViewModel : BaseViewModel
    {
        #region Properites
        private ObservableCollection<Product> products;

        public ObservableCollection<Product> Products
        {
            get { return products; }
            set { products = value; OnPropertyChanged(nameof(Products)); }
        }

        public ICommand ProductDetailCmd { get; set; }

        #endregion

        #region Constructor
        public ProductsViewModel()
        {
            ProductDetailCmd = new Command<Product>(OpenProductDetail);
            //products = new ObservableCollection<Product>();
            //taking products and selected categories from app memory
            string productsJson = Preferences.Get("products", string.Empty);
            string selectedCategories = Preferences.Get("categories", string.Empty);
            if(!string.IsNullOrEmpty(productsJson) && !string.IsNullOrEmpty(selectedCategories)) 
            {
                List<Product> allProducts = JsonConvert.DeserializeObject<List<Product>>(productsJson);
                List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(selectedCategories);
                var selectedCategoryNames = categories.Where(c => c.IsSelected).Select(c => c.Name).ToList();
                Products = new ObservableCollection<Product>(
                   allProducts.Where(p => p.Categories.Intersect(selectedCategoryNames).Any() && p.Active).ToList()
               );
            }
        }


        #endregion

        #region Functions
        private async void OpenProductDetail(Product product)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ProductDetail(product));
        }
        #endregion
    }
}
