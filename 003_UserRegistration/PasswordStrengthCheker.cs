using System.Text.RegularExpressions;

namespace _003_UserRegistration
{
    public class PasswordStrengthCheker
    {
        // Повертає значення, що визначає складність пароля користувача.
        public static int GetPasswordStrength(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return 0;
            }

            int result = 0;

            // +1 балл за довжину.
            if (Math.Max(password.Length, 7) > 7)
            {
                result++;
            }

            //+1 балл за наявність символа в нижньому реєстрі
            if (Regex.Match(password, "[a-z]").Success)
            {
                result++;
            }

            //+1 балл за наявність символа в верхньому реєстрі
            if (Regex.Match(password, "[A-Z]").Success)
            {
                result++;
            }

            // +1 балл за наявність числа.
            if (Regex.Match(password, "[0-9]").Success)
            {
                result++;
            }

            // +1 балл за наявність спеціального символа.
            if (Regex.Match(password,
                   "[\\!\\@\\#\\$\\%\\^\\&\\*\\(\\)\\{\\}\\[\\]\\:\\'\\;\\\"\\/\\?\\.\\>\\,\\<\\~\\`\\-\\\\_\\=\\+\\|]").Success)
            {
                result++;
            }

            return result;
        }
    }
}
