using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;

namespace _28._04
{
  internal class SetInformation
  {
    public static string SetName()
    {
      do
      {
        try
        {
          Console.WriteLine("Enter visitor name: ");

          string name = Console.ReadLine().Trim();

          for (int i = 0; i < name.Length; i++)
          {
            if (!(name[i] >= 'a' && name[i] <= 'z') && !(name[i] >= 'A' && name[i] <= 'Z'))
            {
              throw new ArgumentException("The name was entered incorrectly");
            }
          }

          return name;
        }
        catch (ArgumentException exception)
        {
          Console.WriteLine(exception.Message);
        }
      } while (true);
    }

    public static string SetCertificateNumber()
    {
      do
      {
        try
        {
          Console.WriteLine("Enter Visitor ID Number: ");

          string certificateNumber = Console.ReadLine().Trim();

          if (certificateNumber.Length == Constant.CERTIFICATE_NUMBER_LENGTH)
          {
            for (int i = 0; i < certificateNumber.Length; i++)
            {
              if (!(certificateNumber[i] >= '0' && certificateNumber[i] <= '9'))
              {
                throw new ArgumentException("Only numbers should be in the room");
              }
            }

            return certificateNumber;
          }

          throw new ArgumentException("The length of the entered number does not match the ID number");
        }
        catch (Exception)
        {

          throw;
        }
      } while (true);
    }

    public static Guid SetPersonId()
    {
      do
      {
        try
        {
          Console.WriteLine("Select the number of the person who is leaving:");

          List<Person> persons;

          using (var context = new Context())
          {
            persons = context.People.ToList();

            if (persons.Count == Constant.NULL)
            {
              throw new ArgumentNullException("No people");
            }

            for (int i = 0; i < persons.Count; i++)
            {
              Console.WriteLine($"{i + 1}) {persons[i].Name} : {persons[i].CertificateNumber}");
            }
          }
          int personId;

          if (int.TryParse(Console.ReadLine().Trim(), out personId))
          {
            if (personId > 0 && personId <= persons.Count)
            {
              return persons[personId - 1].Id;
            }

            throw new ArgumentException("No such number, select existing");
          }

          throw new ArgumentException("The number was incorrectly entered");
        }
        catch (ArgumentNullException)
        {
          throw;
        }
        catch (ArgumentException exception)
        {
          Console.WriteLine(exception.Message);
        }
      } while (true);
    }

    public static string SetVisitPurpose()
    {
      Console.WriteLine("Enter the reason for the visitor arrival:");

      string visitPurpose = Console.ReadLine().Trim();

      return visitPurpose;
    }
  }
}