using MyShop.Model;
using MyShop.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyShop
{
    //developed feature 1
    public partial class App : Application
    {
        private static readonly HttpClient client = new HttpClient();
        public App()
        {
            InitializeComponent();
          

            //Get products data from cloud
            //Link - https://personalpages.manchester.ac.uk/staff/grigory.pishchulov/Products.txt
            GetData();

            //App starts by displaying home page which has products and product category button
            MainPage = new NavigationPage(new Home());
        }

        private async Task GetData()
        {
            //url of text file
            string url = "https://personalpages.manchester.ac.uk/staff/grigory.pishchulov/Products.txt";
            List<Product> products = new List<Product>();
            //getting data from text file using http call
            string jsonData =  client.GetStringAsync(url).Result;
            //checkinf if the returned data is empty or not
            if(!string.IsNullOrEmpty(jsonData))
            {
                products = JsonConvert.DeserializeObject<List<Product>>(jsonData);
            }
            else
            {
                //if the returned data is empty using the hardcoded values of products
                string productsJson = "[\r\n  {\r\n    \"Id\": \"000e3c3514c8e80bc12c7cde4f4a341c\",\r\n    \"Name\": \"Animal Shape Storage Stool\",\r\n    \"Brand\": \"Carl Artbay Stools\",\r\n    \"Price\": 276.76,\r\n    \"Image\": \"https://images-na.ssl-images-amazon.com/images/I/41%2BE9X7AFUL._.jpg\",\r\n    \"Active\": true,\r\n    \"Categories\": [\"Furniture\"],\r\n    \"Description\": \"This Storage Ottoman Is Finely Crafted With Superior Faux Leather & Quality Mdf, The After-set-up Construction Is Sturdy & Solid, Decorative Appearance Matches Your Interior Decor & Furniture. It Can Be Used As: Storage Chest/Trunk Sundries Finally Has Somewhere To Go, No Matter Blankets, Cushions, Clothes, Or Remotes, Books... An Easy Solution To Organize Your Working And Living environment. It Is Sturdy As A Bench To Be Placed At The Entrance Or closet. You May Sit On It To Put On Or Take Off Your shoes. Tired After Whole days' Work? Here Comes A Nice Place To Rest Your Feet On While Sitting On couch. Puppies May Use It To Step Onto Your Bed Or Watch Out Of The window. With Ottoman Tray, It Becomes An Ottoman Coffee Table To Place Drinks Or foods. We Have A Variety Of Folding Storage Ottomans In Size And Color, Simply Search Storage Ottoman To Find more. Specifications: - Upholstery Material: Faux Leather/Pluch/Wood - Seater Filling Material: High Resilence Sponge - Product Size: - Product Weight: 6kg. Package Contents: - 1 X Folding Storage Ottoman.\"\r\n  },\r\n  {\r\n    \"Id\": \"2e41a5597d493e63b5cfb43071008f75\",\r\n    \"Name\": \"Coffee Stool with Backrest\",\r\n    \"Brand\": \"Amadon\",\r\n    \"Price\": 156.71,\r\n    \"Image\": \"https://images-na.ssl-images-amazon.com/images/I/31sciL4h0gL._.jpg\",\r\n    \"Active\": false,\r\n    \"Categories\": [\"Furniture\"],\r\n    \"Description\": \"Your support is our greatest motivation, welcome to buy! Product Name: Bar Chair. Color: light gray, dark black, orange. Product category: Dining chair Applicable occasions: hotel, bar, restaurant, living room. Applicable age: adult. Material: Fabric Iron. Internal filler: high elastic foam sponge. Style: European. Frame: metal skeleton. According to the ergonomic design, the L-shape fits the back curve and relieves fatigue to the lumbar support. Note: Due to differences between the different displays, the image may not reflect the actual color of the project. If you have any questions or problems, please feel free to contact us by email and we will get back to you within 24 hours.\"\r\n  },\r\n  {\r\n    \"Id\": \"832a3f7628865c013ac88f0cf0a6b078\",\r\n    \"Name\": \"Cushion Cover (18x18 Inch) - Set of 2 Pcs\",\r\n    \"Brand\": \"RADANYA\",\r\n    \"Price\": 15.91,\r\n    \"Image\": \"https://images-na.ssl-images-amazon.com/images/I/51n3-%2Bc9MNL._.jpg\",\r\n    \"Active\": true,\r\n    \"Categories\": [\"Home Textiles\"],\r\n    \"Description\": \"Digitally Printed Cushion Cover in Polyester fabric. Lab Certified for 1. Color Fastness 2. Stability to washing & Rubbing 3. Good Seam Strength. 4. Cushion cover has Quilted Front Overlap Back. A Beautiful Gift for your loved ones. Custom Policy : Customer may be charged custom duty/taxes as per the import laws of the receiving country, which will be payable by the customer at the time of delivery to the carrier company. Shipper will not be responsible for any custom duty.\"\r\n  },\r\n  {\r\n    \"Id\": \"793b2d914699622f979c3abbe2e3167e\",\r\n    \"Name\": \"Doormat 23.6 * 15.7 inch\",\r\n    \"Brand\": \"Baseball hat shop\",\r\n    \"Price\": 8.93,\r\n    \"Image\": \"https://images-na.ssl-images-amazon.com/images/I/518MQTFiAcL._.jpg\",\r\n    \"Active\": true,\r\n    \"Categories\": [\"Home Decor\"],\r\n    \"Description\": \"Custom unique doormats to decorate your home. These amazing machine washable doormats are ideal for all doorsteps. Dry wet feet, grab dirt, dust and grime! Furthermore, these make great workstation mats and are perfect for use as office indoor/outdoor mats. And it's in durable heat-resistant non-woven fabric top, backed with a neoprene rubber non-slip backing. Choose your favorite style to make your home more unique.\"\r\n  },\r\n  {\r\n    \"Id\": \"6cdca831f618544a68b123caaf7a5d08\",\r\n    \"Name\": \"Exquisite Soap Dish\",\r\n    \"Brand\": \"Royare\",\r\n    \"Price\": 80.32,\r\n    \"Image\": \"https://images-na.ssl-images-amazon.com/images/I/41NU0TNCrKL._.jpg\",\r\n    \"Active\": true,\r\n    \"Categories\": [\"Bath\", \"Accessories\"],\r\n    \"Description\": \"Small and light. Keep the soap dry and easy to reach. Material: resin. Style: simplicity. It is easy to use soap. Suitable for any style toilet and kitchen.\"\r\n  },\r\n  {\r\n    \"Id\": \"ce0defc75dacffa42729da7fd606b081\",\r\n    \"Name\": \"Metal Sign 12x12 Inches\",\r\n    \"Brand\": \"Cheyan\",\r\n    \"Price\": 8.70,\r\n    \"Image\": \"https://images-na.ssl-images-amazon.com/images/I/515bexFVmuL._.jpg\",\r\n    \"Active\": true,\r\n    \"Categories\": [\"Home Decor\"],\r\n    \"Description\": \"At Cheyan, we are dedicated to providing beautifully-printed metal signs, pillows, mugs etc. at fair prices, created with responsible and eco-friendly production practices. We value fair employment, transparent manufacturing methods, and sound working conditions at all of our locations worldwide. After Sales Service: If there is anything we can help you, please feel free to contact us at any time and we will continually provide full support. Please rest assured that we will value every customer highly and do our utmost to serve you. Attention: actual color may slightly vary from the picture owing to lighting effects and monitor settings, thanks for your understanding!\"\r\n  },\r\n  {\r\n    \"Id\": \"5875d0abd012ecc3e5208beacff654df\",\r\n    \"Name\": \"Pillowcase 50x50cm\",\r\n    \"Brand\": \"WEIANG\",\r\n    \"Price\": 6.26,\r\n    \"Image\": \"https://images-na.ssl-images-amazon.com/images/I/61Fz%2Bait5nL._.jpg\",\r\n    \"Active\": true,\r\n    \"Categories\": [\"Home Textiles\"],\r\n    \"Description\": \"Thank you for your love of home life. WEIANG is a home brand dedicated to improving the taste of life, designing and producing cushion covers, floor mats, tapestries, etc. WEIANG's product designs are diverse and stylish, adapting to a variety of scenes such as musical instrument stores, schools, weddings, parties, studios, coffee shops and more. Welcome to cooperate with wholesale and customization. Specifications: Material: Polyester. Fabric: Flannel. Shape: Square. Product weight: about 120g. Product Size (L x W ): about 50cm x 50cm/19.68inch x 19.68inch. Package Contents: 1 x Cushion Cover (the pillow inner is not included). Please allow slight deviation for the color and measurement!\"\r\n  },\r\n  {\r\n    \"Id\": \"2b103e41e1803e248ca0e66c506635a2\",\r\n    \"Name\": \"Small Travel Cosmetic Bag\",\r\n    \"Brand\": \"Longjet\",\r\n    \"Price\": 9.34,\r\n    \"Image\": \"https://images-na.ssl-images-amazon.com/images/I/41NSNt%2B6tCL._.jpg\",\r\n    \"Active\": true,\r\n    \"Categories\": [\"Accessories\"],\r\n    \"Description\": \"Fashion small transparent cosmetic case.\"\r\n  },\r\n  {\r\n    \"Id\": \"fccb4a34e8b518f5104cc7df686c9df7\",\r\n    \"Name\": \"Soft Towel 13x29 inch\",\r\n    \"Brand\": \"DIYthinker\",\r\n    \"Price\": 10.54,\r\n    \"Image\": \"https://images-na.ssl-images-amazon.com/images/I/41TcKZs4RzL._.jpg\",\r\n    \"Active\": true,\r\n    \"Categories\": [\"Bath\"],\r\n    \"Description\": \"Size: 13 x 29 Inch. Classification: Towel. Feature: Full color printing; Fast drying, soft and highly absorbent; Turn your bathroom into your own personal oasis with this towel perfect for drying you off in style. Material: Superfine fiber. Package Quantity: 1 x towel.\"\r\n  },\r\n  {\r\n    \"Id\": \"e8b01edd2896db12cdcb85b199e89d94\",\r\n    \"Name\": \"Wall-Mounted Bathroom Mirror\",\r\n    \"Brand\": \"WFW\",\r\n    \"Price\": 195.48,\r\n    \"Image\": \"https://images-na.ssl-images-amazon.com/images/I/41fH57V4BCL._.jpg\",\r\n    \"Active\": true,\r\n    \"Categories\": [\"Bath\", \"Makeup\"],\r\n    \"Description\": \"Name: Mirror quantity: 1. Color: multicolor. Material: aluminum. Specifications: 50x70cm, 60x70cm, 60x80cm. Product description: 1. In order to ensure that the product can be sent to your hands in good condition, we will carefully handle it when packaging. If the mirror you received is broken, please contact us in time. 2. The product may have a slight color difference, please refer to the actual product. Because it is measured by hand, there may be an error of 2-3 cm in size.\"\r\n  }\r\n]";
                products = JsonConvert.DeserializeObject<List<Product>>(jsonData);
            }
            if(products.Count > 0) 
            {
                // Extract all categories and store in a list with IsSelected property
                List<Category> allCategories = products
                    .SelectMany(p => p.Categories)
                    .Distinct().OrderBy(x => x)
                    .Select(c => new Category { Name = c })
                    .ToList();

                //store the products and categorylist in app memmory
                Preferences.Set("products", JsonConvert.SerializeObject(products));
                Preferences.Set("categories", JsonConvert.SerializeObject(allCategories));
            }
          
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
