
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

    public async Task CreaPrenotazioneAsync(PrenotazioneCreaDTO prenotazione)
    {
        Database.Prenotazione.Add(prenotazione.FromDTO());
        await Database.SaveChangesAsync();
    }

    public async Task EliminaPrenotazioneAsync(int id)
    {
        Database.Prenotazione.Remove(new Prenotazione() { Id = id });
        await Database.SaveChangesAsync();
    }

    public Task ModificaPrenotazioneAsync(PrenotazioneAggiornaDTO prenotazione)
    {
       var prenotazioneDB = prenotazione.FromDTO();
        Database.Prenotazione.Update(prenotazioneDB);
        return Database.SaveChangesAsync();
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

    public async Task<IEnumerable<PrenotazioneDTO>?> EstraiTutteUserIdAsync(int id)
    {
        return await Database.Prenotazione
                   .Include(p => p.UtenteId)
                   .Include(p => p.Risorsa)
                   .Select(p => p.ToDTO())
                   .Where(p => p.UtenteId == id)
                   .ToListAsync();
    }
}
