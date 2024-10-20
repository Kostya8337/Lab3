using System;

namespace Models
{
    class Student
    {
        public string Name { get; set; }    // Ім'я студента
        public int Age { get; set; }        // Вік студента
        public int Course { get; set; }     // Курс студента
        public double Rating { get; set; }  // Рейтинг студента

        private int[] grades = new int[10]; // Оцінки за 10 дисциплін

        // Індексатор для доступу до оцінок
        public int this[int index]
        {
            get { return grades[index]; }
            set { grades[index] = value; }
        }

        // Конструктор без параметрів
        public Student()
        {
            Name = "Anonymous";
            Age = 0;
            Course = 0;
            Rating = 0.0;
        }

        // Конструктор з параметрами
        public Student(string name, int age, int course, double rating)
        {
            Name = name;
            Age = age;
            Course = course;
            Rating = rating;
        }

        // Метод для обчислення середнього рейтингу на основі оцінок
        public double CalculateAverageRating()
        {
            int sum = 0;
            for (int i = 0; i < grades.Length; i++)
            {
                sum += grades[i];
            }
            return (double)sum / grades.Length;
        }

        // Метод для виведення інформації про студента
        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Course: {Course}, Average Rating: {CalculateAverageRating():F2}");
        }
    }
}
