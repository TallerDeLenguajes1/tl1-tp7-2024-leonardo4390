using System;

/*sistema de administracion del personal de una empresa*/
class Program
{


    public static void Main()
    {
        Empleado[] empleados = new Empleado[3];
        DateTime fechaIngreso;

        //cargar empleados
        Console.WriteLine("\n************CARGAR DATOS************\n");
        for (int i = 0; i <empleados.Length; i++)
        {
            Console.WriteLine($"Empleado: {i + 1}");
            Console.WriteLine("Ingrese el Nombre");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el Apellido");
            string apellido = Console.ReadLine();

            Console.WriteLine("Ingrese la Fecha de Nacimiento (dd/mm/yyyy)");
            DateTime fechaNacimiento = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el Estado Civil (Soltero/Casado/Viudo)");
            EstadoCivil estadoCivil = (EstadoCivil)Enum.Parse(typeof(EstadoCivil),Console.ReadLine(),true);

            Console.WriteLine("Ingrese la Fecha de Ingreso del Empleado (dd/mm/yyyy)");
            fechaIngreso = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el Cargo del Empleado (Auxiliar/Administracion/Ingeniero/Especialista/Investigador)");
            Cargo cargo = (Cargo)Enum.Parse(typeof(Cargo),Console.ReadLine(),true);
            
            Console.WriteLine("Ingrese el Sueldo Basico del Empleado");
            double sueldo = Convert.ToDouble(Console.ReadLine());

            empleados[i] = new Empleado(nombre,apellido,fechaNacimiento,estadoCivil,fechaIngreso,sueldo,cargo);
            Console.WriteLine();
            
        }
        Console.WriteLine("\n--------------DATOS EMPLEADOS------------\n");
        foreach (var empleado in empleados)
        {
            
            empleado.MostrarDatosEmpleado();
            Console.WriteLine();
        }

        //total salario obtenido en el arreglo
        Console.WriteLine("\n----------------------------------------------\n");
        double totalSalarios = Empleado.CalcularMontoTotalSalarios(empleados);
        Console.WriteLine($"\nTotal pagado en concepto de salarios: ${totalSalarios}");
        //proximo a juvilarse
        Empleado proximoJubilado = empleadoProximoAJubilarse(empleados);
        Console.WriteLine("\n************ EMPLEADO A JUBILARSE ************\n");
        proximoJubilado.MostrarDatosEmpleado();
        
    }

    public static Empleado empleadoProximoAJubilarse(Empleado[] empleados)
    {
        Empleado proximoJubilado = empleados[0];
        int menorTiempoParaJubilacion = Calculos.CalcularParaJubilarse(proximoJubilado.FechaDeNacimiento);

        foreach (var empleado in empleados)
        {
            int tiempoParaJubilacion = Calculos.CalcularParaJubilarse(empleado.FechaDeNacimiento);
            if (tiempoParaJubilacion < menorTiempoParaJubilacion)
            {
                menorTiempoParaJubilacion = tiempoParaJubilacion;
                proximoJubilado = empleado;
            }
        }

        return proximoJubilado;
    }
}