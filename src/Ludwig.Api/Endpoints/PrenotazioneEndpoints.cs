using Ludwig.Data.DTO;
using Ludwig.Data.Interfaces;
using Ludwig.Domain.Extensions;
namespace Ludwig.Api.Endpoints;

    public static class PrenotazioneEndpoints
    {

        public static void RegistraEndpointPrenotazioni(this WebApplication webApplication)
        {

        var grp = webApplication.MapGroup("/prenotazioni");
        grp.MapGet("/", async (IDatiPrenotazione datiPrenotazioni) =>
        {
            var prenotazioni = await datiPrenotazioni.EstraiTutteAsync();
            if (prenotazioni is null)
                return Results.NotFound();
            return Results.Ok(prenotazioni);
        }).Produces<List<PrenotazioneDTO>>(StatusCodes.Status200OK).Produces(StatusCodes.Status404NotFound).Produces(StatusCodes.Status500InternalServerError);


        grp.MapGet("/{id:int}", async (int id, IDatiPrenotazione datiPrenotazioni) =>
        {
            if (id < 0)
            {
                return Results.BadRequest();
            }
            var categorie = await datiPrenotazioni.EstraiPerIdAsync(id);
            if (categorie is null)
                return Results.NotFound();
            return Results.Ok(categorie);
        }).Produces<PrenotazioneDTO>(StatusCodes.Status200OK).Produces(StatusCodes.Status404NotFound).Produces(StatusCodes.Status500InternalServerError);



        grp.MapPost("/", async (PrenotazioneCreaDTO prenotazione, IDatiPrenotazione datiPrenotazioni) =>
        {
            if (prenotazione == null) { return Results.BadRequest(); }
            if (!prenotazione.CheckDomainConditions()) {
                return Results.BadRequest();
            }
            var p = await datiPrenotazioni.CreaPrenotazioneAsync(prenotazione);
            if (p is null) return Results.NotFound();
            return Results.Created($"/categorie/{p.Id}", p);
        })
     .Produces<PrenotazioneDTO>(StatusCodes.Status201Created)
     .Produces(StatusCodes.Status400BadRequest)
     .Produces(StatusCodes.Status404NotFound)
     .Produces(StatusCodes.Status500InternalServerError);

        grp.MapPatch("/{id:int}", async (int id, PrenotazioneAggiornaDTO prenotazione, IDatiPrenotazione datiPrenotazioni) =>
        {
            if (prenotazione == null) { return Results.BadRequest(); }
            if (id != prenotazione.Id) { return Results.BadRequest(); }
            if (!prenotazione.CheckDomainConditions())
            {
                return Results.BadRequest();
            }
            var boolean = await datiPrenotazioni.ModificaPrenotazioneAsync(prenotazione);
            if (boolean == false)
            {
                return Results.NotFound();
            }

            return Results.NoContent();
        }).Produces(StatusCodes.Status204NoContent)
     .Produces(StatusCodes.Status400BadRequest)
     .Produces(StatusCodes.Status404NotFound)
     .Produces(StatusCodes.Status500InternalServerError);

        grp.MapDelete("/{id:int}", async (int id, IDatiPrenotazione datiPrenotazioni) =>
        {
            if (id < 0) { return Results.BadRequest(); }
            var boolean = await datiPrenotazioni.EliminaPrenotazioneAsync(id);
            if (boolean == false)
            {
                return Results.NotFound();
            }
            return Results.NoContent();
        }).Produces(StatusCodes.Status204NoContent)
     .Produces(StatusCodes.Status400BadRequest)
     .Produces(StatusCodes.Status404NotFound)
     .Produces(StatusCodes.Status500InternalServerError);


        grp.MapGet("/users/{id:int}", async (int id,IDatiPrenotazione datiPrenotazioni) =>
        {
            var prenotazioni = await datiPrenotazioni.EstraiTutteUserIdAsync(id);
            if (prenotazioni is null)
                return Results.NotFound();
            return Results.Ok(prenotazioni);
        }).Produces<List<PrenotazioneDTO>>(StatusCodes.Status200OK).Produces(StatusCodes.Status404NotFound).Produces(StatusCodes.Status500InternalServerError);



    }
}
