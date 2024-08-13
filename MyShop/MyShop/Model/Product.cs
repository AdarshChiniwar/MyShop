using MyShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Model
{
    public class Product : BaseViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public bool Active { get; set; }
        public List<string> Categories { get; set; }
        public string Description { get; set; }
    }
}
