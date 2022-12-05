using System;
using System.Collections.Generic;
using System.Text;

namespace ListasEnlazadas
{
    class CListasEnlazadas
    {
        //es el encabezado o "head"
        private CNodo ancla; //cabeza
        private CNodo cola; //cola

        public void Agregar(int pValor) { // si la lista esta vacia se agrega una cabeza 
            if(estaVacia() == true) {
                ancla = new CNodo(pValor);
                cola = ancla;
                return;
            }

            CNodo nodoActual = ancla;
            while (nodoActual.siguiente != null) {
                nodoActual = nodoActual.siguiente; // si el nodo actual no es nulo se brinca al siguiente
            }
            nodoActual.siguiente = new CNodo(pValor); // sze busca el siguiente null para poder agregar el siguiente nodo
            cola = nodoActual.siguiente;
        }


        public void Borrar(int pValor) {
            if (estaVacia() == true)
                return; // no puede borrar nada porque ya esta vacia

            bool banderaBusqueda = false; //ubicar el numero que estamos bucando
            CNodo nodoAnterior = null; //pasado
            CNodo NodoActual = ancla; //actual
            while (true) {
                if (NodoActual.Dato == pValor){
                    banderaBusqueda = true;
                    break; //intercambia el pasado y el actual, siempre ciclan el break para en el num cuando ya se encontro
                }
                else {
                    nodoAnterior = NodoActual; 
                    NodoActual = NodoActual.siguiente;//intercambia entre actual y pasado
                }
            }

            if (banderaBusqueda == true) {
                nodoAnterior.siguiente = NodoActual.siguiente;
            }
        }

        public void Imprimir() {
            if (estaVacia() == true)
                return;

            CNodo nodoActual = ancla;
            while (nodoActual != null) {
                Console.WriteLine(nodoActual.ToString());
                nodoActual = nodoActual.siguiente; //busca si hay coordenadas para imprimir el siguiente numero y va ciclando cuando no hay es null y deja de imprimir
            }
        }

        public bool estaVacia()
        {
            if (ancla == null){
                return true;
            }
            else{
                return false;
            }
        }

        public void borrarCola() {
            if (estaVacia() == true) //Revisa si la lista esta vacia
                return;

            CNodo nodoActual = ancla; 
            while (nodoActual != null){ 
                if (nodoActual.siguiente == cola) { //Cicla entre nodos hasta encontrar la cola
                    Console.WriteLine("La cola {0} ha sido eliminada, la nueva cola es {1}", cola.Dato, nodoActual.Dato);
                    nodoActual.siguiente = null; //Borras la cola
                    cola = nodoActual; //La nueva cola es el nodo actual
                    break;
                }
                nodoActual = nodoActual.siguiente; //Cambia nodo actual al siguiente nodo
            }
        }
    }
}
