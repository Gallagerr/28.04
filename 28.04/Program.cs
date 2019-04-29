using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _28._04
{
  class Program
  {
    static void Main(string[] args)
    {
      bool isFinish = false;

      do
      {
        switch (Menu.ChooseWhatToDo())
        {
          case Constant.ENTER_CHOICE:
            RecordsService.CraeteReacord();
            break;
          case Constant.EXIT_CHOICE:
            RecordsService.FinishRecord();
            break;
          case Constant.PROGRAMM_FINISH_CHOICE:
            isFinish = true;
            break;
          default:
            Console.WriteLine("Выберите существующи вариант");
            break;
        }
      } while (!isFinish);
    }
  }
}
