using Application.Interfaces;
using Dto.Game;
using RestApi.Interfaces;

namespace RestApi.Endpoints.Game;

public class ActionsEndpoint : IEndpointRoute
{
    public void RegisterRoute(IEndpointRouteBuilder app)
    {
        var apiV1 = app.MapGroup("api/v1/");
        var actionsRoute = apiV1.MapGroup("Actions/");

        actionsRoute.MapPost("List/{gameId:guid}", (IActionService actionService ,Guid gameId , SearchRequestDto search) =>
        {
           var history =  actionService.GetHistory(gameId , search);

            return Results.Ok(history);
        });



    }
}