using MiniECommerce.Domain.Common;
using MiniECommerce.Domain.Enms;

namespace MiniECommerce.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string? OrderNumber { get; set; }

        public DateTime OrderDate { get; set; }

        public OrderStateEnm OrderState { get; set; }
        public PaymentTypesEnm PaymentTypes { get; set; }

        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? OrderNote { get; set; }

        public string? PaymentId { get; set; }
        public string? PaymentToken { get; set; }
        public string? ConversationId { get; set; }

        public List<OrderItem> OrderItems { get; set; }


    }
}
