using _028_CustomerServiceLibrary;
using Moq;

namespace _029_CustomerServiceLibraTest
{
    [TestClass]
    public class CustomerServiceTests
    {
        private List<CustomerDTO> _list;

        private Mock<ICustomerRepository> _customerRepository;

        [TestInitialize]
        public void Initialize()
        {
            _list = new List<CustomerDTO>() {
                new CustomerDTO() { FirstName ="Ivan", LastName="Ivanov" },
                new CustomerDTO() { FirstName ="Petr", LastName="Petrov" },
                new CustomerDTO() { FirstName ="Fedor", LastName="Fedorov" }
            };

            _customerRepository = new Mock<ICustomerRepository>();
        }

        [TestMethod]
        public void CreateMethod_Save_WasCalled()
        {
            // Arrange
            ICustomerRepository repository = _customerRepository.Object;
            CustomerService service = new CustomerService(repository);

            // Act
            service.Create(_list);

            // Assert
            _customerRepository.Verify(x => x.Save(It.IsAny<Customer>()));
        }

        [TestMethod]
        public void CreateMethod_Save_WassCalled_ThreeTimes()
        {
            // Arrange
            ICustomerRepository repository = _customerRepository.Object;
            CustomerService service = new CustomerService(repository);

            // Act
            service.Create(_list);

            // Assert
            // Метод Save мав бути викликаний рівно три рази.
            _customerRepository.Verify(x => x.Save(It.IsAny<Customer>()), Times.Exactly(3));
        }
    }
}