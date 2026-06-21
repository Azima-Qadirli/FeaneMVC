using Feane.ViewModels.Appaeareance;
using Feane.ViewModels.BookTable;
using Feane.ViewModels.Customers;
using Feane.ViewModels.DiscountedProduct;
using Feane.ViewModels.Dish;
using Feane.ViewModels.Slider;

namespace Feane.ViewModels.Home
{
    public class HomeVM
    {
        public List<DiscountedProductGetVM> DiscountedProducts { get; set; }
        public List<AppeareanceGetVM> Appeareances { get; set; }
        public List<BookTableGetVM> BookTable { get;set; }
        public List<CustomersGetVM> Customers { get; set; }
        public List<SliderGetVM> Slider { get; set; }
        public List<DishGetVM> Dishes { get; set; }
    }
}
