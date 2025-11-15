using System.Collections.Generic;
using System.Linq;
using static ContactsAppOOP.InputValidator;

namespace ContactsAppOOP
{
    public class ContactManager
    {
        private readonly List<Contact> _contacts = new List<Contact>();

        public void AddContact()
        {
            System.Console.Write("Enter the person's name: ");
            string name = VerifyName(System.Console.ReadLine()!);

            System.Console.Write("Enter the person's lastname: ");
            string lastname = VerifyName(System.Console.ReadLine()!);

            System.Console.Write("Enter the address: ");
            string address = VerifyField(System.Console.ReadLine()!);

            System.Console.Write("Enter the person's phone: ");
            string phone = VerifyPhone(System.Console.ReadLine()!);

            System.Console.Write("Enter the person's email: ");
            string email = VerifyEmail(System.Console.ReadLine()!);

            System.Console.Write("Enter the person's age: ");
            int age = VerifyAge();

            System.Console.Write("Is this person a best friend? (1. Yes / 2. No): ");
            bool isBestFriend = VerifyBestFriend();

            int nextId = _contacts.Count + 1;

            var contact = new Contact(
                nextId,
                name,
                lastname,
                address,
                phone,
                email,
                age,
                isBestFriend
            );

            _contacts.Add(contact);
            WriteSuccess("Contact added successfully.");
            System.Console.WriteLine("\nPress any key to continue...");
            System.Console.ReadKey(true);
        }

        public void ListContacts()
        {
            if (!_contacts.Any())
            {
                System.Console.WriteLine("You haven't added any contacts yet...");
                System.Console.WriteLine("\nPress any key to go back...");
                System.Console.ReadKey(true);
                return;
            }

            System.Console.WriteLine("Name          Lastname            Address           Phone            Email           Age            Best Friend?");
            System.Console.WriteLine("____________________________________________________________________________________________________________________________");

            foreach (var c in _contacts.OrderBy(c => c.Id))
            {
                string bf = c.IsBestFriend ? "Yes" : "No";
                System.Console.WriteLine($"{c.Name}         {c.LastName}         {c.Address}         {c.Phone}            {c.Email}            {c.Age}          {bf}");
            }

            System.Console.WriteLine("\nPress any key to continue...");
            System.Console.ReadKey(true);
        }

        public void SearchContacts()
        {
            try
            {
                if (!_contacts.Any())
                {
                    System.Console.WriteLine("You haven't added any contacts yet...");
                    System.Console.WriteLine("\nPress any key to go back...");
                    System.Console.ReadKey(true);
                    return;
                }

                System.Console.Write("Search contact (ENTER to show all): ");
                string query = (System.Console.ReadLine() ?? "").Trim().ToLower();

                var results = string.IsNullOrWhiteSpace(query)
                    ? _contacts.OrderBy(c => c.Id).ToList()
                    : _contacts.Where(c =>
                        c.Id.ToString().Contains(query) ||
                        c.Name.ToLower().Contains(query) ||
                        c.LastName.ToLower().Contains(query) ||
                        c.Address.ToLower().Contains(query) ||
                        c.Phone.ToLower().Contains(query) ||
                        c.Email.ToLower().Contains(query) ||
                        c.Age.ToString().Contains(query) ||
                        (c.IsBestFriend ? "yes" : "no").Contains(query)
                    ).OrderBy(c => c.Id).ToList();

                if (!results.Any())
                {
                    System.Console.WriteLine("\nNo matches found.");
                }
                else
                {
                    System.Console.WriteLine("\nName          Lastname            Address           Phone            Email           Age            Best Friend?");
                    System.Console.WriteLine("____________________________________________________________________________________________________________________________");
                    foreach (var c in results)
                    {
                        string bf = c.IsBestFriend ? "Yes" : "No";
                        System.Console.WriteLine($"{c.Name}         {c.LastName}         {c.Address}         {c.Phone}            {c.Email}            {c.Age}          {bf}");
                    }

                    System.Console.ForegroundColor = System.ConsoleColor.Green;
                    System.Console.WriteLine($"\nFound {results.Count} contact(s).");
                    System.Console.ResetColor();
                }

                System.Console.WriteLine("\nPress any key to continue...");
                System.Console.ReadKey(true);
            }
            catch (System.Exception ex)
            {
                WriteError($"\nAn error occurred during the search: {ex.Message}");
                System.Console.WriteLine("\nPress any key to go back...");
                System.Console.ReadKey(true);
            }
        }

        public void EditContact()
        {
            try
            {
                if (!_contacts.Any())
                {
                    System.Console.WriteLine("There are no contacts to modify...");
                    System.Console.WriteLine("\nPress any key to go back...");
                    System.Console.ReadKey(true);
                    return;
                }

                System.Console.WriteLine("Available contacts:");
                foreach (var c in _contacts.OrderBy(c => c.Id))
                    System.Console.WriteLine($"ID: {c.Id} - Name: {c.Name} {c.LastName}");

                System.Console.Write("Enter the ID of the contact you want to modify: ");
                string idText = System.Console.ReadLine()!;
                if (!int.TryParse(idText, out int idToModify))
                {
                    System.Console.WriteLine("Invalid ID. Press any key to go back...");
                    System.Console.ReadKey(true);
                    return;
                }

                var contact = _contacts.FirstOrDefault(c => c.Id == idToModify);
                if (contact == null)
                {
                    System.Console.WriteLine("Contact not found. Press any key to go back...");
                    System.Console.ReadKey(true);
                    return;
                }

                System.Console.WriteLine("\nPress ENTER if you don't want to change the current value.\n");

                System.Console.Write($"Name ({contact.Name}): ");
                var nameInput = System.Console.ReadLine()!;
                if (!string.IsNullOrWhiteSpace(nameInput))
                    contact.Name = VerifyName(nameInput);

                System.Console.Write($"Lastname ({contact.LastName}): ");
                var lastInput = System.Console.ReadLine()!;
                if (!string.IsNullOrWhiteSpace(lastInput))
                    contact.LastName = VerifyName(lastInput);

                System.Console.Write($"Phone ({contact.Phone}): ");
                var phoneInput = System.Console.ReadLine()!;
                if (!string.IsNullOrWhiteSpace(phoneInput))
                    contact.Phone = VerifyPhone(phoneInput);

                System.Console.Write($"Email ({contact.Email}): ");
                var emailInput = System.Console.ReadLine()!;
                if (!string.IsNullOrWhiteSpace(emailInput))
                    contact.Email = VerifyEmail(emailInput);

                System.Console.Write($"Address ({contact.Address}): ");
                var addrInput = System.Console.ReadLine()!;
                if (!string.IsNullOrWhiteSpace(addrInput))
                    contact.Address = VerifyField(addrInput);

                System.Console.Write($"Age ({contact.Age}): ");
                contact.Age = VerifyAge(contact.Age);

                System.Console.Write($"Best Friend? (1=Yes / 2=No) ({(contact.IsBestFriend ? "Yes" : "No")}): ");
                contact.IsBestFriend = VerifyBestFriend(contact.IsBestFriend);

                WriteSuccess("Contact updated successfully.");
                System.Console.WriteLine("\nPress any key to continue...");
                System.Console.ReadKey(true);
            }
            catch (System.Exception ex)
            {
                WriteError($"\nAn error occurred while modifying the contact: {ex.Message}");
                System.Console.WriteLine("\nPress any key to go back...");
                System.Console.ReadKey(true);
            }
        }

        public void DeleteContact()
        {
            try
            {
                if (!_contacts.Any())
                {
                    System.Console.WriteLine("There are no contacts to delete yet.");
                    System.Console.WriteLine("\nPress any key to go back...");
                    System.Console.ReadKey(true);
                    return;
                }

                System.Console.WriteLine("Available contacts:");
                foreach (var c in _contacts.OrderBy(c => c.Id))
                    System.Console.WriteLine($"ID: {c.Id} - {c.Name} {c.LastName}");

                System.Console.Write("\nEnter the ID of the contact you want to delete: ");
                string idText = (System.Console.ReadLine() ?? "").Trim();

                if (!int.TryParse(idText, out int contactToRemove))
                {
                    WriteError("Invalid ID. Press any key to go back...");
                    System.Console.ReadKey(true);
                    return;
                }

                var contact = _contacts.FirstOrDefault(c => c.Id == contactToRemove);
                if (contact == null)
                {
                    WriteError("Contact not found. Press any key to go back...");
                    System.Console.ReadKey(true);
                    return;
                }

                System.Console.Write(
                    $"\nAre you sure you want to delete {contact.Name} {contact.LastName}? (1 = Yes / 2 = No): ");
                bool confirmed = VerifyBestFriend(false);

                if (!confirmed)
                {
                    System.Console.WriteLine("\nOperation canceled.");
                    System.Console.WriteLine("\nPress any key to continue...");
                    System.Console.ReadKey(true);
                    return;
                }

                _contacts.Remove(contact);
                ReindexContacts();

                WriteSuccess("\nThe contact was deleted successfully and the list was reindexed.");
                System.Console.WriteLine("\nPress any key to continue...");
                System.Console.ReadKey(true);
            }
            catch (System.Exception error)
            {
                WriteError($"\nAn error occurred while trying to delete the contact: {error.Message}");
                System.Console.WriteLine("\nPress any key to go back...");
                System.Console.ReadKey(true);
            }
        }

        private void ReindexContacts()
        {
            int index = 1;
            foreach (var contact in _contacts.OrderBy(c => c.Id))
            {
                contact.SetId(index);
                index++;
            }
        }
    }
}
