
using Ludwig.Data.DTO;

namespace Ludwig.Data.Interfaces;
public interface IDatiPrenotazione
{
    Task<IEnumerable<PrenotazioneDTO>?> EstraiTutteAsync();
    Task<IEnumerable<PrenotazioneDTO>?> EstraiTutteUserIdAsync(int id);
    Task CreaPrenotazioneAsync(PrenotazioneCreaDTO prenotazione);
    Task ModificaPrenotazioneAsync(PrenotazioneAggiornaDTO prenotazione);
    Task<PrenotazioneDTO?> EstraiPerIdAsync(int id);
    Task EliminaPrenotazioneAsync(int id);

}
