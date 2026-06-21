namespace Feane.ViewModels.DiscountedProduct
{
    public class DiscountedProductGetVM
    {
        public int Id { get; set; }
        public string ImageName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double Percentage { get; set; }

    }
}
