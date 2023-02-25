namespace VarietyStoreFront.Models {
    public class Order {
        public int id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public int Value { get; set; }
    }
}
