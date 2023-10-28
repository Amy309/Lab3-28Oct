using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using laboratorio3;

class Program
{
    static void Main()
    {
        using (var contextdb = new ContextDB())
        {
            bool Continuar = true;
            while (Continuar)
            {
                Console.WriteLine("Menu:\n");
                Console.WriteLine("1 Insertar Datos");
                Console.WriteLine("2 Modificar Datos");
                Console.WriteLine("Al final saldran los datos ingresados o Modificados");

                int op1 = Convert.ToInt32(Console.ReadLine());

                switch (op1)
                {
                    case 1:
                        contextdb.Database.EnsureCreated();

                        Student asignaturas = new Student();

                        Console.WriteLine("Ingrese el Nombre: ");
                        asignaturas.nombre = Console.ReadLine();

                        Console.WriteLine("");

                        Console.WriteLine("Ingrese las Unidades Valorativas: ");
                        asignaturas.unidadesValorativas = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("");

                        Console.WriteLine("Ingrese el Ciclo: ");
                        asignaturas.ciclo = Console.ReadLine();

                        Console.WriteLine("");

                        Console.WriteLine("Ingrese los que estan inscritos: ");
                        asignaturas.inscritos = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("");

                        contextdb.Add(asignaturas);
                        contextdb.SaveChanges();

                        Console.WriteLine("Datos Agregados.");
                        break;

                    case 2:
                        Console.WriteLine("Ingrese el Id del registro que desea Actualizar");
                        var id = Console.ReadLine();
                        var registro = contextdb.asignaturas.FirstOrDefault(p => p.id == Int32.Parse(id));

                        if (registro != null)
                        {
                            Console.WriteLine("Ingresar el numero 1 para actualizar el nombre");

                            int op = Convert.ToInt32(Console.ReadLine());
                            switch (op)
                            {

                                case 1:
                                    Console.WriteLine("Ingrese el nuevo Nombre: ");
                                    registro.nombre = Console.ReadLine();
                                    Console.WriteLine("Datos Actualizados.");
                                    break;

                            }
                            contextdb.SaveChanges();
                        }
                        else
                        {
                            Console.WriteLine("No se encontro ese registro");
                        }
                        break;
                }
                Console.WriteLine("¿Desea continuar? Ingresar (S) o (N)");
                var cont = Console.ReadLine();
                if (cont.Equals("N"))
                {
                    Continuar = false;
                }

            }
            Console.WriteLine("Lista\n");

            foreach (var s in contextdb.asignaturas)
            {
                Console.WriteLine($"Nombre: {s.nombre}, Unidades: {s.unidadesValorativas}, Ciclo: {s.ciclo}, inscritos: {s.inscritos}");
            }

        }
    }
}