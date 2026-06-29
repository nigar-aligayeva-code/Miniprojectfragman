using System;
using MiniProject2.DAL;
using MiniProject2.Services;
using Microsoft.EntityFrameworkCore;

AppDbContext context = new AppDbContext();
context.Database.Migrate();

DepartmentService deptService = new DepartmentService(context);
EmployeeService empService = new EmployeeService(context, deptService);

while (true)
{
    Console.Clear();
    Console.WriteLine("===== MENU =====");
    Console.WriteLine("1) Yeni sobe elave et");
    Console.WriteLine("2) Yeni isci elave et");
    Console.WriteLine("3) Butun sobeleri goster");
    Console.WriteLine("4) Butun iscileri goster");
    Console.WriteLine("0) Cixis");
    Console.Write("Seciminiz: ");

    switch (Console.ReadLine())
    {
        case "1": Console.Clear(); deptService.Add(); break;
        case "2": Console.Clear(); empService.Add(); break;
        case "3": Console.Clear(); deptService.ShowAll(); Pause(); break;
        case "4": Console.Clear(); empService.ShowAll(); Pause(); break;
        case "0": Console.Clear(); return;
        default: Console.WriteLine("Yanlish secim!"); Pause(); break;
    }
}

void Pause()
{
    Console.WriteLine("\nMenuya qayitmaq ucun Enter basin...");
    Console.ReadLine();
}