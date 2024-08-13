using MyShop.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Essentials;

namespace MyShop.ViewModel
{
    public class ProductCategoriesViewModel : BaseViewModel
    {
        #region Properties
        private ObservableCollection<Category> categories;

        public ObservableCollection<Category> Categories
        {
            get { return categories; }
            set { categories = value; OnPropertyChanged(nameof(Categories)); }
        }

        #endregion

        #region Constructor
        public ProductCategoriesViewModel()
        {
            categories = new ObservableCollection<Category>();
            BuildUI();

        }
        #endregion

        #region Functions
        private void BuildUI()
        {
            string categories = Preferences.Get("categories", string.Empty);
            if(!string.IsNullOrEmpty(categories)) 
            {
                List<Category> allCategories = JsonConvert.DeserializeObject<List<Category>>(categories);
                foreach (var category in allCategories)
                {
                    Categories.Add(category);
                }

            }
        }
        #endregion
    }
}
