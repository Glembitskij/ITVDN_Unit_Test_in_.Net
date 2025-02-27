namespace _008_AssertSamplesTest
{
    // xUnit — це сучасний фреймворк для модульного тестування .NET-додатків,
    // який є наступником MSTest та NUnit. Він був розроблений для покращення
    // гнучкості та підтримки сучасних підходів до тестування.
    public class CollectionAssertMethods
    {
        private static List<string> employees;

        public CollectionAssertMethods()
        {
            // Ініціалізація перед кожним тестом
            if (employees == null)
            {
                employees = new List<string>
                {
                    "Ivan",
                    "Sergey",
                    "Anton",
                    "Roman"
                };
            }
        }

        [Fact]
        public void AllItemsAreNotNull()
        {
            // Перевірка, що всі елементи колекції не є null
            Assert.All(employees, item => Assert.NotNull(item));
        }

        [Fact]
        public void AllItemsAreUnique()
        {
            // Перевірка на унікальність елементів
            var distinctItems = employees.Distinct().ToList();
            Assert.Equal(employees.Count, distinctItems.Count);
        }

        [Fact]
        public void AreEquivalent()
        {
            List<string> employeesTest = new List<string>
            {
                "Sergey",
                "Ivan",
                "Anton",
                "Roman"
            };

            // Перевірка, що колекції мають однакові елементи, порядок не важливий
            Assert.Equal(new HashSet<string>(employees), new HashSet<string>(employeesTest));
        }

        [Fact]
        public void Employees_Subset()
        {
            List<string> employeesSubset = new List<string>
            {
                employees[2]
            };

            // Перевірка, що елементи з employeesSubset є підмножиною employees
            foreach (var item in employeesSubset)
            {
                Assert.Contains(item, employees);
            }
        }
    }

}
