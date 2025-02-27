
using _003_UserRegistration;

string password = "1234567qW$";

int passwordStrength = PasswordStrengthCheker.GetPasswordStrength(password);

Console.WriteLine(passwordStrength);