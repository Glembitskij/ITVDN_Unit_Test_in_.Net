namespace _009_AccountService
{
    public class AccountService
    {
        public bool RegisterUser(string userId, string phone, string email)
        {
            if (userId.Length < 4)
            {
                throw new Exception("Ідентифікатор користувача повинен містити більше 4 символів");
            }

            if (phone.Contains("a"))
            {
                throw new Exception("Номер телефону повинен містити лише цифри");
            }

            if (!email.Contains("@"))
            {
                throw new Exception("Помилка у форматі електронної пошти");
            }

            // Логіка збереження даних

            return true;
        }
    }
}
