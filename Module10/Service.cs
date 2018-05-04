using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratorName;

namespace Module10
{
    public struct Service
    {
        public List<Employees> employeeses;
        private Random random;

        public void GenerateEmployee()
        {
            random = new Random();
            employeeses = new List<Employees>();
            Generator generator = new Generator();
            
            for (int i = 0; i < random.Next(1,200); i++)
            {
                Employees employee = new Employees()
                {
                    FullName  = generator.GenerateDefault((Gender) random.Next(0, 2)),
                    StartDate = DateTime.Now.AddMonths(random.Next(1, 60) * (-1)),
                    Position = (Vacancies) random.Next(0, 4),
                    Salary = random.Next(300000, 10000000) / random.Next(1, 100)
                };
                employeeses.Add(employee);
            }
        }

        public void PrintInfo(List<Employees> employees)
        {
            if (employees != null)
            {
                foreach (Employees item in employees)
                {

                    Console.WriteLine($"{item.FullName}: Зарплата составляет {item.Salary} тг. Был(-а) принят(-а) на работу {item.StartDate}. Должность - {item.Position}");
                }
            }
        }

        public void Report1(Vacancies vacancie)
        {
            double summSalary = 0;
            int countClercs = 0;
            List<Employees> list = new List<Employees>();
            foreach (Employees item in employeeses)
            {
                if (item.Position == Vacancies.Clerk)
                {
                    summSalary+= item.Salary;
                    countClercs++;
                }
            }
            summSalary = summSalary/countClercs;
            foreach (Employees item in employeeses)
            {
                if (item.Position == vacancie && item.Salary > summSalary)
                {
                    list.Add(item);
                }
            }

            Console.WriteLine($"{vacancie.ToString()} зарплата которых больше средней зарплаты {summSalary} всех {countClercs} клерков ");
            list = list.OrderBy(o => o.FullName).ToList();
            PrintInfo(list);
            
        }

        public void Report2()
        {
            Employees boss = new Employees();
            foreach (Employees item in employeeses)
            {
                if (item.Position == Vacancies.Boss)
                {
                    boss = item;
                    break;
                }
            }
            List<Employees> list = new List<Employees>();
            foreach (Employees item in employeeses)
            {
                if (item.StartDate < boss.StartDate)
                {
                    list.Add(item);
                }
            }

            Console.WriteLine($"Информация обо всех сотрудниках, принятиых на работу позже босса - {boss.FullName} ({boss.StartDate})");
            PrintInfo(list);
        }
    }
    
}
