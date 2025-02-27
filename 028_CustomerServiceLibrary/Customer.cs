namespace _028_CustomerServiceLibrary
{
    public class Customer
    {
        public Customer()
        {
                
        }
        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Customer(string firstName, string lastName, string email):
            this(firstName, lastName)
        {
            Email = email;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
