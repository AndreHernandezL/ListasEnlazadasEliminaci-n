using System.Diagnostics.Eventing.Reader;

namespace OperacionesEliminacioListasEnlazadas.Components.Services
{
    public class ListaEnlzada
    {
        public Nodo PrimerNodo;

        public Nodo UltimoNodo;

        Nodo NuevoNodo;

        public int TotalNodos;

        public ListaEnlzada()
        {
            PrimerNodo = null;
            UltimoNodo = null;
            TotalNodos = 0;
        }

        public string EliminarAlInicio()
        {
            if (PrimerNodo == UltimoNodo)
            {
                PrimerNodo = UltimoNodo = null;
            }
            else
            {
                Nodo NodoAuxiliar;
                NodoAuxiliar = PrimerNodo;

                //Ligar el segunto nodo como primer nodo

                PrimerNodo = PrimerNodo.Liga;

                NodoAuxiliar = null;
                TotalNodos--;
            }
            return "Elemento eliminado";
        }
        public string EliminarAlFinal()
        {
            if (PrimerNodo == UltimoNodo)
            {
                PrimerNodo = UltimoNodo = null;
            }
            else
            {
                Nodo NodoActual;
                Nodo NodoSiguiente;

                NodoActual = PrimerNodo;
                NodoSiguiente = NodoActual.Liga;
                
                while (NodoSiguiente.Liga != null)
                {
                    NodoActual = NodoActual.Liga;
                    NodoSiguiente = NodoActual.Liga;
                }
                NodoSiguiente = null;
                NodoActual.Liga = null;
                UltimoNodo = NodoActual;
            }
            TotalNodos--;
            return "Elemento eliminado";
        }
        public string EliminarDespuesX(int id)
        {
            Nodo NodoActual = PrimerNodo;
            Nodo NodoSiguiente = PrimerNodo.Liga;

            bool bandera = false;

            while (NodoActual != null)
            {
                if (id != NodoActual.persona.GetId())
                {
                    NodoSiguiente = NodoActual.Liga;
                }
                else
                {
                    bandera = true;
                    break;
                }
                NodoActual = NodoActual.Liga;
            }

            if (bandera)
            {
                if(NodoActual == UltimoNodo)
                {
                    return "No se puede eliminar despues del ultimo elemento";
                }
                if (NodoActual.Liga == UltimoNodo)
                {
                    EliminarAlFinal();
                }
                else
                {
                    Nodo NodoAuxiliar = NodoSiguiente;
                    NodoActual.Liga = NodoSiguiente.Liga;
                    NodoAuxiliar = null;
                    TotalNodos--;
                }
                return "Persona eliminada";
            }
            else
            {
                return $"La persona no fue encontrada";
            }
        }

        
        public string EliminarAntesX(int id)
        {
            Nodo NodoActual = PrimerNodo;
            Nodo NodoAnterior = PrimerNodo;
            bool bandera = false;

            if (NodoActual.persona.GetId() == id)
            {
                return "No se puede eliminar antes de la primera persona";
            }

            while (NodoActual.Liga != null)
            {
                if (!(NodoActual.Liga.persona.GetId() == id))
                {
                    NodoAnterior = NodoActual;
                    NodoActual = NodoActual.Liga;
                }
                else
                {
                    bandera = true;
                    break;
                }
            }

            if (bandera)
            {
                if (NodoAnterior == PrimerNodo)
                {
                    EliminarAlInicio();
                }
                else
                {
                    Nodo NodoAuxiliar = NodoActual;
                    NodoAnterior.Liga = NodoActual.Liga;
                    NodoAuxiliar = null;
                    TotalNodos--;
                }
                return "Persona eliminado";
            }
            else
            {
                return $"El id de la persona {id} no fue encontrado";
            }
        }

        public string EliminarPoscision(int posicion)
        {
            Nodo NodoActual = PrimerNodo;

            if (posicion <= TotalNodos && posicion >= 1)
            {
                if (posicion == 1)
                {
                    EliminarAlInicio();
                }
                else if (posicion == TotalNodos)
                {
                    EliminarAlFinal();
                }
                else
                {
                    int contador = 1;

                    while (NodoActual != null)
                    {
                        if (contador == posicion - 1)
                        {
                            //creamos el nuevo nodo.
                            Nodo NodoAuxiliar = NodoActual.Liga;
                            NodoActual.Liga = NodoActual.Liga.Liga;
                            NodoAuxiliar = null;
                            TotalNodos--;
                            break;
                        }

                        contador++;
                        NodoActual = NodoActual.Liga;
                    }
                }
                return "Persona eliminado";
            }
            else
            {
                return "La posición ingresada no es valida";
            }
        }
    }
}
