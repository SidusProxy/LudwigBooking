
using Ludwig.Data.DTO;

namespace Ludwig.Data.Interfaces;
public interface IDatiPrenotazione
{
    Task<IEnumerable<PrenotazioneDTO>?> EstraiTutteAsync();
    Task<IEnumerable<PrenotazioneDTO>?> EstraiTutteUserIdAsync(int id);
    Task<PrenotazioneDTO> CreaPrenotazioneAsync(PrenotazioneCreaDTO prenotazione);
    Task<bool> ModificaPrenotazioneAsync(PrenotazioneAggiornaDTO prenotazione);
    Task<PrenotazioneDTO?> EstraiPerIdAsync(int id);
    Task<bool> EliminaPrenotazioneAsync(int id);

}
