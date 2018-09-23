using Model;
using System;
using System.Linq;
namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            SchoolContext context = new SchoolContext();
            Int64 opcion =0;
            Int64 salir = 0;
            while (salir==0)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                context = new SchoolContext();
                Console.WriteLine("Bienvenido al sistema de prueba de ingreso para estudiantes");
                Console.WriteLine("Ver Alumnos (0) ");
                Console.WriteLine("Agregar Alumno (1) ");
                Console.WriteLine("Eliminar Alumno (2) ");
                Console.WriteLine("Cerrar Programa (3)");

                Int64.TryParse(Console.ReadLine(), out opcion);
                switch (opcion)
                {
                    case 0:
                        Console.WriteLine("Opcion 0 --------Ver lista de Alumnos --------- ");                    
                        PrintStudents(context);

                        break;
                    case 1:
                        Console.WriteLine("Opcion 1 -------- Agregar Alumno--------- ");
                        CreateStuden(context);
                    
                        break;
                    case 2:
                        Console.WriteLine("Opcion 2 -------- Eliminar Alumno --------- ");
                        DeleteStudent(context);
                        break;

                    case 3:
                        Console.WriteLine("Seguro que quieres salier de la app? Y/N");
                        string exit = Console.ReadLine().ToLower(); ;
                        if(exit=="y" || exit=="s")
                        {
                            salir = 1;
                        }

                        
                        break;
                    default:
                        Console.WriteLine("Opcion Invalida ");
                        break;
                }

             

            }

        }

        private static void  DeleteStudent(SchoolContext context)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            string nombre = "";
            while (true)
            {
                Console.WriteLine("Ingrese el nombre del estudiande a <<<<ELIMINAR>>>>");
                Console.WriteLine("Para Cancelar Precionar el 0");
                nombre = Console.ReadLine();
                if (nombre != "0")
                {

                    try
                    {
                        Student student2 = context.Students.SingleOrDefault(x => x.Name == nombre);
                        context.Students.Remove(student2);
                        context.SaveChanges();
                    }
                    catch { }
                    PrintStudents(context);
                }
                else { break; }
            }


        }

        private static void CreateStuden(SchoolContext context)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            string nombre = "";
            while (true)
            {
                Console.WriteLine("Ingrese el nombre del estudiande a <<<<INSERTAR>>>>");
                Console.WriteLine("Para Cancelar Precionar el 0");
                nombre = Console.ReadLine();

                if (nombre != "0")
                {
                    Student std = new Student() { Name = nombre };
                    context.Students.Add(std);
                    context.SaveChanges();

                    PrintStudents(context);
                }
                else { break; }

            }

            
 
        }

        private static void PrintStudents(SchoolContext context)
        {
            Console.WriteLine("");
            Console.WriteLine("");

            System.Collections.Generic.List<Student> student = context.Students.ToList();
            Console.WriteLine("Hay {0} estudiantes en total", student.Count);
            Console.WriteLine("---------------------------------------------------------");
            foreach (Student st in student)
            {
              
                Console.WriteLine("| El estudiante {0} es {1} ", st.StudentId.ToString(), st.Name);
       
            }
            Console.WriteLine("---------------------------------------------------------");
        }
    }
}
