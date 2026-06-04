
using Ludwig.Data.DTO;

namespace Ludwig.Data.Interfaces;

public interface IDatiUtenti
{
    Task<UtenteDTO?> EstraiUtente(string email,string pass);

}
