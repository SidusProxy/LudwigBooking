
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

    public async Task<PrenotazioneDTO> CreaPrenotazioneAsync(PrenotazioneCreaDTO prenotazione)
    {
        var tmpPrenotazione = prenotazione.FromDTO();
        Database.Prenotazione.Add(tmpPrenotazione);
        await Database.SaveChangesAsync();
        return tmpPrenotazione.ToDTO();
    }

    public async Task<bool> EliminaPrenotazioneAsync(int id)
    {
        var prenotazione = Database.Prenotazione
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync();
        if (prenotazione == null)
            return false;
        Database.Prenotazione.Remove(new Prenotazione() { Id = id });
        await Database.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ModificaPrenotazioneAsync(PrenotazioneAggiornaDTO prenotazione)
    {
        var prenotazioneDB = prenotazione.FromDTO();
        var prenotazioneTmp = Database.Prenotazione
            .Where(p => p.Id == prenotazioneDB.Id)
            .FirstOrDefaultAsync();
        if (prenotazioneTmp == null)
            return false;
        Database.Prenotazione.Update(prenotazioneDB);
        Database.SaveChangesAsync();
        return true;
    }

    public async Task<PrenotazioneDTO?> EstraiPerIdAsync(int id)
    {
        return await Database.Prenotazione
             .Include("Utente")
            .Include("Risorsa")
            .Select(p => p.ToDTO())
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<PrenotazioneDTO>?> EstraiTutteAsync()
    {
        return await Database.Prenotazione
            .Include("Utente")
            .Include("Risorsa")
            .Select(p => p.ToDTO())
            .ToListAsync();

    }

    public async Task<IEnumerable<PrenotazioneDTO>?> EstraiTutteUserIdAsync(int id)
    {
        return await Database.Prenotazione
                    .Include("Utente")
                    .Include("Risorsa")
                   .Select(p => p.ToDTO())
                   .Where(p => p.UtenteId == id)
                   .ToListAsync();
    }
}
