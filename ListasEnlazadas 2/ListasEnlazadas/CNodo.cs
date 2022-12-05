using System;
using System.Collections.Generic;
using System.Text;

namespace ListasEnlazadas
{
    public class CNodo
    {

        
        //el dato que guarda el nodo
        public int Dato { get; set; }
        //variable de referencia que apunta al nodo siguiente
        public CNodo siguiente { get; set; } 

        public CNodo(int valor) {
            Dato = valor;
            siguiente = null;
        }

        public override string ToString()
        {
            return string.Format("[{0}]", Dato);
        } //todo lo que hace este metodo es cambiar el formato para imprimir
    }
}

