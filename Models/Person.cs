using System;

namespace Models
class Person
{
    public string Name { get; set; }    // Прізвище та ініціали
    public int BirthYear { get; set; }  // Рік народження
    public double Salary { get; set; }  // Оклад

    // Конструктор без параметрів
    public Person()
    {
        Name = "Anonymous";
        BirthYear = 0;
        Salary = 0.0;
    }

    // Конструктор з параметрами
    public Person(string name, int birthYear, double salary)
    {
        Name = name;
        BirthYear = birthYear;
        Salary = salary;
    }

    // Перевизначений метод для форматованого виведення інформації
    public override string ToString()
    {
        return string.Format("Name: {0}, Birth Year: {1}, Salary: {2:F2}", Name, BirthYear, Salary);
    }

    // Метод порівняння імен (прізвище)
    public int Compare(string name)
    {
        return string.Compare(Name, 0, name, 0, name.Length, StringComparison.OrdinalIgnoreCase);
    }

    // Оператори для зміни окладу
    public static double operator +(Person pers, double amount)
    {
        pers.Salary += amount;
        return pers.Salary;
    }

    public static double operator -(Person pers, double amount)
    {
        pers.Salary -= amount;
        if (pers.Salary < 0) throw new FormatException();
        return pers.Salary;
    }
}
