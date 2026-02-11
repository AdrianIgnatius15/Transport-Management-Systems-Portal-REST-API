using Transport_Management_Systems_Portal_REST_API.Models;

namespace Transport_Management_Systems_Portal_REST_API
{
    public interface IAddressRepo
    {
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<Address>> GetAddressesAsync();

        Task CreateNewAddressAsync(Address address);

        Task UpdateAddressAsync(Address updatedAddress);

        Task DeleteAddressAsync(Address address);
    }
}