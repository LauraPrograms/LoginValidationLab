using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LoginValidationLab
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> UserEmailS = new List<string>();
            List<string> UserPasswordS = new List<string>();
            bool run = true;
            string userEmail="", userPassword="";
            while (run)
            {                
                bool validEmail = false;
                while (!validEmail)
                {
                    Console.WriteLine("Please enter a valid email (Name123@domain.com):");
                    userEmail = Console.ReadLine();

                    if (ValidateEmail(userEmail))
                    {
                        validEmail = true;
                    }
                    else
                    {
                        Console.WriteLine("Email not valid please try again.");
                    }
                }
                bool validPassword = false;
                while (!validPassword)
                {
                    Console.WriteLine("Please enter a valid password: ");
                    userPassword = Console.ReadLine();
                    if (ValidatePassword(userPassword))
                    {
                        validPassword = true;
                    }
                    else
                    {
                        Console.WriteLine("Email not valid please try again.");
                    }
                }
                UserEmailS.Add(userEmail);
                UserPasswordS.Add(userPassword);
                
                Console.WriteLine("Would you like to continue? (y/n)");
                string userInput = Console.ReadLine().ToLower();

                if (userInput =="y")
                {
                    run = true;
                }
                else //I am being a kind programmer and letting them break free if they type anything else besides y.
                {
                    run = false;
                }
             }
                      
        }
        public static bool ValidateEmail(string userEmail)
        {
            //name with 3+ letters/numbers, @ after name, domain with 3+letters/numbers, .,ending with 2-3 characthers
            bool verify = Regex.IsMatch(userEmail, "^[a-zA-Z0-9]{3,}[@][a-zA-Z0-9]{3,}[.][a-zA-Z]{2,3}$");   
            return verify;
        }
        public static bool ValidatePassword(string userPassword)
        {
            bool verify;            
            bool hasCapitalization = Regex.IsMatch(userPassword, "[A-Z]");//don't do ^...$ because that means the captured letters must be the first and last characters
            bool hasNumber = Regex.IsMatch(userPassword, "[0-9]");
            bool hasLength = (userPassword.Length >= 5);
            if (hasCapitalization && hasNumber && hasLength)
            {
                verify = true;
            }
            else
            {
                verify = false;
            }
            return verify;

        }
    }
    
}
