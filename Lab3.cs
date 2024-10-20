using System;
using Lab3.Models;
using Lab3.Properties;

namespace Lab3_OOP
{
    class Person
    {
        string name;
        int birth_year;
        double pay;

        public Person() // конструктор без параметрів
        {
            name = "Anonimous";
            birth_year = 0;
            pay = 0;
        }

        public Person(string s) // конструктор з параметром
        {
            string[] split = s.Split(new Char[] { '/' });
            name = split[0].Trim();
            birth_year = Convert.ToInt32(split[1].Trim());
            pay = Convert.ToDouble(split[2].Trim());
            if (birth_year < 0) throw new FormatException();
            if (pay < 0) throw new FormatException();
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, Birth Year: {1}, Pay: {2:F2}", name, birth_year, pay);
        }

        public int Compare(string name)
        {
            return string.Compare(this.name, 0, name, 0, name.Length, StringComparison.OrdinalIgnoreCase);
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int BirthYear
        {
            get { return birth_year; }
            set
            {
                if (value > 0) birth_year = value;
                else throw new FormatException();
            }
        }

        public double Pay
        {
            get { return pay; }
            set
            {
                if (value > 0) pay = value;
                else throw new FormatException();
            }
        }

        // Оператори для роботи з окладом
        public static double operator +(Person pers, double a)
        {
            pers.pay += a;
            return pers.pay;
        }

        public static double operator -(Person pers, double a)
        {
            pers.pay -= a;
            if (pers.pay < 0) throw new FormatException();
            return pers.pay;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person[] dbase = new Person[10];
            int n = 0;
            try
            {
                StreamReader f = new StreamReader("Persons.txt");
                string s;
                int i = 0;
                while ((s = f.ReadLine()) != null)
                {
                    dbase[i] = new Person(s);
                    string[] parts = s.Split('/');
                    Console.WriteLine($"Surname and initials: {parts[0]}, Year of birth: {parts[1]}, Pay: {parts[2]}");
                    ++i;
                }
                n = i;
                f.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            int n_pers = 0;
            double mean_pay = 0;
            Console.WriteLine("Enter employee's surname:");
            string name;
            while ((name = Console.ReadLine()) != "")
            {
                bool not_found = true;
                for (int k = 0; k < n; ++k)
                {
                    Person pers = dbase[k];
                    if (pers.Compare(name) == 0)
                    {
                        Console.WriteLine(pers);
                        ++n_pers; mean_pay += pers.Pay;
                        not_found = false;
                    }
                }
                if (not_found) Console.WriteLine("Employee not found");
                Console.WriteLine("Enter another surname or press Enter to finish:");
            }

            if (n_pers > 0)
                Console.WriteLine("Average pay: {0:F2}", mean_pay / n_pers);
        }
    }
}
