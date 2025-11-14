using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;


Console.WriteLine("Welcome to my Contacts List");

bool running = true;
List<int> ids = new List<int>();
Dictionary<int, string> names = new Dictionary<int, string>();
Dictionary<int, string> lastnames = new Dictionary<int, string>();
Dictionary<int, string> addresses = new Dictionary<int, string>();
Dictionary<int, string> telephones = new Dictionary<int, string>();
Dictionary<int, string> emails = new Dictionary<int, string>();
Dictionary<int, int> ages = new Dictionary<int, int>();
Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();

while (running)
{
    Console.ResetColor();
    Console.WriteLine(@"1. Add Contact     2. View Contacts    3. Search Contacts     4. Modify Contact   5. Delete Contact    6. Exit");
    Console.WriteLine("Enter the number of the desired option:");

    int typeOption;
    while (!int.TryParse(Console.ReadLine(), out typeOption))
        Console.Write("Invalid option. Please enter a number: ");

    switch (typeOption)
    {
        case 1:
            AddContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            break;

        case 2:
            if (ids.Count == 0)
            {
                Console.WriteLine("You haven't added any contacts yet...");
                Console.WriteLine("\nPress any key to go back...");
                Console.ReadKey(true);
                break;
            }

            Console.WriteLine($"Name          Lastname            Address           Phone            Email           Age            Best Friend?");
            Console.WriteLine($"____________________________________________________________________________________________________________________________");

            foreach (var id in ids)
            {
                var isBestFriend = bestFriends[id];
                string isBestFriendStr = isBestFriend ? "Yes" : "No";
                Console.WriteLine($"{names[id]}         {lastnames[id]}         {addresses[id]}         {telephones[id]}            {emails[id]}            {ages[id]}          {isBestFriendStr}");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
            break;

        case 3:
            try
            {
                if (ids.Count == 0)
                {
                    Console.WriteLine("You haven't added any contacts yet...");
                    Console.WriteLine("\nPress any key to go back...");
                    Console.ReadKey(true);
                    break;
                }

                Console.Write("Search contact (ENTER to show all): ");
                string query = (Console.ReadLine() ?? "").Trim().ToLower();

                var results = string.IsNullOrWhiteSpace(query)
                    ? ids
                    : ids.Where(id =>
                        id.ToString().Contains(query) ||
                        names[id].ToLower().Contains(query) ||
                        lastnames[id].ToLower().Contains(query) ||
                        addresses[id].ToLower().Contains(query) ||
                        telephones[id].ToLower().Contains(query) ||
                        emails[id].ToLower().Contains(query) ||
                        ages[id].ToString().Contains(query) ||
                        (bestFriends[id] ? "yes" : "no").Contains(query)
                    );

                if (!results.Any())
                {
                    Console.WriteLine("\nNo matches found.");
                }
                else
                {
                    Console.WriteLine($"\nName          Lastname            Address           Phone            Email           Age            Best Friend?");
                    Console.WriteLine("____________________________________________________________________________________________________________________________");

                    foreach (var id in results)
                    {
                        string bf = bestFriends[id] ? "Yes" : "No";
                        Console.WriteLine($"{names[id]}         {lastnames[id]}         {addresses[id]}         {telephones[id]}           {emails[id]}           {ages[id]}          {bf}");
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nFound {results.Count()} contact(s).");
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey(true);
            }
            catch (Exception ex)
            {
                WriteError($"\nAn error occurred during the search: {ex.Message}");
                Console.WriteLine("\nPress any key to go back...");
                Console.ReadKey(true);
            }
            break;

        case 4:
            try
            {
                if (ids.Count == 0)
                {
                    Console.WriteLine("There are no contacts to modify...");
                    Console.WriteLine("\nPress any key to go back...");
                    Console.ReadKey(true);
                    break;
                }

                Console.WriteLine("Available contacts:");
                foreach (var id in ids)
                    Console.WriteLine($"ID: {id} - Name: {names[id]} {lastnames[id]}");

                Console.Write("Enter the ID of the contact you want to modify: ");
                string idText = Console.ReadLine()!;
                if (!int.TryParse(idText, out int idToModify) || !ids.Contains(idToModify))
                {
                    Console.WriteLine("Invalid ID. Press any key to go back...");
                    Console.ReadKey(true);
                    break;
                }

                Console.WriteLine("\nPress ENTER if you don't want to change the current value.\n");

                Console.Write($"Name ({names[idToModify]}): ");
                var nameInput = Console.ReadLine()!;
                if (!string.IsNullOrWhiteSpace(nameInput))
                    names[idToModify] = VerifyName(nameInput);

                Console.Write($"Lastname ({lastnames[idToModify]}): ");
                var lastInput = Console.ReadLine()!;
                if (!string.IsNullOrWhiteSpace(lastInput))
                    lastnames[idToModify] = VerifyName(lastInput);

                Console.Write($"Phone ({telephones[idToModify]}): ");
                var phoneInput = Console.ReadLine()!;
                if (!string.IsNullOrWhiteSpace(phoneInput))
                    telephones[idToModify] = VerifyPhone(phoneInput);

                Console.Write($"Email ({emails[idToModify]}): ");
                var emailInput = Console.ReadLine()!;
                if (!string.IsNullOrWhiteSpace(emailInput))
                    emails[idToModify] = VerifyEmail(emailInput);

                Console.Write($"Address ({addresses[idToModify]}): ");
                var addrInput = Console.ReadLine()!;
                if (!string.IsNullOrWhiteSpace(addrInput))
                    addresses[idToModify] = VerifyField(addrInput);

                Console.Write($"Age ({ages[idToModify]}): ");
                ages[idToModify] = VerifyAge(ages[idToModify]);

                Console.Write($"Best Friend? (1=Yes / 2=No) ({(bestFriends[idToModify] ? "Yes" : "No")}): ");
                bestFriends[idToModify] = VerifyBestFriend(bestFriends[idToModify]);

                WriteSuccess("Contact updated successfully.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey(true);
            }
            catch (Exception ex)
            {
                WriteError($"\nAn error occurred while modifying the contact: {ex.Message}");
                Console.WriteLine("\nPress any key to go back...");
                Console.ReadKey(true);
            }
            break;

        case 5:
            try
            {
                if (ids.Count == 0)
                {
                    Console.WriteLine("There are no contacts to delete yet.");
                    Console.WriteLine("\nPress any key to go back...");
                    Console.ReadKey(true);
                    break;
                }

                Console.WriteLine("Available contacts:");
                foreach (var contactId in ids.OrderBy(i => i))
                    Console.WriteLine($"ID: {contactId} - {names[contactId]} {lastnames[contactId]}");

                Console.Write("\nEnter the ID of the contact you want to delete: ");
                string idText = (Console.ReadLine() ?? "").Trim();

                if (!int.TryParse(idText, out int contactToRemove) || !ids.Contains(contactToRemove))
                {
                    WriteError("Invalid ID. Press any key to go back...");
                    Console.ReadKey(true);
                    break;
                }

                Console.Write($"\nAre you sure you want to delete {names[contactToRemove]} {lastnames[contactToRemove]}? (1 = Yes / 2 = No): ");
                bool confirmed = VerifyBestFriend(false);

                if (!confirmed)
                {
                    Console.WriteLine("\nOperation canceled.");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey(true);
                    break;
                }

                ids.Remove(contactToRemove);
                names.Remove(contactToRemove);
                lastnames.Remove(contactToRemove);
                addresses.Remove(contactToRemove);
                telephones.Remove(contactToRemove);
                emails.Remove(contactToRemove);
                ages.Remove(contactToRemove);
                bestFriends.Remove(contactToRemove);

                ReindexContacts(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);

                WriteSuccess("\nThe contact was deleted successfully and the list was reindexed.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey(true);
            }
            catch (Exception error)
            {
                WriteError($"\nAn error occurred while trying to delete the contact: {error.Message}");
                Console.WriteLine("\nPress any key to go back...");
                Console.ReadKey(true);
            }
            break;

        case 6:
            running = false;
            break;

        default:
            Console.WriteLine("Are you an idiot or something?");
            break;
    }
}

void AddContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames,
    Dictionary<int, string> addresses, Dictionary<int, string> telephones,
    Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.Write("Enter the person's name: ");
    string name = VerifyName(Console.ReadLine()!);

    Console.Write("Enter the person's lastname: ");
    string lastname = VerifyName(Console.ReadLine()!);

    Console.Write("Enter the address: ");
    string address = VerifyField(Console.ReadLine()!);

    Console.Write("Enter the person's phone: ");
    string phone = VerifyPhone(Console.ReadLine()!);

    Console.Write("Enter the person's email: ");
    string email = VerifyEmail(Console.ReadLine()!);

    Console.Write("Enter the person's age: ");
    int age = VerifyAge();

    Console.Write("Is this person a best friend? (1. Yes / 2. No): ");
    bool isBestFriend = VerifyBestFriend();

    var id = ids.Count + 1;
    ids.Add(id);
    names.Add(id, name);
    lastnames.Add(id, lastname);
    addresses.Add(id, address);
    telephones.Add(id, phone);
    emails.Add(id, email);
    ages.Add(id, age);
    bestFriends.Add(id, isBestFriend);
}

static string VerifyEmail(string input)
{
    while (true)
    {
        try
        {
            var mail = new System.Net.Mail.MailAddress((input ?? "").Trim());
            return mail.Address;
        }
        catch (Exception ex) when (ex is FormatException || ex is ArgumentException)
        {
            WriteError("Invalid email. Example: yourname@outlook.com");
            input = Console.ReadLine() ?? "";
        }
    }
}

static string VerifyPhone(string input)
{
    var regex = new System.Text.RegularExpressions.Regex(@"^[0-9]+$");

    while (string.IsNullOrWhiteSpace(input) || !regex.IsMatch(input))
    {
        WriteError("Phone number must contain only digits (no spaces or letters)");
        input = Console.ReadLine() ?? "";
    }
    return input.Trim();
}

static string VerifyField(string input)
{
    while (string.IsNullOrWhiteSpace(input))
    {
        WriteError("Field cannot be empty. Please try again...");
        input = Console.ReadLine()!;
    }
    return input;
}

static string VerifyName(string input)
{
    var regex = new System.Text.RegularExpressions.Regex(@"^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\s]+$");

    while (string.IsNullOrWhiteSpace(input) || !regex.IsMatch(input))
    {
        WriteError("Name or lastname cannot be empty or contain numbers/symbols.");
        input = Console.ReadLine() ?? "";
    }
    return input.Trim();
}

static int VerifyAge(int? currentValue = null)
{
    while (true)
    {
        string input = (Console.ReadLine() ?? "").Trim();

        if (string.IsNullOrWhiteSpace(input) && currentValue.HasValue)
            return currentValue.Value;

        if (int.TryParse(input, out int age) && age >= 1 && age <= 100)
            return age;

        WriteError("Invalid age. Only numbers 1-100 allowed.");
    }
}

static bool VerifyBestFriend(bool? currentValue = null)
{
    while (true)
    {
        string input = (Console.ReadLine() ?? "").Trim().ToLower().Replace("í", "i");

        if (string.IsNullOrWhiteSpace(input) && currentValue.HasValue)
            return currentValue.Value;

        if (int.TryParse(input, out int option) && (option == 1 || option == 2))
            return option == 1;

        if (input.StartsWith("y") || input == "yes") return true;
        if (input.StartsWith("n") || input == "no") return false;

        WriteError("Invalid input. Type 1 for 'Yes' or 2 for 'No'.");
    }
}

static void ReindexContacts(
    List<int> ids,
    Dictionary<int, string> names,
    Dictionary<int, string> lastnames,
    Dictionary<int, string> addresses,
    Dictionary<int, string> telephones,
    Dictionary<int, string> emails,
    Dictionary<int, int> ages,
    Dictionary<int, bool> bestFriends)
{
    var ordered = ids.OrderBy(x => x).ToList();
    int index = 1;

    var newNames = new Dictionary<int, string>();
    var newLastnames = new Dictionary<int, string>();
    var newAddresses = new Dictionary<int, string>();
    var newPhones = new Dictionary<int, string>();
    var newEmails = new Dictionary<int, string>();
    var newAges = new Dictionary<int, int>();
    var newBestFriends = new Dictionary<int, bool>();

    foreach (var oldId in ordered)
    {
        newNames[index] = names[oldId];
        newLastnames[index] = lastnames[oldId];
        newAddresses[index] = addresses[oldId];
        newPhones[index] = telephones[oldId];
        newEmails[index] = emails[oldId];
        newAges[index] = ages[oldId];
        newBestFriends[index] = bestFriends[oldId];
        index++;
    }

    ids.Clear();
    ids.AddRange(Enumerable.Range(1, newNames.Count));

    names.Clear(); foreach (var kv in newNames) names[kv.Key] = kv.Value;
    lastnames.Clear(); foreach (var kv in newLastnames) lastnames[kv.Key] = kv.Value;
    addresses.Clear(); foreach (var kv in newAddresses) addresses[kv.Key] = kv.Value;
    telephones.Clear(); foreach (var kv in newPhones) telephones[kv.Key] = kv.Value;
    emails.Clear(); foreach (var kv in newEmails) emails[kv.Key] = kv.Value;
    ages.Clear(); foreach (var kv in newAges) ages[kv.Key] = kv.Value;
    bestFriends.Clear(); foreach (var kv in newBestFriends) bestFriends[kv.Key] = kv.Value;
}

static void WriteError(string message)
{
    var prev = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(message);
    Console.ForegroundColor = prev;
}

static void WriteSuccess(string message)
{
    var prev = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(message);
    Console.ForegroundColor = prev;
}
