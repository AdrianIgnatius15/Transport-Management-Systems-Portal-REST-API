using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transport_Management_Systems_Portal_REST_API.Models
{
    public class Order
    {
        [Key]
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [ForeignKey("Client")]
        public Guid ClientId { get; set; } = Guid.NewGuid();

        public Client Client { get; set; } = default!;

        [Required]
        public string OrderNumber { get; set; } = default!;

        [Required]
        public OrderStatus Status { get; set; } = OrderStatus.Created;

        [Required]
        public string Priority { get; set; } = string.Empty;

        [Required]
        [ForeignKey("PickupAddressId")]
        public Guid PickupAddressId { get; set; } = Guid.NewGuid();

        public Address PickupAddress { get; set; } = default!;

        [Required]
        [ForeignKey("DeliveryAddressId")]
        public Guid DeliveryAddressId { get; set; } = Guid.NewGuid();

        public Address DeliveryAddress { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; }
    }
}