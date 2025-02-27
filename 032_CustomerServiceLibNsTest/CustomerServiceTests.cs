using _029_CustomerServiceLibrary;
using NSubstitute;

namespace _032_CustomerServiceLibNsTest
{
    [TestClass]
    public class CustomerServiceTests
    {
        [TestMethod]
        public void Create_AddressNotCreated_ExceptionThrown()
        {
            // Arrange 
            var customer = new CustomerDTO()
            {
                FirstName = "Alex",
                LastName = "Hlembitskij",
                Email = "hlembitskij@test.com"
            };

            var repositoryMock = Substitute.For<ICustomerRepository>();
            var emailBuilderMock = Substitute.For<IEmailBuilder>();

            var service = new CustomerService(repositoryMock, emailBuilderMock);

            // При виклику метода From з будь-яким параметром типу CustomerDTO повертається null
            emailBuilderMock.From(Arg.Any<CustomerDTO>()).Returns(address => null);

            // Act & Assert - перевіряємо, що при виклику Create буде виняток
            Assert.ThrowsException<ApplicationException>(() => service.Create(customer));
        }

        [TestMethod]
        public void Create_AddressCreated_CustomerShouldBeSaved()
        {
            // Arrange 
            var customer = new CustomerDTO()
            {
                FirstName = "Alex",
                LastName = "Hlembitskij",
                Email = "hlembitskij@test.com"
            };

            var repositoryMock = Substitute.For<ICustomerRepository>();
            var emailBuilderMock = Substitute.For<IEmailBuilder>();

            var service = new CustomerService(repositoryMock, emailBuilderMock);

            // При виклику метода From з будь-яким параметром типу CustomerDTO повертається значення
            emailBuilderMock.From(Arg.Any<CustomerDTO>()).Returns(new Address());

            // Act
            service.Create(customer);

            // Assert - перевіряємо, що метод Save викликався хоча б один раз
            repositoryMock.Received(1).Save(Arg.Any<Customer>());
        }

    }
}