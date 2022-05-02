using System;

namespace StringManipulationChallenge
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input some text:");
            string usersString = Console.ReadLine();
            Console.WriteLine($"Your string converted to upper case: \n{StringToUpper(usersString)}");
            Console.WriteLine($"Your string converted to lower case: \n{StringToLower(usersString)}");
            Console.WriteLine($"Your string without leading and trailing white-spaces: \n{StringTrim(usersString)}");
            
            #region substring
            Console.WriteLine("Time for a substring, enter the first element:");
            if (int.TryParse(Console.ReadLine(), out int firstElement)){
                Console.WriteLine("That's not an integer.");
            }

            Console.WriteLine("What is the length of the substring?");
            if (int.TryParse(Console.ReadLine(), out int lengthOfSubstring)){
                Console.WriteLine("That's not an integer.");
            }

            string returnedSubstring = StringSubString(usersString, firstElement, lengthOfSubstring);
            Console.WriteLine($"Your substring is: \n{returnedSubstring}");
            #endregion

            #region char_find
            Console.WriteLine("Enter a character to find the first occurrence of it in your string:");
            if (char.TryParse(Console.ReadLine(), out char usersChar)){
                Console.WriteLine("That's not a single character.");
            }

            int returnedCharacter = SearchChar(usersString, usersChar);
            Console.WriteLine($"The index of the character in the string is \n{returnedCharacter}");
            #endregion

            #region concat
            Console.WriteLine("What is your first name:");
            string firstName = Console.ReadLine();
            
            Console.WriteLine("What is your last name?");
            string lastName = Console.ReadLine();

            //colon- Parameter your setting:the value of that parameter - source/destination
            Console.WriteLine($"{ConcatNames(fName:firstName, lName:lastName)}");
            #endregion
        }

        /// <summary>
        /// This method has one string parameter and will: 
        /// 1) change the string to all upper case and 
        /// 2) return the new string.
        /// </summary>
        /// <param name="usersString"></param>
        /// <returns></returns>
        public static string StringToUpper(string usersString)
        {
            return usersString.ToUpper();
        }

        /// <summary>
        /// This method has one string parameter and will:
        /// 1) change the string to all lower case,
        /// 2) return the new string into the 'lowerCaseString' variable
        /// </summary>
        /// <param name="usersString"></param>
        /// <returns></returns>       
        public static string StringToLower(string usersString)
        {
            return usersString.ToLower();
        }

        /// <summary>
        /// This method has one string parameter and will:
        /// 1) trim the whitespace from before and after the string, and
        /// 2) return the new string.
        /// HINT: When getting input from the user (you are the user), try inputting "   a string with whitespace   " to see how the whitespace is trimmed.
        /// </summary>
        /// <param name="usersString"></param>
        /// <returns></returns>
        public static string StringTrim(string usersString)
        {
            return usersString.Trim();
        }

        /// <summary>
        /// This method has three parameters, one string and two integers. It will:
        /// 1) get the substring based on the first integer element and the length 
        /// of the substring desired.
        /// 2) return the substring.
        /// </summary>
        /// <param name="usersString"></param>
        /// <param name="firstElement"></param>
        /// <param name="lastElement"></param>
        /// <returns></returns>
        public static string StringSubString(string usersString, int firstElement, int lengthOfSubstring)
        {
            return usersString.Substring(firstElement, lengthOfSubstring);
        }

        /// <summary>
        /// This method has two parameters, one string and one char. It will:
        /// 1) search the string parameter for first occurrance of the char parameter and
        /// 2) return the index of the char.
        /// HINT: Think about how StringTrim() (above) would be useful in this situation
        /// when getting the char from the user. 
        /// </summary>
        /// <param name="userInputString"></param>
        /// <param name="charUserWants"></param>
        /// <returns></returns>
        public static int SearchChar(string usersString, char charUserWants)
        {
            return usersString.IndexOf(charUserWants);
        }

        /// <summary>
        /// This method has two string parameters. It will:
        /// 1) concatenate the two strings with a space between them.
        /// 2) return the new string.
        /// HINT: You will need to get the users first and last name in the 
        /// main method and send them as arguments.
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <returns></returns>
        public static string ConcatNames(string fName, string lName)
        {
            return String.Concat(fName, " ", lName);
        }
    }//end of program
}
