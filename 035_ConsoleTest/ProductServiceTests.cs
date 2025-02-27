using System.Globalization;
using _034_Console_Test;
using NSubstitute;

namespace _035_ConsoleTest
{
    [TestClass]
    public class ProductServiceTests
    {
        private IProductRepository _repositoryMock;
        private ProductService _service;
        private StringWriter _consoleOutput;
        private CultureInfo _originalCulture;

        [TestInitialize]
        public void Setup()
        {
            _repositoryMock = Substitute.For<IProductRepository>();
            _service = new ProductService(_repositoryMock);

            // ���������� ������� ��������
            _originalCulture = CultureInfo.CurrentCulture;

            // ������������ �������� �� "en-US" ��� ���������� ������������ ������
            CultureInfo.CurrentCulture = new CultureInfo("en-US");

            // ��������������� ������ ������ � StringWriter
            _consoleOutput = new StringWriter();
            Console.SetOut(_consoleOutput);
        }

        [TestCleanup]
        public void Cleanup()
        {
            // ³��������� ���������� �������� ���� �����
            CultureInfo.CurrentCulture = _originalCulture;
        }

        [TestMethod]
        public async Task PrintProducts_ShouldPrintProductListToConsole()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Name = "Laptop", Price = 1500 },
                new Product { Name = "Mouse", Price = 25 }
            };

            _repositoryMock.GetAllAsync().Returns(products);

            // Act
            await _service.PrintProducts();

            // Assert
            var output = _consoleOutput.ToString();
            StringAssert.Contains(output, "Product: Laptop, Price: $1,500.00");
            StringAssert.Contains(output, "Product: Mouse, Price: $25.00");
        }
    }
}