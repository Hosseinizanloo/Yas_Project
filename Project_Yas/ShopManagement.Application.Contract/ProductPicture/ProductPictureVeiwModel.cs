namespace ShopManagement.Application.Contract.ProductPicture
{
    public class ProductPictureVeiwModel
    {
        public long Id { get; set; }
        public string Product { get; set; }
        public string Pictures { get; set; }
        public long ProductId { get; set; }
        public string CreationDate { get; set; }
        public bool IsRemoved { get; set; }
    }
}
