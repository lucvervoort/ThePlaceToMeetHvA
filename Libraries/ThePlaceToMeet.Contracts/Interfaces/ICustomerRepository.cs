using ThePlaceToMeet.Contracts.DTO;

namespace ThePlaceToMeet.Contracts.Interfaces
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();    
        Customer GetByEmail(string email);
        void Add(Customer klant);
        void SaveChanges();
    }
}
