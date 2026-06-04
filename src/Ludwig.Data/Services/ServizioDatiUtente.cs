using Ludwig.Data.Interfaces;
using Ludwig.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace Ludwig.Data.Services;

public class ServizioDatiUtenti : IDatiUtenti
{
    public ServizioDatiUtenti(BookingSystemContext database)
    {
        Database = database;
    }

    public BookingSystemContext Database { get; }

    public async Task<UtenteDTO?> EstraiUtente(string email, string pass)
    {
        return await Database.Utente.Where(u => u.Email == email && u.Pass == pass).Select(u => new UtenteDTO(u.Id, u.Email, u.Pass, u.Ruolo)).FirstOrDefaultAsync();
    }
}