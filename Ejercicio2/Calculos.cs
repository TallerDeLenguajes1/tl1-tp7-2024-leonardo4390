//calculos
using System;
class Calculos
{
    public static int CalcularAntiguedad(DateTime fechaDeIngreso)
    {
        TimeSpan antiguedad = DateTime.Now - fechaDeIngreso;
        return (int)(antiguedad.Days / 365.25);
    }
    //calculo de edad

    public static int CalcularEdad(DateTime fechaDeNacimiento)
    {
        TimeSpan edad = DateTime.Now - fechaDeNacimiento;
        return (int)(edad.Days / 365.25);
    }

    //calculos para juvilarse
    public static int CalcularParaJubilarse(DateTime fechaDeNacimiento)
    {
        int edad = CalcularEdad(fechaDeNacimiento);
        return 65 - edad;
    }
}