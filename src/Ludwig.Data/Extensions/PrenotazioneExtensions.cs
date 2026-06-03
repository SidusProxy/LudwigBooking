using Ludwig.Data.DTO;
using Ludwig.Data.Models;

namespace Ludwig.Data.Extensions;

public static class PrenotazioneExtensions
{
    public static PrenotazioneDTO? ToDTO(this Prenotazione p)
    {
        return new PrenotazioneDTO(p.Id,p.RisorsaId,p.UtenteId,p.DottoreId,p.Da,p.A,p.Stato);
    }
}

