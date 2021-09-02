using System;
using System.Collections.Generic;
using System.Text;
using ConsoleProject.Interface;

namespace ConsoleProject.models
{
    class Department 
    {
        public string Name;
        public int WorkerLimit;
        public int SalaryLimit;
        public Employee[] Employee;        
        public Department( string name, int workerlimit, int salarylimit) 
        {

            Name = name;
            Employee = new Employee[0];
            WorkerLimit = workerlimit;
            SalaryLimit = salarylimit;

           

            //if (workerlimit <= 1)
            //{
            //    Console.WriteLine("limit en az 1 olmalidir");
            //}
            //else
            //{
            //    WorkerLimit = workerlimit;
            //}

            //if (salarylimit < 250)
            //{
            //    Console.WriteLine("limit en aza 250 olmalidir");

            //}
            //else
            //{
            //    SalaryLimit = salarylimit;
            //}


        }

        public void AddEmployee(Employee employee)
        {
            Array.Resize(ref Employee, Employee.Length + 1);
            Employee[Employee.Length - 1] = employee;
            Console.WriteLine("Isci elave edildi.");
        }

        public void GetEmployees(/*Employee employee*/)
        {
           foreach (var item in Employee)
            {
                Console.WriteLine($"{item.No} {item.FullName} {item.DepartmentName} {item.Salary} ");
            }
        }

        public  int CalcSalarySum()
        {

            /*= new Department();*/
            int sum = 0;
            foreach (var item in Employee)
            {
                if (item != null)
                {
                    sum = sum + item.Salary;
                }
            }
            return sum;
        }

        public int CalcSalaryAverage()
        {
            int sum = 0;
            int count = 0;
            foreach (var item in Employee)
            {
                if (item != null)
                {
                    int index = Array.IndexOf(Employee, item);
                    if (Employee[index] != null)
                    {
                        count++;
                    }
                    sum = (sum + item.Salary);
                }
                
            }
                    

            return sum / count;
            
            
        }
    }
}
