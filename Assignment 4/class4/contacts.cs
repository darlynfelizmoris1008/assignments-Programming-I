namespace ContactsAppOOP
{
    public class Contact
    {
        public int Id { get; private set; }
        public string Name { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Address { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Email { get; set; } = "";
        public int Age { get; set; }
        public bool IsBestFriend { get; set; }

        public string FullName => $"{Name} {LastName}";

        // Constructor principal: obliga a pasar todos los datos
        public Contact(
            int id,
            string name,
            string lastName,
            string address,
            string phone,
            string email,
            int age,
            bool isBestFriend)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Address = address;
            Phone = phone;
            Email = email;
            Age = age;
            IsBestFriend = isBestFriend;
        }

        public void SetAsBestFriend()
        {
            IsBestFriend = true;
        }

        public void UnsetBestFriend()
        {
            IsBestFriend = false;
        }

        internal void SetId(int newId)
        {
            Id = newId;
        }
    }
}
