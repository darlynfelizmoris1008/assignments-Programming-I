namespace ContactsAppOOP
{
    public static class ContactsApp
    {
        public static void Run()
        {
            var manager = new ContactManager();
            bool running = true;

            System.Console.WriteLine("Welcome to my Contacts List");

            while (running)
            {
                System.Console.ResetColor();
                System.Console.WriteLine(
                    "1. Add Contact     2. View Contacts    3. Search Contacts     4. Modify Contact   5. Delete Contact    6. Exit");
                System.Console.WriteLine("Enter the number of the desired option:");

                int typeOption;
                while (!int.TryParse(System.Console.ReadLine(), out typeOption))
                    System.Console.Write("Invalid option. Please enter a number: ");

                switch (typeOption)
                {
                    case 1:
                        manager.AddContact();
                        break;
                    case 2:
                        manager.ListContacts();
                        break;
                    case 3:
                        manager.SearchContacts();
                        break;
                    case 4:
                        manager.EditContact();
                        break;
                    case 5:
                        manager.DeleteContact();
                        break;
                    case 6:
                        running = false;
                        break;
                    default:
                        System.Console.WriteLine("You're an idiot or something?");
                        break;
                }
            }
        }
    }
}
