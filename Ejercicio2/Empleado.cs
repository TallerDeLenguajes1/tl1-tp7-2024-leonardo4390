using System;
enum EstadoCivil
{
    Soltero,
    Casado,
    Viudo
}

enum Cargo
{
    Auxiliar,
    Administracion,
    Ingeniero,
    Especialista,
    Investigador
}
class Empleado
{
    private string nombre;
    private string apellido;
    private DateTime fechaDeNacimiento;
    private DateTime fechaDeIngreso;
    private double sueldoBasico;
    private Cargo cargo;
    private EstadoCivil estadoCivil;

    public Empleado(string nombre, string apellido, DateTime fechaDeNacimiento,EstadoCivil estadoCivil, DateTime fechaDeIngreso, double sueldoBasico, Cargo cargo)
    {
        this.nombre = nombre;
        this.apellido = apellido;
        this.fechaDeNacimiento = fechaDeNacimiento;
        this.estadoCivil = estadoCivil;
        this.fechaDeIngreso = fechaDeIngreso;
        this.sueldoBasico = sueldoBasico;
        this.cargo = cargo;
    }

    public string Nombre
    {
        get{return nombre;}
        set{nombre = value;}
    }

    public string Apellido
    {
        get{return apellido;}
        set{apellido = value;}
    }

    public DateTime FechaDeNacimiento
    {
        get{return fechaDeNacimiento;}
        set{fechaDeNacimiento = value;}
    }

    public DateTime FechaDeIngreso
    {
        get{return fechaDeIngreso;}
        set{fechaDeIngreso = value;}
    }

    public EstadoCivil EstadoCivil
    {
        get{return estadoCivil;}
        set{estadoCivil = value;}
    }

    public Cargo Cargo
    {
        get{return cargo;}
        set{cargo = value;}
    }

    public void MostrarDatosEmpleado()
    {
        Console.WriteLine("Nombre: " + nombre);
        Console.WriteLine("Apellido: " + apellido);
        Console.WriteLine("Fecna de Nacimiento: " + fechaDeNacimiento.ToString("d"));
        Console.WriteLine("Estado Civil: " + estadoCivil);
        Console.WriteLine("Fecna de Ingreso: " + fechaDeIngreso.ToString("d"));
        Console.WriteLine("Cargo del Empleado: " + cargo);
        Console.WriteLine("Sueldo Basico: $" + sueldoBasico);

        int antiguedad = Calculos.CalcularAntiguedad(fechaDeIngreso);
        int edad = Calculos.CalcularEdad(fechaDeNacimiento);
        int tiempoJuvilacion = Calculos.CalcularParaJubilarse(fechaDeNacimiento);
        double salario = CalcularSalario(antiguedad);

        Console.WriteLine("Antiguedad: " + antiguedad + " años");
        Console.WriteLine("Edad: " + edad + " años");
        Console.WriteLine("Años para juvilarse: " + tiempoJuvilacion + " años");
        Console.WriteLine("Salario: $" + salario);

        
    }

    public double CalcularAdicional(int antiguedad)
    {
        double adicional = 0;

        double porcentajeAntiguedad = CalcularPorcentajeAntiguedad(antiguedad);

        if (Cargo == Cargo.Ingeniero || Cargo == Cargo.Especialista)
        {
            porcentajeAntiguedad += porcentajeAntiguedad * 0.5;
        }

        if (EstadoCivil == EstadoCivil.Casado)
        {
            adicional += 150000;
        }

        adicional += sueldoBasico * porcentajeAntiguedad;

        return adicional;
    }

    public double CalcularPorcentajeAntiguedad(int antiguedad)
    {
        double porcentajeAntiguedad = 0;
        if (antiguedad <= 20)
        {
            porcentajeAntiguedad = antiguedad * 0.01;
        }
        else
        {
            porcentajeAntiguedad = 20 * 0.01 + (antiguedad - 20) * 0.0025;
        }
        return porcentajeAntiguedad;
    }

    public double CalcularSalario(int antiguedad)
    {
        double adicional = CalcularAdicional(antiguedad);
        return sueldoBasico + adicional;
    }

    public static double CalcularMontoTotalSalarios(Empleado[] empleados, int antiguedad)
    {
        double total = 0;
        foreach (var empleado in empleados)
        {
            total += empleado.CalcularSalario(antiguedad);
        }
        return total;
    }

    public static double CalcularMontoTotalSalarios(Empleado[] empleados)
    {
        double total = 0;
        foreach (var empleado in empleados)
        {
            int antiguedad = Calculos.CalcularAntiguedad(empleado.FechaDeIngreso);
            total += empleado.CalcularSalario(antiguedad);
        }
        return total;
    }
}