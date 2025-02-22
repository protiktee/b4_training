using System.Runtime.Serialization;

namespace Ecomm_b4.Models
{
    [Serializable] 
    public class BaseProduct
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public double price { get; set; }
        public double discountPercentage { get; set; }
        public double rating { get; set; }
        public int stock { get; set; }
        public List<string> tags { get; set; }
        public string brand { get; set; }
        public string sku { get; set; }
        public double weight { get; set; }
        public BaseDimensions Dimensions { get; set; }
        public string warrantyInformation { get; set; }
        public string shippingInformation { get; set; }
        public string availabilityStatus { get; set; }
        public List<BaseReview> reviews { get; set; }
        public string returnPolicy { get; set; }
        public int minimumOrderQuantity { get; set; }
        public BaseMeta meta { get; set; }
        public List<string> images { get; set; }
        public string thumbnail { get; set; }
    }
    [Serializable]
    public class BaseReview
    {
        public int ProductID { get; set; }
        public int rating { get; set; }
        public string comment { get; set; }
        public string date { get; set; }
        public string reviewerName { get; set; }
        public string reviewerEmail { get; set; }
    }
    [Serializable]
    public class BaseMeta
    {
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public string barcode { get; set; }
        public string qrCode { get; set; }
    }
    [Serializable]
    public class BaseDimensions
    {
        public double width { get; set; }
        public double height { get; set; }
        public double depth { get; set; }
    }
}
