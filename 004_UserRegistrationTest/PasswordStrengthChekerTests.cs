using _003_UserRegistration;

// xUnit � �� �������� ��������� ��� ���������� ���������� .NET-�������,
// ���� � ����������� MSTest �� NUnit. ³� ��� ����������� ��� ����������
// �������� �� �������� �������� ������ �� ����������.
namespace _004_UserRegistrationTest
{
    public class PasswordStrengthChekerTests
    {
        [Fact]
        public void GetPasswordStrength_AllCahrs_5Points()
        {
            // Arrange
            string password = "P2ssw0rd#";
            int expected = 5;

            // Act
            int actual = PasswordStrengthCheker.GetPasswordStrength(password);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetPasswordStrength_UpperCase_3Points()
        {
            // Arrange
            string password = "Password";
            // ������ ����� 1, �� ������� 1, �� ����� ����� 1
            int expected = 3; 

            // Act
            int actual = PasswordStrengthCheker.GetPasswordStrength(password);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetPasswordStrength_ConteinsNumber_0_4Points()
        {
            // Arrange
            string password = "Passw0rd";

            // ������ ����� 1, �� ������� 1, �� ����� ����� 1, �� ����� 1
            int expected = 4;

            // Act
            int actual = PasswordStrengthCheker.GetPasswordStrength(password);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetPasswordStrength_ConteinsNumber_1_4Points()
        {
            // Arrange
            string password = "Passw1rd";

            //������ ����� 1, �� ������� 1, �� ����� ����� 1, �� ����� 1
            int expected = 4;

            // Act
            int actual = PasswordStrengthCheker.GetPasswordStrength(password);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetPasswordStrength_ContainsSpecialChar_at_5Points()
        {
            // Arrange
            string password = "Passw0rd@";

            // ������ ����� 1, �� ������� 1, �� ����� ����� 1 �� ����� 1, ����������� ������ 1
            int expected = 5;

            // Act
            int actual = PasswordStrengthCheker.GetPasswordStrength(password);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetPasswordStrength_ContainsSpecialChar_Hash_5Points()
        {
            // Arrange
            string password = "Passw0rd#";

            // ������ ����� 1, �� ������� 1, �� ����� ����� 1, ������� 1, ����������� ������ 1
            int expected = 5;

            // Act
            int actual = PasswordStrengthCheker.GetPasswordStrength(password);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetPasswordStrength_ContainsSpecialChar_Excl_5Points()
        {
            // Arrange
            string password = "Passw0rd!";

            // ������ ����� 1, �� ������� 1, �� ����� ������� 1, �� ����� 1, ����������� ������ 1
            int expected = 5;

            // Act
            int actual = PasswordStrengthCheker.GetPasswordStrength(password);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetPasswordStrength_ContainsSpecialChar_Doll_5Points()
        {
            // Arrange
            string password = "Passw0rd$";

            // ������ ����� 1, �� ������� 1, �� ����� ������� 1, �� ����� 1, ����������� ������ 1
            int expected = 5;

            // Act
            int actual = PasswordStrengthCheker.GetPasswordStrength(password);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}