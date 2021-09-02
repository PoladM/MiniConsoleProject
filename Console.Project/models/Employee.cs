using System;
using System.Collections.Generic;
using System.Text;
using ConsoleProject.enums;
using ConsoleProject.Interface;

namespace ConsoleProject.models
{
    class Employee 
    {
        private static int count = 1000;
        public string No;
        public string FullName;

        public PositionType Position;

        public int Salary;
        public string DepartmentName;
        //private Department departmentname;
        //private PositionType positionType;
        public Employee( string fullname, PositionType position, int salary, Department departmentname)
        {
            count++;
            FullName = fullname;
            Position = position;
            Salary = salary;
            DepartmentName = departmentname.Name;
            No = departmentname.Name.Substring(0, 2).ToUpper() + count;
        }
        #region
        //public Employee(string fullname, PositionType positionType, int salary, Department departmentname)
        //{
        //    FullName = fullname;
        //    this.positionType = positionType;
        //    Salary = salary;
        //    this.departmentname = departmentname;
        //}

        //public Employee(string no, string fullname, PositionType position, int salary, Department departmentname)
        //{
        //    No = no;
        //    FullName = fullname;
        //    Position = position;
        //    Salary = salary;
        //    this.departmentname = departmentname;
        //}


        //public Employee(DepartmentsType departmentsType)
        //{
        //    count++;

        //    switch (departmentsType)
        //    {
        //        case DepartmentsType.Marketing:
        //            No = "MA" + count;
        //            break;
        //        case DepartmentsType.Finance:
        //            No = "FI" + count;
        //            break;
        //        case DepartmentsType.Sales:
        //            No = "SA" + count;
        //            break;
        //        default:
        //            break;
        //    }


        //}
        #endregion

        

    }
}
