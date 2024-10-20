using Models;
using System;

namespace Models

class Program
{
    static void Main(string[] args)
    {
        // Приклад роботи з класом Person
        Person[] people = new Person[2];
        people[0] = new Person("Ivanov I.I.", 1980, 3000.00);
        people[1] = new Person("Petrov P.P.", 1990, 4000.00);

        foreach (var person in people)
        {
            Console.WriteLine(person);
        }

        // Приклад роботи з класом Student
        Student student = new Student("Alice", 20, 2, 80);
        for (int i = 0; i < 10; i++)
        {
            student[i] = 60 + i; // Встановлення оцінок через індексатор
        }
        student.DisplayInfo();

        // Приклад роботи з класом PublishingEdition
        PublishingEdition book = new PublishingEdition();
        book.DisplayInfo("War and Peace", "Book", 350.00);
        book.DisplayInfo("War and Peace", "Book", 350.00, 1225);
    }
}
