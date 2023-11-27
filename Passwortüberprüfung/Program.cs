using System;

class PasswordPolicy
{
    public int MinLength { get; set; }
    public int MinUpperCase { get; set; }
    public int MinLowerCase { get; set; }
    public int MinDigits { get; set; }
    public int MinSpecialChars { get; set; }
}

class Program
{
    static PasswordPolicy passwordPolicy = new PasswordPolicy();
    static void Main()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Passwortüberprüfungsprogramm");
        Console.WriteLine("---------------------------------");
        SetPasswordRequirements();
        do
        {
            Console.Clear();
            DisplayPasswordRequirements();
            string password = GetPassword();
            if (IsPasswordValid(password))
            {
                Console.WriteLine("Das eingebene Passwort ist laut den Anforderung geeignet!");
            }
            else
            {
                PrintErrorMessage("Passwort entspricht nicht den Anforderungen. Bitte erneut versuchen.");
            }

            Console.Write("Möchten Sie ein neues Passwort prüfen? (j/n): ");
        } while (Console.ReadLine().ToLower() == "j");
    }
    
    static void SetPasswordRequirements()
    {
        Console.WriteLine("Passwortanforderungen:");
        Console.Write("Minimale Länge: ");
        passwordPolicy.MinLength = int.Parse(Console.ReadLine());
        Console.Clear();
        DisplayPasswordRequirements();
        Console.Write("Mindestanzahl Großbuchstaben: ");
        passwordPolicy.MinUpperCase = int.Parse(Console.ReadLine());
        Console.Clear();
        DisplayPasswordRequirements();
        Console.Write("Mindestanzahl Kleinbuchstaben: ");
        passwordPolicy.MinLowerCase = int.Parse(Console.ReadLine());
        Console.Clear();
        DisplayPasswordRequirements();
        Console.Write("Mindestanzahl Ziffern: ");
        passwordPolicy.MinDigits = int.Parse(Console.ReadLine());
        Console.Clear();
        DisplayPasswordRequirements();
        Console.Write("Mindestanzahl Sonderzeichen: ");
        passwordPolicy.MinSpecialChars = int.Parse(Console.ReadLine());
    }

    static void DisplayPasswordRequirements()
    {
        Console.WriteLine("\nAktuelle Passwortanforderungen:");
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine($"Minimale Länge: {passwordPolicy.MinLength}");
        Console.WriteLine($"Mindestanzahl Großbuchstaben: {passwordPolicy.MinUpperCase}");
        Console.WriteLine($"Mindestanzahl Kleinbuchstaben: {passwordPolicy.MinLowerCase}");
        Console.WriteLine($"Mindestanzahl Ziffern: {passwordPolicy.MinDigits}");
        Console.WriteLine($"Mindestanzahl Sonderzeichen: {passwordPolicy.MinSpecialChars}");
        Console.WriteLine("----------------------------------------------");
    }


    static string GetPassword()
    {
        Console.Write("Bitte geben Sie Ihr Passwort ein: ");
        return Console.ReadLine();
    }

    static void PrintErrorMessage(string message)
    {
        Console.WriteLine($"Fehler: {message}");
    }

    static bool IsPasswordValid(string password)
    {
        return
            password.Length >= passwordPolicy.MinLength &&
            HasEnoughLowerCase(password, passwordPolicy.MinLowerCase) &&
            HasEnoughUpperCase(password,  passwordPolicy.MinUpperCase) &&
            HasEnoughDigits(password, passwordPolicy.MinDigits) &&
            HasEnoughSpecialChars(password, passwordPolicy.MinSpecialChars);
    }

    static bool HasEnoughLowerCase(string input, int minCount)
    {
        return input.Count(char.IsLower) >= minCount;
    }

    static bool HasEnoughUpperCase(string input, int minCount)
    {
        return input.Count(char.IsUpper) >= minCount;
    }

    static bool HasEnoughDigits(string input, int minCount)
    {
        return input.Count(char.IsDigit) >= minCount;
    }

    static bool HasEnoughSpecialChars(string input, int minCount)
    {
        return input.Count(c => !char.IsLetterOrDigit(c)) >= minCount;
    }
}
