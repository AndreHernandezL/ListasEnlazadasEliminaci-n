namespace OperacionesEliminacioListasEnlazadas.Components.Services
{
    public class Nodo
    {
        public Persona persona;
        public Nodo Liga;

        public Nodo()
        {
            persona = null;
            Liga = null;
        }

        public Nodo(Persona informacion)
        {
            persona = informacion;
            Liga = null;
        }

        public Nodo(Persona informacion, Nodo liga)
        {
            persona = informacion;
            Liga = liga;
        }

    }
}
