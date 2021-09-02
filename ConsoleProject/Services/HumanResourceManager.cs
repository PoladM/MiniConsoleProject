using System;
using System.Collections.Generic;
using System.Text;
using ConsoleProject.enums;
using ConsoleProject.Interface;
using ConsoleProject.models;

namespace ConsoleProject.Services
{
    class HumanResourceManager : IHumanResourceManager
    {
        private Department[] _departments;
        public HumanResourceManager()
        {
            _departments = new Department[0];
        }
        

        public Department[] Departments => _departments;
        // Department elave eden method
        public void AddDepartments(string name, int workerlimit, int salarylimit)
        {
            Department department = new Department(name, workerlimit, salarylimit);
            //Department arrayinden ref alib yeni bir index yaradib gelen melumatlari assign eden method.
            Array.Resize(ref _departments, _departments.Length + 1);
            _departments[_departments.Length-1] = department;
            Console.WriteLine($"{name} adli Department ugurla elave olundu!");
        }
        //Isci elave eden method
        public void AddEmployee(string fullname, PositionType positionType, int salary, Department departmentname)
        {

            //Her departmentde maksimum olabilecek isci ve maksimum verilecek maas.
            if (departmentname.WorkerLimit > departmentname.Employee.Length)
            {
                if (departmentname.SalaryLimit > departmentname.CalcSalarySum() + salary)
                {
                    Employee employee = new Employee(fullname, positionType, salary, departmentname);
                    departmentname.AddEmployee(employee);
                }
                else
                    Console.WriteLine("Maas limiti asilmisdir.");
                    
                
            }
            else
                Console.WriteLine("Isci limiti asilmisdir.");
        }

        //Departmenti deyisen method
        public void EditDepartaments(string oldName,string newName)
        {
            Department department = FindDepartmentByname(oldName);
            if (department == null)
            {
                Console.WriteLine($"{oldName} department tapilmadi");
                return;
            }
            foreach (var item in _departments)
            {
                if (item.Name.ToLower() == oldName.ToLower())
                {
                    if (item.Employee.Length != 0)
                    {
                        
                            foreach (var item1 in item.Employee)
                            {
                            if (item1 != null)
                                 {
                                     item1.No = item1.No.Replace(item1.No.Substring(0, 2), newName.Substring(0, 2).ToUpper());
                                     item1.DepartmentName = newName;
                                     item.Name = newName;
                                     Console.WriteLine($"Yeni departmenr adi: {item.Name} ");
                                 }
                            }
                        
                    }
                    else
                        Console.WriteLine("Isci yaradilmayib");
                }
            }
        }
        //Iscinin maas ve vezifesini deyisen method.
        public void EditEmployee(string no, PositionType position, int salary)
        {
            bool check = false;
            foreach (var item in _departments)
            {
                foreach (var item1 in item.Employee)
                {
                    if (item1 != null)
                    {
                        if (item1.No.ToUpper() == no.ToUpper())
                        {
                            if (item.SalaryLimit > salary + item.CalcSalarySum())
                            {
                                item1.Salary = salary;
                                item1.Position = position;
                                Console.WriteLine("Isci tapildi");
                                Console.WriteLine($"{item1.FullName} {item1.Salary} {item1.Position}");
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Limit asilmisdir.");
                                return;
                            }
                        }
                    }
                }
            }
            

            check = true;
            if (check == true)
            {
                Console.WriteLine("isci tapilmadi");
                return;
            }
        }
        //Departmentlerin siyahisini elde eden method
        public Department[] GetDepartments() //
        {
            // methodun return type-i Department tipinden arraydir.
                    if (_departments.Length != 0)
                    {
                        SumofEmployees();
                    }   
            return _departments;
        }
        //department,iscisayi,orta maas ekrana cixartmaq ucun method
        public void SumofEmployees()
        {
            int count = 0;
            foreach (var item in Departments)
            {
                foreach (var item1 in item.Employee)
                {
                    int index = Array.IndexOf(item.Employee, item1);
                    if (item.Employee[index] != null)
                    {
                        count++;
                    }
                }
                if (item.Employee.Length != 0)
                {
                    Console.WriteLine($"Department adi:{item.Name} Isci sayi:{count} Maas Ortalamasi: {item.CalcSalaryAverage()}");
                    count = 0;
                }
                else
                    Console.WriteLine("Isci elave edilmeyib.");
            }
        }
        //Iscini silen method.
        public void RemoveEmployee(string name, string fullname)
        {
            Department department = null;
            foreach (var item in _departments)
            {
                if (item.Name.ToLower() == name.ToLower())
                {
                    department = item;
                    break;
                }
            }
            Employee employee = null;
            if (department != null)
            {
                foreach (var item in department.Employee)
                {
                    if (item.FullName.ToLower() == fullname.ToLower())
                    {
                        employee = item;
                    }
                }
            }

            if (employee != null)
            {
                int index = Array.IndexOf(department.Employee, employee);
                Array.Clear(department.Employee, index, 1);
            }

        }

        //gelen adda department olub olmadigini yoxlayib geri qaytaran method
        public Department FindDepartmentByname(string name)
        {
            foreach (var item in _departments)
            {
                if (item.Name.ToLower() == name.ToLower())
                {
                    return item;
                }
            }
            return null;
        }

        
    }
}
