
using Ludwig.Data.DTO;
using Ludwig.Data.Extensions;
using Ludwig.Data.Interfaces;
using Ludwig.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Ludwig.Data.Services;

public class ServizioDatiPrenotazione : IDatiPrenotazione
{

    public ServizioDatiPrenotazione(BookingSystemContext database)
    {
        Database = database;
    }

    public BookingSystemContext Database { get; }

    public Task CreaPrenotazioneAsync(PrenotazioneCreaDTO prenotazione)
    {
        throw new NotImplementedException();
    }

    public Task EliminaPrenotazioneAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task ModificaPrenotazioneAsync(PrenotazioneAggiornaDTO prenotazione)
    {
        throw new NotImplementedException();
    }

    public async Task<PrenotazioneDTO?> EstraiPerIdAsync(int id)
    {
        return await Database.Prenotazione
            .Include(p => p.UtenteId)
            .Include(p => p.Risorsa)
            .Select(p => p.ToDTO())
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<PrenotazioneDTO>?> EstraiTutteAsync()
    {
        return await Database.Prenotazione
            .Include(p => p.UtenteId)
            .Include(p => p.Risorsa)
            .Select(p => p.ToDTO())
            .ToListAsync();

    }
}
