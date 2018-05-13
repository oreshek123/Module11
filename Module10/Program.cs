using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10
{
    class Program
    {
        static void Main(string[] args)
        {
            Service service = new Service();
            service.GenerateEmployee();
            Console.WriteLine("Информация обо всех сотрудниках");
            service.PrintInfo(service.employeeses);

            Console.WriteLine("\n\n\n");
            service.Report1(Vacancies.Manager);
            Console.WriteLine("\n\n");
            service.Report2();
            Console.ReadLine();
        }
    }
}
