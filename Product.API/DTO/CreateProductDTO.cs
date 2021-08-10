namespace Product.API.DTO
{
    public class CreateProductDTO
    {
        public string Name { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string RusSize { get; set; }
    }
}