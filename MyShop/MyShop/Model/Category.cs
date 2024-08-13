using MyShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Model
{
    public class Category : BaseViewModel
    {
        public string Name { get; set; }

        private bool isSelected = true;
        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value; OnPropertyChanged(nameof(IsSelected)); }
        }

    }
}
