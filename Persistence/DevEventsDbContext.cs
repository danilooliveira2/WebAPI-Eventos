using WebAPI_Aprendizado.Models;

namespace WebAPI_Aprendizado.Persistence
{
    public class DevEventsDbContext
    {
        //Apenas para poder ficar atualizado esse dado em memória


        public List<DevEvent> DevEvents { get; set; }

        public DevEventsDbContext()
        {
            DevEvents = new List<DevEvent>();
        }

    }
}
