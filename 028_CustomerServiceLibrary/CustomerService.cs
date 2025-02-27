namespace _028_CustomerServiceLibrary
{
    public class CustomerService
    {
        private ICustomerRepository _repositry;

        public CustomerService(ICustomerRepository repository)
        {
            _repositry = repository;
        }

        public void Create(IEnumerable<CustomerDTO> customers)
        {
            foreach (var customer in customers)
            {
                _repositry.Save(new Customer(customer.FirstName, customer.LastName));
            }
        }
    }
}
