using _029_CustomerServiceLibrary;
using Moq;

namespace _031_CustomerServiceLibraTest
{
    [TestClass]
    public class CustomerServiceTests
    {
        [TestMethod]
        public void Create_AddressNotCreated_ExceptionThrown()
        {
            // Arrange 
            CustomerDTO customer = new CustomerDTO() 
            { 
                FirstName = "Alex", 
                LastName = "Hlembitskij", 
                Email = "hlembitskij@test.com" 
            };

            Mock<ICustomerRepository> repositoryMock = new Mock<ICustomerRepository>();
            Mock<IEmailBuilder> emailBuilderMock = new Mock<IEmailBuilder>();

            CustomerService service = new CustomerService(repositoryMock.Object, emailBuilderMock.Object);

            // ��� ������� ������ From � � ����-���� ���������� ���� CustomerDTO ����������� null
            emailBuilderMock
                .Setup(x => x.From(It.IsAny<CustomerDTO>())) 
                .Returns<Address>(null);

            // Act & Assert - ����������, �� ��� ������� Create ���� �������
            Assert.ThrowsException<ApplicationException>(() => service.Create(customer));
        }

        [TestMethod]
        public void Create_AddressCreated_CustomerShouldBeSaved()
        {
            // Arrange 
            CustomerDTO customer = new CustomerDTO()
            {
                FirstName = "Alex",
                LastName = "Hlembitskij",
                Email = "hlembitskij@test.com"
            };

            Mock<ICustomerRepository> repositoryMock = new Mock<ICustomerRepository>();
            Mock<IEmailBuilder> emailBuilderMock = new Mock<IEmailBuilder>();

            CustomerService service = new CustomerService(repositoryMock.Object, emailBuilderMock.Object);

            // ��� ������� ������ From � ����-���� ���������� ���� CustomerDTO,
            // �� ����������� ����� ���� ���� Address
            emailBuilderMock
                .Setup(x => x.From(It.IsAny<CustomerDTO>())) 
                .Returns(new Address());

            // Act
            service.Create(customer);

            // Assert
            repositoryMock.Verify(x => x.Save(It.IsAny<Customer>()));
        }
    }
}