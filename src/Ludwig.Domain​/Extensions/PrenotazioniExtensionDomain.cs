using Ludwig.Data.DTO;
using Ludwig.Data.Models;

namespace Ludwig.Domain​.Extensions;
public static class PrenotazioniExtensionDomain
{
    public static bool CheckDomainConditions(this PrenotazioneCreaDTO p)
    {
        if (p.Da > p.A) {
            return false;
            }
        return true;
    }

    public static bool CheckDomainConditions(this PrenotazioneAggiornaDTO p)
    {
        if (p.Da > p.A)
        {
            return false;
        }
        return true;
    }
}