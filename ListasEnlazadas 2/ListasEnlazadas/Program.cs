using System;

namespace ListasEnlazadas
{
    class Program  //aqui se llaman a las funciones en el CListasEnlazadas y se imprime
    {
        static void Main(string[] args)
        {
            //se crea una instancia
            CListasEnlazadas miLista = new CListasEnlazadas();  // se cra la lista

            //Revisar Contenidos
            Console.WriteLine("¿Lista vacia? {0}", miLista.estaVacia()); //busca lo que tenga la funcion esta vacia
            Console.ReadLine();

            //Agregar
            Console.WriteLine("Agregar");
            miLista.Agregar(3);
            miLista.Agregar(5);
            miLista.Agregar(7);
            miLista.Agregar(9);
            miLista.Agregar(11);
            miLista.Agregar(15);
            miLista.Agregar(19);
            miLista.Imprimir(); // se imprime todo lo que este en la variable milista 
            Console.ReadLine(); 

            //Borrar
            Console.WriteLine("Borrar");
            miLista.Borrar(7); //se elige cual numero se borra
            miLista.Imprimir();
            Console.ReadLine();

            //Revisar Contenidos
            Console.WriteLine("¿Lista vacia? {0}", miLista.estaVacia());
            Console.ReadLine();

            miLista.borrarCola();
            miLista.Imprimir();
            Console.ReadLine();

        }
    }
}
