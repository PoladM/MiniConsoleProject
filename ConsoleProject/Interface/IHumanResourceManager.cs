using System;
using System.Collections.Generic;
using System.Text;
using ConsoleProject.models;
using ConsoleProject.enums;

namespace ConsoleProject.Interface
{
    interface IHumanResourceManager
    {
        public Department[] Departments { get; }
        public void AddDepartments(string name, int workerlimit,int salarylimit);
        public Department[] GetDepartments(/*Department[] departments*/);
        public void EditDepartaments(string oldName,string newName);
        public void AddEmployee(string fullname, PositionType position, int salary, Department departmentname);
        public void RemoveEmployee(string name, string fullname); 
        public void EditEmployee(string no,PositionType position, int salary);


    }
}
