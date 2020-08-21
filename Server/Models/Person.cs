using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Server.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public int Age { get; set; }
    }

    public class Customer : Person
    {
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public List<Dependent> Dependents { get; set; }
    }

    public class Dependent : Person
    {
        public string Relationship { get; set; }

        [JsonIgnore]
        public Customer Customer { get; set; }
    }
}