using _009_AccountService;

namespace _010_AccountServiceTests
{
    /// <summary>
    /// MSTest — це один із найстаріших фреймворків для модульного тестування у .NET. 
    /// Він розроблений компанією Microsoft і є стандартним для середовища Visual Studio.
    /// MSTest добре інтегрується з Azure DevOps, має підтримку атрибутів для конфігурації 
    /// тестів, але поступається xUnit у гнучкості та ізоляції тестів.
    /// </summary>
    
    [TestClass]
    public class UserManagerTests
    {
        private readonly AccountService accountService = new AccountService();

        // Джерело тестових даних
        public static IEnumerable<object[]> GetUserData()
        {
            return new List<object[]>
            {
                new object[] { "user123", "1234567890", "user@example.com", true },
                new object[] { "usr", "1234567890", "user@example.com", false },
                new object[] { "user456", "phone123", "userexample.com", false }
            };
        }

        [TestMethod]
        [DynamicData(nameof(GetUserData), DynamicDataSourceType.Method)]
        public void UserManager_Add_FromData(string userId, string phone, string email, bool expectedResult)
        {
            if (!expectedResult)
            {
                Assert.ThrowsException<Exception>(() => accountService.RegisterUser(userId, phone, email));
            }
            else
            {
                bool result = accountService.RegisterUser(userId, phone, email);
                Assert.IsTrue(result);
            }
        }
    }


}