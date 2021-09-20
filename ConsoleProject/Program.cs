using System;
using ConsoleProject.models;
using ConsoleProject.enums;
using ConsoleProject.Services;

namespace ConsoleProject
{
    class Program
    {


        static void Main(string[] args)
        {
            HumanResourceManager humanservices = new HumanResourceManager();

            do
            {
                Console.WriteLine("1.1 Departameantlerin siyahisini gostermek");
                Console.WriteLine("1.2 Departamenet yaratmaq");
                Console.WriteLine("1.3 Department uzerinde duzelis et");
                Console.WriteLine("2.1 Iscilerin siyahisini gostermek");
                Console.WriteLine("2.2 Departamentdeki iscilerin siyahisini gostermek");
                Console.WriteLine("2.3 - Isci elave etmek");
                Console.WriteLine("2.4 - Isci uzerinde deyisiklik etmek");
                Console.WriteLine("2.5 - Departamentden isci silinmesi");




                string ans = Console.ReadLine();

                switch (ans)
                {
                    case "1.1":
                        GetDepartments(ref humanservices);
                        break;
                    case "1.2":
                        AddDepartment(ref humanservices);
                        break;
                    case "1.3":
                        EditDepartments(ref humanservices);
                        break;
                    case "2.1":
                        ShowEmployees(ref humanservices);
                        break;
                    case "2.2":
                        ShowEmployeesByDepartment(ref humanservices);
                        break;
                    case "2.3":
                        AddEmployee(ref humanservices);
                        break;
                    case "2.4":
                        EditEmployee(ref humanservices);
                        break;
                    case "2.5":
                        RemoveEmployee(ref humanservices);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Secdiyiniz emeliyyat movcud deyil, tekrar secin!!!");
                        break;
                }
            } while (true);

            // Department elave eden method
            static void AddDepartment(ref HumanResourceManager humanservices)
            {
            namelength:
                Console.WriteLine("Department adi:");
                string name = Console.ReadLine();
                //Eger daxil edilen department adi Departments arrayinde varsa bildiris cixarilir.
                foreach (Department item in humanservices.Departments)
                {
                    if (item.Name == name)
                    {
                        Console.WriteLine($"{item.Name} adli department artiq movcuddur");
                        return;
                    }
                }

                //Eger daxil edilen department 2 herfden azdirsa yeniden deyer istenir
                if (name.Length < 2)
                {
                    Console.WriteLine("En az iki herf qeyd edilmelidir.");
                    goto namelength;
                }
            First:
                Console.WriteLine("Isci limiti:");
                int workerlimit = int.Parse(Console.ReadLine());
                //minimum isci limiti
                if (workerlimit < 1)
                {
                    Console.WriteLine("en az 1 isci olmalidir");
                    goto First;
                }

            Second:
                Console.WriteLine("Maas limiti:");
                int salarylimit = int.Parse(Console.ReadLine());
                //minimum maas limiti
                if (salarylimit < 250)
                {
                    Console.WriteLine("En az 250 manat olmalidir");
                    goto Second;
                }

                humanservices.AddDepartments(name, workerlimit, salarylimit);
            }
            //Departmentlerin siyahisini elde eden method
            static void GetDepartments(ref HumanResourceManager humanservices)
            {
                //Konsolda hec bir department yoxdursa bildiris verilsin.
                if (humanservices.Departments.Length == 0)
                {
                    Console.WriteLine("Departament yaratdiqdan sonra yeniden cehd edin!");
                    return;
                }

                humanservices.GetDepartments();

            }
            //Departmenti deyisen method
            static void EditDepartments(ref HumanResourceManager humanservices)
            {
                if (humanservices.Departments.Length != 0)
                {
                    //oldname degisdirmek istediyimiz department.
                    Console.WriteLine("Degisdireceyiniz departmenti girin:");
                    string oldname = Console.ReadLine();
                    //newname degisdirecegimiz departmentin yeni adi.
                    Console.WriteLine("Yeni ad daxil et:");
                    string newname = Console.ReadLine();
                    foreach (var item in humanservices.Departments)
                    {
                        if (newname.ToLower() == item.Name.ToLower())
                        {
                            Console.WriteLine($"{item.Name} department artiq movcuddur");
                            return;
                        }
                        if (oldname.ToLower() == newname.ToLower())
                        {
                            Console.WriteLine("Yeni daxil edeceyiniz ad evvelki adla eynidir.");
                            return;
                        }
                    }
                    humanservices.EditDepartaments(oldname, newname);
                }
                else
                    Console.WriteLine("Ilk once Department yaradilmalidir!");
            }
            //Isci elave eden method
            static void AddEmployee(ref HumanResourceManager humanservices)
            {
                if (humanservices.Departments.Length != 0)
                {
                    int typeint;
                    string fullname;
                    do
                    {
                        Console.WriteLine("Ad ve Soyad girin:");

                        fullname = Console.ReadLine();

                    } while (int.TryParse(fullname, out typeint));
                    //Departments arrayindeki Departmentleri konsola cixaran alqoritm
                    for (int j = 0; j < humanservices.Departments.Length; j++)
                    {
                        Console.WriteLine($"{j + 1} - {humanservices.Departments[j].Name}");
                    }
                    string dprtStr;
                    int dprtInt;
                    //Secimin dogru olub olmadigini yoxlayan alqoritm
                    do
                    {
                        Console.WriteLine("elave edeceyiniz department");
                        dprtStr = Console.ReadLine();
                    } while (!int.TryParse(dprtStr, out dprtInt) || dprtInt <= 0 || dprtInt > humanservices.Departments.Length);

                    Console.WriteLine("Isci novleri:");
                    string[] typeNames = Enum.GetNames(typeof(PositionType));
                    //PositionType enum-undaki enumlari konsola cixaran alqoritm
                    for (int i = 0; i < typeNames.Length; i++)
                    {
                        Console.WriteLine($"{(i + 1)} - {typeNames[i]}");
                    }

                    string typeStr;
                    int typeInt;
                    //Secimin dogru olub olmadigini yoxlayan alqoritm
                    do
                    {
                        Console.WriteLine("Secim edin:");
                        typeStr = Console.ReadLine();
                    }
                    while (!int.TryParse(typeStr, out typeInt) || typeInt <= 0 || typeInt > typeNames.Length);
                    PositionType type = (PositionType)typeInt;


                start:
                    // isci maasi
                    Console.WriteLine("Maas:");
                    int salary = int.Parse(Console.ReadLine());
                    if (salary < 250)
                    {
                        Console.WriteLine("iscinin maasi 250-den asagi ola bilmez");
                        goto start;
                    }
                    humanservices.AddEmployee(fullname, type, salary, humanservices.Departments[dprtInt - 1]);
                }
                else
                    Console.WriteLine("Ilk once Department yarat");
            }
            //Iscinin maas ve vezifesini deyisen method.
            static void EditEmployee(ref HumanResourceManager humanservices)
            {
                if (humanservices.Departments.Length != 0)
                {
                    foreach (var item in humanservices.Departments)
                    {

                        if (item.Employee.Length != 0)
                        {
                            //Isci id si daxil edilir meselen : ID1001
                            Console.WriteLine("Isci nomresini daxil edin:");
                            string no = Console.ReadLine();
                            //Isci sahesi
                            Console.WriteLine("Pozisiyalar");
                            string[] typeName = Enum.GetNames(typeof(PositionType));
                            for (int i = 0; i < typeName.Length; i++)
                            {
                                Console.WriteLine($"{i + 1} {typeName[i]}");
                            }
                            string typeStr;
                            int typeInt;
                            //Yeni sahe ile evez olunur.
                            Console.WriteLine("Yeni Pozisiya secin");
                            typeStr = Console.ReadLine();

                            //Iscinin input-unun duzgunluyu yoxlanilir.
                            while (!int.TryParse(typeStr, out typeInt) || typeInt < 0 || typeInt > typeName.Length)
                            {
                                Console.WriteLine("Duzgun position daxil edin.");
                                typeStr = Console.ReadLine();
                            }
                            PositionType positionType = (PositionType)(typeInt);
                        Start:
                            //Yeni maas daxil edilir.
                            string salarystring;
                            int salary;
                            do
                            {
                                Console.WriteLine("Yeni Maas teyin edin:");
                                salarystring = Console.ReadLine();
                            } while (!int.TryParse(salarystring, out salary) || salary < 0);
                            if (salary < 250)
                            {
                                Console.WriteLine("minimum maas 250 olabilmez");
                                goto Start;
                            }
                            humanservices.EditEmployee(no, positionType, salary);
                        }
                        else
                            Console.WriteLine("Isci yoxdur.");
                    }
                }
                else
                {
                    Console.WriteLine("Department yoxdur.");
                }
            }
            //Butun iscileri ekrana cixaran
            static void ShowEmployees(ref HumanResourceManager humanservices)
            {
                //eger isci yoxdursa bildiris verilir.
                for (int i = 0; i < humanservices.Departments.Length; i++)
                {
                    if (humanservices.Departments[i].Employee.Length != 0)
                    {
                        for (int j = 0; j < humanservices.Departments[i].Employee.Length; j++)
                        {
                            if (humanservices.Departments[i].Employee[j] != null)
                            {
                                Console.WriteLine($"{i + 1} {humanservices.Departments[i].Employee[j].FullName} {humanservices.Departments[i].Employee[j].No} {humanservices.Departments[i].Employee[j].Salary} {humanservices.Departments[i].Employee[j].DepartmentName}");
                            }
                        }
                    }
                    else
                        Console.WriteLine("Isci teyin edilmeyib");
                }
            }
            //Departamentdeki iscileri ekrana cixaran.
            static void ShowEmployeesByDepartment(ref HumanResourceManager humanservices)
            {

                if (humanservices.Departments.Length > 0)
                {
                    for (int i = 0; i < humanservices.Departments.Length; i++)
                    {
                        Console.WriteLine($"{i + 1} {humanservices.Departments[i].Name}");
                    }
                    string stringj;
                    int j;
                    do
                    {
                        Console.WriteLine("Hansi departmentin iscileri: ");
                        stringj = Console.ReadLine();
                    } while (!int.TryParse(stringj, out j));
                    if (humanservices.Departments[j - 1].Employee.Length == 0)
                    {
                        Console.WriteLine("Isci teyin edilmeyib");
                    }

                    else
                    {
                        for (int a = 0; a < humanservices.Departments[j - 1].Employee.Length; a++)
                        {
                            if (j <= 0)
                            {
                                Console.WriteLine("Duzgun reqem daxil edin.");
                            }
                            if (humanservices.Departments[j - 1].Employee[a] != null)
                            {


                                Console.WriteLine($"{humanservices.Departments[j - 1].Employee[a].FullName} {humanservices.Departments[j - 1].Employee[a].No} {humanservices.Departments[j - 1].Employee[a].Salary} {humanservices.Departments[j - 1].Employee[a].Position}");
                            }
                        }
                    }
                    return;
                }
                Console.WriteLine("Sistemde hec bir department yoxdur.");
            }
            //Iscini silen method.
            static void RemoveEmployee(ref HumanResourceManager humanservices)
            {
                foreach (var item in humanservices.Departments)
                {
                    if (item.Employee.Length != 0)
                    {
                        Console.WriteLine("department adi:");
                        string name = Console.ReadLine();

                        Console.WriteLine("isci adini daxil et:");
                        string fullname = Console.ReadLine();

                        humanservices.RemoveEmployee(name, fullname);
                    }
                    else
                        Console.WriteLine("Isci yoxdur.");
                }
            }
        }

    }
}