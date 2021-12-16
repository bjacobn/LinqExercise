using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

           
            //Print the Sum and Average of numbers

            var sum = numbers.Sum();
            var average = numbers.Average();

            Console.WriteLine($"Total = {sum} \n");
            Console.WriteLine($"Average = {average} \n");


          
            
            //Order numbers in ascending order and decsending order. Print each to console.

            Console.WriteLine("---Acending Order ---");

            var acendingOrder = numbers.OrderBy(num => num);

            foreach (int number in acendingOrder)
            {
                Console.WriteLine(number);
            }


            Console.WriteLine("---Decending Order---");

            var decendingOrder = numbers.OrderByDescending(num => num); 

            foreach (int number in decendingOrder)
            {
                Console.WriteLine(number);
            }



           
            
            //Print to the console only the numbers greater than 6

            Console.WriteLine("---Numbers greater then 6---");

            var greaterThenSix = numbers.Where(num => num > 6);          

            foreach (int number in greaterThenSix)
            {
                Console.WriteLine(number);
            }



            
            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**

            Console.WriteLine("---Four numbers in Acending Order ---");

            var orderNumbers = numbers.Where(num => num > 3 && num < 8);

            foreach (int number in orderNumbers)
            {
                Console.WriteLine(number);
            }





            //Change the value at index 4 to your age, then print the numbers in decsending order

            Console.WriteLine("---Replace index 4 print in Decending Order---");

            numbers[4] = 47;

            var sortIndexed = numbers.OrderByDescending(num => num);

            foreach (int number in sortIndexed)
            {
                Console.WriteLine(number);
            }




            // List of employees ***Do not remove this***
            var employees = CreateEmployees();


            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.


            Console.WriteLine("---First Names start with C or S---");

            var resultList = employees.Where(emp => emp.FirstName .StartsWith("C") || emp.FirstName.StartsWith("S")).OrderBy(emp => emp.FirstName);


            foreach (var employee in resultList)
            {
                Console.WriteLine(employee.FullName);
            }

            Console.WriteLine();




            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.

            Console.WriteLine("---Over 26 yeas old---");

            var overTwentySix = employees.Where(emp => emp.Age > 26).OrderBy(emp => emp.Age).ThenBy(emp => emp.FirstName);

            foreach (var employee in overTwentySix)
            {
                Console.WriteLine ($"{employee.Age}   {employee.FullName}");
            }

            Console.WriteLine();


            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35

            Console.WriteLine("---Over 36 years old with less then 11 years experience");

            var employeeYOE = employees.Where(num => num.YearsOfExperience <= 10 && num.Age > 35);

            var sumYOE = employeeYOE.Sum(emp => emp.YearsOfExperience);
            var avgYOE = employeeYOE.Average(emp => emp.YearsOfExperience);



            foreach (var employee  in employeeYOE)
            {
                Console.WriteLine($"{employee.Age} {employee.YearsOfExperience} {employee.FullName}");
            }

            Console.WriteLine();

            Console.WriteLine($"Total YOE = {sumYOE}");
            Console.WriteLine($"Average YOE = {avgYOE}\n");


            //Add an employee to the end of the list without using employees.Add()

            Console.WriteLine("---Add new Employee---");


            employees = employees.Append(new Employee("Jack", "Thompson", 37, 7)).ToList();

            foreach (var emp in employees)
            {
                Console.WriteLine($"{ emp.Age}  {emp.FullName} ");
            }


            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
