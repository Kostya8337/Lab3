using System;

namespace Models.Properties
{
    class Properties
    {
        // Властивості для співробітника або студента
        public string Name { get; set; }  // Ім'я та прізвище
        public int BirthYear { get; set; }  // Рік народження
        public double Salary { get; set; }  // Оклад або рейтинг для студента

        // Додаткові властивості для студента
        public int Course { get; set; }  // Курс студента
        public int[] Grades { get; set; }  // Масив оцінок

        // Конструктори
        public Properties()  // Конструктор без параметрів
        {
            Name = "Невідомо";
            BirthYear = 2000;
            Salary = 0.0;
            Course = 1;
            Grades = new int[10];
        }

        public Properties(string name, int birthYear, double salary)  // Конструктор для співробітника
        {
            Name = name;
            BirthYear = birthYear;
            Salary = salary;
        }

        public Properties(string name, int birthYear, double salary, int course, int[] grades)  // Конструктор для студента
        {
            Name = name;
            BirthYear = birthYear;
            Salary = salary;
            Course = course;
            Grades = grades;
        }

        // Метод для розрахунку середнього рейтингу студента
        public double CalculateAverageGrade()
        {
            if (Grades == null || Grades.Length == 0)
                return 0;

            int sum = 0;
            for (int i = 0; i < Grades.Length; i++)
            {
                sum += Grades[i];
            }
            return (double)sum / Grades.Length;
        }

        // Метод виведення інформації
        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Birth Year: {BirthYear}");
            Console.WriteLine($"Salary/Grade Average: {Salary:F2}");

            if (Grades != null && Grades.Length > 0)
            {
                Console.WriteLine("Grades:");
                foreach (var grade in Grades)
                {
                    Console.Write(grade + " ");
                }
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Приклад використання для співробітника
            Properties employee = new Properties("Іванов І.І.", 1985, 5000.00);
            employee.DisplayInfo();

            // Приклад використання для студента
            int[] studentGrades = { 75, 80, 85, 90, 95, 60, 70, 65, 88, 92 };
            Properties student = new Properties("Петров П.П.", 2001, 0, 2, studentGrades);

            // Розрахунок середнього балу студента
            double avgGrade = student.CalculateAverageGrade();
            student.Salary = avgGrade;  // В даному випадку Salary використовується як середній рейтинг
            student.DisplayInfo();
        }
    }
}
