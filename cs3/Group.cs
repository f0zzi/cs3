using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs3
{
    interface ISortSt
    {
        void Sort(List<Student> students);
    }
    class SortRecBook : ISortSt
    {
        public void Sort(List<Student> students)
        {
            students.Sort((x, y) => x.RecordBook.CompareTo(y.RecordBook));
        }
    }
    class SortSurname : ISortSt
    {
        public void Sort(List<Student> students)
        {
            students.Sort((x, y) => x.Surname.CompareTo(y.Surname));
        }
    }
    class SortAverage : ISortSt
    {
        public void Sort(List<Student> students)
        {
            students.Sort((x, y) => y.Average().CompareTo(x.Average()));
        }
    }
    class Group
    {
        Random rnd = new Random();

        List<Student> students = new List<Student>();
        string name;
        private ISortSt strategy;
        public Group(string name = "noname group") { this.name = name; }
        public void AddSt(Student st)
        {
            st.Group = name;
            students.Add(st);
        }
        public void RemSt(string surname)
        {
            students.Remove(students.Find(st => st.Surname == surname));
        }
        public void RemSt(int recordbook)
        {
            students.Remove(students.Find(st => st.RecordBook == recordbook));
        }
        public void Show()
        {
            foreach (var el in students)
                el.Info();
        }
        public void SetStrategy(ISortSt strat)
        {
            if (strat != null)
                strategy = strat;
        }
        public void SortGr()
        {
            strategy.Sort(students);
        }
        public void SetRandMarks()
        {
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
        }
        public void ShowBest(int number = 3)
        {
            if (number <= students.Count && number > 0)
            {
                List<Student> st_copy = new List<Student>(students);
                var tmp = new SortAverage();
                tmp.Sort(st_copy);
                Console.WriteLine($"Best {number} students:");
                for (int i = 0; i < st_copy.Count && i < number; i++)
                {
                    st_copy[i].Info();
                }
            }
            else
                Console.WriteLine("Invalid index.");
        }
    }
}
