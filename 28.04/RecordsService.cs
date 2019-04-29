using System;

namespace _28._04
{
  internal class RecordsService
  {
    public static void CraeteReacord()
    {
      Person newPerson = new Person()
      {
        Name = SetInformation.SetName(),
        CertificateNumber = SetInformation.SetCertificateNumber()
      };

      Ledger newRecord = new Ledger()
      {
        Person = newPerson,
        EnterTime = DateTime.Now,
        ExitTime = null,
        PersonId = newPerson.Id,
        VisitPurpose = SetInformation.SetVisitPurpose()
      };

      using (var context = new Context())
      {
        context.People.Add(newPerson);
        context.Ledgers.Add(newRecord);
        context.SaveChanges();
      }
    }

    public static void FinishRecord()
    {
      try
      {
        Guid personId = SetInformation.SetPersonId();

        using (var context = new Context())
        {
          var leavingPerson = context.People.Find(personId);
          var ledgers = context.Ledgers.ToList();

          for (int i = 0; i < ledgers.Count; i++)
          {
            if (ledgers[i].PersonId == leavingPerson.Id)
            {
              context.Ledgers.Remove(ledgers[i]);
              context.SaveChanges();
              ledgers[i].ExitTime = DateTime.Now;
              context.Ledgers.Add(ledgers[i]);
              context.SaveChanges();
              break;
            }
          }
        }
      }
      catch (ArgumentNullException exception)
      {
        Console.WriteLine(exception.ParamName);
      }
    }
  }
}