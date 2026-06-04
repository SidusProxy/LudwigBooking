using Ludwig.Api.Auth;
using Ludwig.Api.Exceptions.ExceptionsClasses;
using Ludwig.Data.DTO;
using Ludwig.Data.Interfaces;
using Ludwig.Domain.Extensions;
namespace Ludwig.Api.Endpoints;

public static class PrenotazioneEndpoints
{

    public static void RegistraEndpointPrenotazioni(this WebApplication webApplication)
    {

        var grp = webApplication.MapGroup("/prenotazioni");
        grp.MapGet("/", async (IDatiPrenotazione datiPrenotazioni, AppUser user) =>
        {
            var prenotazioni = await datiPrenotazioni.EstraiTutteAsync();
            if (prenotazioni is null)
                return Results.NotFound();
            return Results.Ok(prenotazioni);
        }).RequireAuthorization()
        .Produces<List<PrenotazioneDTO>>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status500InternalServerError);


        grp.MapGet("/{id:int}", async (int id, IDatiPrenotazione datiPrenotazioni, AppUser user) =>
        {
            if (id < 0)
            {
                return Results.BadRequest();
            }
            var categorie = await datiPrenotazioni.EstraiPerIdAsync(id);
            if (categorie is null)
                throw new ItemNotFoundException($"La prenotazione con ID {id} non è stata trovata nei sistemi.");
            return Results.Ok(categorie);
        }).RequireAuthorization()
        .Produces<PrenotazioneDTO>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status500InternalServerError);



        grp.MapPost("/", async (PrenotazioneCreaDTO prenotazione, IDatiPrenotazione datiPrenotazioni, AppUser user) =>
        {
            if (prenotazione == null) { return Results.BadRequest(); }
            if (!prenotazione.CheckDomainConditions())
            {
                throw new IntegrityConditionException($"Una delle condizioni di integrità del sistema non viene rispettata dai parametri passati nel body");

            }
            var p = await datiPrenotazioni.CreaPrenotazioneAsync(prenotazione);
            if (p is null) return Results.BadRequest();
            return Results.Created($"/categorie/{p.Id}", p);
        }).RequireAuthorization()
     .Produces<PrenotazioneDTO>(StatusCodes.Status201Created)
     .Produces(StatusCodes.Status400BadRequest)
     .Produces(StatusCodes.Status404NotFound)
     .Produces(StatusCodes.Status500InternalServerError);

        grp.MapPatch("/{id:int}", async (int id, PrenotazioneAggiornaDTO prenotazione, IDatiPrenotazione datiPrenotazioni, AppUser user) =>
        {
            if (user.Role != "doctor")
            {
                return Results.Unauthorized();
            }
            if (prenotazione == null) { return Results.BadRequest(); }
            if (id != prenotazione.Id) { return Results.BadRequest(); }
            if (!prenotazione.CheckDomainConditions())
            {
                throw new IntegrityConditionException($"Una delle condizioni di integrità del sistema non viene rispettata dai parametri passati nel body");
            }
            var boolean = await datiPrenotazioni.ModificaPrenotazioneAsync(prenotazione);
            if (boolean == false)
            {
                throw new ItemNotFoundException($"La prenotazione con ID {id} non è stata trovata nei sistemi.");
            }

            return Results.NoContent();
        }).RequireAuthorization()
       .Produces(StatusCodes.Status204NoContent)
     .Produces(StatusCodes.Status400BadRequest)
     .Produces(StatusCodes.Status404NotFound)
     .Produces(StatusCodes.Status500InternalServerError);

        grp.MapDelete("/{id:int}", async (int id, IDatiPrenotazione datiPrenotazioni, AppUser user) =>
        {
            if (user.Role != "doctor") {
                return Results.Unauthorized();
            }
            if (id < 0) { return Results.BadRequest(); }
            var boolean = await datiPrenotazioni.EliminaPrenotazioneAsync(id);
            if (boolean == false)
            {
                throw new ItemNotFoundException($"La prenotazione con ID {id} non è stata trovata nei sistemi.");
            }
            return Results.NoContent();
        }).RequireAuthorization()
     .Produces(StatusCodes.Status204NoContent)
     .Produces(StatusCodes.Status400BadRequest)
     .Produces(StatusCodes.Status404NotFound)
     .Produces(StatusCodes.Status500InternalServerError);


        grp.MapGet("/utenti/{id:int}", async (int id, IDatiPrenotazione datiPrenotazioni, AppUser user) =>
        {
            var prenotazioni = await datiPrenotazioni.EstraiTutteUserIdAsync(id);
            if (prenotazioni is null)
                throw new ItemNotFoundException($"Questo utente non ha prenotazioni");
            return Results.Ok(prenotazioni);
        }).RequireAuthorization()
        .Produces<List<PrenotazioneDTO>>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status500InternalServerError);


        grp.MapPost("/overlapping", async (PrenotazioneDTO prenotazione, IDatiPrenotazione datiPrenotazioni, AppUser user) =>
        {
            var prenotazioniOverlapping = await datiPrenotazioni.EstraiOverlappingAsync(prenotazione);
            if (prenotazioniOverlapping is null)
                throw new ItemNotFoundException("Non esistono prenotazioni che si overlappano");
            return Results.Ok(prenotazioniOverlapping);
        })
        .RequireAuthorization()
        .Produces<List<PrenotazioneDTO>>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status500InternalServerError);



    }
}
