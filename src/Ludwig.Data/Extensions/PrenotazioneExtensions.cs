using Ludwig.Data.DTO;
using Ludwig.Data.Models;

namespace Ludwig.Data.Extensions;

public static class PrenotazioneExtensions
{
    public static PrenotazioneDTO? ToDTO(this Prenotazione p)
    {
        return new PrenotazioneDTO(p.Id,p.RisorsaId,p.UtenteId,p.DottoreId,p.Da,p.A,p.Stato);
    }

    public static Prenotazione? FromDTO(this PrenotazioneDTO p)
    {
        return new Prenotazione { UtenteId = p.UtenteId,DottoreId=p.DottoreId,A=p.A,Da=p.Da,Id=p.Id,Stato=p.Stato,RisorsaId =p.RisorsaId};
    }

    public static PrenotazioneAggiornaDTO? ToAggiornaDTO(this Prenotazione p)
    {
        return new PrenotazioneAggiornaDTO(p.Id, p.RisorsaId, p.UtenteId, p.DottoreId, p.Da, p.A, p.Stato);
    }

    public static Prenotazione? FromDTO(this PrenotazioneAggiornaDTO p)
    {
        return new Prenotazione { UtenteId = p.UtenteId, DottoreId = p.DottoreId, A = p.A, Da = p.Da, Id = p.Id, Stato = p.Stato, RisorsaId = p.RisorsaId };
    }

    public static PrenotazioneCreaDTO? ToCreaDTO(this Prenotazione p)
    {
        return new PrenotazioneCreaDTO(p.RisorsaId, p.UtenteId, p.DottoreId, p.Da, p.A, p.Stato);
    }

    public static Prenotazione? FromDTO(this PrenotazioneCreaDTO p)
    {
        return new Prenotazione { UtenteId = p.UtenteId, DottoreId = p.DottoreId, A = p.A, Da = p.Da, Stato = p.Stato, RisorsaId = p.RisorsaId };
    }
}

