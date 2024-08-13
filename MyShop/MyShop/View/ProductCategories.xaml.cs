using MyShop.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyShop.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductCategories : ContentPage
    {
        ProductCategoriesViewModel productCategoriesViewModel;
        public ProductCategories()
        {
            InitializeComponent();
            productCategoriesViewModel = new ProductCategoriesViewModel();
            BindingContext = productCategoriesViewModel;
            
        }

        protected override bool OnBackButtonPressed()
        {
            Preferences.Set("categories", JsonConvert.SerializeObject(productCategoriesViewModel.Categories));
            return base.OnBackButtonPressed();
        }
        //Saving the status of selected and unselected categories in app memory
        //protected override bool OnBackButtonPressed()
        //{
        //    Preferences.Set("categories", JsonConvert.SerializeObject(productCategoriesViewModel.Categories));
        //    return true;
        //}

        protected override void OnDisappearing()
        {
            Preferences.Set("categories", JsonConvert.SerializeObject(productCategoriesViewModel.Categories));
            base.OnDisappearing();
        }
    }
}