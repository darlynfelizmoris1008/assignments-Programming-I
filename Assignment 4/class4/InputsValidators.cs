using System.Net.Mail;
using System.Text.RegularExpressions;

namespace ContactsAppOOP
{
    public static class InputValidator
    {
        public static string VerifyEmail(string input)
        {
            while (true)
            {
                try
                {
                    var mail = new MailAddress((input ?? "").Trim());
                    return mail.Address;
                }
                catch
                {
                    WriteError("Invalid email. Example: yourname@outlook.com");
                    input = System.Console.ReadLine() ?? "";
                }
            }
        }

        public static string VerifyPhone(string input)
        {
            var regex = new Regex(@"^[0-9]+$");

            while (string.IsNullOrWhiteSpace(input) || !regex.IsMatch(input))
            {
                WriteError("Phone number must contain only digits (no spaces or letters).");
                input = System.Console.ReadLine() ?? "";
            }
            return input.Trim();
        }

        public static string VerifyField(string input)
        {
            while (string.IsNullOrWhiteSpace(input))
            {
                WriteError("Field cannot be empty. Please try again...");
                input = System.Console.ReadLine() ?? "";
            }
            return input;
        }

        public static string VerifyName(string input)
        {
            var regex = new Regex(@"^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\s]+$");

            while (string.IsNullOrWhiteSpace(input) || !regex.IsMatch(input))
            {
                WriteError("Name or lastname cannot be empty or contain numbers/symbols.");
                input = System.Console.ReadLine() ?? "";
            }
            return input.Trim();
        }

        public static int VerifyAge(int? currentValue = null)
        {
            while (true)
            {
                string input = (System.Console.ReadLine() ?? "").Trim();

                // ENTER = mantener valor actual (para editar)
                if (string.IsNullOrWhiteSpace(input) && currentValue.HasValue)
                    return currentValue.Value;

                if (int.TryParse(input, out int age) && age >= 1 && age <= 100)
                    return age;

                WriteError("Invalid age. Only numbers 1–100 allowed.");
            }
        }

        public static bool VerifyBestFriend(bool? currentValue = null)
        {
            while (true)
            {
                string input = (System.Console.ReadLine() ?? "").Trim().ToLower().Replace("í", "i");

                // ENTER = mantener valor actual (para editar)
                if (string.IsNullOrWhiteSpace(input) && currentValue.HasValue)
                    return currentValue.Value;

                if (int.TryParse(input, out int option) && (option == 1 || option == 2))
                    return option == 1;

                if (input.StartsWith("y") || input == "yes") return true;
                if (input.StartsWith("n") || input == "no") return false;

                WriteError("Invalid input. Type 1 for 'Yes' or 2 for 'No'.");
            }
        }

        public static void WriteError(string message)
        {
            var prev = System.Console.ForegroundColor;
            System.Console.ForegroundColor = System.ConsoleColor.Red;
            System.Console.WriteLine(message);
            System.Console.ForegroundColor = prev;
        }

        public static void WriteSuccess(string message)
        {
            var prev = System.Console.ForegroundColor;
            System.Console.ForegroundColor = System.ConsoleColor.Green;
            System.Console.WriteLine(message);
            System.Console.ForegroundColor = prev;
        }
    }
}
