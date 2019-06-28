namespace DataLayer.EfClasses
{
    public class OrderInfo
    {
        public int OrderInfoId { get; set; }
        public string OrderNumber { get; set; }
        public Address BillingAddress { get; set; }
        public Address DeliveryAddress { get; set; }
        public Address HomeAddress { get; set; }
    }
}