namespace OperacionesEliminacioListasEnlazadas.Components.Services
{
    public class Persona
    {
        int id;
        string nombre;

        public Persona(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
        
        public int GetId()
        {
            return id;
        }
        public string GetNombre()
        {
            return nombre;
        }

    }
}
