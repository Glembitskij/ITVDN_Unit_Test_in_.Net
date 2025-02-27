namespace _029_CustomerServiceLibrary
{
    //  DTO - Data Transfer Object, об'єкт, який передає
    //  інформацію між шарами програми, полегшуючи
    //  комунікацію між нними.
    public class CustomerDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
