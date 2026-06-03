namespace Ludwig.Data.DTO;

public record PrenotazioneDTO(int Id, int RisorsaId, int UtenteId, int DottoreId, DateTime Da, DateTime A, String Stato);

public record PrenotazioneCreaDTO(int RisorsaId, int UtenteId, int DottoreId, DateTime Da, DateTime A, String Stato);

public record PrenotazioneAggiornaDTO(int Id, int RisorsaId, int UtenteId, int DottoreId, DateTime Da, DateTime A, String Stato);



