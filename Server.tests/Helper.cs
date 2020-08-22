using System.Collections.Generic;

using Server.Models;

namespace Server.tests
{
    public static class Helper
    {
        public static List<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer
                {
                    Id = 0,
                    Name = "Test 1",
                    Cpf = "12312312312",
                    Age = 20,
                    Phone = "(11) 9 1234-5678",
                    Email = "test1@mail.com",
                    Address = "Test Street, 1000",
                    Dependents = null
                },
                new Customer
                {
                    Id = 1,
                    Name = "Test 2",
                    Cpf = "45645645645",
                    Age = 30,
                    Phone = "(11) 9 8765-4321",
                    Email = "test2@mail.com",
                    Address = "Test Street, 2000",
                    Dependents = new List<Dependent>
                    {
                        new Dependent
                        {
                            Id = 2,
                            Name = "Depenent Test",
                            Cpf = "12312312312",
                            Age = 4,
                            Relationship = "Child"
                        }
                    }
                }

            };
        }
    }
}