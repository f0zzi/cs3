using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs3
{
    class Program
    {
        static void Task1()
        {
            Random rnd = new Random();
            List<Student> students = new List<Student>();
            students.Add(new Student("name1", "surn1", "patr1"));
            students.Add(new Student("name2", "surn2", "patr2"));
            students.Add(new Student("name3", "surn3", "patr3"));
            students.Add(new Student("name4", "surn4", "patr4"));
            students.Add(new Student("name5", "surn5", "patr5"));
            uint[] arr;
            foreach (var el in students)
            {
                arr = new uint[rnd.Next(1, 10)];
                for (int j = 0; j < arr.Length; j++)
                {
                    arr[j] = Convert.ToUInt32(rnd.Next(1, 13));
                }
                el.SetAdm(arr);
                arr = new uint[rnd.Next(1, 10)];
                for (int j = 0; j < arr.Length; j++)
                {
                    arr[j] = Convert.ToUInt32(rnd.Next(1, 13));
                }
                el.SetDes(arr);
                arr = new uint[rnd.Next(1, 10)];
                for (int j = 0; j < arr.Length; j++)
                {
                    arr[j] = Convert.ToUInt32(rnd.Next(1, 13));
                }
                el.SetProg(arr);
            }
            foreach (var el in students)
                el.Info();
            Console.WriteLine("Student with max average mark:");
            Student.MaxAv(students);
            Console.WriteLine("Student with min average mark:");
            Student.MinAv(students);
            Student.PassedSubject(students);
        }
        static void Task2()
        {
            Group group = new Group("33СПА-2");
            group.AddSt(new Student("name_one", "surn_one", "patr_one"));
            group.AddSt(new Student("name_two", "surn_two", "patr_two"));
            group.AddSt(new Student("name_three", "surn_three", "patr_three"));
            group.AddSt(new Student("name_four", "surn_four", "patr_four"));
            group.AddSt(new Student("name_five", "surn_five", "patr_five"));
            group.AddSt(new Student("name_six", "surn_six", "patr_six"));
            group.SetRandMarks();
            group.Show();

            Console.WriteLine("remove student six===============================");
            group.RemSt("surnsix");
            group.Show();

            Console.WriteLine("Sort by surname===============================");
            ISortSt strategy = new SortSurname();
            group.SetStrategy(strategy);
            group.SortGr();
            group.Show();

            Console.WriteLine("Sort by average===============================");
            strategy = new SortAverage();
            group.SetStrategy(strategy);
            group.SortGr();
            group.Show();

            Console.WriteLine("Sort by recbook===============================");
            strategy = new SortRecBook();
            group.SetStrategy(strategy);
            group.SortGr();
            group.Show();

            group.ShowBest();
        }
        static void Main(string[] args)
        {
            Task1();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            Task2();
        }
    }
}
