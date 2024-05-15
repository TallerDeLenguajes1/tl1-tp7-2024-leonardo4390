using System;
public class Calculadora{
    private double numero1,numero2;

    public void Sumar(double numero1,double numero2)
    {
        Console.WriteLine("\nSuma: " + (numero1 + numero2));
    }

    public void Restar(double numero1,double numero2)
    {
        Console.WriteLine("\nResta: " + (numero1 - numero2));
    }

    public void Multiplicar(double numero1,double numero2)
    {
        Console.WriteLine("\nMultiplicacion: " + (numero1 * numero2));

    }

    public void Dividir(double numero1,double numero2)
    {
        Console.WriteLine("\nDivision: " + (numero1 / numero2));
    }

    public void Resultado(){
        int opcion = -1;
        while (opcion !=0)
        {
            Console.WriteLine("***MENU***");
            Console.WriteLine("1 - Suma");
            Console.WriteLine("2 - Resta");
            Console.WriteLine("3 - Multiplicacion");
            Console.WriteLine("4 - Division");
            Console.WriteLine("0 - Salir");
            opcion = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese un numero");
            double numero = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Ingrese otro numero");
            double numero2 = Convert.ToDouble(Console.ReadLine());
            
            switch (opcion)
            {
                case 1: Sumar(numero,numero2);
                    break;
                case 2: Restar(numero,numero2);
                    break;
                case 3: Multiplicar(numero,numero2);
                    break;
                case 4: Dividir(numero,numero2);
                    break;
                case 0: Console.WriteLine("Finalizar programa ...");
                    break;
                default:Console.WriteLine("Opcion incorrecata");
                    break;
            }
           

        }
    }

    public static void Main(String[] args)
    {
        Calculadora calculadora = new Calculadora();
        calculadora.Resultado();

        
    }
}