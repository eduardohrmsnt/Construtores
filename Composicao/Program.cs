using System;
using System.Globalization;
using Composicao.Entities;
using Composicao.Entities.Enums;

namespace Composicao
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter departament's name: ");
            string deptname = Console.ReadLine();

            Console.WriteLine("Enter worker data");
            Console.Write("Name: ");
            string workername = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base salary: ");
            double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Departament dept = new Departament(deptname);
            Worker worker = new Worker(workername, level, salary, dept);

            Console.WriteLine("How many contracts to this worker?");
            int times = int.Parse(Console.ReadLine());
            

            for(int i = 1; i <= times; i++)
            {
                Console.WriteLine();
                Console.WriteLine("Enter #"+ i +" contract data:" );
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime data = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valueHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours):");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(data, valueHour, hours);

                worker.AddContract(contract);
            }

            Console.WriteLine();

            Console.Write("Enter month and year to calculate income (MM/YYYY): ");

            string vet = Console.ReadLine();
            int month = int.Parse(vet.Substring(0,2));
            int year = int.Parse(vet.Substring(3));
            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Departament: " + worker.Departament.Name);
            Console.WriteLine("Income for: " + vet + ": " + worker.Income(year, month));


        }
    }
}
