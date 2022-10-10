using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Base
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Создать два объекта типа Person с совпадающими данными и проверить, что ссылки на объекты не равны, а объекты равны, вывести значения хэшкодов для объектов.
            var person1 = new Person("Alex", "Avgust", new DateTime(2004, 04, 08));
            var person2 = new Person("Alex", "Avgust", new DateTime(2004, 04, 08));

            Console.WriteLine(Object.ReferenceEquals(person2, person1));
            Console.WriteLine(person1 == person2);
            Console.WriteLine("хэш: \n{0}  \n{1}", person1.GetHashCode(), person2.GetHashCode());
            Console.WriteLine();

            // Создать объект типа Student, добавить элементы в список экзаменов и зачетов, вывести данные объекта Student. 
            var student = new Student(new Person("Alex", "Avgust", new DateTime(2004, 04, 08)), Education.Specialist, 320);
            student.AddExams(new Exam("\n OAip", 5, new DateTime(2022, 09, 14)));
            student.AddTests(new Test("OAiP", true));

            // Вывести значение свойства типа Person для объекта типа Student.
            Console.WriteLine(student.ToString());
            Console.WriteLine(student.Persons);
            Console.WriteLine();

            // С помощью метода DeepCopy() создать полную копию объекта Student. Изменить данные в исходном объекте Student и вывести копию и исходный объект, полная копия исходного объекта должна остаться без изменений.
            var studentClone = (Student)student.DeepCopy();
            student.Names = "Sena";
            student.Surnames = "African";
            // student.DateOfBirths = new DateTime(2020, 02, 12);
            Console.WriteLine(student.ToString());
            Console.WriteLine(studentClone.ToString());


            // В блоке try/catch присвоить свойству с номером группы некорректное значение, в обработчике исключения вывести сообщение, переданное через объект - исключение.
            try
            {
                student.GroupNumbers = 600;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }


            // С помощью оператора foreach для итератора, определенного в классе Student, вывести список всех зачетов и экзаменов. 
            foreach (var task in student.GetResults())
                Console.WriteLine(task.ToString());

            // С помощью оператора foreach для итератора с параметром, определенного в классе Student, вывести список всех экзаменов с оценкой выше 3.

            foreach (var task in student.ExamsOver(3))
                Console.WriteLine(task.ToString());
            Console.ReadKey();
        }
    }

    enum Education
    {
        Specialist,
        Вachelor,
        SecondEducation
    }


    interface IDateAndCopy
    {
        object DeepCopy();
        DateTime Date { get; set; }
    }
}


