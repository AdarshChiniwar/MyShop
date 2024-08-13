using MyShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyShop.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Products : ContentPage
    {
        ProductsViewModel productsViewModel;
        public Products()
        {
            InitializeComponent();
            productsViewModel = new ProductsViewModel();
            BindingContext = productsViewModel;
        }
    }
}