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

        public bool EstaVacia()
        {
            return PrimerNodo == null ? true : false;
        }
        public string AgregarNodoAlInicio(Persona informacion)
        {
            NuevoNodo = new Nodo(informacion);

            if (EstaVacia())
            {
                UltimoNodo = NuevoNodo;
            }
            else
            {
                NuevoNodo.Liga = PrimerNodo;
            }

            PrimerNodo = NuevoNodo;
            TotalNodos++;

            return $"Se ha agregado a la persona:{informacion.GetNombre()} al incio de la lista";
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

        public string EliminarAntesPosicion(int posicion)
        {
            Nodo NodoActual = PrimerNodo;
            Nodo NodoAnterior = PrimerNodo;
            bool bandera = false;
            int contador = 1;

            if (contador == posicion)
            {
                return "No se puede eliminar antes de la primera posicion";
            }

            while (NodoActual.Liga != null)
            {
                if (contador != posicion)
                {
                    NodoAnterior = NodoActual;
                    NodoActual = NodoActual.Liga;
                }
                else
                {
                    bandera = true;
                    break;
                }
                contador++;
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
                return $"la posocion {posicion} no fue encontrada";
            }
        }

        public string EliminarDespuesPosicion(int posicion)
        {
            Nodo NodoActual = PrimerNodo;
            Nodo NodoSiguiente = PrimerNodo.Liga;

            bool bandera = false;
            int contador = 1;
            while (NodoActual != null)
            {
                if (posicion != contador)
                {
                    NodoSiguiente = NodoActual.Liga;
                }
                else
                {
                    bandera = true;
                    break;
                }
                NodoActual = NodoActual.Liga;
                contador++;
            }

            if (bandera)
            {
                if (NodoActual == UltimoNodo)
                {
                    return "No se puede eliminar despues de la ultima posicion";
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
                return $"La posicion no fue encontrada";
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

        public string EliminarDato(int id)
        {
            Nodo NodoActual = PrimerNodo;
            Nodo NodoAnterior = PrimerNodo;

            if (NodoActual.persona.GetId() == id)
            {
                EliminarAlInicio();
            }
            else
            {
                while (NodoActual != null)
                {
                    if (id == NodoActual.persona.GetId())
                    {
                        //creamos el nuevo nodo.
                        Nodo NodoAuxiliar = NodoActual;
                        NodoAnterior.Liga = NodoActual.Liga;
                        NodoAuxiliar = null;
                        TotalNodos--;
                        break;
                    }
                    NodoAnterior = NodoActual;
                    NodoActual = NodoActual.Liga;
                }
            }
            return "Persona eliminada";
            
        }

        public string OrdenarLista()
        {
            Persona Auxiliar;

            if (EstaVacia() == false)
            {
                if (PrimerNodo.Liga != null)
                {
                    Nodo NodoAnterior = PrimerNodo;
                    Nodo NodoActual = PrimerNodo.Liga;

                    while (NodoActual != null)
                    {
                        if (NodoAnterior.persona.GetId() > NodoActual.persona.GetId())
                        {
                            Auxiliar = NodoActual.persona;
                            NodoActual.persona = NodoAnterior.persona;
                            NodoAnterior.persona = Auxiliar;

                            if (NodoActual == PrimerNodo.Liga)
                            {
                                NodoAnterior = NodoActual;
                                NodoActual = NodoActual.Liga;
                            }
                            else
                            {
                                NodoAnterior = PrimerNodo;
                                NodoActual = PrimerNodo.Liga;
                            }
                        }
                        else
                        {
                            NodoAnterior = NodoActual;
                            NodoActual = NodoActual.Liga;
                        }
                    }
                }
                else
                {
                    return "La lista ya esta ordenada";
                }
            }
            else
            {
                return "La lista esta vacía";
            }

            return "La lista fue ordenada de manera desendete";

        }

        public string RecorridoRecursivo(Nodo NodoActual, int contador)
        {
            if (NodoActual == null)
            {
                return "";
            }
            else
            {
                return $"({contador++}) -> [{NodoActual.persona.GetId()}]: {NodoActual.persona.GetNombre()} |" + RecorridoRecursivo(NodoActual.Liga, contador);
            }
        }
    }
}
