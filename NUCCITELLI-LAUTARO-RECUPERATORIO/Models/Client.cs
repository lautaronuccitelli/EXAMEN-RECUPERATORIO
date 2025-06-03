namespace Models
{
    public class Client
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string ID { get; set; }
        public string Email { get; set; }

        public Client() { }

        public Client(string name, string lastName, string id, string email)
        {
            Name = name;
            LastName = lastName;
            ID = id;
            Email = email;
        }
    }

}
