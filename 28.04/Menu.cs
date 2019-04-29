using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _28._04
{
  internal class Menu
  {
    public static int ChooseWhatToDo()
    {
      do
      {
        try
        {
          Console.WriteLine("To record a new user, click on '1'\n" +
                            "To record the time of care of a person, click on '2'\n" +
                            "To exit the program, click on '3'");

          int choice;

          if (int.TryParse(Console.ReadLine().Trim(), out choice))
          {
            return choice;
          }

          throw new ArgumentException("Enter the number correctly");
        }
        catch (ArgumentException exception)
        {
          Console.WriteLine(exception.Message);
        }
      } while (true);
    }
  }
}
