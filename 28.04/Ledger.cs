using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _28._04
{
  public class Ledger : Entity
  {
    public DateTime EnterTime { get; set; }
    public DateTime? ExitTime { get; set; }
    public Person Person { get; set; }
    public Guid PersonId { get; set; }
    public string VisitPurpose { get; set; }
  }
}
