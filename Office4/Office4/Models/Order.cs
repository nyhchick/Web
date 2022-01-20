
namespace Office4.Models
{
    public class Order
    {
        // ID покупки
        public int OrderId { get; set; }
        // имя и фамилия покупателя
        public string Person { get; set; }
        // адрес покупателя
        public string Address { get; set; }
        // ID товара
        public int ProductId { get; set; }
        
    }
}