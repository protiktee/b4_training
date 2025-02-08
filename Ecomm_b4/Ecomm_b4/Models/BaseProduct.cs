namespace Ecomm_b4.Models
{
    public class BaseProduct
    {
        //{"name":"Samsung","tag":"Samsung","categoryid":1,"price":15000}
        public string name { get; set; }
        public string tag { get; set; }
        public BaseCategory Category { get; set; }
        public double price { get; set; }
        public List<BaseReview> baseReviews { get; set; }
        public BaseProduct()
        {
            baseReviews = new List<BaseReview>();
            Category=new BaseCategory();
        }
    }
    public class BaseCategory
    {
        public int CategoryId { get; set; }
        public string Category { get; set; }

    }
    public class BaseReview
    { 
        public int ReviewId { get; set; }
        public string Review { get; set; }

    }
}
