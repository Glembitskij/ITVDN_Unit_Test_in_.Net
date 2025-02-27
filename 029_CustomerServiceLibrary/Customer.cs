namespace _029_CustomerServiceLibrary
{
    public class Customer
    {
        public Customer(){}

        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Email { get; set; }
    }
}
